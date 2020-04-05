#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.CardFileHandler.CardFilePreferences;
using EasyCardFile.Settings;
using EasyCardFile.UtilityClasses.Constants;
using EasyCardFile.UtilityClasses.FileAssociation;
using EasyCardFile.UtilityClasses.Miscellaneous.Dialogs;
using VPKSoft.ErrorLogger;
using VPKSoft.IPC;
using VPKSoft.LangLib;
using VPKSoft.PosLib;
using VPKSoft.Utils;

namespace EasyCardFile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // localizeProcess (user wishes to localize the software)..
            Process localizeProcess = VPKSoft.LangLib.Utils.CreateDBLocalizeProcess(Paths.AppInstallDir);

            // if the localize process was requested via the command line..
            if (localizeProcess != null)
            {
                // start the DBLocalization.exe and return..
                localizeProcess.Start();
                return;
            }

            string[] args = Environment.GetCommandLineArgs();

            // this is for the installer/un-installer..
            foreach (var s in args)
            {
                if (s.Equals("--un_associate"))
                {
                    AssociateFileExtension.RemoveAssociatedFileExtension(EasyCardFileConstants.FileExtension);
                    return;
                }

                if (s.Equals("--associate"))
                {
                    AssociateFileExtension.AssociateApplicationToFileExtension(EasyCardFileConstants.FileExtension);
                    return;
                }
            }

            if (AppRunning.CheckIfRunningNoAdd("VPKSoft.EasyCardFile.Application.2020"))
            {
                if (!Debugger.IsAttached) // this is too efficient, the exceptions aren't caught by the ide :-)
                {
                    ExceptionLogger.Bind(); // bind before any visual objects are created
                    ExceptionLogger.ApplicationCrashData += ExceptionLogger_ApplicationCrashData;
                }


                // Save languages..
                if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormMain();
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormDialogAddRenameCard();
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormDialogCardFileNaming();
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormDialogCardFilePreferences();
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormDialogSettings();
                    // ReSharper disable once ObjectCreationAsStatement
                    new FormDialogSelectImageArea();

                    if (!Debugger.IsAttached)
                    {
                        ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
                    }

                    ExceptionLogger.ApplicationCrashData -= ExceptionLogger_ApplicationCrashData;
                    return;
                }

                ExceptionLogger.LogMessage($"Application is running. Checking for open file requests. The current directory is: '{Environment.CurrentDirectory}'.");
                try
                {
                    IpcClientServer ipcClient = new IpcClientServer();
                    ipcClient.CreateClient("localhost", 50672);

                    // only send the existing files to the running instance, don't send the executable
                    // file name thus the start from 1..
                    for (int i = 1; i < args.Length; i++)
                    {
                        string file = args[i];
                        
                        ExceptionLogger.LogMessage($"Request file open: '{file}'.");
                        if (File.Exists(file))
                        {
                            ExceptionLogger.LogMessage($"File exists: '{file}'. Send open request.");
                            ipcClient.SendMessage(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogError(ex);
                    // just in case something fails with the IPC communication..
                }
                ExceptionLogger.ApplicationCrashData -= ExceptionLogger_ApplicationCrashData;
                ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
                return;
            }

            PositionCore.Bind(); // attach the PosLib to the application            

            AppRunning.CheckIfRunning("VPKSoft.EasyCardFile.Application.2020");

            foreach (var arg in args)
            {
                if (File.Exists(arg) && Path.GetExtension(arg) != null && Path.GetExtension(arg)
                    .Equals(EasyCardFileConstants.FileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    OpenFileQueue.Enqueue(arg);
                }
            }

            // create an IPC server at localhost, the port was randomized in the development phase..
            IpcServer.CreateServer("localhost", 50672);

            // subscribe to the IPC event if the application receives a message from another instance of this application..
            IpcClientServer.RemoteMessage.MessageReceived += RemoteMessage_MessageReceived;

            Paths.MakeAppSettingsFolder(); // ensure there is an application settings folder..

            if (!Debugger.IsAttached) // this is too efficient, the exceptions aren't caught by the ide :-)
            {
                ExceptionLogger.Bind(); // bind before any visual objects are created
                ExceptionLogger.ApplicationCrashData += ExceptionLogger_ApplicationCrashData;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            PositionCore.UnBind(); // release the event handlers used by the PosLib and save the default data

            if (!Debugger.IsAttached)
            {
                ExceptionLogger.ApplicationCrashData -= ExceptionLogger_ApplicationCrashData;
                ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
            }
        }

        // an event handler for the IPC channel ask the main application instance to open..
        private static void RemoteMessage_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            OpenFileQueue.Enqueue(e.Message);
        }

        public static Queue<string> OpenFileQueue { get; set; } = new Queue<string>();

        /// <summary>
        /// An IPC client / server to transmit Windows shell file open requests to the current process.
        /// </summary>
        private static readonly IpcClientServer IpcServer = new IpcClientServer();

        private static void ExceptionLogger_ApplicationCrashData(ApplicationCrashEventArgs e)
        {
            // unsubscribe this event handler..
            ExceptionLogger.ApplicationCrashData -= ExceptionLogger_ApplicationCrashData;

            if (!Debugger.IsAttached)
            {
                ExceptionLogger.UnBind(); // unbind the exception logger..
            }

            // kill self as the native inter-op libraries may have some issues of keeping the process alive..
            Process.GetCurrentProcess().Kill();

            // This is the end..
        }
    }
}
