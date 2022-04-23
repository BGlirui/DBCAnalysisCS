using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.BitTimingDefinition;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.BitTimingDefinition
{
    public class BitTimingAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.BitTimingDefinition.BitTimingAnalysisMachine";

        private BitTiming _bitTiming;
        

        #region 接口函数
        public override bool AnalysisExecute(string line)
        {
            this._bitTiming = new BitTiming();
            
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(BitTiming.KEY_WORD, "");
            // 去除关键字后的“：”
            subLineStartIndex = subLine.IndexOf(':') + 1;
            subLine = subLine.Substring(subLineStartIndex);
            // 去除首尾关键字
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取baudrate信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(':') - subLineStartIndex;
            this._bitTiming.GetSubKeyWordListMap().Add(BitTiming.BAUDRATE, new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取BTR1信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(',', subLineStartIndex) - subLineStartIndex;
            this._bitTiming.GetSubKeyWordListMap().Add(BitTiming.BTR1, new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取BTR2信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = 0;
            this._bitTiming.GetSubKeyWordListMap().Add(BitTiming.BTR2, new string[] { subLine.Substring(subLineStartIndex) });
            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._bitTiming;
        }

        public override string GetClassFullName()
        {
            return BitTimingAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return BitTiming.KEY_WORD;
        }
        #endregion
    }
}
