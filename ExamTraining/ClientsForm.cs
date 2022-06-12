using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExamTraining
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            showClients();
        }

        private void showClients()
        {
            lvClients.Items.Clear();

            var clients = Program.db.ClientsSet;
            List<ListViewItem> list = new List<ListViewItem>();

            foreach (var client in clients)
            {
                ListViewItem lvItem = new ListViewItem(new string[] {
                client.id.ToString(),
                client.first_name,
                client.last_name,
                client.middle_name,
                client.phone,
                client.email
                });
                lvClients.Items.Add(lvItem);

            }

            lvClients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private bool fieldsIsNotEmpty()
        {
            return
                txtEmail.Text != ""
                && txtFirstName.Text != ""
                && txtLastName.Text != ""
                && txtMiddleName.Text != ""
                && numericPhone.Value > 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string middleName = txtMiddleName.Text;
            string email = txtEmail.Text;
            string phone = numericPhone.Value.ToString();

            if (fieldsIsNotEmpty())
            {
                if (Helpers.StringHelpers.isValidEmail(email))
                {
                    var client = new ClientsSet();
                    client.phone = phone;
                    client.email = email;
                    client.first_name = firstName;
                    client.last_name = lastName;
                    client.middle_name = middleName;

                    Program.db.ClientsSet.Add(client);
                    Program.db.SaveChanges();
                    showClients();
                }
                else
                {
                    MessageBox.Show("Почта невалидная!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
