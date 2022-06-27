using SQL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL
{
    public static class SQLController
    {

        private static SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private static DataTable table = new DataTable();
        private static DataTable tableEmployee = new DataTable();
        private static string connectionString = @"Data Source=(LocalDb)\MYSQL1;Initial Catalog=Task_C#_042022;Integrated Security=True";

        public static DataTable GetData(string selectCommand)
        {
            try
            {
                table = new DataTable();

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.Fill(table);

                return table;

            }
            catch (SqlException e)
            {
                MessageBox.Show("Error occurred while connecting to SQL server: " + e.Message);
                return new DataTable(); 
            }
        }


        public static void SaveChanges()
        {
            dataAdapter.Update(table);
        }

        public static void SaveEmployeeChanges(DataTable empTable)
        {  
            var id = (int)empTable.Rows[0][0];
            var name = empTable.Rows[0][1].ToString();
            var phone = empTable.Rows[0][2].ToString();
            var address = empTable.Rows[0][3].ToString();
            var departmentId = GetDepartments().FirstOrDefault(x => x.Name.Equals(empTable.Rows[0][4].ToString()));
            var department = departmentId == null ? "" : $" Department_Id = {departmentId.Id},";

            var jobTitleId = GetJobTitles().FirstOrDefault(x => x.Name.Equals(empTable.Rows[0][5].ToString()));
            var jobTitle = jobTitleId == null ? "" : $"JobTitle_Id = {jobTitleId.Id},";

            var sallary = Convert.ToDecimal(empTable.Rows[0][6]).ToString().Replace(",", ".");
            var kpiId = GetKPI().First(x => x.Name.Equals(empTable.Rows[0][7].ToString())).Id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = $"UPDATE Employees SET Name = '{name}', PhoneNumber = '{phone}', Adress = '{address}',{department}{jobTitle} Salary = {sallary}, KPI_Id = {kpiId} WHERE Id = {id};";

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
         
            };

        }


        public static DataTable GetEmployee(int Id)
        {
            tableEmployee = new DataTable();

            var command = $"SELECT dbo.Employees.Id, dbo.Employees.Name, dbo.Employees.PhoneNumber, dbo.Employees.Adress, dbo.Departmenst.Department, dbo.JobTitle.JobTitle, dbo.Employees.Salary, dbo.KPI.KPI, dbo.KPI.Сoefficient* dbo.Employees.Salary AS Bonus FROM dbo.Employees INNER JOIN dbo.KPI ON dbo.Employees.KPI_Id = dbo.KPI.Id full OUTER JOIN dbo.JobTitle ON dbo.Employees.JobTitle_Id = dbo.JobTitle.Id full OUTER JOIN dbo.Departmenst ON dbo.Employees.Department_Id = dbo.Departmenst.Id WHERE(dbo.Employees.Id = {Id})";
            
            dataAdapter = new SqlDataAdapter(command, connectionString);

            dataAdapter.Fill(tableEmployee);

            return tableEmployee;
        }

        public static void Delete(string type, int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                if (type.Equals("Departmenst"))
                {
                    command.CommandText = $"UPDATE Employees SET Department_Id = NULL WHERE Department_Id = {Id};";
                    command.ExecuteNonQuery();
                }

                if (type.Equals("JobTitle"))
                {
                    command.CommandText = $"UPDATE Employees SET JobTitle_Id = NULL WHERE JobTitle_Id = {Id};";
                    command.ExecuteNonQuery();
                }

                command.CommandText = $"DELETE FROM dbo.{type} WHERE(dbo.{type}.Id = {Id})";

                command.ExecuteNonQuery();

                connection.Close();

            };
        }

        public static void Create(string type, string values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                switch (type)
                {
                    case "Department":
                        command.CommandText = $"INSERT INTO dbo.Departmenst (Department) VALUES ('{values}')";
                        break;
                    case "JobTitle":
                        command.CommandText = $"INSERT INTO dbo.JobTitle (JobTitle) VALUES ('{values}')";
                        break;
                    case "Employee":
                        command.CommandText = $"{values}";
                        break;

                }

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Edit(string type, int id, string newValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                switch (type)
                {
                    case "Department":
                        command.CommandText = $"UPDATE dbo.Departmenst SET Department = '{newValue}' WHERE Id = {id}";
                        break;
                    case "JobTitle":
                        command.CommandText = $"UPDATE dbo.JobTitle SET JobTitle = '{newValue}' WHERE Id = {id}";
                        break;
                    case "Employee":
                        break;

                }

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();

            };


        }

        public static DataTable GetFullSalaryTable()
        {
            try
            {
                var salarytable = new DataTable();

                var selectCommand = "SELECT dbo.Employees.Name, dbo.JobTitle.JobTitle, dbo.Departmenst.Department, dbo.Employees.Salary, dbo.KPI.Сoefficient * dbo.Employees.Salary AS Bonus, dbo.KPI.Сoefficient* dbo.Employees.Salary + dbo.Employees.Salary AS FullSalary FROM dbo.Employees left OUTER JOIN dbo.Departmenst ON dbo.Employees.Department_Id = dbo.Departmenst.Id INNER JOIN dbo.KPI ON dbo.Employees.KPI_Id = dbo.KPI.Id left OUTER JOIN dbo.JobTitle ON dbo.Employees.JobTitle_Id = dbo.JobTitle.Id";
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.Fill(salarytable);

                return salarytable;

            }
            catch (SqlException e)
            {
                MessageBox.Show("Error occurred while connecting to SQL server: " + e.Message);
                return new DataTable();
            }
        }

        public static DataTable GetReport()
        {
            try
            {
                var reporttable = new DataTable();

                var selectCommand = "SELECT dbo.Employees.Name, dbo.Departmenst.Department, dbo.JobTitle.JobTitle, dbo.Employees.Salary, dbo.KPI.KPI, dbo.KPI.Сoefficient * dbo.Employees.Salary AS Bonus FROM dbo.Employees left OUTER JOIN dbo.Departmenst ON dbo.Employees.Department_Id = dbo.Departmenst.Id INNER JOIN dbo.KPI ON dbo.Employees.KPI_Id = dbo.KPI.Id left OUTER JOIN dbo.JobTitle ON dbo.Employees.JobTitle_Id = dbo.JobTitle.Id ORDER BY dbo.Departmenst.Department";
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.Fill(reporttable);

                return reporttable;

            }
            catch (SqlException e)
            {
                MessageBox.Show("Error occurred while connecting to SQL server: " + e.Message);
                return new DataTable();
            }
        }

        public static Department[] GetDepartments()
        {
            var tableDepartment = new DataTable();

            var command = $"SELECT dbo.Departmenst.Department, dbo.Departmenst.Id FROM dbo.Departmenst";

            dataAdapter = new SqlDataAdapter(command, connectionString);

            dataAdapter.Fill(tableDepartment);

            var result = new List<Department>();

            foreach (DataRow row in tableDepartment.Rows)
            {
                result.Add(new Department() { Id = (int)row[1], Name = row[0].ToString() });
            }

            return result.ToArray();


        }

        public static JobTitle[] GetJobTitles()
        {
            var tableJobTitles = new DataTable();

            var command = $"SELECT dbo.JobTitle.JobTitle, dbo.JobTitle.Id FROM dbo.JobTitle";

            dataAdapter = new SqlDataAdapter(command, connectionString);

            dataAdapter.Fill(tableJobTitles);

            var result = new List<JobTitle>();

            foreach (DataRow row in tableJobTitles.Rows)
            {
                result.Add(new JobTitle() { Id = (int)row[1], Name = row[0].ToString() });
            }

            return result.ToArray();
        }
        public static KPI[] GetKPI()
        {
            var tableKPI = new DataTable();

            var command = $"SELECT dbo.KPI.KPI, dbo.KPI.Id FROM dbo.KPI";

            dataAdapter = new SqlDataAdapter(command, connectionString);

            dataAdapter.Fill(tableKPI);

            var result = new List<KPI>();

            foreach (DataRow row in tableKPI.Rows)
            {
                result.Add(new KPI() { Id = (int)row[1], Name = row[0].ToString() });
            }

            return result.ToArray();
        }
    }
}
