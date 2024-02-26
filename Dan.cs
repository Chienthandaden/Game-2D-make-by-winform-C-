using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dacs
{
    class Dan
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;
        public int laserleft;
        public int lasertop;
        private int dnspeed = 30;
        private int dnrspeed = 20;
        private int lsspeed = 75;
        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private PictureBox laser = new PictureBox();
        private PictureBox danno = new PictureBox();
        private PictureBox dannora = new PictureBox();
        private PictureBox danlua = new PictureBox();


        private Timer bulletTimer = new Timer();
        private Timer laserTimer = new Timer();
        private Timer dannoTimer = new Timer();
        private Timer dannoraTimer = new Timer();
        private Timer dannluaTimer = new Timer();


        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Top = bulletTop;
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.BringToFront();
            form.Controls.Add(bullet);
            bulletTimer.Interval= speed;
            bulletTimer.Tick += new EventHandler(BulletTimeEvent);
            bulletTimer.Start();
        }
        public void MakeLaser(Form form)
        {
            laser.BackColor = Color.Red;
            laser.Size = new Size(30, 60);
            laser.Top = bulletTop;
            laser.Tag = "laser";
            laser.Left = bulletLeft;
            laser.BringToFront();
            form.Controls.Add(laser);
            laserTimer.Interval = lsspeed;
            laserTimer.Tick += new EventHandler(LaserTimeEvent);
            laserTimer.Start();

        }
        public void MakeDanno(Form form)
        {
            danno.BackColor = Color.Yellow;
            danno.Size = new Size(12, 12);
            danno.Top = bulletTop;
            danno.Tag = "DN";
            danno.Left = bulletLeft;
            danno.BringToFront();
            form.Controls.Add(danno);
            dannoTimer.Interval = dnspeed;
            dannoTimer.Tick += new EventHandler(DannoTimeEvent);
            dannoTimer.Start();
        }

        public void MakeDannora(Form form)
        {
            dannora.BackColor = Color.Yellow;
            dannora.Size = new Size(10, 10);
            dannora.Top = bulletTop;
            dannora.Tag = "DNR";
            dannora.Left = bulletLeft;
            dannora.BringToFront();
            form.Controls.Add(dannora);
            dannoraTimer.Interval = dnrspeed;
            dannoraTimer.Tick += new EventHandler(DannoraTimeEvent);
            dannoraTimer.Start();
        }

        public void MakeDanlua(Form form)
        {
            danlua.BackColor = Color.Black;
            danlua.Size = new Size(10, 10);
            danlua.Top = bulletTop;
            danlua.Tag = "danlua";
            danlua.Left = bulletLeft;
            danlua.BringToFront();
            form.Controls.Add(danlua);
            dannluaTimer.Interval = speed;
            dannluaTimer.Tick += new EventHandler(DanluaTimeEvent);
            dannluaTimer.Start();
        }

        public void DanluaTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                danlua.Left -= speed;
            }
            if (direction == "right")
            {
                danlua.Left += speed;
            }
            if (direction == "up")
            {
                danlua.Top -= speed;
            }
            if (direction == "down")
            {
                danlua.Top += speed;
            }
            if (danlua.Left < 10 || danlua.Left > 1000 || danlua.Top < 10 || danlua.Top > 800)
            {
                dannluaTimer.Stop();
                dannluaTimer.Dispose();
                danlua.Dispose();
                dannluaTimer = null;
                danlua = null;
            }
        }
        public void BulletTimeEvent(object sender, EventArgs e)
        {
            if(direction == "left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }
            if (bullet.Left < 10 || bullet.Left > 1000  || bullet.Top < 10 || bullet.Top > 800) 
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
        private void LaserTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                laser.Left -= lsspeed;
            }
            if (direction == "right")
            {
                laser.Left += lsspeed;
            }
            if (direction == "up")
            {
                laser.Top -= lsspeed;
            }
            if (direction == "down")
            {
                laser.Top += lsspeed;
            }
            if (laser.Left < 20 || laser.Left > 800 || laser.Top < 20 || laser.Top > 500)
            {
                laserTimer.Stop();
                laserTimer.Dispose();
                laser.Dispose();
                laserTimer = null;
                laser = null;
            }
        }
        private void DannoTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                danno.Left -= dnspeed;
            }
            if (direction == "right")
            {
                danno.Left += dnspeed;
            }
            if (direction == "up")
            {
                danno.Top -= dnspeed;
            }
            if (direction == "down")
            {
                danno.Top += dnspeed;
            }
            if (danno.Left < 10 || danno.Left > 1000 || danno.Top < 10 || danno.Top > 800)
            {
                dannoTimer.Stop();
                dannoTimer.Dispose();
                danno.Dispose();
                dannoTimer = null;
                danno = null;
            }
        }
        private void DannoraTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                dannora.Left -= dnrspeed;
            }
            if (direction == "right")
            {
                dannora.Left += dnrspeed;
            }
            if (direction == "up")
            {
                dannora.Top -= dnrspeed;
            }
            if (direction == "down")
            {
                dannora.Top += dnrspeed;
            }
            if (dannora.Left < 10 || dannora.Left > 1000 || dannora.Top < 10 || dannora.Top > 800)
            {
                dannoraTimer.Stop();
                dannoraTimer.Dispose();
                dannora.Dispose();
                dannoraTimer = null;
                dannora = null;
            }
        }
    }

    
}
