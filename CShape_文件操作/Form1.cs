﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TXT_ClassLibrary;

namespace CShape_文件操作
{
    public partial class Form1 : Form
    {
        //创建操作对象
        //TXT_ClassLibrary.Class1 txt = new TXT_ClassLibrary.Class1();
        public Form1()
        {
            InitializeComponent();
        }
        //向TXT写入内容
        private void button1_Click(object sender, EventArgs e)
        {
            TXT_ClassLibrary.Class1.wirte_txt("D:\\myfile.txt", this.textBox1.Text);
            ////创建文件流
            //FileStream fs = new FileStream("D:\\myfile.txt", FileMode.Create);
            ////创建写入器
            //StreamWriter sw = new StreamWriter(fs);
            ////以文件流的形式写入数据
            //sw.Write(this.textBox1.Text);
            ////关闭写入器
            //sw.Close();
            ////关闭文件流
            //fs.Close();
        }

        //读取文件操作
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = TXT_ClassLibrary.Class1.Read_txt("D:\\myfile.txt");
            ////创建文件流
            //FileStream fs = new FileStream(@"D:\myfile.txt", FileMode.Open);
            ////创建操作器
            //StreamReader sr = new StreamReader(fs);
            ////文件流的方式读取数据
            //this.textBox1.Text = sr.ReadToEnd();
            ////关闭写入器
            //sr.Close();
            ////关闭文件流
            //fs.Close();
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

        //移动文件
        private void button6_Click(object sender, EventArgs e)
        {
            //目的地文件是否存在-如果存在文件会报警提示所以复制之前要看一下目的地文件是否存在
            if (File.Exists(this.textBox3.Text.Trim()))
            {
                //删除目的地文件
                File.Delete(this.textBox3.Text.Trim());
            }
            //判断要移动的文件是否存在
            if (File.Exists(this.textBox2.Text.Trim())==false)
            {
                MessageBox.Show("移动文件不存在请检查");
            }
            else
            {
                File.Move(this.textBox2.Text.Trim(), this.textBox3.Text.Trim());
            }
        }

        //指定目录下所有的文件
        private void button7_Click(object sender, EventArgs e)
        {
            //读取指定目录下所有的文件
            string[] files = Directory.GetFiles("D:\\");
            //清空txtbox文本
            this.textBox1.Clear();
            //遍历显示所有
            foreach (String item in files)
            {
                this.textBox1.Text += item + "\r\n";
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //显示所有子目录
        private void button8_Click(object sender, EventArgs e)
        {
            string[] dir = Directory.GetDirectories("D:\\");
            this.textBox1.Clear();
            foreach (string item in dir)
            {
                this.textBox1.Text += item + "\r\n";
            }   
        }

        //创建文件夹
        private void button9_Click(object sender, EventArgs e)
        {
            //
            for (int i = 0; i < 5; i++)
            {
                Directory.CreateDirectory("D:\\CShape_TEST\\"+i.ToString());
            }
            
        }

        //删除文件夹下的子目录
        private void button10_Click(object sender, EventArgs e)
        {
            //创建操作对象
            DirectoryInfo dir = new DirectoryInfo("D:\\CShape_TEST");
            //执行操作
            dir.Delete(true);
        }

        //保存界面信息配置
        private void button11_Click(object sender, EventArgs e)
        {
            string file_Path = System.AppDomain.CurrentDomain.BaseDirectory + "Save_file.ini";
            WritePrivateProfileString("Information", "源文件路径", this.textBox2.Text, file_Path);
        }

        //应用非委托动态链接库 C++
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder revaul, int size, string filepath);

        //往INI文件写入
        public static string contentValue(string section,string key,string filePath)
        {
            //创建可变字符串空间
            StringBuilder temp = new StringBuilder(1024);
            //拿到返回的值
            GetPrivateProfileString(section, key, "", temp, 1024, filePath);
            //返回ＩＮＩ的值
            return temp.ToString();
        }

        //读取配置信息
        private void button12_Click(object sender, EventArgs e)
        {
            string file_Path = System.AppDomain.CurrentDomain.BaseDirectory + "Save_file.ini";
            this.textBox2.Text = contentValue("Information", "源文件路径", file_Path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string file_Path = System.AppDomain.CurrentDomain.BaseDirectory + "Save_file.ini";
            this.textBox2.Text = contentValue("Information", "源文件路径", file_Path);
        }
    }
}
