using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.VersionAndNewSymbolSpecification;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.VersionAndNewSymbolSpecification
{
    // 该解析器将包括对空关键字信息的解析
    class NewSymbolAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.VersionAndNewSymbolSpecification.NewSymbolAnalysisMachine";

        private NewSymbol _newSymbol;
        private NullKeyWordAnalysisMachine _nullKeyWordAnalysisMachine;

        #region 接口函数
        public override bool AnalysisExecute(string line)
        {
            // 该关键字需要解析空关键字子内容，需要给NullKeyWordAnalysisMachine解析
            if(this._nullKeyWordAnalysisMachine == null)
            {
                this._nullKeyWordAnalysisMachine = BeanOpe.GetBeanOpe().GetObject<NullKeyWordAnalysisMachine>();
            }
            this._nullKeyWordAnalysisMachine.SetFatherKeyWordFlag(NewSymbol.KEY_WORD);
            return true;
        }

        public new bool HaveSubNullKeyWordString()
        {
            return true;
        }

        public new bool NullKeyWordAnalysis(string line)
        {
            /***
             * 1. 因为子关键字对应的内容都为固定内容，所以依次解析字符即可
             * */
            if (Regex.IsMatch(line, NewSymbol.BA_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_, new string[] { NewSymbol.BA_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_DEF_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_DEF_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_DEF_, new string[] { NewSymbol.BA_DEF_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_DEF_DEF_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_DEF_DEF_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_DEF_DEF_, new string[] { NewSymbol.BA_DEF_DEF_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_DEF_DEF_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_DEF_DEF_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_DEF_DEF_REL_, new string[] { NewSymbol.BA_DEF_DEF_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_DEF_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_DEF_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_DEF_REL_, new string[] { NewSymbol.BA_DEF_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_DEF_SGTYPE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_DEF_SGTYPE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_DEF_SGTYPE_, new string[] { NewSymbol.BA_DEF_SGTYPE_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_REL_, new string[] { NewSymbol.BA_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BA_SGTYPE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BA_SGTYPE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BA_SGTYPE_, new string[] { NewSymbol.BA_SGTYPE_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BO_TX_BU_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BO_TX_BU_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BO_TX_BU_, new string[] { NewSymbol.BO_TX_BU_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BU_BO_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BU_BO_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BU_BO_REL_, new string[] { NewSymbol.BU_BO_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BU_EV_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BU_EV_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BU_EV_REL_, new string[] { NewSymbol.BU_EV_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.BU_SG_REL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.BU_SG_REL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.BU_SG_REL_, new string[] { NewSymbol.BU_SG_REL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.CAT_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.CAT_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.CAT_, new string[] { NewSymbol.CAT_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.CAT_DEF_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.CAT_DEF_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.CAT_DEF_, new string[] { NewSymbol.CAT_DEF_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.CM_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.CM_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.CM_, new string[] { NewSymbol.CM_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.ENVVAR_DATA_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.ENVVAR_DATA_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.ENVVAR_DATA_, new string[] { NewSymbol.ENVVAR_DATA_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.EV_DATA_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.EV_DATA_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.EV_DATA_, new string[] { NewSymbol.EV_DATA_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.FILTER))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.FILTER))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.FILTER, new string[] { NewSymbol.FILTER });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SGTYPE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SGTYPE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SGTYPE_, new string[] { NewSymbol.SGTYPE_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SGTYPE_VAL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SGTYPE_VAL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SGTYPE_VAL_, new string[] { NewSymbol.SGTYPE_VAL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SIGTYPE_VALTYPE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SIGTYPE_VALTYPE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SIGTYPE_VALTYPE_, new string[] { NewSymbol.SIGTYPE_VALTYPE_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SIG_GROUP_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SIG_GROUP_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SIG_GROUP_, new string[] { NewSymbol.SIG_GROUP_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SIG_TYPE_REF_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SIG_TYPE_REF_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SIG_TYPE_REF_, new string[] { NewSymbol.SIG_TYPE_REF_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.SIG_VALTYPE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.SIG_VALTYPE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.SIG_VALTYPE_, new string[] { NewSymbol.SIG_VALTYPE_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.VAL_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.VAL_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.VAL_, new string[] { NewSymbol.VAL_ });
                }
            }
            if (Regex.IsMatch(line, NewSymbol.VAL_TABLE_))
            {
                if (!this._newSymbol.HaveSubKeyWordListInMap(NewSymbol.VAL_TABLE_))
                {
                    this._newSymbol.GetSubKeyWordListMap().Add(NewSymbol.VAL_TABLE_, new string[] { NewSymbol.VAL_TABLE_ });
                }
            }
            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._newSymbol;
        }

        public override string GetClassFullName()
        {
            return NewSymbolAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return NewSymbol.KEY_WORD;
        }
        #endregion
    }
}
