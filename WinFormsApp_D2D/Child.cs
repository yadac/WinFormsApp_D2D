using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;
using FontStyle = Microsoft.WindowsAPICodePack.DirectX.DirectWrite.FontStyle;

namespace WinFormsApp_D2D
{
    public partial class Child : Form
    {
        private List<RenderTarget> renderTargets;
        RenderTarget renderTarget1, renderTarget2;
        Random rand;
        SolidColorBrush blackBlush;
        SolidColorBrush redBlush;
        SolidColorBrush greenBlush;
        SolidColorBrush blueBlush;
        D2DFactory d2DFactory;
        DWriteFactory dwriteFactory;
        private Timer onPaintTimer;
        Form[] forms = new Form[10];
        private int index = 0;

        /// <summary>
        /// 描画リソース解放
        /// </summary>
        ~Child()
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
        public Child()
        {
            // todo : mdi container
            // todo : load data to memory from excel
            // todo : mstest, coverrage, msbuild

            InitializeComponent();
            this.ControlBox = false;
            this.Text = "child";
            // this.ClientSize = new Size(MaximumSize.Width, MaximumSize.Height);
            this.WindowState = FormWindowState.Maximized;
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
                foreach (var renderTarget in renderTargets)
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
            }
            catch (Exception ex)
            {
                // handle if draw failed.
                Console.WriteLine("[error][{0}]{1}", DateTime.Now.Millisecond, ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
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
                //DpiX = 0,
                //DpiY = 0,
                //PixelFormat = new PixelFormat(Microsoft.WindowsAPICodePack.DirectX.Graphics.Format.Unknown, AlphaMode.Ignore),
                PixelFormat = new PixelFormat(),
                Usage = RenderTargetUsages.None,
                RenderTargetType = RenderTargetType.Default
            };

            // handle1
            HwndRenderTargetProperties hwndRenderTargetProperties1 = new HwndRenderTargetProperties
            {
                // WindowHandle = this.Handle,
                // WindowHandle = Graphics.FromHdc(this.pictureBox1.Handle).GetHdc(),
                WindowHandle = this.pictureBox1.Handle,
                // PixelSize = new SizeU((uint)this.ClientRectangle.Width, (uint)this.ClientRectangle.Height), // クライアント領域次第で変わる
                PixelSize = new SizeU((uint)this.MdiParent.ClientRectangle.Width, (uint)this.MdiParent.ClientRectangle.Height), // クライアント領域次第で変わる
                // PixelSize = new SizeU((uint)this.pictureBox1.Width, (uint)this.pictureBox1.Height),
                PresentOptions = PresentOptions.Immediately
            };
            renderTarget1 = d2DFactory.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties1);

            // handle2
            HwndRenderTargetProperties hwndRenderTargetProperties2 = new HwndRenderTargetProperties
            {
                //WindowHandle = Graphics.FromHdc(this.pictureBox2.Handle).GetHdc(),
                WindowHandle = this.pictureBox2.Handle,
                PixelSize = new SizeU((uint)this.MdiParent.ClientRectangle.Width, (uint)this.MdiParent.ClientRectangle.Height), // クライアント領域次第で変わる
                // PixelSize = new SizeU((uint)this.pictureBox2.Width, (uint)this.pictureBox2.Height),
                PresentOptions = PresentOptions.Immediately
            };
            renderTarget2 = d2DFactory.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties2);

            renderTargets = new List<RenderTarget>
            {
                renderTarget1,
                renderTarget2,
            };

            // create blushes
            blackBlush = renderTarget1.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 0.0f));
            redBlush = renderTarget1.CreateSolidColorBrush(new ColorF(1.0f, 0.0f, 0.0f));
            greenBlush = renderTarget2.CreateSolidColorBrush(new ColorF(0.0f, 1.0f, 0.0f));
            blueBlush = renderTarget1.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 1.0f));

            // define and start onPaintTimer
            onPaintTimer = new Timer();
            onPaintTimer.Interval = 500;
            onPaintTimer.Tick += Render;
            onPaintTimer.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = !(this.splitContainer1.Panel2Collapsed);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (forms.Length > index)
            {
                SubWindow s1 = new SubWindow()
                {
                    TopLevel = false,
                    AllowTransparency = true,
                    Opacity = 0.5, // きかない
                };
                this.forms[index] = s1;
                index++;
                this.Controls.Add(s1);
                s1.BringToFront();
                s1.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !(this.splitContainer1.Panel1Collapsed);
        }
    }
}
