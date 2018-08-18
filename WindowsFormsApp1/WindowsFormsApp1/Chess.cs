using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Chess
    {
        public int[,] Board = new int[3, 3];//定义棋盘的二维数组
        /// <summary>
        /// 玩家下棋
        /// </summary>
        /// <param name="panels"></param>
        public void PersonPlay(Panel[,] panels)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = Convert.ToInt32(panels[i, j].Tag);
                }
            }
        }
        /// <summary>
        /// 电脑下棋
        /// </summary>
        /// <param name="panels"></param>
        /// <param name="CanGO"></param>
        public void AIPlay(Panel[,] panels,ref bool CanGO)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = Convert.ToInt32(panels[i, j].Tag);
                }
            }

            AIjudge.AIkudge aIkudge = new AIjudge.AIkudge();
            Chessman draw = new Chessman();
            draw.DrawCross(panels[aIkudge.FindNext(Board)[0], aIkudge.FindNext(Board)[1]]);
            panels[aIkudge.FindNext(Board)[0], aIkudge.FindNext(Board)[1]].Tag = "-1";
            CanGO = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = Convert.ToInt32(panels[i, j].Tag);
                }
            }
        }
    }
}
