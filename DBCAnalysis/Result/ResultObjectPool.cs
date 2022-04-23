using DBCAnalysis.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Result
{
    class ResultObjectPool
    {
        
        private Dictionary<string ,ResultObject> _resultObjectMap = new Dictionary<string, ResultObject>();
        /// <summary>
        /// 结果集池，其中键为DBC文件路径信息，值为结果集
        /// </summary>
        public Dictionary<string, ResultObject> ResultObjectMap
        {
            get { return _resultObjectMap; }
            set { _resultObjectMap = value; }
        }

        private Dictionary<uint,string> dbcAndMessageIdMap = new Dictionary<uint, string>();
        /// <summary>
        /// DBC文件路径和MessageId的映射关系。
        /// </summary>
        public Dictionary<uint, string> DbcAndMessageIdMap
        {
            get { return dbcAndMessageIdMap; }
            set { dbcAndMessageIdMap = value; }
        }


    }
}
