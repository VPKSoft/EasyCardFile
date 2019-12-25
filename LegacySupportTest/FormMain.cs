using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegacySupportQTVersion;
using VPKSoft.MessageBoxExtended;

namespace LegacySupportTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private CardFileDataReader reader;

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                string password = "";
                if (CardFileDataReader.IsEncrypted(odCardFile.FileName))
                {

                    if (string.IsNullOrEmpty(password = MessageBoxQueryPassword.Show(this, "Give a password:", "Password")))
                    {
                        return;
                    }
                }
                reader = new CardFileDataReader(odCardFile.FileName, password);

                foreach (var card in reader.GetCards())
                {
                    MessageBox.Show(card.cardContents);
                }

//                reader.GetCards()
            }
        }

        private void mnuTestPasswordValidation_Click(object sender, EventArgs e)
        {
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                if (CardFileDataReader.IsEncrypted(odCardFile.FileName))
                {
                    var password = "";
                    if (string.IsNullOrEmpty(password = MessageBoxQueryPassword.Show(this, "Give a password:", "Password")))
                    {
                        return;
                    }
                    MessageBox.Show(CardFileDataReader.ValidPassword(odCardFile.FileName, password).ToString());
                }
            }
        }
    }
}
