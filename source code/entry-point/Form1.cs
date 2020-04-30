using System;
using System.Collections.ObjectModel;
using Domain.Classes;
using Domain.Intefaces;
using System.Windows.Forms;

namespace entry_point
{
    public partial class Form1 : Form
    {
        private readonly int MAX_WIDTH = 0;
        private readonly int MAX_HEIGHT = 0;
        private readonly int SIDE_GETTER = 5;
        private readonly int TOP_GETTER = 10;
        RectanglesStore store;
        Collection<IRectangle> rectangles;

        public Form1()
        {
            InitializeComponent();

            this.MAX_HEIGHT = Screen.GetWorkingArea(this).Height - (this.TOP_GETTER + 28);
            this.MAX_WIDTH = Screen.GetWorkingArea(this).Width - (this.SIDE_GETTER * 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Random rnd = new Random();

            Rectangle bounds = new Rectangle(this.SIDE_GETTER, this.TOP_GETTER, this.MAX_WIDTH, this.MAX_HEIGHT);

            System.Drawing.SolidBrush c = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255, 255));

            e.Graphics.FillRectangle(c, this.SIDE_GETTER, this.TOP_GETTER, this.MAX_WIDTH, this.MAX_HEIGHT);

            rectangles = new Collection<IRectangle>();
            
            store = new RectanglesStore();

            int[] tops = new int[] {
                776, 435, 869, 141, 700, 791, 957, 66, 252, 450, 806, 48, 124, 384, 440, 693, 42, 301, 602, 519, 630, 597, 523
            };

            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 8);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            foreach (int top in tops)
            {
                int w = rnd.Next(20, this.MAX_WIDTH / 3);
                int h = rnd.Next(20, this.MAX_HEIGHT / 3);
                int x = rnd.Next(this.SIDE_GETTER, this.MAX_WIDTH);
                int y = top; // rnd.Next(this.TOP_GETTER, this.MAX_HEIGHT);

                #region rectangle size fixes
                if ((w + x) > this.MAX_WIDTH)
                {
                    w -= ((w + x) - this.MAX_WIDTH);
                    w += this.SIDE_GETTER;
                }

                if ((h + y) > this.MAX_HEIGHT)
                {
                    h -= ((h + y) - this.MAX_HEIGHT);
                    h += this.TOP_GETTER;
                }
                #endregion

                rectangles.Add(new Rectangle(x, y, w, h));

                System.Drawing.SolidBrush color = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(50, rnd.Next(256), rnd.Next(256), rnd.Next(256)));

                e.Graphics.DrawString(string.Format("X: {0}, Y: {1}", x, y), drawFont, drawBrush, x, y, drawFormat);
                e.Graphics.FillRectangle(color, x, y, w, h);
            }

            store.initialize(bounds: bounds, rectangles: rectangles);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MouseEventArgs e2 = (MouseEventArgs)e;

            IRectangle closest = store.findRectangleAt(e2.X, e2.Y);

            MessageBox.Show(string.Format("The closest IRectangle locate in X: {0} Y: {1}", closest.getLeft(), closest.getTop()));
        }
    }
}
