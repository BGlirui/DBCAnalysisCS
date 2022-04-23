using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.DbcAnalysis;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine;
using DBCAnalysis.FileOpen;
using DBCAnalysis.Models.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis
{
    public class DbcFileAnalysis
    {
        private HashSet<string> _dbcFilePaths = new HashSet<string>();
        private OpenFileByStreamReader _openFileByStreamReader;
        private DbcAnalysisOperation _dbcAnalysisOperation;
        private DbcAnalysisMachinePoolOpe _dbcAnalysisMachinePool;

        public DbcFileAnalysis()
        {
            this._openFileByStreamReader = BeanOpe.GetBeanOpe().GetObject<OpenFileByStreamReader>();
            this._dbcAnalysisOperation = BeanOpe.GetBeanOpe().GetObject<DbcAnalysisOperation>();
            this._dbcAnalysisMachinePool = BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>();
        }

        public bool SetAnalysisMachine(AnalysisMachine analysisMachine)
        {
            this._dbcAnalysisMachinePool.RegisterAnalysisMachine(analysisMachine);
            return true;
        }

        /// <summary>
        /// 设置DBC文件路径
        /// </summary>
        /// <param name="dbcFilePath"></param>
        public bool SetDbcFile(string dbcFilePath)
        {
            // 判断文件是否为DBC文件
            if(!dbcFilePath.EndsWith(".dbc"))
            {
                return false;
            }
            // 判断路径对应的文件是否存在
            if(!File.Exists(dbcFilePath))
            {
                return false;
            }
            // 添加到DBC文件路径集合，如果重复则忽略
            if(this._dbcFilePaths.Contains(dbcFilePath))
            {
                return false;
            }
            this._dbcFilePaths.Add(dbcFilePath);
            return true;
        }

        public bool Execute()
        {
            /***
             * 注意：所有已加载路径的DBC文件为循环执行
             * 1. 设置解析器
             * 2. 循环开始
             * 3. 将路径对应的DBC文件转换为文本信息列表
             * 4. 开始解析
             * */

            // 设置解析器
            this.setDefaultAnalysisMachine();

            if(this._openFileByStreamReader == null)
            {
                return false;
            }
            foreach(string dbcFilePath in this._dbcFilePaths)
            {
                //将路径对应的DBC文件转换为文本信息列表
                List<string> dbcMessage = this._openFileByStreamReader.GetListMessageByPath(dbcFilePath);
                //开始解析
                this._dbcAnalysisOperation.DbcMessageAnalysisToResultObject(dbcFilePath, dbcMessage);
            }
            return true;
        }

        private void setDefaultAnalysisMachine()
        {
            // 注册节点相关解析器
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetNodeAnalysisMachine());
            // 注册消息相关解析器
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetMessageAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetMessageTransmitterAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetSignalAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetSignalExtendedValueTypeListAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetValueDescriptionsForSignalAanlysisMachine());
            // 注册注释信息相关解析器
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetCommentAnalysisMachine());
            // 注册属性相关解析器
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetAttributeDefaultAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetAttributeDefinitionAnalysisMachine());
            this.SetAnalysisMachine(QueryAnalysisMachineObject.GetAttributeValueForObjectAnalysisMachine());
        }
    }
}
