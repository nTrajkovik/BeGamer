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
    public partial class StartingScreen : Form
    {
        private Form1 game;
        public StartingScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game = new Form1(this);
            game.Show();
        }
        public string ScoreText
        {
            get { return lb_Score.Text; }
            set { lb_Score.Text = value; }
        }
    }
}
