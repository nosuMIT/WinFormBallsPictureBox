using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBalls
{
    class Ball:PictureBox
    {
        protected int radius = 20;
        double vx = 10, vy = 10;

        public Ball(int x, int y, Form form)
        {
            this.Left = x;
            this.Top = y;
            this.Load("images/angry.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Width = 2 * radius;
            this.Height = 2 * radius;
            form.Controls.Add(this);
        }


}
