using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.BitTimingDefinition
{
    public class BitTiming : BaseKeyModelOpe
    {
        /// <summary>
        /// BitTiming的关键字
        /// </summary>
        public const string KEY_WORD = "BS_";

        /// <summary>
        /// baudrate字段，该字段可以出现零次或一次，类型为unsigned integer
        /// </summary>
        public const string BAUDRATE = "baudrate";
        /// <summary>
        /// BTR1字段，该字段可以出现零次或一次，类型为unsigned integer
        /// </summary>
        public const string BTR1 = "BTR1";
        /// <summary>
        /// BTR2字段，该字段可以出现零次或一次，类型为unsigned integer
        /// </summary>
        public const string BTR2 = "BTR2";

        public override string GetKeyWord()
        {
            return BitTiming.KEY_WORD;
        }
    }
}
