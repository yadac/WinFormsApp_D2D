using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BackColor = Color.Yellow;
            this.Cursor = new Cursor(Resource1.sp.GetHicon());


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
