using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace AnalysisTools
{
    public class CommonDto
    {
        /// <summary>
        /// 起始符
        /// </summary>
        public byte startCharacter { get; set; }

        /// <summary>
        /// 功能码
        /// </summary>
        public byte functionCode { get; set; }

        /// <summary>
        /// 帧ID
        /// </summary>
        public byte frameId { get; set; }

        /// <summary>
        /// 总包数
        /// </summary>
        public byte totalPackagesCount {  get; set; }

        /// <summary>
        /// 分包ID
        /// </summary>
        public byte subcontractingId { get; set; }

        /// <summary>
        /// 转发串口
        /// </summary>
        public byte forwardSerialPort { get; set; }

        /// <summary>
        /// Body长度
        /// </summary>
        public byte bodyLength { get; set; }

        /// <summary>
        /// 校验
        /// </summary>
        public byte check { get; set; }

        /// <summary>
        /// 结束符
        /// </summary>
        public byte endSymbol { get; set; }
    }
    public class ChannelSampleDataCommandDto
    {
        /// <summary>
        /// 协议版本
        /// </summary>
        public byte protocolVersion { get; set; }

        /// <summary>
        /// 通道总数
        /// </summary>
        public byte channelCount { get; set; }

        /// <summary>
        /// 通道号
        /// </summary>
        public ushort channelNumber { get; set; }

        /// <summary>
        /// 工步号
        /// </summary>
        public ushort stepNumber { get; set; }

        /// <summary>
        /// 工步模式
        /// </summary>
        public byte stepMode { get; set; }

        /// <summary>
        /// 循环工步号
        /// </summary>
        public ushort cycleStepNumber { get; set; }

        /// <summary>
        /// 循环号
        /// </summary>
        public ushort cycleNumber { get; set; }

        /// <summary>
        /// 通道状态
        /// </summary>
        public byte channelStatus { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        public int voltage { get; set; }

        /// <summary>
        /// 电流
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
        public int capacity { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public int energy { get; set; }


        /// <summary>
        /// 总容量
        /// </summary>
        public int totalCapacity { get; set; }

        /// <summary>
        /// 电池温度1
        /// </summary>
        public int batteryTemperature1 { get; set; }

        /// <summary>
        /// 电池温度2
        /// </summary>
        public int batteryTemperature2 { get; set; }

        /// <summary>
        /// 功率管温度1
        /// </summary>
        public int powerTubeTemperature1 { get; set; }

        /// <summary>
        /// 功率管温度2
        /// </summary>
        public int powerTubeTemperature2 { get; set; }

        /// <summary>
        /// 工步运行时间
        /// </summary>
        public Int64 stepRunTime { get; set; }
        /// <summary>
        ///数据采样时间
        /// </summary>
        public Int64 dataSampleTime { get; set; }

        /// <summary>
        /// 数据来源标志
        /// </summary>
        public byte dataSourceFlag { get; set; }

        /// <summary>
        ///极耳电压
        /// </summary>
        public int polarVoltage { get; set; }

        /// <summary>
        ///接触电阻
        /// </summary>
        public int contactResistance { get; set; }

        /// <summary>
        ///直流内阻
        /// </summary>
        public int internalResistance { get; set; }

        /// <summary>
        ///回路电阻
        /// </summary>
        public int loopResistance { get; set; }

        /// <summary>
        ///气压值
        /// </summary>
        public int pressureValue { get; set; }

        /// <summary>
        ///采样线电压（真实值）
        /// </summary>
        public int samplingLineVoltage { get; set; }

        /// <summary>
        ///功率线电压（真实值）
        /// </summary>
        public int powerLineVoltage { get; set; }

        /// <summary>
        ///母线电压
        /// </summary>
        public int linkVoltage { get; set; }

        /// <summary>
        ///异常码
        /// </summary>
        public byte exceptionCode { get; set; }
    }
}
