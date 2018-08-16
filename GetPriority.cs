using System;

namespace AIjudge
{
    public class AIkudge
    {
        private int[,] priority = new int[3, 3];

        /// <summary>
        /// 每个位置如何判断优先级
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="panel">棋盘状态，是需要传入的参数，为一个3X3二维数组，1为已有玩家棋子，-1为已有AI棋子，0为空位</param>
        /// <returns></returns>
        public int GetPriority(int i, int j, int[,] panel)
        {
            if (panel[i, j] != 0)
            {
                return 1;//该位置已有棋子，最低优先级
            }
            else
            {
                //横三连
                if (i == 2 && panel[i - 1, j] == -1 && panel[i - 2, j] == -1)
                    return 5;//可以获胜，最高优先级
                if (i == 0 && panel[i + 1, j] == -1 && panel[i + 2, j] == -1)
                    return 5;
                if (i == 1 && panel[i + 1, j] == -1 && panel[i - 1, j] == -1)
                    return 5;
                //竖三连
                if (j == 0 && panel[i, j + 1] == -1 && panel[i, j + 2] == -1)
                    return 5;
                if (j == 1 && panel[i, j + 1] == -1 && panel[i, j - 1] == -1)
                    return 5;
                if (j == 2 && panel[i, j - 1] == -1 && panel[i, j - 2] == -1)
                    return 5;
                //斜三连
                if (i == 0 && j == 0 && panle[i + 1, j + 1] == -1 && panel[i + 2, j + 2] == -1)
                    return 5;
                if (i == 1 && j == 1 && panle[i + 1, j + 1] == -1 && panel[i - 1, j - 1] == -1)
                    return 5;
                if (i == 2 && j == 2 && panle[i - 1, j - 1] == -1 && panel[i - 2, j - 2] == -1)
                    return 5;
                if (i == 0 && j == 2 && panle[i + 1, j - 1] == -1 && panel[i + 2, j - 2] == -1)
                    return 5;
                if (i == 1 && j == 1 && panle[i - 1, j + 1] == -1 && panel[i + 1, j - 1] == -1)
                    return 5;
                if (i == 2 && j == 0 && panle[i - 1, j + 1] == -1 && panel[i - 2, j + 2] == -1)
                    return 5;
                //对手二连
                if (i == 2 && panel[i - 1, j] == 1 && panel[i - 2, j] == 1)
                    return 4;//阻止对手获胜，第二优先级
                if (i == 0 && panel[i + 1, j] == 1 && panel[i + 2, j] == 1)
                    return 4;
                if (i == 1 && panel[i + 1, j] == 1 && panel[i - 1, j] == 1)
                    return 4;
                if (j == 0 && panel[i, j + 1] == 1 && panel[i, j + 2] == 1)
                    return 4;
                if (j == 1 && panel[i, j + 1] == 1 && panel[i, j - 1] == 1)
                    return 4;
                if (j == 2 && panel[i, j - 1] == 1 && panel[i, j - 2] == 1)
                    return 4;
                if (i == 0 && j == 0 && panle[i + 1, j + 1] == 1 && panel[i + 2, j + 2] == 1)
                    return 4;
                if (i == 1 && j == 1 && panle[i + 1, j + 1] == 1 && panel[i - 1, j - 1] == 1)
                    return 4;
                if (i == 2 && j == 2 && panle[i - 1, j - 1] == 1 && panel[i - 2, j - 2] == 1)
                    return 4;
                if (i == 0 && j == 2 && panle[i + 1, j - 1] == 1 && panel[i + 2, j - 2] == 1)
                    return 4;
                if (i == 1 && j == 1 && panle[i - 1, j + 1] == 1 && panel[i + 1, j - 1] == 1)
                    return 4;
                if (i == 2 && j == 0 && panle[i - 1, j + 1] == 1 && panel[i - 2, j + 2] == 1)
                    return 4;
                if (i == 1 && j == 1)
                    return 3;//占中，第三优先级
                else
                    return 2;//其他位置，第四优先级
            }
        }

        //为每个位置设置下棋优先级
        public int[,] SetPriority(int[,] priority, int[,] panel)
        {
            priority = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    priority[i, j] = GetPriority(i, j, panel);
        }

        //找到最高优先级位置
        public int[] FindNext(int[,] priority)
        {
            int[] position = new int[2] { 0, 0 };
            int MaxPriority = 0;
            for (int i = 1; i < 9; i++)
            {
                if (priority[i % 3, i / 3] >= priority[(i - 1) % 3, (i - 1) / 3])
                {
                    MaxPriority = priority[i % 3, i / 3];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (priority[i,j]==MaxPriority)
                        position =new int[]{ i,j};
                }
            }
            return position;
        }

    }
}
