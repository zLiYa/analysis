using System;

namespace AnalysisTools
{
    //协议信息
	public class state_0X12
    {

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 哈哈哈
        /// </summary>
        public string Hhh { get; set; }

    }

    //计算长度
    public class Information
    {
        /// <summary>
        /// Body长度
        /// </summary>
        public int BodyLength { get; set; } = 756;

        /// <summary>
        /// 库长
        /// </summary>
        public int KuLength { get; set; } = 189;

        /// <summary>
        /// 下标字符串集合
        /// </summary>
        public string[] Index { get; set; } = { "1,2,3","11,22,3" };
    }

    //选择协议字典
    public class ExplainDictionary
    {
        public Dictionary<int, string> dictionary0 = new Dictionary<int, string>();
        public Dictionary<int, string> dictionary1 = new Dictionary<int, string>();
        public ExplainDictionary()
        {
            dictionary0.Add(1, "RTX版本");
            dictionary0.Add(2, "Linux版本");

            dictionary1.Add(2, "Linux版本");
        }

    }
}
