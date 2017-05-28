using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeGamer
{
    public partial class Form1 : Form
    {
        private Scene scene;
        private Random random;
        public Player player1;
        private PlatformFactory platformFactory;
        private int _ticks;
        private StartingScreen mainForm = null;
        public Form1()
        {
            
        }
        /// <summary>
        /// Overloaded constructor for form control
        /// </summary>
        /// <param name="callingForm"></param>
        public Form1(Form callingForm)
        {
            mainForm = callingForm as StartingScreen;
            InitializeComponent();
            _ticks = 0;
            platformFactory = new PlatformFactory();
            random = new Random();
            scene = new Scene();
            player1 = new Player(new Point(100, 10), Color.Violet, 100, 100);
            scene.AddToScene(player1);
            this.DoubleBuffered = true;
            Platform p = new Platform(new Point(100, 750), Color.Aqua, new Size(1000, 150));
            scene.AddToScene(p);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            scene.CheckCollision();
            scene.Draw(e.Graphics);
            scene.Destroy();
            player1.CheckOutOfScreen(Height, Width);
            if (!player1.IsAlive)
            {
                mainForm.Show();
                mainForm.ScoreText = "Score:" + _ticks;
                this.Close();
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (player1.IsAlive)
            {
                lb_Entities.Text = "Score: " + _ticks;
                LifeBar.Value = player1.Health;
                _ticks++;
                this.Text = _ticks.ToString();
                if (_ticks % random.Next(25, 35) == 0)
                {
                    Enemy nextEnemy = new Enemy(new Point(Width + 25, random.Next(50, Height - 50)), Color.Red, 50, 50);
                    scene.AddToScene(nextEnemy);
                }
                if (_ticks % random.Next(30, 40) == 0)
                {
                    scene.AddToScene(platformFactory.Next(Width, Height));
                }
                Invalidate(true);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (player1.CanJump)
                {
                    player1.dY -= 25;
                    player1.CanJump = false;
                }
            }
            if (e.KeyCode == Keys.A)
            {
                player1.MoveLeft();
            }
            if (e.KeyCode == Keys.D)
            {
                player1.MoveRight();
            }
            if (e.KeyCode == Keys.R)
            {
                player1.dX = 0;
                player1.dY = 0;
                player1.player.Location = new Point(50, 50);
                player1.CanJump = false;
            }
        }

    }
}
