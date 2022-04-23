using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.VersionAndNewSymbolSpecification
{
    /// <summary>
    /// 存储了NeySymbol信息. 格式模板为：new_symbols = [ '_NS' ':' ['CM_'] ['BA_DEF_'] ['BA_'] ['VAL_']
    ///                                                ['CAT_DEF_'] ['CAT_'] ['FILTER'] ['BA_DEF_DEF_'] ['EV_DATA_']
    ///                                                ['ENVVAR_DATA_'] ['SGTYPE_'] ['SGTYPE_VAL_'] ['BA_DEF_SGTYPE_']
    ///                                                ['BA_SGTYPE_'] ['SIG_TYPE_REF_'] ['VAL_TABLE_'] ['SIG_GROUP_']
    ///                                                ['SIG_VALTYPE_'] ['SIGTYPE_VALTYPE_'] ['BO_TX_BU_']
    ///                                                ['BA_DEF_REL_'] ['BA_REL_'] ['BA_DEF_DEF_REL_'] ['BU_SG_REL_']
    ///                                                ['BU_EV_REL_'] ['BU_BO_REL_'] ];
    /// </summary>
    class NewSymbol : BaseKeyModelOpe
    {
        #region 关键字
        /// <summary>
        /// NewSymbol的关键字,实际与文档中描述不一致
        /// </summary>
        public const string KEY_WORD = "NS_";
        /// <summary>
        /// CM_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string CM_ = "CM_";
        /// <summary>
        /// BA_DEF_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_DEF_ = "BA_DEF_";
        /// <summary>
        /// BA_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_ = "BA_";
        /// <summary>
        /// VAL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string VAL_ = "VAL_";
        /// <summary>
        /// CAT_DEF_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string CAT_DEF_ = "CAT_DEF_";
        /// <summary>
        /// CAT_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string CAT_ = "CAT_";
        /// <summary>
        /// FILTER关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string FILTER = "FILTER";
        /// <summary>
        /// BA_DEF_DEF_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_DEF_DEF_ = "BA_DEF_DEF_";
        /// <summary>
        /// EV_DATA_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string EV_DATA_ = "EV_DATA_";
        /// <summary>
        /// ENVVAR_DATA_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string ENVVAR_DATA_ = "ENVVAR_DATA_";
        /// <summary>
        /// SGTYPE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SGTYPE_ = "SGTYPE_";
        /// <summary>
        /// SGTYPE_VAL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SGTYPE_VAL_ = "SGTYPE_VAL_";
        /// <summary>
        /// BA_DEF_SGTYPE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_DEF_SGTYPE_ = "BA_DEF_SGTYPE_";
        /// <summary>
        /// BA_SGTYPE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_SGTYPE_ = "BA_SGTYPE_";
        /// <summary>
        /// SIG_TYPE_REF_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SIG_TYPE_REF_ = "SIG_TYPE_REF_";
        /// <summary>
        /// VAL_TABLE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string VAL_TABLE_ = "VAL_TABLE_";
        /// <summary>
        /// SIG_GROUP_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SIG_GROUP_ = "SIG_GROUP_";
        /// <summary>
        /// SIG_VALTYPE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SIG_VALTYPE_ = "SIG_VALTYPE_";
        /// <summary>
        /// SIGTYPE_VALTYPE_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string SIGTYPE_VALTYPE_ = "SIGTYPE_VALTYPE_";
        /// <summary>
        /// BO_TX_BU_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BO_TX_BU_ = "BO_TX_BU_";
        /// <summary>
        /// BA_DEF_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_DEF_REL_ = "BA_DEF_REL_";
        /// <summary>
        /// BA_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_REL_ = "BA_REL_";
        /// <summary>
        /// BA_DEF_DEF_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BA_DEF_DEF_REL_ = "BA_DEF_DEF_REL_";
        /// <summary>
        /// BU_SG_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BU_SG_REL_ = "BU_SG_REL_";
        /// <summary>
        /// BU_EV_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BU_EV_REL_ = "BU_EV_REL_";
        /// <summary>
        /// BU_BO_REL_关键字，该关键字可以出现零次或一次
        /// </summary>
        public const string BU_BO_REL_ = "BU_BO_REL_";

        public override string GetKeyWord()
        {
            return NewSymbol.KEY_WORD;
        }
        #endregion
    }
}
