using Domain.Intefaces;

namespace Domain.Classes
{
    public class Rectangle : IRectangle
    {
        #region Members
        private int _left;
        private int _top;
        private int _width;
        private int _hight;
        #endregion

        #region Properties
        public int Left
        {
            get
            {
                return this._left;
            }
            private set
            {
                this._left = value;
            }
        }

        public int Top
        {
            get
            {
                return this._top;
            }
            private set
            {
                this._top = value;
            }
        }

        public int Width
        {
            get
            {
                return this._width;
            }
            private set
            {
                this._width = value;
            }
        }

        public int Hight
        {
            get
            {
                return this._hight;
            }
            private set
            {
                this._hight = value;
            }
        }
        #endregion

        #region CTOR's
        public Rectangle()
        {

        }

        public Rectangle(int x, int y, int w, int h)
        {
            this.Left = x;
            this.Top = y;
            this.Width = w;
            this.Hight = h;
        }
        #endregion

        #region IRectangle implementation
        public int getBottom()
        {
            return this.Top + this.Hight;
        }

        public int getLeft()
        {
            return this.Left;
        }

        public Properties getProperties()
        {
            throw new System.NotImplementedException();
        }

        public int getRight()
        {
            return this.Left + this.Width;
        }

        public int getTop()
        {
            return this.Top;
        }
        #endregion
    }
}
