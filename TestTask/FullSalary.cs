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
    public partial class FullSalary : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private DataTable emplTable;
        public FullSalary()
        {
            InitializeComponent();
        }

        private void FullSalary_Load(object sender, EventArgs e)
        {
            emplTable = SQLController.GetFullSalaryTable();
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = emplTable;

            decimal expenses = 0;
            for (var i = 0; i < emplTable.Rows.Count; i++)
            {
                var row = emplTable.Rows[i];
                expenses += decimal.Parse(row[5].ToString());
            }

            labelExpenses.Text = $"All Expenses (All Full Salaries): {expenses}";

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(SQLController.GetDepartments().Select(x => x.Name).Append("All").ToArray());
            comboBox1.Text = "All";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("All"))
            {
                (bindingSource1.DataSource as DataTable).DefaultView.RowFilter = $"Department = '{comboBox1.Text}'";
            }
            else if (comboBox1.Text.Equals("All"))
            {
                bindingSource1.DataSource = null;
                emplTable = SQLController.GetFullSalaryTable();
                bindingSource1.DataSource = emplTable;

                dataGridView1.Refresh();
            }
            decimal expenses = 0;
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var cell = dataGridView1.Rows[i].Cells[5].Value;
                
                expenses += decimal.Parse(cell.ToString());
            }

            labelExpenses.Text = $"All Expenses (All Full Salaries): {expenses}";
        }
    }
}
