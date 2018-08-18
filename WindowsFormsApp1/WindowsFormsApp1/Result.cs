using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Result
    {
        /// <summary>
        /// 判定游戏是否结束以及输赢
        /// </summary>
        /// <param name="x"></param>
        /// <param name="fr"></param>
        /// <param name="isover"></param>
        public void GG(int[,] x,Form fr,ref bool isover)
        {
            if (x[0, 0] + x[0, 1] + x[0, 2] == 3 || x[1, 0] + x[1, 1] + x[1, 2] == 3 || x[2, 0] + x[2, 1] + x[2, 2] == 3 || x[0, 0] + x[1, 0] + x[2, 0] == 3 || x[0, 1] + x[1, 1] + x[2, 1] == 3 || x[0, 2] + x[1, 2] + x[2, 2] == 3 || x[0, 0] + x[1, 1] + x[2, 2] == 3 || x[0, 2] + x[1, 1] + x[2, 0] == 3)
            {
                Record save = new Record();
                MessageBox.Show("恭喜你，获得胜利");
                save.SaveResult(0);
                isover = true;
                fr.Close();
            }
            else if (x[0, 0] + x[0, 1] + x[0, 2] == -3 || x[1, 0] + x[1, 1] + x[1, 2] == -3 || x[2, 0] + x[2, 1] + x[2, 2] == -3 || x[0, 0] + x[1, 0] + x[2, 0] == -3 || x[0, 1] + x[1, 1] + x[2, 1] == -3 || x[0, 2] + x[1, 2] + x[2, 2] == -3 || x[0, 0] + x[1, 1] + x[2, 2] == -3 || x[0, 2] + x[1, 1] + x[2, 0] == -3)
            {
                Record save = new Record();
                MessageBox.Show("很遗憾，你失败了");
                save.SaveResult(1);
                isover = true;
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
                    Record save = new Record();
                    MessageBox.Show("平局");
                    save.SaveResult(2);
                    isover = true;
                    fr.Close();
                }
            }
        }
    }
}
