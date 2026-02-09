using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Car_Racing
{
    public partial class Form1 : Form
    {
        int collectedcoin = 0;
        int gameSpeed = 2;
        int moveSpeed = 7;
        Random r = new Random();
        int x;
        bool isGameOver = false;

        Player player;
        List<Enemy> enemies;
        List<Coin> coins;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            btnRefresh.Enabled = false;

            player = new Player(car);

            enemies = new List<Enemy>()
            {
                new Enemy(enemy1),
                new Enemy(enemy2),
                new Enemy(enemy3)
            };

            coins = new List<Coin>()
            {
                new Coin(coin1),
                new Coin(coin2),
                new Coin(coin3),
                new Coin(coin4)
            };
        }

        // ================= FORM LOAD =================
        private void Form1_Load(object sender, EventArgs e)
        {
            over.Visible = false;
            isGameOver = false;
        }

        // ================= GAME LOOP =================
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            MoveEnemies();
            MoveCoins();
            CheckGameOver();
        }

        // ================= GAME OVER =================
        void CheckGameOver()
        {
            foreach (Enemy e in enemies)
            {
                if (e.IsColliding(car))
                {
                    isGameOver = true;
                    timer1.Enabled = false;
                    over.Visible = true;
                    btnRefresh.Enabled = true;
                    SaveScore();
                    break;
                }
            }
        }


        // ================= ENEMY LOGIC =================
        void MoveEnemies()
        {
            foreach (Enemy e in enemies)
            {
                if (e.Sprite.Top >= 500)
                {
                    x = r.Next(0, 400);
                    e.Sprite.Location = new Point(x, 0);
                }
                else
                {
                    e.Move(gameSpeed);
                }
            }
        }

        // ================= COIN LOGIC =================
        void MoveCoins()
        {
            foreach (Coin c in coins)
            {
                if (c.IsColliding(car))
                {
                    collectedcoin++;
                    label1.Text = "Coins=" + collectedcoin;
                    x = r.Next(0, 400);
                    c.Sprite.Location = new Point(x, 0);
                }

                if (c.Sprite.Top >= 500)
                {
                    x = r.Next(0, 400);
                    c.Sprite.Location = new Point(x, 0);
                }
                else
                {
                    c.Move(gameSpeed);
                }
            }
        }

        // ================= CONTROLS =================
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver) return;

            if (e.KeyCode == Keys.Left)
                player.MoveLeft(moveSpeed);

            if (e.KeyCode == Keys.Right)
                player.MoveRight(moveSpeed);

            if (e.KeyCode == Keys.Up && gameSpeed < 21)
                gameSpeed++;

            if (e.KeyCode == Keys.Down && gameSpeed > 0)
                gameSpeed--;
        }

        // ================= DATA HANDLING =================
        void SaveScore()
        {
            try
            {
                File.WriteAllText("score.txt", collectedcoin.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message);
            }
        }

        void RestartGame()
        {
            timer1.Stop();

            // Reuse load logic
            Form1_Load(this, EventArgs.Empty);

            // Reset game values
            collectedcoin = 0;
            gameSpeed = 2;
            label1.Text = "Coins=0";
            btnRefresh.Enabled = false;

            // Reset car position
            car.Left = 150;
            car.Top = 350;

            // Reset enemies & coins
            Random r = new Random();

            enemy1.Location = new Point(r.Next(0, 400), 0);
            enemy2.Location = new Point(r.Next(0, 400), 0);
            enemy3.Location = new Point(r.Next(0, 400), 0);

            coin1.Location = new Point(r.Next(0, 400), 0);
            coin2.Location = new Point(r.Next(0, 400), 0);
            coin3.Location = new Point(r.Next(0, 400), 0);
            coin4.Location = new Point(r.Next(0, 400), 0);

            timer1.Start();
            this.Focus();
        }




        // ===== EMPTY DESIGNER EVENTS (DO NOT DELETE) =====
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click_1(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void enemy1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartGame();
            this.Focus();
        }

    }

    // ================= INTERFACES =================
    interface IMovable
    {
        void Move(int speed);
    }

    interface ICollidable
    {
        bool IsColliding(Control other);
    }

    // ================= ABSTRACT CLASS =================
    abstract class GameObject : IMovable, ICollidable
    {
        public PictureBox Sprite;

        protected GameObject(PictureBox sprite)
        {
            Sprite = sprite;
        }

        public abstract void Move(int speed);

        public bool IsColliding(Control other)
        {
            return Sprite.Bounds.IntersectsWith(other.Bounds);
        }
    }

    // ================= PLAYER =================
    class Player : GameObject
    {
        public Player(PictureBox sprite) : base(sprite) { }
        public override void Move(int speed) { }

        public void MoveLeft(int speed)
        {
            if (Sprite.Left > 2)
                Sprite.Left -= speed;
        }

        public void MoveRight(int speed)
        {
            if (Sprite.Right < 400)
                Sprite.Left += speed;
        }
    }

    // ================= ENEMY =================
    class Enemy : GameObject
    {
        public Enemy(PictureBox sprite) : base(sprite) { }

        public override void Move(int speed)
        {
            Sprite.Top += speed;
        }
    }

    // ================= COIN =================
    class Coin : GameObject
    {
        public Coin(PictureBox sprite) : base(sprite) { }

        public override void Move(int speed)
        {
            Sprite.Top += speed;
        }
    }
}