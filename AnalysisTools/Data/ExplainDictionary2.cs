using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisTools
{
    //协议对应解释
    public class ExplainDictionary2
    {
        //定义字典
        public Dictionary<int, string> dictionary0 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary1 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary3 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary4 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary5 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary6 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary7 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary8 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary9 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary10 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary11 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary12 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary13 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary14 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary15 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary16 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary17 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary18 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary19 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary20 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary21 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary22 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary23 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary24 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary25 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary26 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary27 = new Dictionary<int, string>();
        // 构造函数，初始化字典
        public ExplainDictionary2()
        {
            dictionary3.Add(0, "0");
            dictionary3.Add(1, "搁置");
            dictionary3.Add(2, "恒流充电");
            dictionary3.Add(3, "恒压充电");
            dictionary3.Add(4, "恒流恒压充电");
            dictionary3.Add(5, "直流内阻");
            dictionary3.Add(6, "恒流放电");
            dictionary3.Add(7, "恒压放电");
            dictionary3.Add(8, "恒流恒压放电");
            dictionary3.Add(9, "恒阻放电");
            dictionary3.Add(11, "工步结束");
            dictionary3.Add(12, "工步跳转");

            dictionary6.Add(1, "断线");
            dictionary6.Add(2, "异常结束");
            dictionary6.Add(3, "手动结束");
            dictionary6.Add(4, "自动结束");
            dictionary6.Add(5, "待机");
            dictionary6.Add(6, "等待");
            dictionary6.Add(7, "锁定");
            dictionary6.Add(16, "告警");
            dictionary6.Add(17, "暂停");
            dictionary6.Add(18, "负压暂停");
            dictionary6.Add(19, "执行工步");

            dictionary18.Add(0, "0");
            dictionary18.Add(1, "断线存储");
            dictionary18.Add(2, "非断线存储");
        }

        // 定义一个方法，接受整数参数，返回对应的字符串
        //public string GetValueByInteger(int key)
        //{
        //    if (dictionary0.TryGetValue(key, out string value))
        //    {
        //        return value;
        //    }
        //    else
        //    {
        //        return "当前值不存在"; // 当键不存在时返回一个默认提示信息
        //    }
        //}
    }
}
