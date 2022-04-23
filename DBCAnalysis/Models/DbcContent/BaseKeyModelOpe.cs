using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent
{
    public abstract class BaseKeyModelOpe : IBaseKeyModel
    {
        protected Dictionary<string, string[]> _subKeyWordListMap;
        public BaseKeyModelOpe()
        {
            this._subKeyWordListMap = new Dictionary<string, string[]>();
        }

        public Dictionary<string,string[]> GetSubKeyWordListMap()
        {
            return this._subKeyWordListMap;
        }

        public string[] GetSubKeyWordList(string subKeyWordName)
        {
            if(this._subKeyWordListMap.ContainsKey(subKeyWordName))
            {
                return this._subKeyWordListMap[subKeyWordName];
            }
            return null;
        }

        /// <summary>
        /// 判断Map中是否已经存在子关键字信息
        /// </summary>
        /// <param name="subKeyWordName">子关键字名称</param>
        /// <returns></returns>
        public bool HaveSubKeyWordListInMap(string subKeyWordName)
        {
            return this._subKeyWordListMap.ContainsKey(subKeyWordName);
        }

        public abstract string GetKeyWord();
    }
}
