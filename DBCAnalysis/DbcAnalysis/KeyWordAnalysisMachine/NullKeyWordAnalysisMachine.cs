using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    class NullKeyWordAnalysisMachine : AnalysisMachine
    {
        private NullKeyWordString _nullKeyWordString;
        private Dictionary<string, bool> _fatherKeyWordFlagMap = new Dictionary<string, bool>();
        private Dictionary<string, AnalysisMachine> _fatherAnalysisMachineMap = new Dictionary<string, AnalysisMachine>();

        // 设置父类标志
        public void SetFatherKeyWordFlag(string fatherKeyWord)
        {
            foreach(KeyValuePair<string,bool> kvp in this._fatherKeyWordFlagMap)
            {
                this._fatherKeyWordFlagMap[kvp.Key] = false;
            }
            if(this._fatherKeyWordFlagMap.ContainsKey(fatherKeyWord))
            {
                this._fatherKeyWordFlagMap[fatherKeyWord] = true;
            }
        }

        // 注册父类解析器
        public void RegisterFatherKeyWordAnalysisMachine(AnalysisMachine fatherKeyWordAnalysisMachine)
        {
            if(this._fatherAnalysisMachineMap.ContainsKey(fatherKeyWordAnalysisMachine.GetKeyWord()))
            {
                this._fatherAnalysisMachineMap.Remove(fatherKeyWordAnalysisMachine.GetKeyWord());
            }
            if(this._fatherKeyWordFlagMap.ContainsKey(fatherKeyWordAnalysisMachine.GetKeyWord()))
            {
                this._fatherKeyWordFlagMap.Remove(fatherKeyWordAnalysisMachine.GetKeyWord());
            }
            this._fatherAnalysisMachineMap.Add(fatherKeyWordAnalysisMachine.GetKeyWord(), fatherKeyWordAnalysisMachine);
            this._fatherKeyWordFlagMap.Add(fatherKeyWordAnalysisMachine.GetKeyWord(), false);
        }

        // 执行解析
        public override bool AnalysisExecute(string line)
        {
            string fatherKeyWord = null;
            foreach(KeyValuePair<string,bool> kvp in this._fatherKeyWordFlagMap)
            {
                if(kvp.Value)
                {
                    fatherKeyWord = kvp.Key;
                    break;
                }
            }
            if(fatherKeyWord == null)
            {
                return false;
            }
            if(this._fatherAnalysisMachineMap.ContainsKey(fatherKeyWord))
            {
                return false;
            }
            this._fatherAnalysisMachineMap[fatherKeyWord].AnalysisExecute(line);
            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._nullKeyWordString;
        }

        public override string GetClassFullName()
        {
            if (this._nullKeyWordString == null)
            {
                this._nullKeyWordString = new NullKeyWordString();
            }
            return this._nullKeyWordString.GetType().FullName;
        }

        public override string GetKeyWord()
        {
            return NullKeyWordString.KEY_WORD;
        }
    }
}
