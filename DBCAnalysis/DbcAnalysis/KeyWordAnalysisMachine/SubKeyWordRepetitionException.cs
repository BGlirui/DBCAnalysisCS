using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    public class SubKeyWordRepetitionException : ApplicationException
    {
        private static SubKeyWordRepetitionException _subKeyWordRepetitionException;
        public SubKeyWordRepetitionException() : base("子关键字在Map中重复")
        { }

        public static SubKeyWordRepetitionException GetSubKeyWordRepetitionException()
        {
            if(SubKeyWordRepetitionException._subKeyWordRepetitionException == null)
            {
                SubKeyWordRepetitionException._subKeyWordRepetitionException = new SubKeyWordRepetitionException();
            }
            return SubKeyWordRepetitionException._subKeyWordRepetitionException;
        }
    }
}
