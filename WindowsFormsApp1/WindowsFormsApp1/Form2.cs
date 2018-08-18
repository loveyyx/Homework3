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
        Chessman draw = new Chessman();
        Result GameEnd = new Result();
        Chess Chess = new Chess();
        public Form2(bool cango)
        {
            InitializeComponent();
            CanGO = cango;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            PlayChess(panel1);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            PlayChess(panel2);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            PlayChess(panel3);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            PlayChess(panel4);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            PlayChess(panel5);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            PlayChess(panel6);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            PlayChess(panel7);
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            PlayChess(panel8);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            PlayChess(panel9);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();//关闭游戏界面后回到登录界面
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
                timer1.Enabled = false;
                System.Threading.Thread.Sleep(500);//延时半秒
                Panel[,] panels= new Panel[,] { { panel1, panel2, panel3 }, { panel4, panel5, panel6 }, { panel7, panel8, panel9 } };
                Chess.AIPlay(panels, ref CanGO);
                GameEnd.GG(Chess.Board, this, ref ISOver);
                timer1.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 玩家点击棋盘后的操作过程
        /// </summary>
        /// <param name="panel"></param>
        private void PlayChess(Panel panel)
        {
            if (CanGO == true && Convert.ToString(panel.Tag) == "0" && ISOver == false)
            {
                draw.DrawCircle(panel);
                panel.Tag = "1";              
                Panel[,] panels = new Panel[,] { { panel1, panel2, panel3 }, { panel4, panel5, panel6 }, { panel7, panel8, panel9 } };
                Chess.PersonPlay(panels);
                GameEnd.GG(Chess.Board, this, ref ISOver);
                CanGO = false;
            }
        }
    }
}
