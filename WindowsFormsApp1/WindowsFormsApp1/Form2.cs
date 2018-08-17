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
    public partial class Form2 : Form
    {
        bool CanGO;//判定是否该玩家走
        bool ISOver = false;//判定游戏是否结束
        Draw draw = new Draw();
        GameEnd GameEnd = new GameEnd();

        public Form2(bool cango)
        {
            InitializeComponent();
            CanGO = cango;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            NewMethod(panel3);
        }


        private void panel1_Click(object sender, EventArgs e)
        {
            NewMethod(panel1);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            NewMethod(panel2);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            NewMethod(panel4);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            NewMethod(panel5);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            NewMethod(panel6);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            NewMethod(panel7);
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            NewMethod(panel8);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            NewMethod(panel9);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void 重新开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //判定是否该电脑操作以及操作过程
            if (CanGO == false && ISOver == false)
            {
                System.Threading.Thread.Sleep(500);

                Panel[,] CheckerBoard = new Panel[,] { { panel1, panel2, panel3 }, { panel4, panel5, panel6 }, { panel7, panel8, panel9 } };
                int[,] Tag = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Tag[i, j] = Convert.ToInt32(CheckerBoard[i, j].Tag);
                    }
                }
                AIjudge.AIkudge aIkudge = new AIjudge.AIkudge();
               
                Draw draw = new Draw();
                draw.DrawCross(CheckerBoard[aIkudge.FindNext(Tag)[0], aIkudge.FindNext(Tag)[1]]);
                CheckerBoard[aIkudge.FindNext(Tag)[0], aIkudge.FindNext(Tag)[1]].Tag = "-1";
                CanGO = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Tag[i, j] = Convert.ToInt32(CheckerBoard[i, j].Tag);
                    }
                }
                GameEnd gameEnd = new GameEnd();
                GameEnd.GG(Tag, this, ref ISOver);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void NewMethod(Panel panel)
        {
            if (CanGO == true && Convert.ToString(panel.Tag) == "0" && ISOver == false)
            {
                draw.DrawCircle(panel);
                panel.Tag = "1";

                Panel[,] CheckerBoard = new Panel[,] { { panel1, panel2, panel3 }, { panel4, panel5, panel6 }, { panel7, panel8, panel9 } };
                int[,] Tag = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Tag[i, j] = Convert.ToInt32(CheckerBoard[i, j].Tag);
                    }
                }
                GameEnd.GG(Tag, this, ref ISOver);
                CanGO = false;
            }
        }
    }
}
