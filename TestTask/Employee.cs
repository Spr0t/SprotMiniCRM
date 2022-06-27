using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQL;

namespace TestTask
{
    public partial class Employee : Form
    {
        private ComboBox comboBox;
        private Label bonus;
        private NumericUpDown salary;
        private DataTable employeeTable;
        private List<TextBox> textBoxes = new List<TextBox>();
        private ComboBox department;
        private ComboBox jobtitle;
        private int EmployeeId;
        private bool EmplAdd;

        public Employee(int Id, bool addEmployee = false)
        {
            InitializeComponent();
            EmployeeId = Id;
            EmplAdd = addEmployee;

            comboBox = new ComboBox();
            bonus = new Label();
            salary = new NumericUpDown();
            textBoxes.Clear();
            employeeTable = SQLController.GetEmployee(Id);
            if (addEmployee)
            {
                button1.Visible = false;
            }
            

            for (int i = 1; i < 9; i++)
            {
                var labelName = new Label()
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(20, 32 * i + 5),
                    Size = new Size(200, 20),
                    Name = "label" + i,
                    Text = employeeTable.Columns[i].ColumnName
                };

                if (i < 4)
                {
                    var box = new TextBox()
                    {
                        Location = new Point(110, 32 * i + 5),
                        Size = new Size(200, 20),
                        Name = "textBox" + i,
                        Text = employeeTable.Rows[0][i] == null ? "" : employeeTable.Rows[0][i].ToString()

                    };
                    if (addEmployee)
                    {
                        box.Text = "";
                    }
                    box.TextChanged += new EventHandler(textBox_TextChanged);         
                    textBoxes.Add(box);
                    Controls.Add(box);
                }
                else if (i == 4)
                {
                    department = new ComboBox()
                    {
                        FormattingEnabled = true,
                        Location = new Point(110, 32 * i + 5),
                        Name = "comboBoxdepartment",
                        Size = new Size(200, 20),
                        TabIndex = 3,
                        AutoCompleteMode = AutoCompleteMode.Suggest
                    };
                    department.DropDownStyle = ComboBoxStyle.DropDownList;
                    department.Items.AddRange(SQLController.GetDepartments().Select(x => x.Name).ToArray());
                    department.Text = employeeTable.Rows[0][i].ToString();
                    if (addEmployee)
                    {
                        department.Text = department.Items[0].ToString();
                    }
                    Controls.Add(department);
                }
                else if (i == 5)
                {
                    jobtitle = new ComboBox()
                    {
                        FormattingEnabled = true,
                        Location = new Point(110, 32 * i + 5),
                        Name = "comboBoxjobtitle",
                        Size = new Size(200, 20),
                        TabIndex = 3,
                        AutoCompleteMode = AutoCompleteMode.Suggest
                    };
                    jobtitle.DropDownStyle = ComboBoxStyle.DropDownList;
                    jobtitle.Items.AddRange(SQLController.GetJobTitles().Select(x=> x.Name).ToArray());
                    jobtitle.Text = employeeTable.Rows[0][i].ToString();
                    if (addEmployee)
                    {
                        jobtitle.Text = jobtitle.Items[0].ToString();
                    }
                    Controls.Add(jobtitle);
                }
                else if (i == 6)
                {
                    salary = new NumericUpDown()
                    {
                        Location = new Point(110, 32 * i + 5),
                        Minimum = 0,
                        Maximum = 10000,
                        Name = "numericUpDown1",
                        Size = new Size(200, 20),
                        TabIndex = 3,
                        Value = Parse(employeeTable.Rows[0][i].ToString())

                    };
                    salary.ValueChanged += new EventHandler(numericUpDown_ValueChanged);
                    if (addEmployee)
                    {
                        salary.Value = 0;
                    }
                    Controls.Add(salary);
                }
                else if (i == 7)
                {
                    comboBox = new ComboBox()
                    {
                        FormattingEnabled = true,                      
                        Location = new Point(110, 32 * i + 5),
                        Name = "comboBox1",
                        Size = new Size(200, 20),
                        TabIndex = 3,                     
                        AutoCompleteMode = AutoCompleteMode.Suggest
                    };
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Items.AddRange(SQLController.GetKPI().Select(x => x.Name).ToArray());
                    comboBox.Text = employeeTable.Rows[0][i].ToString();
                    comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
                    if (addEmployee)
                    {
                        comboBox.Text = comboBox.Items[0].ToString();
                    }
                    Controls.Add(comboBox);
                }
                else
                {
                    bonus = new Label()
                    {
                        AutoSize = false,
                        Location = new Point(110, 32 * i + 5),
                        TextAlign = ContentAlignment.MiddleLeft,
                        Size = new Size(200, 20),
                        Name = "label" + i,
                        Text = employeeTable.Rows[0][i].ToString()
                    };
                    if (addEmployee)
                    {
                        bonus.Text = "0";
                    }
                    Controls.Add(bonus);
                }              

                Controls.Add(labelName);
            }




        }

        private decimal Parse(string input)
        {
            if (decimal.TryParse(input, out var result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Error occurred while parsing Employee Salary");
                return 0;
            }


        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateBonus();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateBonus();
        }

        private void CalculateBonus()
        {
            decimal bonusCalc = 0;

            if (comboBox.Text.Equals("A"))
            {
                bonusCalc = decimal.Multiply(salary.Value, 0.80M);
            }
            if (comboBox.Text.Equals("B"))
            {
                bonusCalc = decimal.Multiply(salary.Value, 0.70M);
            }
            if (comboBox.Text.Equals("C"))
            {
                bonusCalc = decimal.Multiply(salary.Value, 0.60M);
            }

            bonus.Text = decimal.Floor(bonusCalc).ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (EmplAdd)
            {
                if (textBoxes.All(x => x.Text.Length > 0))
                {
                    var departmentId = SQLController.GetDepartments().FirstOrDefault(x => x.Name.Equals(department.Text)).Id;
                    var jobtitleId = SQLController.GetJobTitles().FirstOrDefault(x => x.Name.Equals(jobtitle.Text)).Id;
                    var KPIid = SQLController.GetKPI().FirstOrDefault(x => x.Name.Equals(comboBox.Text)).Id;
                    var sallary = Convert.ToDecimal(salary.Value.ToString().Replace(",", "."));

                    SQLController.Create("Employee", $"INSERT INTO dbo.Employees(Name, PhoneNumber, Adress, Department_Id, JobTitle_Id, Salary, KPI_Id) VALUES('{textBoxes[0].Text}', '{textBoxes[1].Text}', '{textBoxes[2].Text}', {departmentId}, {jobtitleId}, {sallary}, {KPIid});");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter info about Employee first.");
                }

            }
            else
            {
                SaveTable();
                SQLController.SaveEmployeeChanges(employeeTable);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveTable()
        {
            for (var i = 0; i < 3; i++)
            {
                employeeTable.Rows[0][i+1] = textBoxes[i].Text;
            }
            employeeTable.Rows[0][4] = department.Text;
            employeeTable.Rows[0][5] = jobtitle.Text;
            employeeTable.Rows[0][6] = salary.Value;
            employeeTable.Rows[0][7] = comboBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {employeeTable.Rows[0][1]} from database?", "Confirm Delete!", MessageBoxButtons.YesNo);
            

            if (confirmResult == DialogResult.Yes)
            {
                SQLController.Delete("Employees", EmployeeId);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
