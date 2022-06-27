using SQL;
using SQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
  
    public partial class EditDeleteOrCreatecs : Form
    {
        Type type;
        Department[] departments;
        JobTitle[] jobtitles;

        public EditDeleteOrCreatecs(Type t)
        {
            InitializeComponent();
            type = t;

            switch (type.Name)
            {
                case "Department":
                    departments = SQLController.GetDepartments();
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox1.Items.AddRange(departments.Select(x => x.Name).ToArray());
                    comboBox1.Text = comboBox1.Items[0].ToString();
                    break;
                case "JobTitle":
                    jobtitles = SQLController.GetJobTitles();
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox1.Items.AddRange(jobtitles.Select(x => x.Name).ToArray());
                    comboBox1.Text = comboBox1.Items[0].ToString();
                    break;

            }



        }

        private void EditDeleteOrCreatecs_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var nameform = new EnterName();

            if (nameform.ShowDialog() == DialogResult.OK)
            {
                switch (type.Name)
                {
                    case "Department":
                        SQLController.Create("Department", nameform.name);
                        departments = SQLController.GetDepartments();
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(departments.Select(x => x.Name).ToArray());

                        break;
                    case "JobTitle":
                        SQLController.Create("JobTitle", nameform.name);
                        jobtitles = SQLController.GetJobTitles();
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(jobtitles.Select(x => x.Name).ToArray());

                        break;

                }

                comboBox1.Text = comboBox1.Items[0].ToString();
            }


        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show($"Please choose {type.Name}");
            }
            else
            {
                var nameform = new EnterName(comboBox1.Text);

                if (nameform.ShowDialog() == DialogResult.OK)
                {
                    switch (type.Name)
                    {
                        case "Department":
                            SQLController.Edit("Department", departments.First(x => x.Name.Equals(comboBox1.Text)).Id, nameform.name);
                            departments = SQLController.GetDepartments();
                            comboBox1.Items.Clear();
                            comboBox1.Items.AddRange(departments.Select(x => x.Name).ToArray());

                            break;
                        case "JobTitle":
                            SQLController.Edit("JobTitle", jobtitles.First( x => x.Name.Equals(comboBox1.Text)).Id, nameform.name);
                            jobtitles = SQLController.GetJobTitles();
                            comboBox1.Items.Clear();
                            comboBox1.Items.AddRange(jobtitles.Select(x => x.Name).ToArray());

                            break;

                    }
                }
            }

            comboBox1.Text = comboBox1.Items[0].ToString();

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show($"Please choose {type.Name}");
            }
            else
            {

                var confirmResult = MessageBox.Show($"Are you sure you want to delete {comboBox1.Text} from database?", "Confirm Delete!", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    switch (type.Name)
                    {
                        case "Department":
                            SQLController.Delete("Departmenst", departments.First(x => x.Name == comboBox1.Text).Id);
                            departments = SQLController.GetDepartments();
                            comboBox1.Items.Clear();
                            comboBox1.Items.AddRange(departments.Select(x => x.Name).ToArray());
                            break;
                        case "JobTitle":
                            SQLController.Delete("JobTitle", jobtitles.First(x => x.Name == comboBox1.Text).Id);
                            jobtitles = SQLController.GetJobTitles();
                            comboBox1.Items.Clear();
                            comboBox1.Items.AddRange(jobtitles.Select(x => x.Name).ToArray());

                            break;

                    }
                }
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
            }


        }
    }
}
