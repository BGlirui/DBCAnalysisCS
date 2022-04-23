using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions
{
    public class MessageAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions.MessageAnalysisMachine";

        private Message _message;
        private List<string> _signalList = new List<string>();

        public override bool AnalysisExecute(string line)
        {
            /* Signal子关键字将在Signal类中进行获取，但是装载是在本类中进行，装载旧SignalName信息需要在初始化新Message对象之前完成，
               装载完旧SignalNam后需要清空signalList*/
            if(this._message != null)
            {
                string[] signalArray = this._signalList.ToArray();
                this._message.GetSubKeyWordListMap().Add(Message.SIGNAL, signalArray);
                this._signalList.Clear();
            }

            // 初始化Message对象
            this._message = new Message();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(Message.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取MessageId相关内容
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ',subLineStartIndex) - subLineStartIndex;
            string canIdStr = subLine.Substring(subLineStartIndex, subLineStartLength);
            this._message.GetSubKeyWordListMap().Add(Message.MESSAGE_ID, new string[] { canIdStr });
            // 将MessageId转换为uint格式的字符串
            uint canIdUint = Convert.ToUInt32(canIdStr);
            bool extendFlag = false;
            if((canIdUint&0x80000000)>0)
            {
                /* 如果最高位为1则为扩展帧 */
                extendFlag = true;
                canIdUint = canIdUint & 0x7FFFFFFF;
            }
            this._message.GetSubKeyWordListMap().Add(Message.MESSAGE_ID_EXTEND_FLAG, new string[] { extendFlag.ToString() });
            this._message.GetSubKeyWordListMap().Add(Message.MESSAGE_ID_UINT, new string[] { canIdUint.ToString() });
            // 获取MessageName相关内容
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._message.GetSubKeyWordListMap().Add(Message.MESSAGE_NAME, new string[] { subLine.Substring(subLineStartIndex, subLineStartLength).Replace(" ","") });
            // 获取MessageSize相关内容
            subLineStartIndex = subLine.IndexOf(':', subLineStartIndex) + 1;
            subLine = subLine.Substring(subLineStartIndex);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._message.GetSubKeyWordListMap().Add(Message.MESSAGE_SIZE, new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取Transmitter相关内容
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._message.GetSubKeyWordListMap().Add(Message.TRANSMITTER, new string[] { subLine.Substring(subLineStartIndex) });
            
            return true;
        }


        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._message;
        }

        public void AddSignalToList(string signalName)
        {
            this._signalList.Add(signalName);
        }

        public string GetMessageIdUint()
        {
            return this._message.GetSubKeyWordListMap()[Message.MESSAGE_ID_UINT][0];
        }

        public override string GetKeyWord()
        {
            return Message.KEY_WORD;
        }

        public override string GetClassFullName()
        {
            return MessageAnalysisMachine.CLASS_FULL_NAME;
        }
    }
}
