using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dacs
{
    public partial class Form1 : Form
    {
        private Timer playTimer;
        private int elapsedTime; // Thời gian chơi tính bằng giây
        private Label timeLabel;
        private int zombieCount = 3; // Số lượng zombie ban đầu
        private bool bossSpawned = false; // Kiểm tra xem boss đã xuất hiện chưa
        private bool gameStarted = false;
        bool goLeft, goRight, goUp, goDown, gameOver;      
        string facing = "Up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int laserammo = 1;
        int dannoammo = 3;    
        int zombiespeed = 3;
        int zombiebossspeed = 4;
        int zombiesuperbossspeed = 5;
        int bossHealth = 3;
        int superbosshealth = 5;
        int score;
        int scoretoboss = 10;
        Random randNum = new Random();
        List<PictureBox> zombiesList = new List<PictureBox>();
        List<PictureBox> Zombieboss = new List<PictureBox>();
        List<PictureBox> Zombiesuperboss = new List<PictureBox>();





        public Form1()
        {
            
            InitializeComponent();
            RestarGame();
            
          


            this.Controls.Add(timeLabel);

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        
        private void tgchinh(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                
                ThanhMau.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                nguoichoi.Image = Properties.Resources.dead;
                gametime.Stop();
            }
            txtDan.Text = "Đạn" + ammo;
            txtDiem.Text = "Điểm" + score;
            txtLaser.Text = "Laser" + laserammo;
            txtDanno.Text = "Explode" + dannoammo;
            

            if (goLeft == true && nguoichoi.Left > 0)
            {
                nguoichoi.Left -= speed;
            }
            if (goRight == true && nguoichoi.Left + nguoichoi.Width < this.ClientSize.Width)
            {
                nguoichoi.Left += speed;
            }
            if (goUp == true && nguoichoi.Top > 45)
            {
                nguoichoi.Top -= speed;
            }
            if (goDown == true && nguoichoi.Top + nguoichoi.Height < this.ClientSize.Height)
            {
                nguoichoi.Top += speed;
            }
            foreach (Control x in this.Controls)
            {
                int solanbiban = 0;
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 10;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "heal")
                {
                    
                        if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                        ThanhMau.Maximum += 50;
                            playerHealth += 50;
                        }                        
                }
                if (x is PictureBox && (string)x.Tag == "lsammo")
                {
                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        laserammo += 1;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "dnammo")
                {
                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        dannoammo += 3;
                    }
                }
                

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (x.Left > nguoichoi.Left)
                    {
                        x.Left -= zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Left < nguoichoi.Left)
                    {
                        x.Left += zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > nguoichoi.Top)
                    {
                        x.Top -= zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (x.Top < nguoichoi.Left)
                    {
                        x.Top += zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "BossZombie")

                {
                   
                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 2;
                    }

                    if (x.Left > nguoichoi.Left)
                    {
                        x.Left -= zombiebossspeed;
                        ((PictureBox)x).Image = Properties.Resources.bossz__1_;
                    }
                    if (x.Left < nguoichoi.Left)
                    {
                        x.Left += zombiebossspeed;
                        ((PictureBox)x).Image = Properties.Resources.bossz__1_;
                    }
                    if (x.Top > nguoichoi.Top)
                    {
                        x.Top -= zombiebossspeed;
                        ((PictureBox)x).Image = Properties.Resources.bossz__1_;
                    }
                    if (x.Top < nguoichoi.Left)
                    {
                        x.Top += zombiebossspeed;
                        ((PictureBox)x).Image = Properties.Resources.bossz__1_;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "SuperBossZombie")

                {

                    if (nguoichoi.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 3;
                    }

                    if (x.Left > nguoichoi.Left)
                    {
                        x.Left -= zombiesuperbossspeed;
                        ((PictureBox)x).Image = Properties.Resources.fzleft;
                    }
                    if (x.Left < nguoichoi.Left)
                    {
                        x.Left += zombiesuperbossspeed;
                        ((PictureBox)x).Image = Properties.Resources.fz1;
                    }
                    if (x.Top > nguoichoi.Top)
                    {
                        x.Top -= zombiesuperbossspeed;
                        ((PictureBox)x).Image = Properties.Resources.fz1;
                    }
                    if (x.Top < nguoichoi.Left)
                    {
                        x.Top += zombiesuperbossspeed;
                        ((PictureBox)x).Image = Properties.Resources.fz1;
                    }
                }


                foreach (Control j in this.Controls)
                {
                    
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {

                            scoretoboss--;
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();
                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "BossZombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            bossHealth--;
                            // Hiển thị số "-1" trên đầu con boss
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-1";
                            minusOneLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            if (bossHealth <= 0) 
                            {
                                scoretoboss -= 3;
                                score += 3;
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                Zombieboss.Remove(((PictureBox)x));
                                MakeBoss();
                                
                            }
                            
                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "SuperBossZombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            superbosshealth--;
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-1";
                            minusOneLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 1000; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            if (superbosshealth <= 0)
                            {
                                scoretoboss -= 3;
                                score += 3;
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                Zombiesuperboss.Remove(((PictureBox)x));
                                MakeSuperBoss();
                            }

                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "danlua" && x is PictureBox && (string)x.Tag == "zombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {

                            scoretoboss--;
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();
                        }
                    }

                    if (j is PictureBox && (string)j.Tag == "laser" && x is PictureBox && (string)x.Tag == "zombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-∞";
                            minusOneLabel.Font = new Font("Arial", 25, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            zombieCount--;
                            scoretoboss--;
                            score++;
                            
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            
                                MakeZombies();
                             
                           
                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "laser" && x is PictureBox && (string)x.Tag == "BossZombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-∞";
                            minusOneLabel.Font = new Font("Arial", 25, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            bossHealth -=3;
                            scoretoboss -= 3;
                            score += 3;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            Zombieboss.Remove(((PictureBox)x));
                            MakeBoss();
                        }


                    }
                    
                    if (j is PictureBox && (string)j.Tag == "DN" && x is PictureBox && (string)x.Tag == "zombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-∞";
                            minusOneLabel.Font = new Font("Arial", 25, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            scoretoboss--;
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            
                            MakeZombies();
                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "DN" && x is PictureBox && (string)x.Tag == "BossZombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-2";
                            minusOneLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            bossHealth -=2 ;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            if (bossHealth <= 0)
                            {
                                scoretoboss -= 3;
                                score += 3;
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                Zombieboss.Remove(((PictureBox)x));
                                MakeBoss();
                            }

                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "cn" && x is PictureBox && (string)x.Tag == "zombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-1";
                            minusOneLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            scoretoboss--;
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();
                        }
                    }
                    if (j is PictureBox && (string)j.Tag == "cn" && x is PictureBox && (string)x.Tag == "BossZombie")
                    {

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Label minusOneLabel = new Label();
                            minusOneLabel.Text = "-1";
                            minusOneLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            minusOneLabel.ForeColor = Color.Red;
                            minusOneLabel.AutoSize = true;
                            minusOneLabel.Location = new Point(x.Left, x.Top - 20);
                            this.Controls.Add(minusOneLabel);
                            minusOneLabel.BringToFront();

                            // Tạo một timer để ẩn label sau một khoảng thời gian
                            Timer timer = new Timer();
                            timer.Interval = 500; // 1 giây
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                this.Controls.Remove(minusOneLabel);
                                minusOneLabel.Dispose();
                            };
                            timer.Start();
                            bossHealth--;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            if (bossHealth <= 0)
                            {
                                scoretoboss -= 3;
                                score += 3;
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                Zombieboss.Remove(((PictureBox)x));
                                MakeBoss();
                            }

                        }
                    }
                   

                }
            }

        }   
        
        

        private void keyisDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                nguoichoi.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                nguoichoi.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                nguoichoi.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                nguoichoi.Image = Properties.Resources.down;
            }
            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                ShootBullet(facing);
                if (ammo < 1)
                {
                    DropAmmo();
                    DropHeal();
                    
                }
            }
            if (e.KeyCode == Keys.M && laserammo >0 && gameOver == false)
            {
                laserammo--;
                ShootLaser(facing);
                if(laserammo < 1)
                {
                    DropItem();
                }
            }
            if(e.KeyCode == Keys.N && dannoammo >0 && gameOver == false)
            {
                dannoammo--;
                ShootDanno(facing);
                if(dannoammo < 1)
                {
                    DropItem();
                }
            }
            if(e.KeyCode==Keys.F && gameOver == false)
            {
                
                ChemCanchien(facing);
                

            }
            

        }

        private void nguoichoi_Click(object sender, EventArgs e)
        {

        }

        private void keyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;

            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestarGame();
            }

        }
        private void ShootBullet(string direction)
        {
            Dan shootBullet = new Dan();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            shootBullet.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            shootBullet.MakeBullet(this);
        }

       

        private void ShootLaser (string direction)
        {
            Dan shootLaser = new Dan();
            shootLaser.direction = direction;
            shootLaser.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            shootLaser.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            shootLaser.MakeLaser(this);
        }

        private void ShootDanno(string direction)
        {
            Dan danno1 = new Dan();
            danno1.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            danno1.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            danno1.direction = "up";
            danno1.MakeDanno(this);

            Dan danno2 = new Dan();
            danno2.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            danno2.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            danno2.direction = "left";
            danno2.MakeDanno(this);

            Dan danno3 = new Dan();
            danno3.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            danno3.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            danno3.direction = "right";
            danno3.MakeDanno(this);

            Dan danno4 = new Dan();
            danno4.bulletLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            danno4.bulletTop = nguoichoi.Top + (nguoichoi.Height / 2);
            danno4.direction = "down";
            danno4.MakeDanno(this);
        }

       

        private void ChemCanchien(string direction)
        {
            Canchien ChemCanchien = new Canchien();
            ChemCanchien.direction = direction;
            ChemCanchien.canchienLeft = nguoichoi.Left + (nguoichoi.Width / 2);
            ChemCanchien.canchienTop = nguoichoi.Top + (nguoichoi.Height / 2);
            switch (direction)
            {
                case "up":
                    nguoichoi.Image = Properties.Resources.updao;  // Thay đổi ảnh thành updao
                    break;
                case "down":
                    nguoichoi.Image = Properties.Resources.downdao; // Thay đổi ảnh thành downdao
                    break;
                case "left":
                    nguoichoi.Image = Properties.Resources.leftdao; // Thay đổi ảnh thành leftdao
                    break;
                case "right":
                    nguoichoi.Image = Properties.Resources.rightdao; // Thay đổi ảnh thành rightdao
                    break;
                default:
                    // Hướng không hợp lệ, không thực hiện cận chiến
                    return;
            }
            ChemCanchien.MakeCanChien(this);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 800);
            zombie.Top = randNum.Next(0, 650);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.BackColor = Color.Transparent;
            zombie.BorderStyle = BorderStyle.None;
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            nguoichoi.BringToFront();
        }
        private void MakeBoss()
        {
            PictureBox zomboss = new PictureBox();           
            zomboss.Tag = "BossZombie";
            zomboss.Image = Properties.Resources.bossz__1_;
            zomboss.Left = randNum.Next(0, 800);
            zomboss.Top = randNum.Next(0, 650);
            zomboss.SizeMode = PictureBoxSizeMode.AutoSize;
            zomboss.BackColor = Color.Transparent;
            bossHealth = 3;
            Zombieboss.Add(zomboss);
            this.Controls.Add(zomboss);
            nguoichoi.BringToFront();

           
        }

        

        private void MakeSuperBoss()
        {
            PictureBox zomsuperboss = new PictureBox();
            zomsuperboss.Tag = "SuperBossZombie";
            zomsuperboss.Image = Properties.Resources.fz1;
            zomsuperboss.Left = randNum.Next(0, 900);
            zomsuperboss.Top = randNum.Next(0, 800);
            zomsuperboss.SizeMode = PictureBoxSizeMode.AutoSize;
            superbosshealth = 5;
            Zombiesuperboss.Add(zomsuperboss);
            this.Controls.Add(zomsuperboss);
            nguoichoi.BringToFront();
        }
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            nguoichoi.BringToFront();
        }
        private void DropLaser()
        {
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.Laser;
            laser.SizeMode = PictureBoxSizeMode.AutoSize;
            laser.Left = randNum.Next(10, this.ClientSize.Width - laser.Width);
            laser.Top = randNum.Next(60, this.ClientSize.Height - laser.Height);
            laser.Tag = "lsammo";
            this.Controls.Add(laser);
            laser.BringToFront();
            nguoichoi.BringToFront();
        }

        private void DropDanno()
        {
            PictureBox Danno = new PictureBox();
            Danno.Image = Properties.Resources.Dan_no;
            Danno.SizeMode = PictureBoxSizeMode.AutoSize;
            Danno.Left = randNum.Next(10, this.ClientSize.Width - Danno.Width);
            Danno.Top = randNum.Next(60, this.ClientSize.Height - Danno.Height);
            Danno.Tag = "dnammo";
            this.Controls.Add(Danno);
            Danno.BringToFront();
            nguoichoi.BringToFront();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void DropItem()
        {
            int randomValue = randNum.Next(2); // Sinh số ngẫu nhiên 0 hoặc 1

            if (randomValue == 0)
            {
                DropLaser();
            }
            else
            {
                DropDanno();
            }
        }
        private void DropRandomAmmo()
        {
           
        }
            
        private void DropHeal()
        {
            PictureBox heal = new PictureBox();
            heal.Image = Properties.Resources.Timto;
            heal.SizeMode = PictureBoxSizeMode.AutoSize;
            heal.Left = randNum.Next(10, this.ClientSize.Width - heal.Width);
            heal.Top = randNum.Next(60, this.ClientSize.Height - heal.Height);
            heal.Tag = "heal";
            this.Controls.Add(heal);
            heal.BringToFront();
            nguoichoi.BringToFront();
        }
        
        private void RestarGame()
        {

              gameStarted = false;
            

            elapsedTime = 0; // Reset thời gian chơi
            

            nguoichoi.Image = Properties.Resources.up;
            nguoichoi.BackColor = Color.Transparent;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }
            foreach (PictureBox i in Zombieboss)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for (int i = 0; i < 3; i++)
            {
                MakeZombies();
            }
            Zombieboss.Clear();
            for (int i = 0; i < 1; i++)
            {

                MakeBoss();
               
               

            }
            



            Timer startTimer = new Timer();
            startTimer.Interval = 1000;
            startTimer.Tick += (s, args) =>
            {
                startTimer.Stop();
                gameStarted = true;
               
                // Bắt đầu các hoạt động trong game
                
            };

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;
            playerHealth = 100;
            score = 0;
            ammo = 10;
            laserammo = 1;
            dannoammo= 3;
            gametime.Start();
        }
        private void UpdateScore(int pointsToAdd)
        {
            score += pointsToAdd;
            txtDiem.Text = "Điểm: " + score;

            if (score % 30 == 0) // Kiểm tra xem điểm số có phải bội số của 30
            {
                IncreaseZombieSpeed(); // Tăng tốc độ zombie
            }
        }
        private void IncreaseZombieSpeed()
        {
            zombiespeed =+5; // Tăng tốc độ zombie
                           // Bạn cũng có thể thêm logic để không tăng quá một giới hạn nào đó
        }
    }
}