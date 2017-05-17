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
        private Player player1;
        private int _ticks;
        public Form1()
        {
            InitializeComponent();
            _ticks = 0;
            random = new Random();
            scene = new Scene();
            player1 = new Player(new Point(50, 50), Color.Violet, 100, 100);
            //scene.AddToScene(player1);
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            scene.Draw(e.Graphics);
            player1.Draw(e.Graphics);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            this.Text = _ticks.ToString();
            Enemy next = new Enemy(new Point(Width + 25, random.Next(50, Height - 50)), Color.Red, 50, 100);
            if (_ticks % random.Next(25, 35) == 0)
            {
                scene.AddToScene(next);
            }
            Invalidate(true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                player1.dY -= 5;
            }
            if (e.KeyCode == Keys.S)
            {
                player1.dY += 5;
            }
            if (e.KeyCode == Keys.A)
            {
                player1.dY -= 5;
            }
            if (e.KeyCode == Keys.D)
            {
                player1.dY += 5;
            }
        }
    }
}
