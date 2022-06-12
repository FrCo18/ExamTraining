using System;
using System.Windows.Forms;

namespace ExamTraining
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientsForm frm = new ClientsForm();
            frm.ShowDialog();
        }
    }
}
