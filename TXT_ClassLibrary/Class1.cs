using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TXT_ClassLibrary
{
    public static class Class1
    {
        public static void wirte_txt(string path,string content)
        {
            //创建文件流
            FileStream fs = new FileStream(path, FileMode.Create);
            //创建写入器
            StreamWriter sw = new StreamWriter(fs);
            //以文件流的形式写入数据
            sw.Write(content);
            //关闭写入器
            sw.Close();
            //关闭文件流
            fs.Close();
        }

        public static string Read_txt(string path)
        {
            //读取到的内容
            string str;
            //创建文件流
            FileStream fs = new FileStream(path, FileMode.Open);
            //创建操作器
            StreamReader sr = new StreamReader(fs);
            //文件流的方式读取数据
            str = sr.ReadToEnd();
            //关闭写入器
            sr.Close();
            //关闭文件流
            fs.Close();
            //返回内容
            return str;
        }
    }
}
