using AnalysisTools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Documents;

namespace AnalysisTools
{
    public partial class GenerateViewModel : ObservableObject
    {

        [ObservableProperty]
        private string? _agreementName;

        [ObservableProperty]
        private string? _bodyLengthChanged;

        [ObservableProperty]
        private string? _kuLengthChanged;
        
        [ObservableProperty]
        private string? _dataTypeChanged;

        //表格数据源
        [ObservableProperty]
        private ObservableCollection<BgInfo> tableRows = new ObservableCollection<BgInfo>(); 

        [RelayCommand]
        //提交生成.cs文件
        public void SubmitSC()
        {
            var className = AgreementName; // 类名
            StringBuilder codeBuilder = new StringBuilder();

            //这里获取协议名称类里有多少属性，是为了给实体类中的Information和ExplainDictionary0区分开
            //实例化对象
            ChoosePrName choosePrName = new ChoosePrName();
            //获取类型
            Type targetType = choosePrName.GetType();
            //Type targetType = typeof(ChoosePrName);
            //获取类的所有公共实例属性（包括非私有属性）
            PropertyInfo[] propertyInfos = targetType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            // 计算属性总数
            int totalProperties = propertyInfos.Length;

            codeBuilder.AppendLine("using System;");
            codeBuilder.AppendLine();
            codeBuilder.AppendLine("namespace AnalysisTools");
            codeBuilder.AppendLine("{");
            codeBuilder.AppendLine("\t//协议信息");
            codeBuilder.AppendLine("\t" + $"public class {AgreementName}");
            codeBuilder.AppendLine("\t" + "{");
            foreach (var row in tableRows)
            {
                codeBuilder.AppendLine($"\t\t/// <summary>");
                codeBuilder.AppendLine($"\t\t/// {row.Field1}");
                codeBuilder.AppendLine($"\t\t/// </summary>");

                string propertyName = Sanitize(row.Field2); // 将属性名进行清理和转义处理
                codeBuilder.AppendLine($"\t\tpublic {DataTypeChanged} {propertyName} {{ get; set; }}");
                codeBuilder.AppendLine();
            }
            codeBuilder.AppendLine("\t" + "}");
            codeBuilder.AppendLine();

            codeBuilder.AppendLine("\t//计算长度");
            codeBuilder.AppendLine("\t" + $"public class Information{propertyInfos.Length}");
            codeBuilder.AppendLine("\t" + "{");
            codeBuilder.AppendLine($"\t\t/// <summary>");
            codeBuilder.AppendLine($"\t\t/// Body长度");
            codeBuilder.AppendLine($"\t\t/// </summary>");
            codeBuilder.AppendLine($"\t\tpublic int BodyLength {{ get; set; }} = {BodyLengthChanged};");
            codeBuilder.AppendLine();
            codeBuilder.AppendLine($"\t\t/// <summary>");
            codeBuilder.AppendLine($"\t\t/// 库长");
            codeBuilder.AppendLine($"\t\t/// </summary>");
            codeBuilder.AppendLine($"\t\tpublic int KuLength {{ get; set; }} = {KuLengthChanged};");
            codeBuilder.AppendLine();
            codeBuilder.AppendLine($"\t\t/// <summary>");
            codeBuilder.AppendLine($"\t\t/// 下标数组");
            codeBuilder.AppendLine($"\t\t/// </summary>");
            //使用二维数组存
            List<string> dataList = new List<string>();
            foreach (var row in tableRows) dataList.Add(row.Field4);
            // 将List<string>转换为string[]
            string[] stringArray = dataList.ToArray();
            //将数组元素用双引号和逗号连接起来,变为字符串数组初始化文本
            string arrayAsText = $"{{ \"{string.Join("\", \"", stringArray)}\" }}";
            codeBuilder.AppendLine($"\t\tpublic string[] Index {{ get; set; }} = {arrayAsText};");
            codeBuilder.AppendLine();
            codeBuilder.AppendLine("\t" + "}");
            codeBuilder.AppendLine();

            codeBuilder.AppendLine("\t//数据解释");
            codeBuilder.AppendLine("\t" + $"public class ExplainDictionary");
            codeBuilder.AppendLine("\t" + "{");
            int rowCount = tableRows.Count;
            foreach (var row in tableRows)
            {
                codeBuilder.AppendLine($"\t\tpublic Dictionary<int, string> dictionary{tableRows.IndexOf(row)} = new Dictionary<int, string>();");
            }
            codeBuilder.AppendLine("\t\tpublic ExplainDictionary(){");
            foreach(var row in tableRows)
            {
                codeBuilder.AppendLine($"\t\t\t{tableRows.IndexOf(row)}.Add({1}, {1});");
            }
            //dictionary0.Add(1, "RTX版本");
            codeBuilder.AppendLine("\t\t}");

            codeBuilder.AppendLine("\t" + "}");
            codeBuilder.AppendLine();

            codeBuilder.AppendLine("}");

            string classContent = codeBuilder.ToString();

            WriteToFile(classContent, $"{className}.cs");
        }

        private static void WriteToFile(string content, string fileName)
        {
            string saveDirectory = @"E:\Work\项目源代码\解析工具\改\analysis - 副本\AnalysisTools\Data\"; // 指定你希望保存文件的目录
            string fullPath = Path.Combine(saveDirectory, fileName);
            try
            {
                //指定目录保存
                File.WriteAllText(fullPath, content, Encoding.UTF8);
                // 可在此处添加成功提示
            }
            catch (IOException ex)
            {
                // 处理文件写入异常
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }
        // 清理函数，确保属性名合法
        private string Sanitize(string input)
        {
            // 实现清理逻辑，比如移除非法字符、首字母大写等
            return char.IsLetter(input[0]) ? Char.ToUpperInvariant(input[0]) + input.Substring(1) : "_"; 
        }

        //表格数据
        public class BgInfo : ObservableObject
        {
            public string? Field1 { get; set; }
            public string? Field2 { get; set; }
            public string? Field3 { get; set; }
            public string? Field4 { get; set; }
        }
    }
}
