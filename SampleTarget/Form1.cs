using System;
using System.Threading;
using System.Windows.Forms;

namespace SampleTarget
{
    // setterとpropertyで実装
    // https://msdn.microsoft.com/ja-jp/library/ms171728(v=vs.110).aspx

    public partial class Form1 : Form
    {
        private Thread _demoThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));
            this._demoThread.Start();
        }

        private void ThreadProcSafe()
        {
            this.SetText("this text was set safely");
            this.TextBox1Text = "also this text was set safely";
        }

        private delegate void SetTextCallback(string s);

        // setter style
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        // property style
        public string TextBox1Text
        {
            set
            {
                if (this.textBox1.InvokeRequired)
                {
                    var d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { value });
                }
                else
                {
                    this.textBox1.Text = value;
                }                
            }
        }
    }
}
