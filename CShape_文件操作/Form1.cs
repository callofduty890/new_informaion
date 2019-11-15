using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CShape_文件操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //向TXT写入内容
        private void button1_Click(object sender, EventArgs e)
        {
            //创建文件流
            FileStream fs = new FileStream("D:\\myfile.txt", FileMode.Create);
            //创建写入器
            StreamWriter sw = new StreamWriter(fs);
            //以文件流的形式写入数据
            sw.Write(this.textBox1.Text);
            //关闭写入器
            sw.Close();
            //关闭文件流
            fs.Close();
        }

        //读取文件操作
        private void button2_Click(object sender, EventArgs e)
        {
            //创建文件流
            FileStream fs = new FileStream(@"D:\myfile.txt", FileMode.Open);
            //创建操作器
            StreamReader sr = new StreamReader(fs);
            //文件流的方式读取数据
            this.textBox1.Text = sr.ReadToEnd();
            //关闭写入器
            sr.Close();
            //关闭文件流
            fs.Close();
        }

        //模拟写入日志-用来检查程序是否正常运行排BUG
        private void button3_Click(object sender, EventArgs e)
        {
            //创建文件流
            FileStream fs = new FileStream("D:\\myfile.txt", FileMode.Append);
            //创建写入器
            StreamWriter sw = new StreamWriter(fs);
            //以文件流的形式写入数据
            sw.WriteLine(DateTime.Now.ToString() + " [日志写入] 正常");
            //关闭写入器
            sw.Close();
            //关闭文件流
            fs.Close();
        }

        //删除文件
        private void button4_Click(object sender, EventArgs e)
        {
            //源文件路径
            File.Delete(this.textBox2.Text.Trim());
        }

        //复制文件
        private void button5_Click(object sender, EventArgs e)
        {
            //目的地文件是否存在-如果存在文件会报警提示所以复制之前要看一下目的地文件是否存在
            if (File.Exists(this.textBox3.Text.Trim()))
            {
                //删除目的地文件
                File.Delete(this.textBox3.Text.Trim());
            }
            //移动文件夹
            File.Copy(this.textBox2.Text.Trim(), this.textBox3.Text.Trim());
        }
    }
}
