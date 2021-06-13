using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class food
    {
        public int x;
        public int y;
        public int segment;
        public void New_food()
        {
            Random r = new Random();
            x = r.Next(0, 40) * segment;
            y = r.Next(0, 40) * segment;
        }
        public food(int segment)
        {
            this.segment = segment;
            New_food();
        }
        public bool generateFood(int head_x, int head_y)
        {
            if( x == head_x && y == head_y)
            {
                New_food();
                return true;
            }
            return false;
        }
        public void draw_food(Graphics g, Brush b)
        {
            g.FillEllipse(b, x, y, segment, segment);
        }
    }
    
}

