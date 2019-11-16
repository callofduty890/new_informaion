using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TXT_ClassLibrary
{
    public class Class1
    {
        public void wirte_txt(string path,string content)
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
    }
}
