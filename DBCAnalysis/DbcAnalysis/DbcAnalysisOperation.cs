using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using DBCAnalysis.Models.Result;
using DBCAnalysis.Result;

namespace DBCAnalysis.DbcAnalysis
{
    public class DbcAnalysisOperation : IDbcAnalysis
    {
        private ResultObjectOpe _resultObjectOpe;
        private DbcAnalysisMachinePoolOpe _dbcAnalysisMachinePool;
        private Regex _regex;
        public DbcAnalysisOperation()
        {
            this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            this._dbcAnalysisMachinePool = BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>();
            this._regex = new Regex("[\\s]+");
        }

        /// <summary>
        /// 对行信息列表进行解析，并返回结果对象
        /// </summary>
        /// <param name="lineMessageList">包含DBC文本信息的行信息列表</param>
        /// <returns>解析结果对象</returns>
        public bool DbcMessageAnalysisToResultObject(string dbcPath, List<string> lineMessageList)
        {
            if(!this.isLoadedBean())
            {
                return false;
            }
            /* 创建结果对象 */
            ResultObject resultObject = new ResultObject();
            /* 将结果对象添加到结果集中 */
            this._resultObjectOpe.SetResultObject(dbcPath, resultObject);
            /* 开始解析 */
            if(!this.analysisMineLoop(lineMessageList))
            {
                return false;
            }
            /* 解析结束清除结果集设置标志*/
            this._resultObjectOpe.CloseCurrentResultObjectOpe();
            return true;
        }

        /// <summary>
        /// 循环解析DBC文件中每行内容
        /// </summary>
        /// <param name="lineMessageList">DBC文件的行信息</param>
        /// <returns>解析结果</returns>
        private bool analysisMineLoop(List<string> lineMessageList)
        {
            if(lineMessageList == null)
            {
                return false;
            }
            if(lineMessageList.Count < 1)
            {
                return false;
            }
            foreach(string line in lineMessageList)
            {
                analysisLineMessage(line);
            }

            return true;
        }

        /// <summary>
        /// 解析单行文本信息
        /// </summary>
        /// <param name="line">行文本信息</param>
        /// <returns></returns>
        private bool analysisLineMessage(string line)
        {
            string subLine = null;
            BaseKeyModelOpe baseKeyModelOpe = null;
            // 将多空格全部转换为单空格
            subLine = this._regex.Replace(line," ");
            // 清除首尾空字符
            subLine = this.removeBlankWithStartAndEnd(subLine);
            if("".Equals(subLine))
            {
                return true;
            }
            // 获取关键字
            string keyWord = this.getKeyWordByLine(line);
            if(keyWord == null)
            {
                return true;
            }
            // 循环解析
            Dictionary<string,AnalysisMachine> analysisMachineList = this._dbcAnalysisMachinePool.GetAnalysisMachine(keyWord);
            if(analysisMachineList == null)
            {
                return true;
            }
            foreach(KeyValuePair<string,AnalysisMachine> analysisMachineTemp in analysisMachineList)
            {
                if(analysisMachineTemp.Value.AnalysisExecute(subLine))
                {
                    baseKeyModelOpe = analysisMachineTemp.Value.GetBaseKeyModelOpe();
                    
                    break;
                }
            }
            // 添加结果信息
            if(baseKeyModelOpe == null)
            {
                return false;
            }
            this._resultObjectOpe.AddBaseKeyModel(baseKeyModelOpe);
            // 判断关键字是否为Message相关的，如果相关则将MessageId设置到到结果对象池中，使MessageId信息和Dbc文件名信息关联在一起
            if (Message.KEY_WORD.Equals(keyWord))
            {
                this._resultObjectOpe.AddMessageId(Convert.ToUInt32(baseKeyModelOpe.GetSubKeyWordListMap()[Message.MESSAGE_ID_UINT][0]));
            }
            return true;
        }

        // 获取关键字
        private string getKeyWordByLine(string line)
        {
            int subLineStartIndex = 0;
            int subLineStartLength = line.IndexOf(' ');
            if(subLineStartLength < 0)
            {
                return NullKeyWordString.KEY_WORD;
            }
            string subLine = line.Substring(subLineStartIndex, subLineStartLength);
            return subLine.Replace(":", "");
        }

        // 移除首尾空字符
        private string removeBlankWithStartAndEnd(string line)
        {
            return line.Trim();
        }

        // 判断是否以加载所有需要的Bean
        private bool isLoadedBean()
        {
            if(this._resultObjectOpe == null)
            {
                return false;
            }
            if(this._dbcAnalysisMachinePool == null)
            {
                return false;
            }
            return true;
        }
        
    }
}
