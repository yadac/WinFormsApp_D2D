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
    public partial class Toolbar : UserControl
    {
        public Toolbar()
        {
            InitializeComponent();
        }

        public event Action OnButton1Clicked;


        private void button1_Click(object sender, EventArgs e)
        {
            OnButton1Clicked?.Invoke();
        }


    }
}
