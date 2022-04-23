using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using DBCAnalysis.Models.CommunicationHandle;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using DBCAnalysis.Models.Result;
using DBCAnalysis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.CommunicationHandle
{
    class MessageAnalysis
    {
        private ResultObjectOpe _resultObjectOpe;
        private DataPool _dataPool;
        private Dictionary<string, Dictionary<uint,MessageAndSignalInfo>> _messageAndSignalInfoMap;
        private int[] byteEndIndexArray = new int[8] { 7, 15, 23, 31, 39, 47, 55, 63 };
        private int[] byteStartIndexArray = new int[8] { 0, 8, 16, 24, 32, 40, 48, 56 };
        private byte[] littleByteMarkArray = new byte[] { 0x00, 0x01, 0x03, 0x07, 0x0F, 0x1F, 0x3F, 0x7F, 0xFF };
        private byte[] bigByteMarkArray = new byte[] { 0x00, 0x80, 0xC0, 0xE0, 0xF0, 0xF8, 0xFC, 0xFE, 0xFF };

        public MessageAnalysis()
        {
            if(this._resultObjectOpe == null)
            {
                this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            }
            if(this._dataPool == null)
            {
                this._dataPool = BeanOpe.GetBeanOpe().GetObject<DataPool>();
            }
            this._messageAndSignalInfoMap = new Dictionary<string, Dictionary<uint, MessageAndSignalInfo>>();
        }
        #region 初始化相关
        /// <summary>
        /// 初始化操作。在结果集出现变更后，需要进行初始化操作。
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            if (this._resultObjectOpe == null)
            {
                this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            }
            this._messageAndSignalInfoMap.Clear();
            this._dataPool.SignalValueMap.Clear();
            this._dataPool.MessageData.Clear();
            // 获取所有结果集
            Dictionary<string, ResultObject> resultObjectMap = this._resultObjectOpe.GetAllResultObject();
            // 遍历DBC文件路径
            foreach(KeyValuePair<string,ResultObject> resultObjKvp in resultObjectMap)
            {
                this.updateMessageIdMap(resultObjKvp.Key,this._resultObjectOpe.GetBaseKeyModelOpesByClassFullName(resultObjKvp.Value, MessageAnalysisMachine.CLASS_FULL_NAME));
                this.updateSignalMap(resultObjKvp.Key, this._resultObjectOpe.GetBaseKeyModelOpesByClassFullName(resultObjKvp.Value, SignalAnalysisMachine.CLASS_FULL_NAME));
            }
            return true;
        }

        // 更新报文信息
        private void updateMessageIdMap(string dbcPath,List<BaseKeyModelOpe> baseKeyModelOpes)
        {
            Dictionary<uint, MessageAndSignalInfo> messageMap = new Dictionary<uint, MessageAndSignalInfo>();
            uint messageId = 0;
            foreach(BaseKeyModelOpe temp in baseKeyModelOpes)
            {
                messageId = Convert.ToUInt32(temp.GetSubKeyWordListMap()[Message.MESSAGE_ID_UINT][0]);
                if(messageMap.ContainsKey(messageId))
                {
                    continue;
                }
                MessageAndSignalInfo messageAndSignalInfo = new MessageAndSignalInfo();
                messageAndSignalInfo.MessageId = messageId;
                messageAndSignalInfo.MessageModel = temp;
                messageAndSignalInfo.SignalModelList = new List<BaseKeyModelOpe>();
                messageMap.Add(messageId, messageAndSignalInfo);
            }
            this._messageAndSignalInfoMap.Add(dbcPath, messageMap);
        }

        // 更新信号信息
        private void updateSignalMap(string dbcPath,List<BaseKeyModelOpe> baseKeyModelOpes)
        {
            string signalName = null;
            uint messageId = 0;
            if(this._messageAndSignalInfoMap.ContainsKey(dbcPath))
            {
                return;
            }
            foreach(BaseKeyModelOpe temp in baseKeyModelOpes)
            {
                signalName = temp.GetSubKeyWordListMap()[Signal.SIGNAL_NAME][0];
                messageId = Convert.ToUInt32(temp.GetSubKeyWordListMap()[Signal.MESSAGE_ID][0]);
                if(!this._messageAndSignalInfoMap[dbcPath].ContainsKey(messageId))
                {
                    continue;
                }
                MessageAndSignalInfo messageAndSignalInfo = this._messageAndSignalInfoMap[dbcPath][messageId];
                if(messageAndSignalInfo.SignalModelList == null)
                {
                    continue;
                }
                messageAndSignalInfo.SignalModelList.Add(temp);
                this.addSignalValueObjectToMap(signalName);
            }
        }
        // 向信号值列表中添加新的信号名
        private void addSignalValueObjectToMap(string signalName)
        {
            if(this._dataPool == null)
            {
                this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            }
            if(this._dataPool.SignalValueMap.ContainsKey(signalName))
            {
                return;
            }
            this._dataPool.SignalValueMap.Add(signalName, 0);
        }
        #endregion
        #region 解析报文操作
        /// <summary>
        /// 放置报文信息，通过放置报文信息操作后将会自动对报文数据进行解析。
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="Data"></param>
        public bool SetMessageInfo(uint messageId, byte[] data)
        {
            if(this._messageAndSignalInfoMap == null)
            {
                return false;
            }
            if(this._resultObjectOpe == null)
            {
                return false;
            }
            // 获取ID对应的路径信息
            string dbcPath = this._resultObjectOpe.GetDbcPathByMessageId(messageId);
            if(dbcPath == null)
            {
                return false;
            }
            // 获取MessageId对应的MessageAndSignalInfo对象
            if(!this._messageAndSignalInfoMap.ContainsKey(dbcPath))
            {
                return false;
            }
            if(!this._messageAndSignalInfoMap[dbcPath].ContainsKey(messageId))
            {
                return false;
            }
            // 将数组展开
            string messageDataStr = this.dataSpread(data);
            MessageAndSignalInfo messageAndSignalInfo = this._messageAndSignalInfoMap[dbcPath][messageId];
            //开始解析数据
            UInt64 signalValue = 0;
            List<BaseKeyModelOpe> signalInfoObj = messageAndSignalInfo.SignalModelList;
            foreach(BaseKeyModelOpe signalTemp in signalInfoObj)
            {
                UInt64 factor = Convert.ToUInt64(signalTemp.GetSubKeyWordListMap()[Signal.FACTOR][0]);
                UInt64 offset = Convert.ToUInt64(signalTemp.GetSubKeyWordListMap()[Signal.OFFSET][0]);
                int startBit = Convert.ToInt32(signalTemp.GetSubKeyWordListMap()[Signal.START_BIT][0]);
                int signalSize = Convert.ToInt32(signalTemp.GetSubKeyWordListMap()[Signal.SIGNAL_SIZE][0]);
                byte byteOrder = Convert.ToByte(signalTemp.GetSubKeyWordListMap()[Signal.BYTE_ORDER][0]);
                UInt64 rawValue = this.getRawValue(messageDataStr, startBit, signalSize, byteOrder);
                UInt64 physicalValue = rawValue * factor + offset;
                string signalName = signalTemp.GetSubKeyWordListMap()[Signal.SIGNAL_NAME][0];
                if (this._dataPool.SignalValueMap.ContainsKey(signalName))
                {
                    this._dataPool.SignalValueMap[signalName] = physicalValue;
                }
                else
                {
                    this._dataPool.SignalValueMap.Add(signalName, physicalValue);
                }
            }
            return true;
        }
        // 数据展开操作函数
        private string dataSpread(byte[] data)
        {
            StringBuilder strBuilder = new StringBuilder();
            int i,j;
            for(i=7;i>=0;i--)
            {
                string byteStr = Convert.ToString(data[i], 2);
                int oweZeroStrNum = 8 - byteStr.Length;
                for(j=0;j<oweZeroStrNum;j++)
                {
                    strBuilder.Append("0");
                }
                strBuilder.Append(Convert.ToString(data[i], 2));
            }
            return strBuilder.ToString();
        }
        // 根据信号信息获取报文中的值
        private UInt64 getRawValue(string data,int startBit, int signalSize, byte byteOrder)
        {
            UInt64 result = 0;
            switch (byteOrder)
            {
                case 0:
                    // Intel类型
                    result = this.getRawValueByIntelOrder(data,startBit,signalSize);
                    break;
                case 1:
                    // Motorola类型
                    result = this.getRawValueByMotorolaOrder(data,startBit,signalSize);
                    break;
            }
            return result;
        }
        // 从Intel类型的Can通信数据中获取未经处理的信号原始值
        private UInt64 getRawValueByIntelOrder(string data, int startBit, int signalSize)
        {
            /***
             * Intel类型跨字节时，高位放在高字节的高位，低位放在低字节的低位
             * */
            UInt64 result = 0;
            int startIndex = 64 - ((startBit + signalSize));
            string subData = data.Substring(startIndex,signalSize);
            result = Convert.ToUInt64(subData);
            return result;
        }
        // 从Motorola类型的Can通信数据中获取未经处理的信号原始值
        private UInt64 getRawValueByMotorolaOrder(string data, int startBit, int signalSize)
        {
            /***
             * Motorola类型跨字节时，高位放在低字节的高位，低位放在高字节的低位
             * */
            UInt64 result = 0;
            int i;
            int endBit = startBit - signalSize - 1;
            StringBuilder strBuilder = new StringBuilder();
            for(i=0;i<8;i++)
            {
                if(endBit > this.byteEndIndexArray[i])
                {
                    continue;
                }
                if(startBit < this.byteStartIndexArray[i])
                {
                    continue;
                }
                if(startBit >= this.byteStartIndexArray[i] && startBit <= this.byteEndIndexArray[i])
                {
                    strBuilder.Append(data.Substring((63 - this.byteEndIndexArray[i]), (this.byteEndIndexArray[i] - startBit + 1)));
                    continue;
                }
                if(endBit >= this.byteStartIndexArray[i] && endBit <= this.byteEndIndexArray[i])
                {
                    strBuilder.Append(data.Substring((63 - endBit), (endBit - this.byteStartIndexArray[i]) + 1));
                    continue;
                }
                strBuilder.Append(data.Substring((63 - this.byteEndIndexArray[i]), 8));
            }
            result = Convert.ToUInt64(strBuilder.ToString());
            return result;
        }
        #endregion
        #region 获取报文操作
        

        /// <summary>
        /// 通过报文ID来获取报文信息
        /// </summary>
        /// <param name="messageId">报文ID</param>
        /// <returns></returns>
        public byte[] GetMessage(uint messageId)
        {
            byte[] result = new byte[8];
            if(this._resultObjectOpe == null)
            {
                return result;
            }
            if(this._dataPool == null)
            {
                return result;
            }
            if(this._dataPool.MessageData == null)
            {
                return result;
            }
            if(this._dataPool.SignalValueMap == null)
            {
                return result;
            }
            // 获取Message信息对象
            string dbcPath = this._resultObjectOpe.GetDbcPathByMessageId(messageId);
            if(!this._messageAndSignalInfoMap.ContainsKey(dbcPath))
            {
                return result;
            }
            if(!this._messageAndSignalInfoMap[dbcPath].ContainsKey(messageId))
            {
                return result;
            }
            MessageAndSignalInfo messageInfo = this._messageAndSignalInfoMap[dbcPath][messageId];
            foreach(BaseKeyModelOpe signalTemp in messageInfo.SignalModelList)
            {
                this.setSignalRawValue(result, signalTemp);
            }
            return result;
        }
        // 向数据中写入参数
        private void setSignalRawValue(byte[] data, BaseKeyModelOpe signalInfo)
        {
            
            string signalName = signalInfo.GetSubKeyWordListMap()[Signal.SIGNAL_NAME][0];
            if (!this._dataPool.SignalValueMap.ContainsKey(signalName))
            {
                return;
            }
            int startBit = Convert.ToInt32(signalInfo.GetSubKeyWordListMap()[Signal.START_BIT][0]);
            int signalSize = Convert.ToInt32(signalInfo.GetSubKeyWordListMap()[Signal.SIGNAL_SIZE][0]);
            byte byteOrder = Convert.ToByte(signalInfo.GetSubKeyWordListMap()[Signal.BYTE_ORDER][0]);
            UInt64 factor = Convert.ToUInt64(signalInfo.GetSubKeyWordListMap()[Signal.FACTOR][0]);
            UInt64 offset = Convert.ToUInt64(signalInfo.GetSubKeyWordListMap()[Signal.OFFSET][0]);
            UInt64 minimum = Convert.ToUInt64(signalInfo.GetSubKeyWordListMap()[Signal.MINIMUM][0]);
            UInt64 maximum = Convert.ToUInt64(signalInfo.GetSubKeyWordListMap()[Signal.MAXIMUM][0]);
            UInt64 physicalValue = this._dataPool.SignalValueMap[signalName];
            UInt64 rawValue = (physicalValue - offset) / factor;
            switch(byteOrder)
            {
                case 0:
                    this.setRawValueByIntel(data, startBit, signalSize, rawValue);
                    break;
                case 1:
                    this.setRawValueByMotorola(data, startBit, signalSize, rawValue);
                    break;
            }
        }
        // 用Intel类型报文写入参数
        private void setRawValueByIntel(byte[] data, int startBit, int signalSize, UInt64 rawValue)
        {
            int i;
            int endBit = startBit + signalSize - 1;
            int moveBitNum = 0;
            UInt64 tempRawValue = rawValue;
            for (i=0;i<8;i++)
            {
                if(startBit >= this.byteEndIndexArray[i])
                {
                    continue;
                }
                if(endBit <= this.byteStartIndexArray[i])
                {
                    continue;
                }
                if(startBit >= this.byteStartIndexArray[i] && startBit <= this.byteEndIndexArray[i])
                {
                    moveBitNum = startBit - this.byteStartIndexArray[i];
                    data[i] = (byte)((data[i] & this.littleByteMarkArray[moveBitNum]) + (byte)(tempRawValue << moveBitNum));
                    tempRawValue = tempRawValue >> (8 - moveBitNum);
                    continue;
                }
                if(endBit >= this.byteStartIndexArray[i] && endBit <= this.byteEndIndexArray[i])
                {
                    moveBitNum = endBit - this.byteStartIndexArray[i] + 1;
                    data[i] = (byte)((data[i] & this.bigByteMarkArray[moveBitNum]) + (byte)(tempRawValue));
                    tempRawValue = tempRawValue >> moveBitNum;
                    continue;
                }
                data[i] = (byte)tempRawValue;
                tempRawValue = tempRawValue >> 8;
            }
        }

        // 用Motorola类型报文写入参数
        private void setRawValueByMotorola(byte[] data, int startBit, int signalSize, UInt64 rawValue)
        {
            int i;
            int endBit = startBit - signalSize - 1;
            int moveBitNum = 0;
            UInt64 tempRawValue = rawValue;
            for(i=7;i>=0;i--)
            {
                if(startBit <= this.byteStartIndexArray[i])
                {
                    continue;
                }
                if(endBit >= this.byteEndIndexArray[i])
                {
                    continue;
                }
                if(startBit >= this.byteStartIndexArray[i] && startBit <= this.byteEndIndexArray[i])
                {
                    moveBitNum = startBit - this.byteStartIndexArray[i];
                    data[i] = (byte)((data[i] & this.littleByteMarkArray[moveBitNum]) + (byte)(tempRawValue << moveBitNum));
                    tempRawValue = tempRawValue >> (8 - moveBitNum);
                    continue;
                }
                if(endBit >= this.byteStartIndexArray[i] && endBit <= this.byteEndIndexArray[i])
                {
                    moveBitNum = endBit - this.byteStartIndexArray[i] + 1;
                    data[i] = (byte)((data[i] & this.bigByteMarkArray[moveBitNum]) + (byte)(tempRawValue));
                    tempRawValue = tempRawValue >> moveBitNum;
                    continue;
                }
                data[i] = (byte)tempRawValue;
                tempRawValue = tempRawValue >> 8;
            }
        }
        #endregion
        
    }
}
