using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class snake
    {
        public int segments;
        public int segment;
        public int[] x = new int[900];
        public int[] y = new int[900];
        public string move;
        public snake(int width ,int height)
        {

            segment = width / 40;
            segments = 6;
            move = "right";
            int xh = 19 * segment;
            int yh = 19 * segment;
            for(int i = 0; i < segments; i++)
            {
                x[i] = xh - (i * segment);
                y[i] = yh;
            }
        }
        public void fmove()
        {
            for (int i = segments; i > 0; i --)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }
            if(move == "left")
            {
                x[0] = x[0] - segment;
            }
            if (move == "right")
            {
                x[0] = x[0] + segment;
            }
            if (move == "up")
            {
                y[0] = y[0] - segment;
            }
            if (move == "down")
            {
               y[0] = y[0] + segment;
            }
            if(x[0] < 0) { x[0] = segment * 39; }
            if (x[0] > segment*39) { x[0] = 0; }
            if (y[0] < 0) { y[0] = segment * 39; }
            if (y[0] > segment * 39) { y[0] = 0; }
        }
        public void draw(Graphics g,Brush b)
        {
            g.FillRectangle(new SolidBrush(Color.LimeGreen), x[0], y[0], segment, segment);
            for (int i = 1; i < segments; i++)
            {
                g.FillRectangle(b, x[i], y[i], segment, segment);
            }
        }
        public void Add()
        {
            x[segments] = x[segments - 1];
            y[segments] = y[segments - 1];
            segments++;
        }
        public bool alive()
        {
            for ( int i =1; i < segments; i++)
            {
                if(x[0] == x[i] && y[0] == y[i])
                {
                     return false;
                }
            }
            
            return true;
        }
    }
}
