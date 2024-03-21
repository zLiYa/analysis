using AnalysisTools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;


namespace AnalysisTools
{

    public partial class ParseViewModel : ObservableObject
    {

        [ObservableProperty]
        private string? _contentChanged="请输入\n\n\n";

        [ObservableProperty]
        private string? _parseTheDataChanged = "暂无数据";

        [ObservableProperty]
        private string? _selectedOption;


        //提交
        [RelayCommand]
        private void Submit()
        {
            // 判断选择了哪个选项
            switch (_selectedOption)
            {
                case "state_0X12":
                      state0X12();
                    break;
                case "state_0X11":
                    state0X11();
                    break;
            }

        }

        //0X12
        private void state0X12()
        {
            //readonly int _Kulength = 189;//库长度，不可改变
            int _Kulength = 189;//库长度，不可改变

            //协议的实体
            state0_12 state12 = new state0_12();

            //创建一个以整数作为键，以字符串作为值的字典
            Dictionary<int, string> ageDict = new Dictionary<int, string>();

            string result = "";

            ExplainDictionary0 ExDict = new ExplainDictionary0();

            //2个
            int[] a = { 7, 8 };
            int[] b = { 9, 10 };
            int[] c = { 11, 12 };
            int[] d = { 13, 14 };
            int[] e = { 15, 16 };
            int[] f = { 17, 18 };
            int[] n = { 45, 46 };
            int[] m = { 47, 48 };
            int[] o = { 50, 51 };
            int[] p = { 52, 53 };

            int[] y = { 93, 94 };
            int[] z = { 95, 96 };
            int[] a1 = { 97, 98 };
            int[] b1 = { 99, 100 };
            int[] c1 = { 101, 102 };
            int[] d1 = { 103, 104 };
            int[] e1 = { 105, 106 };
            int[] f1 = { 107, 108 };
            int[] g1 = { 109, 110 };
            int[] h1 = { 111, 112 };
            int[] i1 = { 113, 114 };
            int[] j1 = { 115, 116 };
            int[] k1 = { 117, 118 };
            int[] l1 = { 119, 120 };
            int[] n1 = { 121, 122 };
            int[] m1 = { 123, 124 };

            int[] o1 = { 125, 126 };
            int[] p1 = { 127, 128 };
            int[] q1 = { 129, 130 };
            int[] r1 = { 131, 132 };
            int[] s1 = { 133, 134 };
            int[] t1 = { 135, 136 };
            int[] u1 = { 137, 138 };
            int[] v1 = { 139, 140 };

            int[] w1 = { 141, 142 };
            int[] x1 = { 143, 144 };
            int[] y1 = { 145, 146 };
            int[] z1 = { 147, 148 };
            int[] a2 = { 149, 150 };
            int[] b2 = { 151, 152 };
            int[] c2 = { 153, 154 };
            int[] d2 = { 155, 156 };


            //4个
            int[] g = { 19, 20, 21, 22 };
            int[] h = { 23, 24, 25, 26 };
            int[] i = { 27, 28, 29, 30 };
            int[] j = { 33, 34, 35, 36 };
            int[] k = { 37, 38, 39, 40 };
            int[] l = { 41, 42, 43, 44 };
            int[] q = { 59, 60, 61, 62 };
            int[] r = { 63, 64, 65, 66 };
            int[] s = { 67, 68, 68, 70 };
            int[] t = { 71, 72, 73, 74 };
            int[] u = { 77, 78, 79, 80 };
            int[] v = { 81, 82, 83, 84 };
            int[] w = { 85, 86, 87, 88 };
            int[] x = { 89, 90, 91, 92 };

            int[] e2 = { 157, 158, 159, 160 };
            int[] f2 = { 161, 162, 163, 164 };
            int[] g2 = { 165, 166, 167, 168 };
            int[] h2 = { 169, 170, 171, 172 };
            int[] i2 = { 173, 174, 175, 176 };
            int[] j2 = { 177, 178, 179, 180 };
            int[] k2 = { 181, 182, 183, 184 };
            int[] l2 = { 185, 186, 187, 188 };

            var valueFromInputBox = ContentChanged;

            //将用户输入的值转为数组
            string[] numbersArray = valueFromInputBox.Split(' ');

            //获取到长度的16进制，从第10个下标开始截取两个值
            var subArray = numbersArray.Skip(10).Take(2).ToArray();

            //拿到body长度的16进制，转换高低位
            string combined = string.Join("", subArray.Reverse());

            //计算Body长度（16进制转换为10进制）
            int decimalValueUsingParse = int.Parse(combined, System.Globalization.NumberStyles.HexNumber);

            int kulength = decimalValueUsingParse / _Kulength;

            //截取到body的值，跳过body前的12位，截取12位后的756个长度的值
            var bodyArray = numbersArray.Skip(12).Take(decimalValueUsingParse).ToArray();

            //以库位长度为准，截取数组每189个，获取到每个库位的值
            var triplets = bodyArray.Select((value, index) => new { Value = value, Index = index })
                      .GroupBy(x => x.Index / _Kulength)
                      .Select(g => g.Select(v => v.Value).ToArray());

            //将Body的值分库截取开
            foreach (var triplet in triplets)
            {
                var list = triplet.ToList();
                //Console.WriteLine(string.Join("", triplet));

                state12.LibrarylocationNumber = "货位号：" + int.Parse(list[0], System.Globalization.NumberStyles.HexNumber);
                state12.DeviceType = "中位机设备类型：" + ExDict.dictionary1[(int.Parse(list[1], System.Globalization.NumberStyles.HexNumber))];
                state12.ProtocolType = "协议类型：" + int.Parse(list[2], System.Globalization.NumberStyles.HexNumber);
                state12.ProtocolVersion = "协议版本：" + int.Parse(list[3], System.Globalization.NumberStyles.HexNumber);
                state12.LocationState = "库位状态：" + ExDict.dictionary4[int.Parse(list[4], System.Globalization.NumberStyles.HexNumber)];
                state12.Buzzer = "蜂鸣器：" + ExDict.dictionary5[int.Parse(list[5], System.Globalization.NumberStyles.HexNumber)];
                state12.TricolourLight = "三色灯：" + ExDict.dictionary6[int.Parse(list[6], System.Globalization.NumberStyles.HexNumber)];
                state12.OnlineAisleQuantity = "在线通道数量：" + int.Parse((string.Concat(a.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.WarningAisleQuantity = "告警通道数量：" + int.Parse((string.Concat(b.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.ProcessNumber = "做流程数量：" + int.Parse((string.Concat(c.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.SuspendAisleQuantity = "暂停通道数量：" + int.Parse((string.Concat(d.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.StyletPressCount = "探针压合次数：" + int.Parse((string.Concat(e.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_1Q = "前部分预留1：" + int.Parse((string.Concat(f.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_2Q = "前部分预留2：" + int.Parse((string.Concat(g.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_3Q = "前部分预留3：" + int.Parse((string.Concat(h.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_4Q = "前部分预留4：" + int.Parse((string.Concat(i.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FireControlDoor = "消防门控制：" + ExDict.dictionary17[int.Parse(list[31], System.Globalization.NumberStyles.HexNumber)];
                state12.ControlState = "控制状态：" + int.Parse(list[32], System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_1 = "后部分预留1：" + int.Parse((string.Concat(j.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_2 = "后部分预留2：" + int.Parse((string.Concat(k.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_3 = "后部分预留3：" + int.Parse((string.Concat(l.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_4 = "后部分预留4：" + int.Parse((string.Concat(n.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.BarotropicValue = "正压值：" + int.Parse((string.Concat(m.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.PcsIoStatus = "库位PCS_IO状态：" + ExDict.dictionary24[int.Parse(list[49], System.Globalization.NumberStyles.HexNumber)];
                state12.PlceVrsionsNumber = "PLC版本号：" + int.Parse((string.Concat(o.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.NegativePressureValue = "负压值：" + int.Parse((string.Concat(p.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.TrayState = "托盘状态：" + ExDict.dictionary27[int.Parse(list[54], System.Globalization.NumberStyles.HexNumber)];
                state12.PlcState = "PLC状态：" + int.Parse(list[55], System.Globalization.NumberStyles.HexNumber);
                state12.LocationDoorInductor = "库位门感应：" + int.Parse(list[56], System.Globalization.NumberStyles.HexNumber);
                state12.EquipmentCylinderPressInductor = "托盘、气缸压合感应：" + int.Parse(list[57], System.Globalization.NumberStyles.HexNumber);
                state12.CylinderWarning = "气缸报警：" + ExDict.dictionary31[int.Parse(list[58], System.Globalization.NumberStyles.HexNumber)];
                state12.Reserved_5 = "后部分预留5：" + int.Parse((string.Concat(q.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Inductor = "感应：" + ExDict.dictionary33[int.Parse((string.Concat(r.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber)];
                state12.Reserved_7 = "后部分预留7：" + int.Parse((string.Concat(s.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_8 = "后部分预留8：" + int.Parse((string.Concat(t.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.GiveAnAlarm_1 = "报警1：" + int.Parse(list[75], System.Globalization.NumberStyles.HexNumber);
                state12.GiveAnAlarm_2 = "报警2：" + int.Parse(list[76], System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_9 = "后部分预留9：" + int.Parse((string.Concat(u.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Warning_3 = "警告3：" + int.Parse((string.Concat(v.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_11 = "后部分预留11：" + int.Parse((string.Concat(w.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_12 = "后部分预留12：" + int.Parse((string.Concat(x.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                state12.EnvironmentTemperature_1 = "环境温度1：" + int.Parse((string.Concat(y.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_2 = "环境温度2：" + int.Parse((string.Concat(z.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_3 = "环境温度3：" + int.Parse((string.Concat(a1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_4 = "环境温度4：" + int.Parse((string.Concat(b1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_5 = "环境温度5：" + int.Parse((string.Concat(c1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_6 = "环境温度6：" + int.Parse((string.Concat(d1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_7 = "环境温度7：" + int.Parse((string.Concat(e1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_8 = "环境温度8：" + int.Parse((string.Concat(f1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_9 = "环境温度9：" + int.Parse((string.Concat(g1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_10 = "环境温度10：" + int.Parse((string.Concat(h1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_11 = "环境温度11：" + int.Parse((string.Concat(i1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_12 = "环境温度12：" + int.Parse((string.Concat(j1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_13 = "环境温度13：" + int.Parse((string.Concat(k1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_14 = "环境温度14：" + int.Parse((string.Concat(l1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_15 = "环境温度15：" + int.Parse((string.Concat(n1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.EnvironmentTemperature_16 = "环境温度16：" + int.Parse((string.Concat(m1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                state12.FanSpeedPwm_1 = "风扇转速1 (PWM)：" + int.Parse((string.Concat(o1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_2 = "风扇转速2 (PWM)：" + int.Parse((string.Concat(p1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_3 = "风扇转速3 (PWM)：" + int.Parse((string.Concat(q1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_4 = "风扇转速4 (PWM)：" + int.Parse((string.Concat(r1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_5 = "风扇转速5 (PWM)：" + int.Parse((string.Concat(s1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_6 = "风扇转速6 (PWM)：" + int.Parse((string.Concat(t1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_7 = "风扇转速7 (PWM)：" + int.Parse((string.Concat(u1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedPwm_8 = "风扇转速8 (PWM)：" + int.Parse((string.Concat(v1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                state12.FanSpeedGrade_1 = "风扇转速1 (等级)：" + int.Parse((string.Concat(w1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_2 = "风扇转速2 (等级)：" + int.Parse((string.Concat(x1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_3 = "风扇转速3 (等级)：" + int.Parse((string.Concat(y1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_4 = "风扇转速4 (等级)：" + int.Parse((string.Concat(z1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_5 = "风扇转速5 (等级)：" + int.Parse((string.Concat(a2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_6 = "风扇转速6 (等级)：" + int.Parse((string.Concat(b2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_7 = "风扇转速7 (等级)：" + int.Parse((string.Concat(c2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.FanSpeedGrade_8 = "风扇转速8 (等级)：" + int.Parse((string.Concat(d2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                state12.Reserved_9Q = "前部分预留9：" + int.Parse((string.Concat(e2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_10Q = "前部分预留10：" + int.Parse((string.Concat(f2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_11Q = "前部分预留11：" + int.Parse((string.Concat(g2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_12Q = "前部分预留12：" + int.Parse((string.Concat(h2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_13Q = "前部分预留13：" + int.Parse((string.Concat(i2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_14Q = "前部分预留14：" + int.Parse((string.Concat(j2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_15Q = "前部分预留15：" + int.Parse((string.Concat(k2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state12.Reserved_16Q = "前部分预留16：" + int.Parse((string.Concat(l2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                //string ss = string.Empty;

                //将值反射出来
                PropertyInfo[] listdate = state12.GetType().GetProperties();
                foreach (PropertyInfo info in typeof(state0_12).GetProperties())
                {
                    //s += info.Name + "/n";

                    //ss += info.GetValue(state12, null) + "\n";

                    result += info.GetValue(state12, null) + "\t";

                };
                result += "\n\n";
            }

            //将解析好的所有报文都传到页面上
            ParseTheDataChanged = result;
        }

        //0x11
        private void state0X11()
        {
            

            int _Kulength = 89;//库长度，不可改变

            //协议的实体
            state_11 state11 = new state_11();

            //创建一个以整数作为键，以字符串作为值的字典
            Dictionary<int, string> ageDict = new Dictionary<int, string>();

            string result = "";

            ExplainDictionary2 ExDict = new ExplainDictionary2();

            var valueFromInputBox = ContentChanged;

            //将用户输入的值转为数组
            string[] numbersArray = valueFromInputBox.Split(' ');

            //获取到长度的16进制，从第10个下标开始截取两个值
            var subArray = numbersArray.Skip(10).Take(2).ToArray();

            //拿到body长度的16进制，转换高低位
            string combined = string.Join("", subArray.Reverse());

            int sy = int.Parse(combined)-2;
            combined = sy.ToString();

            //计算Body长度（16进制转换为10进制），0X11这里需要将Body前两个字节截取掉
            int decimalValueUsingParse = int.Parse(combined, System.Globalization.NumberStyles.HexNumber);

            int kulength = decimalValueUsingParse / _Kulength;

            //截取到body的值，跳过body前的14位，0X11body的前两位不需要
            var bodyArray = numbersArray.Skip(14).Take(decimalValueUsingParse).ToArray();

            //以库位长度为准，截取数组每89个，获取到每个库位的值
            var triplets = bodyArray.Select((value, index) => new { Value = value, Index = index })
                      .GroupBy(x => x.Index / _Kulength)
                      .Select(g => g.Select(v => v.Value).ToArray());

            int[] a0 = { 0,1 };
            int[] a1 = { 2,3 };
            int[] a2 = { 5,6 };
            int[] a3 = { 7,8 };
            int[] a4 = { 10,11,12,13 };
            int[] a5 = { 14,15,16,17 };
            int[] a6 = { 18,19,20,21 };
            int[] a7 = { 22,23,24,25 };
            int[] a8 = { 26,27,28,29 };
            int[] a9 = { 30,31 };
            int[] a10 = { 32,33 };
            int[] a11 = { 34,35 };
            int[] a12 = { 36,37 };
            int[] a13 = { 38,39,40,41,42,43,44,45 };
            int[] a14 = { 46,47,48,49,50,51,52,53 };
            int[] a15 = { 55,56,57,58 };
            int[] a16 = { 59,60,61,62 };
            int[] a17 = { 63,64,65,66 };
            int[] a18 = { 67,68,69,70 };
            int[] a19 = { 71,72,73,74 };
            int[] a20 = { 75,76,77,78 };
            int[] a21 = { 79,80,81,82 };
            int[] a22 = { 83,84,85,86 };
            int[] a23 = { 87,88 };

            //将Body的值分库截取开
            foreach (var triplet in triplets)
            {
                var list = triplet.ToList();
                //Console.WriteLine(string.Join("", triplet));
                //state12.TricolourLight = "三色灯：" + ExDict.dictionary6[int.Parse(list[6], System.Globalization.NumberStyles.HexNumber)];
                //state12.OnlineAisleQuantity = "在线通道数量：" + int.Parse((string.Concat(a.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                state11.channelNumber = "通道号：" + int.Parse((string.Concat(a0.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.stepNumber = "工步号：" + int.Parse((string.Concat(a1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.stepMode = "工步模式：" + ExDict.dictionary3[int.Parse(list[4], System.Globalization.NumberStyles.HexNumber)];
                state11.cycleStepNumber = "循环工步号：" + int.Parse((string.Concat(a2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.cycleNumber = "循环号：" + int.Parse((string.Concat(a3.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.channelStatus = "通道状态：" + ExDict.dictionary6[int.Parse(list[9], System.Globalization.NumberStyles.HexNumber)];
                state11.voltage = "电压：" + int.Parse((string.Concat(a4.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.Current = "电流：" + int.Parse((string.Concat(a5.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.capacity = "容量：" + int.Parse((string.Concat(a6.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.energy = "能量：" + int.Parse((string.Concat(a7.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.totalCapacity = "总容量：" + int.Parse((string.Concat(a8.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.batteryTemperature1 = "电池温度1：" + int.Parse((string.Concat(a9.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.batteryTemperature2 = "电池温度2：" + int.Parse((string.Concat(a10.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.powerTubeTemperature1 = "功率管温度1：" + int.Parse((string.Concat(a11.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.powerTubeTemperature2 = "功率管温度2：" + int.Parse((string.Concat(a12.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                var aa1 = (list.Skip(38).Take(4).ToArray());
                string aa2 = string.Join("", aa1.Reverse());
                var aa3 = (list.Skip(42).Take(4).ToArray());
                string aa4 = string.Join("", aa3.Reverse());
                string aa5 = aa4 + aa2;
                Int32 aa6 = int.Parse(aa5, System.Globalization.NumberStyles.HexNumber);
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(aa6);
                string formattedDateTime = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"); // 格式化输出
                state11.stepRunTime = "工步运行时间：" + formattedDateTime;
                var dd1 = (list.Skip(46).Take(4).ToArray());
                string dd2 = string.Join("", dd1.Reverse());
                var dd3 = (list.Skip(50).Take(4).ToArray());
                string dd4 = string.Join("", dd3.Reverse());
                string dd5 = dd4 + dd2;
                long dd6 = long.Parse(dd5, System.Globalization.NumberStyles.HexNumber);
                DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeMilliseconds(dd6);
                string formattedDateTime2 = dateTimeOffset2.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"); // 格式化输出
                state11.dataSampleTime = "数据采样时间：" + formattedDateTime2;
                state11.dataSourceFlag = "数据来源标志：" + ExDict.dictionary18[int.Parse(list[54], System.Globalization.NumberStyles.HexNumber)];
                state11.polarVoltage = "极耳电压：" + int.Parse((string.Concat(a15.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.contactResistance = "接触电阻：" + int.Parse((string.Concat(a16.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.stringernalResistance = "直流内阻：" + int.Parse((string.Concat(a17.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.loopResistance = "回路电阻：" + int.Parse((string.Concat(a18.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.pressureValue = "气压值：" + int.Parse((string.Concat(a19.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.samplingLineVoltage = "采样线电压（真实值）：" + int.Parse((string.Concat(a20.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.powerLineVoltage = "功率线电压（真实值）：" + int.Parse((string.Concat(a21.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.linkVoltage = "母线电压：" + int.Parse((string.Concat(a22.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
                state11.exceptionCode = "异常码：" + int.Parse((string.Concat(a23.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

                //string ss = string.Empty;

                //将值反射出来
                PropertyInfo[] listdate = state11.GetType().GetProperties();
                foreach (PropertyInfo info in typeof(state_11).GetProperties())
                {
                    //s += info.Name + "/n";

                    //ss += info.GetValue(state12, null) + "\n";

                    result += info.GetValue(state11, null) + "\t";

                };
                result += "\n\n";
            }

            //将解析好的所有报文都传到页面上
            ParseTheDataChanged = result;
        }

        //private void Submit()
        //{
        //    var valueFromInputBox = ContentChanged;

        //    //将用户输入的值转为数组
        //    string[] numbersArray = valueFromInputBox.Split(' ');

        //    //获取到长度的16进制，从第10个下标开始截取两个值
        //    var subArray = numbersArray.Skip(10).Take(2).ToArray();

        //    //拿到body长度的16进制，转换高低位
        //    string combined = string.Join("", subArray.Reverse());

        //    //计算Body长度（16进制转换为10进制）
        //    int decimalValueUsingParse = int.Parse(combined, System.Globalization.NumberStyles.HexNumber);

        //    int kulength = decimalValueUsingParse / _Kulength;

        //    //截取到body的值，跳过body前的12位，截取12位后的756个长度的值
        //    var bodyArray = numbersArray.Skip(12).Take(decimalValueUsingParse).ToArray();

        //    //以库位长度为准，截取数组每189个，获取到每个库位的值
        //    var triplets = bodyArray.Select((value, index) => new { Value = value, Index = index })
        //              .GroupBy(x => x.Index / _Kulength)
        //              .Select(g => g.Select(v => v.Value).ToArray());

        //    //将Body的值分库截取开
        //    foreach (var triplet in triplets)
        //    {
        //        var list = triplet.ToList();
        //        //Console.WriteLine(string.Join("", triplet));

        //        state12.LibrarylocationNumber = "货位号：" + int.Parse(list[0], System.Globalization.NumberStyles.HexNumber);
        //        state12.DeviceType = "中位机设备类型：" + ExDict.dictionary1[(int.Parse(list[1], System.Globalization.NumberStyles.HexNumber))];
        //        state12.ProtocolType = "协议类型：" + int.Parse(list[2], System.Globalization.NumberStyles.HexNumber);
        //        state12.ProtocolVersion = "协议版本：" + int.Parse(list[3], System.Globalization.NumberStyles.HexNumber);
        //        state12.LocationState = "库位状态：" + ExDict.dictionary4[int.Parse(list[4], System.Globalization.NumberStyles.HexNumber)];
        //        state12.Buzzer = "蜂鸣器：" + ExDict.dictionary5[int.Parse(list[5], System.Globalization.NumberStyles.HexNumber)];
        //        state12.TricolourLight = "三色灯：" + ExDict.dictionary6[int.Parse(list[6], System.Globalization.NumberStyles.HexNumber)];
        //        state12.OnlineAisleQuantity = "在线通道数量：" + int.Parse((string.Concat(a.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.WarningAisleQuantity = "告警通道数量：" + int.Parse((string.Concat(b.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.ProcessNumber = "做流程数量：" + int.Parse((string.Concat(c.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.SuspendAisleQuantity = "暂停通道数量：" + int.Parse((string.Concat(d.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.StyletPressCount = "探针压合次数：" + int.Parse((string.Concat(e.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_1Q = "前部分预留1：" + int.Parse((string.Concat(f.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_2Q = "前部分预留2：" + int.Parse((string.Concat(g.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_3Q = "前部分预留3：" + int.Parse((string.Concat(h.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_4Q = "前部分预留4：" + int.Parse((string.Concat(i.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FireControlDoor = "消防门控制：" + ExDict.dictionary17[int.Parse(list[31], System.Globalization.NumberStyles.HexNumber)];
        //        state12.ControlState = "控制状态：" + int.Parse(list[32], System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_1 = "后部分预留1：" + int.Parse((string.Concat(j.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_2 = "后部分预留2：" + int.Parse((string.Concat(k.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_3 = "后部分预留3：" + int.Parse((string.Concat(l.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_4 = "后部分预留4：" + int.Parse((string.Concat(n.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.BarotropicValue = "正压值：" + int.Parse((string.Concat(m.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.PcsIoStatus = "库位PCS_IO状态：" + ExDict.dictionary24[int.Parse(list[49], System.Globalization.NumberStyles.HexNumber)];
        //        state12.PlceVrsionsNumber = "PLC版本号：" + int.Parse((string.Concat(o.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.NegativePressureValue = "负压值：" + int.Parse((string.Concat(p.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.TrayState = "托盘状态：" + ExDict.dictionary27[int.Parse(list[54], System.Globalization.NumberStyles.HexNumber)];
        //        state12.PlcState = "PLC状态：" + int.Parse(list[55], System.Globalization.NumberStyles.HexNumber);
        //        state12.LocationDoorInductor = "库位门感应：" + int.Parse(list[56], System.Globalization.NumberStyles.HexNumber);
        //        state12.EquipmentCylinderPressInductor = "托盘、气缸压合感应：" + int.Parse(list[57], System.Globalization.NumberStyles.HexNumber);
        //        state12.CylinderWarning = "气缸报警：" + ExDict.dictionary31[int.Parse(list[58], System.Globalization.NumberStyles.HexNumber)];
        //        state12.Reserved_5 = "后部分预留5：" + int.Parse((string.Concat(q.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Inductor = "感应：" + ExDict.dictionary33[int.Parse((string.Concat(r.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber)];
        //        state12.Reserved_7 = "后部分预留7：" + int.Parse((string.Concat(s.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_8 = "后部分预留8：" + int.Parse((string.Concat(t.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.GiveAnAlarm_1 = "报警1：" + int.Parse(list[75], System.Globalization.NumberStyles.HexNumber);
        //        state12.GiveAnAlarm_2 = "报警2：" + int.Parse(list[76], System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_9 = "后部分预留9：" + int.Parse((string.Concat(u.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Warning_3 = "警告3：" + int.Parse((string.Concat(v.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_11 = "后部分预留11：" + int.Parse((string.Concat(w.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_12 = "后部分预留12：" + int.Parse((string.Concat(x.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

        //        state12.EnvironmentTemperature_1 = "环境温度1：" + int.Parse((string.Concat(y.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_2 = "环境温度2：" + int.Parse((string.Concat(z.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_3 = "环境温度3：" + int.Parse((string.Concat(a1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_4 = "环境温度4：" + int.Parse((string.Concat(b1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_5 = "环境温度5：" + int.Parse((string.Concat(c1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_6 = "环境温度6：" + int.Parse((string.Concat(d1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_7 = "环境温度7：" + int.Parse((string.Concat(e1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_8 = "环境温度8：" + int.Parse((string.Concat(f1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_9 = "环境温度9：" + int.Parse((string.Concat(g1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_10 = "环境温度10：" + int.Parse((string.Concat(h1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_11 = "环境温度11：" + int.Parse((string.Concat(i1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_12 = "环境温度12：" + int.Parse((string.Concat(j1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_13 = "环境温度13：" + int.Parse((string.Concat(k1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_14 = "环境温度14：" + int.Parse((string.Concat(l1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_15 = "环境温度15：" + int.Parse((string.Concat(n1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.EnvironmentTemperature_16 = "环境温度16：" + int.Parse((string.Concat(m1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

        //        state12.FanSpeedPwm_1 = "风扇转速1 (PWM)：" + int.Parse((string.Concat(o1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_2 = "风扇转速2 (PWM)：" + int.Parse((string.Concat(p1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_3 = "风扇转速3 (PWM)：" + int.Parse((string.Concat(q1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_4 = "风扇转速4 (PWM)：" + int.Parse((string.Concat(r1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_5 = "风扇转速5 (PWM)：" + int.Parse((string.Concat(s1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_6 = "风扇转速6 (PWM)：" + int.Parse((string.Concat(t1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_7 = "风扇转速7 (PWM)：" + int.Parse((string.Concat(u1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedPwm_8 = "风扇转速8 (PWM)：" + int.Parse((string.Concat(v1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

        //        state12.FanSpeedGrade_1 = "风扇转速1 (等级)：" + int.Parse((string.Concat(w1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_2 = "风扇转速2 (等级)：" + int.Parse((string.Concat(x1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_3 = "风扇转速3 (等级)：" + int.Parse((string.Concat(y1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_4 = "风扇转速4 (等级)：" + int.Parse((string.Concat(z1.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_5 = "风扇转速5 (等级)：" + int.Parse((string.Concat(a2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_6 = "风扇转速6 (等级)：" + int.Parse((string.Concat(b2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_7 = "风扇转速7 (等级)：" + int.Parse((string.Concat(c2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.FanSpeedGrade_8 = "风扇转速8 (等级)：" + int.Parse((string.Concat(d2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

        //        state12.Reserved_9Q = "前部分预留9：" + int.Parse((string.Concat(e2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_10Q = "前部分预留10：" + int.Parse((string.Concat(f2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_11Q = "前部分预留11：" + int.Parse((string.Concat(g2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_12Q = "前部分预留12：" + int.Parse((string.Concat(h2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_13Q = "前部分预留13：" + int.Parse((string.Concat(i2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_14Q = "前部分预留14：" + int.Parse((string.Concat(j2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_15Q = "前部分预留15：" + int.Parse((string.Concat(k2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);
        //        state12.Reserved_16Q = "前部分预留16：" + int.Parse((string.Concat(l2.OrderByDescending(c => c).Select(i => list[i]).ToList())), System.Globalization.NumberStyles.HexNumber);

        //        //string ss = string.Empty;

        //        //将值反射出来
        //        PropertyInfo[] listdate = state12.GetType().GetProperties();
        //        foreach (PropertyInfo info in typeof(state0_12).GetProperties())
        //        {
        //            //s += info.Name + "/n";

        //            //ss += info.GetValue(state12, null) + "\n";

        //            result += info.GetValue(state12, null) + "\t";

        //        };
        //        result += "\n\n";
        //    }

        //    //将解析好的所有报文都传到页面上
        //    ParseTheDataChanged = result;

        //}
        //复制
        
        [RelayCommand]
        private void Copy()
        {
            if (CopyCommand != null && !string.IsNullOrEmpty(ParseTheDataChanged))
            {
                Clipboard.SetText(ParseTheDataChanged);
            }
        }

        public ObservableCollection<string> Options { get; } = new ObservableCollection<string>
        {
            "state_0X11",
            "state_0X12",
        };

    }
}
