using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using DBCAnalysis.Result;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions
{
    public class ValueDescriptionsForSignalAanlysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions.ValueDescriptionsForSignalAanlysisMachine";

        private ValueDescriptionsForSignal _valueDescriptionsForSignal;
        private ResultObjectOpe _resultObjectOpe;
        private DbcAnalysisMachinePoolOpe _dbcAnalysisMachinePool;
        public ValueDescriptionsForSignalAanlysisMachine()
        {
            this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            this._dbcAnalysisMachinePool = BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>();
        }

        public override bool AnalysisExecute(string line)
        {
            // 创建新对象
            this._valueDescriptionsForSignal = new ValueDescriptionsForSignal();
            
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;

            // 清除关键字信息
            subLine = line.Replace(ValueDescriptionsForSignal.KEY_WORD, "");
            // 清除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            // 获取MessagId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            string messageId = subLine.Substring(subLineStartIndex, subLineStartLength);
            // 判断是否符合本解析器的条件。
            if(!this.judgeAnalysisMachine(messageId))
            {
                return false;
            }

            // 添加MessageId信息
            this._valueDescriptionsForSignal.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.MESSAGE_ID
                , new string[] { messageId});

            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._valueDescriptionsForSignal.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.SIGNAL_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            // 获取ValueDescription信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex,subLineStartLength));
            this._valueDescriptionsForSignal.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.VALUE_DESCRIPTION
                , subLine.Split(' '));
            return true;
        }

        private bool judgeAnalysisMachine(string messageId)
        {
            /***
             * 判断条件为，查看关键字后的第一个字段是否为MessageId
             * */
            if (this._resultObjectOpe == null)
            {
                return false;
            }
            if (this._dbcAnalysisMachinePool == null)
            {
                return false;
            }
            Dictionary<string,AnalysisMachine> analysisMachines = this._dbcAnalysisMachinePool.GetAnalysisMachine(Message.KEY_WORD);
            if (analysisMachines == null)
            {
                return false;
            }
            if(analysisMachines.Count < 1)
            {
                return false;
            }
            List<BaseKeyModelOpe> baseKeyModelOpes = this._resultObjectOpe
                .GetCurrentBaseKeyModelOpesByClassFullName(analysisMachines.Last().Value.GetClassFullName());
            foreach(BaseKeyModelOpe temp in baseKeyModelOpes)
            {
                if(!temp.GetSubKeyWordListMap().ContainsKey(Message.MESSAGE_ID))
                {
                    return false;
                }
                if (messageId.Equals(temp.GetSubKeyWordListMap()[Message.MESSAGE_ID][0]))
                {
                    return true;
                }
            }
            return false;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._valueDescriptionsForSignal;
        }

        public override string GetClassFullName()
        {
            return ValueDescriptionsForSignalAanlysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return ValueDescriptionsForSignal.KEY_WORD;
        }
    }
}
