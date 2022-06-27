using SQL;
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
  

    public partial class Filtering : Form
    {
        ComboBox department;
        public string filterName = "";

        public Filtering()
        {
            InitializeComponent();
        }

        private void Filtering_Load(object sender, EventArgs e)
        {
            department = new ComboBox()
            {           
                FormattingEnabled = true,
                Location = new Point(35, 50),
                Name = "comboBoxdepartment",
                Size = new Size(150, 20),
                TabIndex = 3,
                AutoCompleteMode = AutoCompleteMode.Suggest
            };
            department.DropDownStyle = ComboBoxStyle.DropDownList;
            department.Items.AddRange(SQLController.GetDepartments().Select(x => x.Name).Append("All").ToArray());
            department.Text = "All";
            Controls.Add(department);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {           
            filterName = department.Text;
            if (!filterName.Equals("All"))
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
