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
            listViewClient.Items.Clear();

            var clients = Program.db.ClientsSet;

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

                lvItem.Tag = client;
                listViewClient.Items.Add(lvItem);

            }

            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientsSet client = listViewClient.SelectedItems[0].Tag as ClientsSet;
                client.phone = numericPhone.Value.ToString();
                client.first_name = txtFirstName.Text;
                client.last_name = txtLastName.Text;
                client.middle_name = txtMiddleName.Text;
                client.email = txtEmail.Text;

                Program.db.SaveChanges();
                showClients();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                var client = listViewClient.SelectedItems[0].Tag as ClientsSet;
                Program.db.ClientsSet.Remove(client);
                Program.db.SaveChanges();
                showClients();
            }
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientsSet client = listViewClient.SelectedItems[0].Tag as ClientsSet;
                txtFirstName.Text = client.first_name;
                txtEmail.Text = client.email;
                txtLastName.Text = client.last_name;
                txtMiddleName.Text = client.middle_name;
                numericPhone.Value = Convert.ToInt64(client.phone);
            }
        }
    }
}
