using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;
using FontStyle = Microsoft.WindowsAPICodePack.DirectX.DirectWrite.FontStyle;

namespace WinFormsApp_D2D
{
    public partial class Situation : Form
    {
        private RenderTarget renderTarget;
        Random rand;
        SolidColorBrush blackBlush;
        SolidColorBrush redBlush;
        SolidColorBrush greenBlush;
        SolidColorBrush blueBlush;
        D2DFactory d2DFactory;
        DWriteFactory dwriteFactory;
        private Timer onPaintTimer;
        List<Form> forms = new List<Form>();
        private int index = 0;

        /// <summary>
        /// 描画リソース解放
        /// </summary>
        ~Situation()
        {
            // relase unmanaged resources
            d2DFactory.Dispose();
            dwriteFactory.Dispose();
        }

        /// <summary>
        /// 初期化処理
        /// ・描画リソース作成
        /// ・タイマー起動
        /// </summary>
        public Situation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

        }

        /// <summary>
        /// timer call, raise onPaintEvent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Render(object sender, EventArgs e)
        {
            InvokePaint(this, null);
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            rand = new Random(Environment.TickCount);
            try
            {
                // 描画開始
                renderTarget.BeginDraw();

                // 背景塗りつぶし
                renderTarget.Clear(new ColorF(0.9f, 0.9f, 0.9f));

                // テキスト描画            
                // define font style
                const string fontFamily = "Wingdings"; // you can edit this of course, ex) "Wingdings", "Arial"
                const float fontSize = 20.0f;
                TextFormat tf = dwriteFactory.CreateTextFormat(
                    fontFamily,
                    fontSize,
                    FontWeight.Normal,
                    FontStyle.Normal,
                    FontStretch.Normal);

                // 16進数 -> 数値 -> 文字 -> 文字列
                string charCode = "51";
                int charCode16 = Convert.ToInt32(charCode, 16);  // 16進数文字列 -> 数値
                char c = Convert.ToChar(charCode16);  // 数値(文字コード) -> 文字
                string str = c.ToString();    // 文字 -> 「文字列」
                for (int i = 0; i < 10; i++)
                {
                    float left = rand.Next(0, (int)renderTarget.Size.Width);
                    float top = rand.Next(0, (int)renderTarget.Size.Height);
                    renderTarget.DrawText(str, tf, new RectF(left, top, left + fontSize, top + fontSize), renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 1.0f)));
                }

                // 描画終了 flush buffered data
                renderTarget.EndDraw();
            }
            catch (Exception ex)
            {
                // handle if draw failed.
                Console.WriteLine("[error][{0}]{1}", DateTime.Now.Millisecond, ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
            finally
            {
            }
            // 描画領域の背面に隠れるのを防ぐ
            foreach (var form in forms)
                form?.BringToFront();
        }

        private void Situation_Load(object sender, EventArgs e)
        {
            Console.WriteLine("load!!");
            // create factory (un-managed resource)
            d2DFactory = D2DFactory.CreateFactory(D2DFactoryType.SingleThreaded);
            dwriteFactory = DWriteFactory.CreateFactory();

            // target
            RenderTargetProperties renderTargetProperties = new RenderTargetProperties
            {
                PixelFormat = new PixelFormat(),
                Usage = RenderTargetUsages.None,
                RenderTargetType = RenderTargetType.Default
            };

            // handle
            HwndRenderTargetProperties hwndRenderTargetProperties1 = new HwndRenderTargetProperties
            {
                WindowHandle = this.pictureBox1.Handle,
                PixelSize = new SizeU((uint)this.pictureBox1.Width, (uint)this.pictureBox1.Height),
                PresentOptions = PresentOptions.Immediately
            };
            renderTarget = d2DFactory.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties1);

            // create blushes
            blackBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 0.0f));
            redBlush = renderTarget.CreateSolidColorBrush(new ColorF(1.0f, 0.0f, 0.0f));
            greenBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 1.0f, 0.0f));
            blueBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 1.0f));

            // define and start onPaintTimer
            onPaintTimer = new Timer();
            onPaintTimer.Interval = 500;
            onPaintTimer.Tick += Render;
            onPaintTimer.Start();

        }

        public void AddForms(Form form)
        {
            this.Controls.Add(form);
            this.forms.Add(form);
        }
    }
}
