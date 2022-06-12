using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamTraining
{
    public partial class RealEstateForm : Form
    {
        public RealEstateForm()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            loadListViews();
        }

        private void showApartaments(RealEstateSet realEstate)
        {
            ListViewItem item = new ListViewItem(new string[] {
                    realEstate.id.ToString(),
                    realEstate.address_city,
                    realEstate.address_street,
                    realEstate.address_house,
                    realEstate.address_number,
                    realEstate.coordinate_latitude.ToString(),
                    realEstate.coordinate_longtitude.ToString(),
                    realEstate.total_area.ToString(),
                    realEstate.rooms.ToString(),
                    realEstate.total_floors.ToString(),
                    realEstate.floor.ToString()
                    });

            item.Tag = realEstate;
            listViewApartament.Items.Add(item);
            listViewApartament.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void loadListViews()
        {
            listViewApartament.Items.Clear();
            listViewHouse.Items.Clear();
            listViewLand.Items.Clear();
            var realEstates = Program.db.RealEstateSet;

            foreach (var realEstate in realEstates)
            {
                if (realEstate.type == 0)
                {
                    showApartaments(realEstate);
                }
                else if (realEstate.type == 1)
                {
                    showHouses(realEstate);
                }
                else if (realEstate.type == 2)
                {
                    showLands(realEstate);
                }
            }
        }

        private void showHouses(RealEstateSet realEstate)
        {
            ListViewItem item = new ListViewItem(new string[] {
                realEstate.id.ToString(),
                realEstate.address_city,
                realEstate.address_street,
                realEstate.address_house,
                realEstate.coordinate_latitude.ToString(),
                realEstate.coordinate_longtitude.ToString(),
                realEstate.total_area.ToString(),
                realEstate.rooms.ToString(),
                realEstate.total_floors.ToString(),
                });

            item.Tag = realEstate;
            listViewHouse.Items.Add(item);

            listViewHouse.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void showLands(RealEstateSet realEstate)
        {
            ListViewItem item = new ListViewItem(new string[] {
                realEstate.id.ToString(),
                realEstate.address_city,
                realEstate.address_street,
                realEstate.coordinate_latitude.ToString(),
                realEstate.coordinate_longtitude.ToString(),
                realEstate.total_area.ToString(),
                });

            item.Tag = realEstate;
            listViewLand.Items.Add(item);

            listViewLand.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearFields();

            if (comboBoxType.SelectedItem.ToString() == "Квартира")
            {
                listViewHouse.SelectedItems.Clear();
                listViewLand.SelectedItems.Clear();

                listViewApartament.Visible = true;
                listViewHouse.Visible = false;
                listViewLand.Visible = false;
            }
            else if (comboBoxType.SelectedItem.ToString() == "Дом")
            {
                listViewLand.SelectedItems.Clear();
                listViewApartament.SelectedItems.Clear();

                listViewApartament.Visible = false;
                listViewHouse.Visible = true;
                listViewLand.Visible = false;
            }
            else if (comboBoxType.SelectedItem.ToString() == "Земля")
            {
                listViewApartament.SelectedItems.Clear();
                listViewHouse.SelectedItems.Clear();

                listViewApartament.Visible = false;
                listViewHouse.Visible = false;
                listViewLand.Visible = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RealEstateSet realEstateSet = new RealEstateSet();

            realEstateSet = setRealEstateFields(realEstateSet);

            Program.db.RealEstateSet.Add(realEstateSet);
            Program.db.SaveChanges();
            loadListViews();
        }

        private void isInputNumber(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text != ""
                && !Helpers.StringHelpers.isNumber(textBox.Text)
                && !Regex.IsMatch(textBox.Text, @"^\d{0,}\.$"))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.TextLength;
            }
        }

        private void setFiealds(RealEstateSet realEstate)
        {
            textBoxAdress_City.Text = realEstate.address_city;
            textBoxAddress_Street.Text = realEstate.address_street;
            numericHouse.Value = Convert.ToDecimal(realEstate.address_house);
            numericApartament.Value = Convert.ToDecimal(realEstate.address_number);
            numericFloor.Value = Convert.ToInt32(realEstate.floor);
            numericFloors.Value = Convert.ToInt32(realEstate.total_floors);
            numericRooms.Value = Convert.ToInt32(realEstate.rooms);
            textBoxTotalArea.Text = realEstate.total_area.ToString();
            textBoxLatitude.Text = realEstate.coordinate_latitude.ToString();
            textBoxLongtitude.Text = realEstate.coordinate_longtitude.ToString();
            comboBoxType.SelectedIndex = realEstate.type;
        }

        private void clearFields()
        {
            textBoxAdress_City.Text = "";
            textBoxAddress_Street.Text = "";
            numericHouse.Value = 0;
            numericApartament.Value = 0;
            numericFloor.Value = 0;
            numericFloors.Value = 0;
            numericRooms.Value = 0;
            textBoxTotalArea.Text = "";
            textBoxLatitude.Text = "";
            textBoxLongtitude.Text = "";
            comboBoxType.SelectedIndex = comboBoxType.SelectedIndex;
        }

        private void listViewLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLand.SelectedItems.Count == 1)
            {
                var realEstate = listViewLand.SelectedItems[0].Tag as RealEstateSet;
                setFiealds(realEstate);
            }
        }

        private void listViewHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHouse.SelectedItems.Count == 1)
            {
                var realEstate = listViewHouse.SelectedItems[0].Tag as RealEstateSet;
                setFiealds(realEstate);
            }
        }

        private void listViewApartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewApartament.SelectedItems.Count == 1)
            {
                var realEstate = listViewApartament.SelectedItems[0].Tag as RealEstateSet;
                setFiealds(realEstate);
            }
        }

        private RealEstateSet setRealEstateFields(RealEstateSet realEstateSet)
        {
            if (comboBoxType.SelectedItem.ToString() == "Квартира")
            {
                realEstateSet.address_city = textBoxAdress_City.Text;
                realEstateSet.address_street = textBoxAddress_Street.Text;
                realEstateSet.address_number = numericHouse.Value.ToString();
                realEstateSet.address_house = numericApartament.Value.ToString();
                realEstateSet.coordinate_latitude = Convert.ToDouble(textBoxLatitude.Text);
                realEstateSet.coordinate_longtitude = Convert.ToDouble(textBoxLongtitude.Text);
                realEstateSet.total_area = Convert.ToDouble(textBoxTotalArea.Text);
                realEstateSet.type = 0;
                realEstateSet.rooms = Convert.ToInt32(numericRooms.Value);
                realEstateSet.total_floors = Convert.ToInt32(numericFloors.Value);
                realEstateSet.floor = Convert.ToInt32(numericFloor.Value);
            }
            else if (comboBoxType.SelectedItem.ToString() == "Дом")
            {
                realEstateSet.address_city = textBoxAdress_City.Text;
                realEstateSet.address_street = textBoxAddress_Street.Text;
                realEstateSet.address_house = numericApartament.Value.ToString();
                realEstateSet.coordinate_latitude = Convert.ToDouble(textBoxLatitude.Text);
                realEstateSet.coordinate_longtitude = Convert.ToDouble(textBoxLongtitude.Text);
                realEstateSet.total_area = Convert.ToDouble(textBoxTotalArea.Text);
                realEstateSet.type = 1;
                realEstateSet.rooms = Convert.ToInt32(numericRooms.Value);
                realEstateSet.total_floors = Convert.ToInt32(numericFloors.Value);
            }
            else if (comboBoxType.SelectedItem.ToString() == "Земля")
            {
                realEstateSet.address_city = textBoxAdress_City.Text;
                realEstateSet.address_street = textBoxAddress_Street.Text;
                realEstateSet.coordinate_latitude = Convert.ToDouble(textBoxLatitude.Text);
                realEstateSet.coordinate_longtitude = Convert.ToDouble(textBoxLongtitude.Text);
                realEstateSet.total_area = Convert.ToDouble(textBoxTotalArea.Text);
                realEstateSet.type = 2;
            }

            return realEstateSet;
        }

        private RealEstateSet getRealEstateFromSelectedListviews()
        {
            if (listViewApartament.SelectedItems.Count == 1)
            {
                return setRealEstateFields(listViewApartament.SelectedItems[0].Tag as RealEstateSet);
            }
            else if (listViewHouse.SelectedItems.Count == 1)
            {
                return setRealEstateFields(listViewHouse.SelectedItems[0].Tag as RealEstateSet);
            }
            else if (listViewLand.SelectedItems.Count == 1)
            {
                return setRealEstateFields(listViewLand.SelectedItems[0].Tag as RealEstateSet);
            }

            return null;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var realEstate = getRealEstateFromSelectedListviews();
            if (realEstate != null)
            {
                Program.db.SaveChanges();
                loadListViews();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var realEstate = getRealEstateFromSelectedListviews();
            if (realEstate != null)
            {
                Program.db.RealEstateSet.Remove(realEstate);
                Program.db.SaveChanges();
                loadListViews();
            }
        }
    }
}
