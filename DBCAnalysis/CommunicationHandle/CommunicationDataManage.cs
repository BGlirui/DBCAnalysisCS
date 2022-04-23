using DBCAnalysis.Core.BeanManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.CommunicationHandle
{
    class CommunicationDataManage
    {
        private MessageAnalysis _messageAnalysis;
        private DataPool _dataPool;

        public CommunicationDataManage()
        {
            if(this._messageAnalysis == null)
            {
                this._messageAnalysis = BeanOpe.GetBeanOpe().GetObject<MessageAnalysis>();
            }
            if(this._dataPool == null)
            {
                this._dataPool = BeanOpe.GetBeanOpe().GetObject<DataPool>();
            }
        }

        /// <summary>
        /// 通过信号名来获取信号值
        /// </summary>
        /// <param name="signalName"></param>
        /// <returns></returns>
        public UInt64 GetSignalValueBySignalName(string signalName)
        {
            if (this._dataPool == null)
            {
                return 0;
            }
            if (this._dataPool.SignalValueMap == null)
            {
                return 0;
            }
            if (!this._dataPool.SignalValueMap.ContainsKey(signalName))
            {
                return 0;
            }
            return this._dataPool.SignalValueMap[signalName];
        }

        /// <summary>
        /// 设置信号值
        /// </summary>
        /// <param name="signalName">信号值名称</param>
        /// <param name="signalValue">信号值</param>
        /// <returns></returns>
        public bool SetSignalValue(string signalName, UInt64 signalValue)
        {
            if (!this._dataPool.SignalValueMap.ContainsKey(signalName))
            {
                return false;
            }
            this._dataPool.SignalValueMap[signalName] = signalValue;
            return true;
        }

        /// <summary>
        /// 通过MessageId获取对应数据
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public byte[] GetMessageData(uint messageId)
        {
            if(this._messageAnalysis == null)
            {
                return null;
            }
            return this._messageAnalysis.GetMessage(messageId);
        }

        /// <summary>
        /// 解析Message报文。完成解析后可以通过
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AnalysisMessage(uint messageId, byte[] data)
        {
            if(this._messageAnalysis == null)
            {
                return false;
            }
            return this._messageAnalysis.SetMessageInfo(messageId, data);
        }
    }
}
