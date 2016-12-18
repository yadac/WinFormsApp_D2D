using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_D2D
{
    public partial class Toolbar : Form
    {

        private Dictionary<string, Form> formContainer;

        /// <summary>
        /// 初期化処理
        /// ・描画リソース作成
        /// ・タイマー起動
        /// </summary>
        public Toolbar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            formContainer = new Dictionary<string, Form>();

        }

        ~Toolbar()
        {
        }

        private void Toolbar_Load(object sender, EventArgs e)
        {
            // シチュエーション領域インスタンス生成
            Situation situation = new Situation();
            situation.TopLevel = false;
            situation.Height = this.Height - toolbar1.Height;
            situation.Width = this.Width;
            situation.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y); // todo : 仕方なくパネルで表示位置設定
            this.Controls.Add(situation);
            situation.BringToFront(); // todo : パネルより手前に出す処理
            situation.Show();

            // サブウィンドウのインスタンス生成
            SubWindow1 s1v = new SubWindow1();
            SubWindow1Presenter s1p = new SubWindow1Presenter(s1v);
            toolbar1.OnButton1Clicked += s1p.Show;
            s1v.TopLevel = false;
            situation.AddForms(s1v);

        }
    }
}
