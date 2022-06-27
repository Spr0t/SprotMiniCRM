using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQL
{
    public static class FilesController
    {
        public static bool IsDone = false;
        public static string filename = "";

        public static void WriteToFile(DataTable table)
        {
            IsDone = false;
            filename = $"Report-{DateTime.Now:d}-{DateTime.Now.Millisecond}.txt";
            using (var sw = new StreamWriter(filename))
            {

                for (var i = 0; i < table.Rows.Count; i++)
                {
                    var line = new StringBuilder();

                    foreach (var cell in table.Rows[i].ItemArray)
                    {
                        line.Append(cell.ToString() + ";\t");
                    }
                    sw.WriteLine(line);
                }

            }
            Thread.Sleep(5000);

            IsDone = true;




        }







    }
}
