using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            _ticks = 0;
            platformFactory = new PlatformFactory();
            random = new Random();
            scene = new Scene();
            player1 = new Player(new Point(50, 50), Color.Violet, 100, 100);
            scene.AddToScene(player1);
            this.DoubleBuffered = true;
            Platform p = new Platform( new Point(300,300), Color.Aqua , new Size(150, 150));
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
            //player1.Draw(e.Graphics);
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            this.Text = _ticks.ToString();
            if (_ticks % random.Next(25, 35) == 0)
            {
                Enemy nextEnemy = new Enemy(new Point(Width + 25, random.Next(50, Height - 50)), Color.Red, 50, 100);
                scene.AddToScene(nextEnemy);
            }
            if (_ticks % random.Next(30, 35) == 0)
            {
                scene.AddToScene(platformFactory.Next(Width, Height));
            }
            Invalidate(true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                //if(player1.CanMove(Entity.Direction.UP))
                player1.dY -= 25;
            }
            //if (e.KeyCode == Keys.S)
            //{
            //    //if (player1.CanMove(Entity.Direction.DOWN))
            //    player1.dY += 6;
            //}
            if (e.KeyCode == Keys.A)
            {
                //if (player1.CanMove(Entity.Direction.LEFT))
                player1.dX -= 6;
            }
            if (e.KeyCode == Keys.D)
            {
                //if (player1.CanMove(Entity.Direction.RIGHT))
                player1.dX += 6;
            }
            if (e.KeyCode == Keys.R)
            {
                player1.player.Location = new Point(50, 50);
            }
        }
    }
}
