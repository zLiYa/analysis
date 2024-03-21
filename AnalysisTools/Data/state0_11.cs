using System;

namespace AnalysisTools
{
	//协议信息
	public class state_11
	{
        /// <summary>
        /// 协议版本
        /// </summary>
        public string protocolVersion { get; set; }

        /// <summary>
        /// 通道总数
        /// </summary>
        public string channelCount { get; set; }

        /// <summary>
        /// 通道号
        /// </summary>
        public string channelNumber { get; set; }

        /// <summary>
        /// 工步号
        /// </summary>
        public string stepNumber { get; set; }

        /// <summary>
        /// 工步模式
        /// </summary>
        public string stepMode { get; set; }

        /// <summary>
        /// 循环工步号
        /// </summary>
        public string cycleStepNumber { get; set; }

        /// <summary>
        /// 循环号
        /// </summary>
        public string cycleNumber { get; set; }

        /// <summary>
        /// 通道状态
        /// </summary>
        public string channelStatus { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        public string voltage { get; set; }

        /// <summary>
        /// 电流
        /// </summary>
        public string Current { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
        public string capacity { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public string energy { get; set; }


        /// <summary>
        /// 总容量
        /// </summary>
        public string totalCapacity { get; set; }

        /// <summary>
        /// 电池温度1
        /// </summary>
        public string batteryTemperature1 { get; set; }

        /// <summary>
        /// 电池温度2
        /// </summary>
        public string batteryTemperature2 { get; set; }

        /// <summary>
        /// 功率管温度1
        /// </summary>
        public string powerTubeTemperature1 { get; set; }

        /// <summary>
        /// 功率管温度2
        /// </summary>
        public string powerTubeTemperature2 { get; set; }

        /// <summary>
        /// 工步运行时间
        /// </summary>
        public string stepRunTime { get; set; }
        /// <summary>
        ///数据采样时间
        /// </summary>
        public string dataSampleTime { get; set; }

        /// <summary>
        /// 数据来源标志
        /// </summary>
        public string dataSourceFlag { get; set; }

        /// <summary>
        ///极耳电压
        /// </summary>
        public string polarVoltage { get; set; }

        /// <summary>
        ///接触电阻
        /// </summary>
        public string contactResistance { get; set; }

        /// <summary>
        ///直流内阻
        /// </summary>
        public string stringernalResistance { get; set; }

        /// <summary>
        ///回路电阻
        /// </summary>
        public string loopResistance { get; set; }

        /// <summary>
        ///气压值
        /// </summary>
        public string pressureValue { get; set; }

        /// <summary>
        ///采样线电压（真实值）
        /// </summary>
        public string samplingLineVoltage { get; set; }

        /// <summary>
        ///功率线电压（真实值）
        /// </summary>
        public string powerLineVoltage { get; set; }

        /// <summary>
        ///母线电压
        /// </summary>
        public string linkVoltage { get; set; }

        /// <summary>
        ///异常码
        /// </summary>
        public string exceptionCode { get; set; }
    }

}
