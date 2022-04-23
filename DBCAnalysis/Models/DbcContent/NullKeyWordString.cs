using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent
{
    class NullKeyWordString : BaseKeyModelOpe
    {
        public const string KEY_WORD = "NullKeyWordString";
        public override string GetKeyWord()
        {
            return NullKeyWordString.KEY_WORD;
        }
    }
}
