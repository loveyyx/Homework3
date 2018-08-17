using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Save
    {
        /// <summary>
        /// 存储游戏记录
        /// </summary>
        /// <param name="result"></param>
        public void SaveResult(int result)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strY = currentTime.ToString("f");
            FileStream fs = new FileStream(@"..\history.txt", FileMode.Append, FileAccess.Write);
            
            StreamWriter sw = new StreamWriter(fs);
            switch (result)
            {
                case (0):
                    sw.WriteLine(strY + "    您赢了");
                    break;
                case (1):
                    sw.WriteLine(strY + "    您输了");
                    break;
                case (2):
                    sw.WriteLine(strY + "    平局");
                    break;

            }

            sw.Close();
        }

        /// <summary>
        /// 查看游戏记录
        /// </summary>
        /// <returns>返回字符串</returns>
        public string history()
        {
            FileStream ks = new FileStream(@"..\history.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(ks);
            string history = sr.ReadToEnd();
            sr.Close();
            return history;
        }

    }
}
