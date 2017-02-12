using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class Toolbar : UserControl
    {
        private readonly StringFormat sf;
        private int counter = 9;
        ContextMenuStrip menu;
        private Font fnt;

        public Toolbar()
        {
            InitializeComponent();
            this.button1.Paint += Render;

            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            menu = new ContextMenuStrip();
            var a = new ToolStripMenuItem() { Name = "aaa", Text = @"this is aaa", CheckOnClick = true, };
            var b = new ToolStripMenuItem() { Name = "bbb", Text = @"this is bbb", };
            var c = new ToolStripMenuItem() { Name = "ccc", Text = @"this is ccc", };
            a.Click += OnItemClickedEvent;
            b.Click += OnItemClickedEvent;
            c.Click += OnItemClickedEvent;
            menu.Items.AddRange(new ToolStripItem[] { a, b, c });
            fnt = new Font("MS UI Gothic", 8);
            this.Cursor = Cursors.Cross;
        }

        private void OnItemClickedEvent(object sender, EventArgs eventArgs)
        {
            var temp = sender as ToolStripMenuItem;
            Console.WriteLine($@"OnItemClickedEvent : name is {temp?.Name} value is {temp?.Text}");
            counter++;
            button1.Refresh();
        }

        private void Render(object sender, PaintEventArgs eventArgs)
        {
            Console.WriteLine("timer tick");
            Rectangle redEllipse = new Rectangle(
                button1.Location.X + (button1.ClientSize.Width / 2),
                button1.Location.Y,
                20,
                20);
            eventArgs.Graphics.FillEllipse(Brushes.Red, redEllipse);
            eventArgs.Graphics.DrawString(
                counter.ToString(),
                fnt,
                Brushes.White,
                redEllipse,
                sf);
        }

        ~Toolbar()
        {
            fnt.Dispose();
            sf.Dispose();
        }

        public event Action OnButton1Clicked;

        private void button1_Click(object sender, EventArgs e)
        {
            OnButton1Clicked?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu.Show(button2, new Point(0, button2.Height));
        }
    }
}
