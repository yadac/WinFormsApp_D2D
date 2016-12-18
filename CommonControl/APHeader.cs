using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class APHeader : UserControl
    {
        public APHeader()
        {
            InitializeComponent();
        }

        public event Action Button1Click;
        public event Action Button2Click;

        public string Label1 { set { this.label1.Text = value; } }
        public string Label2 { set { this.label2.Text = value; } }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button1Click?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button2Click?.Invoke();
        }
    }
}
