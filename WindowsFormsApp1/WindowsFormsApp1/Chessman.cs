using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Chessman
    {
        /// <summary>
        /// 画圆圈
        /// </summary>
        /// <param name="panel"></param>
        public void DrawCircle(Panel panel)
        {
            Pen P = new Pen(Color.Ivory, 6);
            Graphics g = panel.CreateGraphics();
            g.DrawEllipse(P, 10, 10, 55, 55);
        }

        /// <summary>
        /// 画叉
        /// </summary>
        /// <param name="panel"></param>
        public void DrawCross(Panel panel)
        {
            Pen P = new Pen(Color.Black, 6);
            Graphics g = panel.CreateGraphics();
            g.DrawLine(P, 10, 10, 65, 65);
            g.DrawLine(P, 10, 65, 65, 10);
        }
    }
}
