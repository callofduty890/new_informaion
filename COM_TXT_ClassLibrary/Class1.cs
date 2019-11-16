using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//DLL 引用
using System.Runtime.InteropServices;
using System.IO;

namespace COM_TXT_ClassLibrary
{
    //1.接口
    [ComVisible(true)]
    [Guid("C19AEC1D-8324-442B-AB42-4E7BB276FC67")]
    public interface IMyClass
    {
        //使用到的函数
        //往txt写入
        void wirte_txt(string path, string content);
        //从txt读取
        string Read_txt(string path);
    }

    //2.实现接口
    [ComVisible(true)]
    [Guid("F821F9E9-EE2D-4A6B-B912-68D829E3AFFD")]
    [ProgId("COM_TXT_ClassLibrary.Class1")]
    public class Class1: IMyClass
    {
        public void wirte_txt(string path, string content)
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

        public string Read_txt(string path)
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
