using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3EntityFramework
{
    public partial class Form4 : Form
    {
        public AuthHandler auth;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth(textBox1.Text, textBox2.Text, checkBox1.Checked);
            textBox1.Text = "";
            textBox1.Text = "";
        }
    }
}
