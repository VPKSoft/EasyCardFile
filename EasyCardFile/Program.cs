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
using System.Diagnostics;
using System.Windows.Forms;
using VPKSoft.ErrorLogger;
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
            Paths.MakeAppSettingsFolder(); // ensure there is an application settings folder..

            if (!Debugger.IsAttached) // this is too efficient, the exceptions aren't caught by the ide :-)
            {
                ExceptionLogger.Bind(); // bind before any visual objects are created
                ExceptionLogger.ApplicationCrashData += ExceptionLogger_ApplicationCrashData;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            if (!Debugger.IsAttached)
            {
                ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
            }
        }

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
