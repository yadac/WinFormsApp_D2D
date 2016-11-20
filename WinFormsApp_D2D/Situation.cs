using System;
//using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;

namespace WinFormsApp_D2D
{
    public partial class Situation : Form
    {
        RenderTarget renderTarget;
        Random rand;
        SolidColorBrush blackBlush;
        SolidColorBrush redBlush;
        SolidColorBrush greenBlush;
        SolidColorBrush blueBlush;
        D2DFactory d2DFactory;
        DWriteFactory dwriteFactory;

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
            // todo : mdi container
            // todo : load data to memory from excel
            // todo : mstest, coverrage, msbuild

            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(MaximumSize.Width, MaximumSize.Height);

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
            //Console.WriteLine("onpaint!!");
            rand = new Random(Environment.TickCount);
            try
            {
                // 描画開始
                renderTarget.BeginDraw();

                // 背景塗りつぶし
                renderTarget.Clear(new ColorF(0.9f, 0.9f, 0.9f));

                // 線分描画 buffering on memory 
                //renderTarget.DrawLine(
                //    new Point2F(0, 0),
                //    new Point2F(this.ClientRectangle.Width, this.ClientRectangle.Height),
                //    blush,
                //    1);

                // テキスト描画            
                // define font style
                const string fontFamily = "Wingdings"; // you can edit this of course, ex) "Wingdings", "Arial"
                const float fontSize = 14.0f;
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
                    renderTarget.DrawText(str, tf, new RectF(left, top, left + fontSize, top + fontSize), blueBlush);
                }

                // 描画終了 flush buffered data
                renderTarget.EndDraw();
            }
            catch (Exception ex)
            {
                // handle if draw failed.
                Console.WriteLine("[error][{0}]{1}", DateTime.Now.Millisecond, ex.Message);
                throw;
            }
            finally
            {
                // nothing to do
            }
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

            // handle
            HwndRenderTargetProperties hwndRenderTargetProperties = new HwndRenderTargetProperties
            {
                WindowHandle = this.Handle,
                // PixelSize = new SizeU((uint)this.ClientRectangle.Width, (uint)this.ClientRectangle.Height), // クライアント領域次第で変わる
                PixelSize = new SizeU((uint)this.MdiParent.ClientRectangle.Width, (uint)this.MdiParent.ClientRectangle.Height), // クライアント領域次第で変わる
                PresentOptions = PresentOptions.Immediately
            };
            renderTarget = d2DFactory.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties);

            // create blushes
            blackBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 0.0f));
            redBlush = renderTarget.CreateSolidColorBrush(new ColorF(1.0f, 0.0f, 0.0f));
            greenBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 1.0f, 0.0f));
            blueBlush = renderTarget.CreateSolidColorBrush(new ColorF(0.0f, 0.0f, 1.0f));

            // define and start timer
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Render;
            timer.Start();

        }
    }
}
