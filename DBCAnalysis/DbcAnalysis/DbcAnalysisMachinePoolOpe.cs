using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.VersionAndNewSymbolSpecification;

namespace DBCAnalysis.DbcAnalysis
{
    public class DbcAnalysisMachinePoolOpe
    {
        private Dictionary<string, Dictionary<string,AnalysisMachine>> _analysisMachineMap = new Dictionary<string, Dictionary<string, AnalysisMachine>>();
        
        /// <summary>
        /// 注册解析器
        /// </summary>
        /// <param name="analysisMachine"></param>
        public void RegisterAnalysisMachine(AnalysisMachine analysisMachine)
        {
            // 添加关键字对应的解析器到Map中
            if(!this._analysisMachineMap.ContainsKey(analysisMachine.GetKeyWord()))
            {
                this._analysisMachineMap.Add(analysisMachine.GetKeyWord(), new Dictionary<string, AnalysisMachine>());
            }
            if(!this._analysisMachineMap[analysisMachine.GetKeyWord()].ContainsKey(analysisMachine.GetClassFullName()))
            {
                this._analysisMachineMap[analysisMachine.GetKeyWord()].Add(analysisMachine.GetClassFullName(), analysisMachine);
            }
            // 注册空关键字子行信息
            if(!analysisMachine.HaveSubNullKeyWordString())
            {
                return;
            }
            NullKeyWordAnalysisMachine nullKeyWordAnalysisMachine = null;
            if (this._analysisMachineMap.ContainsKey(NullKeyWordString.KEY_WORD))
            {
                nullKeyWordAnalysisMachine = new NullKeyWordAnalysisMachine();
                this._analysisMachineMap.Add(NullKeyWordString.KEY_WORD, new Dictionary<string, AnalysisMachine>());
                this._analysisMachineMap[NullKeyWordString.KEY_WORD].Add(nullKeyWordAnalysisMachine.GetClassFullName(), nullKeyWordAnalysisMachine);
            }
            nullKeyWordAnalysisMachine.RegisterFatherKeyWordAnalysisMachine(analysisMachine);
        }

        /// <summary>
        /// 移除已注册的解析器对象
        /// </summary>
        /// <typeparam name="TAnalysisMachine"></typeparam>
        public void RemoveAnalysisMachine(IAnalysisMachine analysisMachine)
        {
            if(!this._analysisMachineMap.ContainsKey(analysisMachine.GetKeyWord()))
            {
                return;
            }
            if(!this._analysisMachineMap[analysisMachine.GetKeyWord()].ContainsKey(analysisMachine.GetClassFullName()))
            {
                return;
            }
            this._analysisMachineMap[analysisMachine.GetKeyWord()].Remove(analysisMachine.GetClassFullName());
        }

        /// <summary>
        /// 判断关键字是否已经注册
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public bool IsRegistered(string keyWord)
        {
            return this._analysisMachineMap.ContainsKey(keyWord);
        }

        /// <summary>
        /// 获取所有已注册解析器对象的类全名
        /// </summary>
        /// <returns>获取到的类全名列表</returns>
        public List<string> GetAllRegisteredAnalysisMachineClassFullName()
        {
            List<string> result = new List<string>();
            foreach(KeyValuePair<string,Dictionary<string,AnalysisMachine>> kvp in this._analysisMachineMap)
            {
                foreach(KeyValuePair<string,AnalysisMachine> temp in kvp.Value)
                {
                    result.Add(temp.Key);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取所有已注册解析器对象的类名
        /// </summary>
        /// <returns>获取到的类名列表</returns>
        public List<string> GetAllRegisteredAnalysisMachineClassName()
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, Dictionary<string,AnalysisMachine>> kvp in this._analysisMachineMap)
            {
                foreach (KeyValuePair<string,AnalysisMachine> temp in kvp.Value)
                {
                    result.Add(temp.Value.GetType().Name);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取关键字对应解析器的列表，因为存在重复的关键字，因此需要以列表的形式返回。当关键字未注册时将返回null
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public Dictionary<string,AnalysisMachine> GetAnalysisMachine(string keyWord)
        {
            if(this._analysisMachineMap.ContainsKey(keyWord))
            {
                return this._analysisMachineMap[keyWord];
            }
            return null;
        }
    }
}
