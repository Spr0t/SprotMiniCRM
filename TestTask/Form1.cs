using SQL;
using SQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
 
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        string sqlRequest = "SELECT dbo.Employees.Id, dbo.Employees.Name, dbo.Departmenst.Department, dbo.JobTitle.JobTitle, dbo.Employees.Salary, dbo.KPI.KPI, dbo.KPI.Сoefficient * dbo.Employees.Salary AS Bonus FROM dbo.Departmenst right OUTER JOIN dbo.Employees ON dbo.Departmenst.Id = dbo.Employees.Department_Id left OUTER JOIN dbo.JobTitle ON dbo.Employees.JobTitle_Id = dbo.JobTitle.Id INNER JOIN dbo.KPI ON dbo.Employees.KPI_Id = dbo.KPI.Id";
        Form help;
        //string sqlRequest = "SELECT dbo.Employees.Id, dbo.Employees.Name, dbo.Departmenst.Department, dbo.JobTitle.JobTitle, dbo.Employees.Salary, dbo.KPI.KPI, dbo.KPI.Сoefficient * dbo.Employees.Salary AS Bonus FROM dbo.Departmenst INNER JOIN dbo.Employees ON dbo.Departmenst.Id = dbo.Employees.Department_Id INNER JOIN dbo.JobTitle ON dbo.Employees.JobTitle_Id = dbo.JobTitle.Id INNER JOIN dbo.KPI ON dbo.Employees.KPI_Id = dbo.KPI.Id";
        

        public Form1()
        {      
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;            
            bindingSource1.DataSource = SQLController.GetData(sqlRequest);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                var Id = dataGridView1[0, e.RowIndex].Value;

                if (int.TryParse(Id.ToString(), out var intId))
                {
                    var form = new Employee(intId);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        bindingSource1.DataSource = null;
                        bindingSource1.DataSource = SQLController.GetData(sqlRequest);

                        dataGridView1.Refresh();
                    }
                    
                }
                else 
                {
                    MessageBox.Show("Error occurred" + Id);
                }
            }
            else if (e.RowIndex != -1)
            {
                //MessageBox.Show("To open Employee Menu - please click Employee Name");
            }



            

      
        }
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var form = new Filtering();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    (bindingSource1.DataSource as DataTable).DefaultView.RowFilter = $"Department = '{form.filterName}'";
                }
                else if (form.filterName == "All")
                {
                    bindingSource1.DataSource = null;
                    bindingSource1.DataSource = SQLController.GetData(sqlRequest);

                    dataGridView1.Refresh();
                }
            }
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            help = new Help();
            help.Show();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            help.Close();
        }

        private void EditDepartment_Click(object sender, EventArgs e)
        {
            var form = new EditDeleteOrCreatecs(typeof(Department));
            form.ShowDialog();

            bindingSource1.DataSource = null;
            bindingSource1.DataSource = SQLController.GetData(sqlRequest);

            dataGridView1.Refresh();
        }

        private void EditJobTitle_Click(object sender, EventArgs e)
        {
            var form = new EditDeleteOrCreatecs(typeof(JobTitle));
            form.ShowDialog();

            bindingSource1.DataSource = null;
            bindingSource1.DataSource = SQLController.GetData(sqlRequest);

            dataGridView1.Refresh();
        }

        private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Employee((int)dataGridView1[0, 0].Value, true);

            if (form.ShowDialog() == DialogResult.OK)
            {
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = SQLController.GetData(sqlRequest);

                dataGridView1.Refresh();
            }
        }

        private void SalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FullSalary();
            form.ShowDialog();
        }

        private void ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lableWait = new Label()
            {
                AutoSize = true,
                Location = new Point(400, 13),
                Name = "label2",
                Size = new Size(44, 16),
                TabIndex = 4,
                Text = "Wait"
            };
            Controls.Add(lableWait);


            Task.Run(() =>
            {
                FilesController.WriteToFile(SQLController.GetReport());
            });

            Task.Run(() =>
            {
                while (!FilesController.IsDone)
                {
                    if (lableWait.Text.Contains("..."))
                    {
                        lableWait.Invoke((Action)delegate { lableWait.Text = "Wait"; });
                    }
                    else
                    {
                        lableWait.Invoke((Action)delegate { lableWait.Text += "."; });
                    }
                    Thread.Sleep(500);
                }

                lableWait.Invoke((Action)delegate { lableWait.Text = $"Report is Ready! File Name: {FilesController.filename}"; });
                Thread.Sleep(3000);
                lableWait.Invoke((Action)delegate { lableWait.Text = ""; });
            });

 




        }



    }
}
