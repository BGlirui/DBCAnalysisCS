using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.FileOpen
{
    interface IOpen
    {
        List<String> GetListMessageByPath(string path);
    }
}
