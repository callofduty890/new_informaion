using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//DLL 引用
using System.Runtime.InteropServices;

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

    public class Class1
    {

    }
}
