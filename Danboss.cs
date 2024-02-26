using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dacs
{
     class Danboss
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;
        private int dnbossspeed = 30;
        private int speed = 25;
        private PictureBox bulletboss = new PictureBox();
        private PictureBox dannoboss = new PictureBox();
        private Timer bulletbossTimer = new Timer();
        private Timer dannobossTimer = new Timer();

        public void MakeBossBullet(Form form)
        {
            bulletboss.BackColor = Color.White;
            bulletboss.Size = new Size(5, 5);
            bulletboss.Top = bulletTop;
            bulletboss.Tag = "bossbullet";
            bulletboss.Left = bulletLeft;
            bulletboss.BringToFront();
            form.Controls.Add(bulletboss);
            bulletbossTimer.Interval = speed;
            bulletbossTimer.Tick += new EventHandler(BulletTimeEvent);
            bulletbossTimer.Start();
        }

        public void MakeBossDanno(Form form)
        {
            dannoboss.BackColor = Color.Yellow;
            dannoboss.Size = new Size(12, 12);
            dannoboss.Top = bulletTop;
            dannoboss.Tag = "DN";
            dannoboss.Left = bulletLeft;
            dannoboss.BringToFront();
            form.Controls.Add(dannoboss);
            dannobossTimer.Interval = dnbossspeed;
            dannobossTimer.Tick += new EventHandler(DannoTimeEvent);
            dannobossTimer.Start();
        }
        public void BulletTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bulletboss.Left -= speed;
            }
            if (direction == "right")
            {
                bulletboss.Left += speed;
            }
            if (direction == "up")
            {
                bulletboss.Top -= speed;
            }
            if (direction == "down")
            {
                bulletboss.Top += speed;
            }
            if (bulletboss.Left < 10 || bulletboss.Left > 1000 || bulletboss.Top < 10 || bulletboss.Top > 800)
            {
                bulletbossTimer.Stop();
                bulletbossTimer.Dispose();
                bulletboss.Dispose();
                bulletbossTimer = null;
                bulletboss = null;
            }
        }
        private void DannoTimeEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                dannoboss.Left -= dnbossspeed;
            }
            if (direction == "right")
            {
                dannoboss.Left += dnbossspeed;
            }
            if (direction == "up")
            {
                dannoboss.Top -= dnbossspeed;
            }
            if (direction == "down")
            {
                dannoboss.Top += dnbossspeed;
            }
            if (dannoboss.Left < 10 || dannoboss.Left > 1000 || dannoboss.Top < 10 || dannoboss.Top > 800)
            {
                dannobossTimer.Stop();
                dannobossTimer.Dispose();
                dannoboss.Dispose();
                dannobossTimer = null;
                dannoboss = null;
            }
        }
    }
}
