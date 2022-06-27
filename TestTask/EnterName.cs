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
    public partial class EnterName : Form
    {
        public string name;
        public EnterName(string input = "")
        {
            InitializeComponent();
            textBox1.Text = input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            if (!string.IsNullOrEmpty(name))
            {
                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void EnterName_Load(object sender, EventArgs e)
        {

        }
    }
}
