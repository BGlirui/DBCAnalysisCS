using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.FileOpen
{
    class OpenFileByStreamReader:IOpen
    {
        public List<string> GetListMessageByPath(string path)
        {
            List<string> result = new List<string>();
            StreamReader streamReader = new StreamReader(path);
            string line;
            while((line = streamReader.ReadLine()) != null)
            {
                result.Add(line);
            }
            streamReader.Close();
            return result;
        }
    }
}
