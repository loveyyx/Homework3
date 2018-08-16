using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GameEnd
    {
        //判定游戏是否结束以及输赢
        public void GG(int[,] x,Form fr)
        {
            if (x[0, 0] + x[0, 1] + x[0, 2] == 3 || x[1, 0] + x[1, 1] + x[1, 2] == 3 || x[2, 0] + x[2, 1] + x[2, 2] == 3 || x[0, 0] + x[1, 0] + x[2, 0] == 3 || x[0, 1] + x[1, 1] + x[2, 1] == 3 || x[0, 2] + x[1, 2] + x[2, 2] == 3 || x[0, 0] + x[1, 1] + x[2, 2] == 3 || x[0, 2] + x[1, 1] + x[2, 0] == 3)
            {
                Save save = new Save();
                MessageBox.Show("恭喜你，获得胜利");
                save.SaveResult(0);
                fr.Close();
            }
            else if (x[0, 0] + x[0, 1] + x[0, 2] == -3 || x[1, 0] + x[1, 1] + x[1, 2] == -3 || x[2, 0] + x[2, 1] + x[2, 2] == -3 || x[0, 0] + x[1, 0] + x[2, 0] == -3 || x[0, 1] + x[1, 1] + x[2, 1] == -3 || x[0, 2] + x[1, 2] + x[2, 2] == -3 || x[0, 0] + x[1, 1] + x[2, 2] == -3 || x[0, 2] + x[1, 1] + x[2, 0] == -3)
            {
                Save save = new Save();
                MessageBox.Show("很遗憾，你失败了");
                save.SaveResult(1);
                fr.Close();
            }
            else
            {
                int flag = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (x[i, j] == 0) flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Save save = new Save();
                    MessageBox.Show("平局");
                    save.SaveResult(2);
                    fr.Close();
                }
            }
        }
    }
}
