using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormBalls
{
    public class SimpleBall
    {

        static Random rnd = new Random();

        protected int radius = 20;
        protected int x, y;
        protected int vx, vy;
        protected Color color = Color.Aqua;
        Color clearColor;
        protected Form form;
        Graphics g;
        
        int MAXSpeed = 50;
        Timer timer;


        public SimpleBall(int x, int y, Form form)
        {
            this.x = x;
            this.y = y;
            g = form.CreateGraphics();
            this.form = form;
            vx = rnd.Next(-MAXSpeed, MAXSpeed);
            vy = rnd.Next(-MAXSpeed, MAXSpeed);
            clearColor = form.BackColor;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clear();
            Move();
            Show();
        }

        public void Pause()
        {
            timer.Enabled = !timer.Enabled;
        }

        public void Show()
        {
            //Pen p = Pens.Aqua;
            //g.DrawEllipse(p, x, y, 2 * radius, 2 * radius);
            Brush br = new SolidBrush(color);
            g.FillEllipse(br, x - radius, y - radius, 2 * radius, 2 * radius);
        }

        public void Clear()
        {
            Brush br = new SolidBrush(clearColor);
            g.FillEllipse(br, x - radius, y - radius, 2 * radius, 2 * radius);
        }

        public virtual void Move()
        {
            x += vx;
            y += vy;
        }
    }

    public class BilliardBall : SimpleBall
    {
        public BilliardBall(int x, int y, Form form) : base(x, y, form)
        {
            color = Color.Chocolate;
        }

        public override void Move()
        {
            if (y <= radius)
            {
                vy = -vy;
                y = radius + 1; 
            }
            if (x <= radius)
            {
                vx = -vx;
            }
            if (x >= form.ClientSize.Width - radius)
            {
                vx = -vx;
            }
            if (y >= form.ClientSize.Height - radius)
            {
                vy = -vy;
            }
            x += vx;
            y += vy;
        }
    }
}
