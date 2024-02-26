using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace dacs
{
    class Canchien
    {
        public string direction;
        public int canchienLeft;
        public int canchienTop;
        public int Width { get; set; }
        public int Height { get; set; }
        private int canchienspeed = 20;
        private PictureBox canchien = new PictureBox();
        private Timer canchienTimer = new Timer();

        public void MakeCanChien(Form form)
        {
            canchien.Size = new Size(150, 150);
            
            canchien.BackgroundImageLayout= ImageLayout.Stretch;
           
            
            canchien.Tag = "cn";
            
            canchien.BringToFront();

            if (direction == "left")
            {
                canchien.Left = canchienLeft - canchien.Width;
                canchien.Top = canchienTop + (Height / 2) - (canchien.Height / 2);
                canchien.BackgroundImage = Properties.Resources.Chemtrai;
            }
            else if (direction == "right")
            {
                canchien.Left = canchienLeft + Width; 
                canchien.Top = canchienTop + (Height / 2) - (canchien.Height / 2);
                canchien.BackgroundImage = Properties.Resources.Chemphai;
            }
            else if (direction == "up")
            {
                canchien.Left = canchienLeft + (Width / 2) - (canchien.Width / 2);
                canchien.Top = canchienTop - canchien.Height; 
                canchien.BackgroundImage = Properties.Resources.Chemtren;
            }
            else if (direction == "down")
            {
                canchien.Left = canchienLeft + (Width / 2) - (canchien.Width / 2);
                canchien.Top = canchienTop + Height;
                canchien.BackgroundImage = Properties.Resources.chemduoi;
            }



            form.Controls.Add(canchien);
            canchienTimer.Interval = 200;
            canchienTimer.Tick += (sender, e) =>
            {
                canchien.Dispose();
                canchienTimer.Stop();
            };
            canchienTimer.Start();
        }

    }
}
