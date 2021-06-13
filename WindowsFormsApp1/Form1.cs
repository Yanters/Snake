using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Snake : Form
    {
        
        private bool is_game_on;
        private snake snake;
        private food food;
        public int pointsy;
        public bool start=true;
        public Snake()
        {
            
            InitializeComponent();
            is_game_on = false;
            timer1.Enabled = true;
            pauseToolStripMenuItem.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_game_on)
            {
                
                Points.Text = pointsy.ToString();
                game_area.CreateGraphics().Clear(Color.Black);
                snake.fmove();
                snake.draw(game_area.CreateGraphics(), new SolidBrush(Color.Aqua));
                food.draw_food(game_area.CreateGraphics(), new SolidBrush(Color.Red));
                if (food.generateFood(snake.x[0], snake.y[0]))
                {
                    snake.Add();
                    pointsy++;
                }
                if (snake.alive() == false)
                {
                    pauseToolStripMenuItem.Enabled = false;
                    is_game_on = false;
                    startToolStripMenuItem.Enabled = true;
                    FontFamily fontFamily1 = new FontFamily("Arial");
                    Font f = new Font(fontFamily1, 21);
                    Brush b = new SolidBrush(Color.Red);
                    game_area.CreateGraphics().DrawString("YOU LOST \n       :c", f, b, 200, 220);
                    start = false;
                    pointsy = 0;
                }
                else { pauseToolStripMenuItem.Enabled = true;
                    ;
                }

            }
            if(start)
            {

                FontFamily fontFamily1 = new FontFamily("Arial");
                Font f = new Font(fontFamily1, 21);
                Brush b = new SolidBrush(Color.Red);
                game_area.CreateGraphics().DrawString("Press the START button \n     to start the game", f, b, 130, 220);
                start = false;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_game_on = true;
            snake = new snake(game_area.Width, game_area.Height);
            food = new food(snake.segment);
            pauseToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W) snake.move = "up";
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S) snake.move = "down";
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A) snake.move = "left";
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D) snake.move = "right";
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (is_game_on)
            {
                startToolStripMenuItem.Enabled = false;
                restartToolStripMenuItem.Enabled = false;
                is_game_on = false;
                pauseToolStripMenuItem.Text = "Unpause";
                game_area.CreateGraphics().Clear(Color.Black);
                FontFamily fontFamily1 = new FontFamily("Arial");
                Font f = new Font(fontFamily1, 21);
                Brush b = new SolidBrush(Color.Red);
                game_area.CreateGraphics().DrawString("Press the UNPAUSE button \n     to start the game", f, b, 120, 220);
            }
            else
            {
                startToolStripMenuItem.Enabled = true;
                is_game_on = true;
                pauseToolStripMenuItem.Text = "Pause";
                restartToolStripMenuItem.Enabled = true;
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_game_on = false;
                snake = new snake(game_area.Width, game_area.Height);
                food = new food(snake.segment);
            is_game_on = true;
            pointsy = 0;


        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 200;
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 70;
        }
        private void Points_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}
