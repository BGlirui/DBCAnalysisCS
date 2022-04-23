using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Result
{
    class ResultObjectOpe
    {
        private ResultObjectPool _resultObjectPool = new ResultObjectPool();
        private ResultObject _resultObject;
        private string _dbcPath;
        private bool _setResultObjectFlag = false;

        /// <summary>
        /// 设置结果集对象
        /// </summary>
        /// <param name="dbcPath">DBC文件路径</param>
        /// <param name="resultObject">结果集对象</param>
        public void SetResultObject(string dbcPath,ResultObject resultObject)
        {
            this._resultObject = resultObject;
            this._dbcPath = dbcPath;
            this._setResultObjectFlag = true;
        }


        /// <summary>
        /// 关闭结果集标志
        /// </summary>
        public void CloseCurrentResultObjectOpe()
        {
            this._resultObjectPool.ResultObjectMap.Add(this._dbcPath,this._resultObject);
            this._resultObject = null;
            this._setResultObjectFlag = false;
        }
        
        /// <summary>
        /// 向当前结果集对象中添加基础关键模型
        /// </summary>
        /// <param name="baseKeyModel">基础关键模型</param>
        /// <returns></returns>
        public bool AddBaseKeyModel(BaseKeyModelOpe baseKeyModel)
        {
            if(!this._setResultObjectFlag)
            {
                return false;
            }
            if(this._resultObject == null)
            {
                return false;
            }
            if(!this._resultObject.BaseKeyModelOpeMap.ContainsKey(baseKeyModel.GetType().FullName))
            {
                this._resultObject.BaseKeyModelOpeMap.Add(baseKeyModel.GetType().FullName, new List<BaseKeyModelOpe>());
            }
            this._resultObject.BaseKeyModelOpeMap[baseKeyModel.GetType().FullName].Add(baseKeyModel);
            return true;
        }

        /// <summary>
        /// 设置MessageId和DBC文件路径的关联项
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public bool AddMessageId(uint messageId)
        {
            if (this._setResultObjectFlag)
            {
                return false;
            }
            if (this._resultObjectPool == null)
            {
                return false;
            }
            if (this._dbcPath == null)
            {
                return false;
            }
            if (this._resultObjectPool.DbcAndMessageIdMap.ContainsKey(messageId))
            {
                return false;
            }
            this._resultObjectPool.DbcAndMessageIdMap.Add(messageId, this._dbcPath);
            return true;
        }

        /// <summary>
        /// 通过MessageId获取Dbc文件路径信息
        /// </summary>
        /// <param name="messageId">报文Id</param>
        /// <returns></returns>
        public string GetDbcPathByMessageId(uint messageId)
        {
            if (this._setResultObjectFlag)
            {
                return null;
            }
            if (this._resultObjectPool == null)
            {
                return null;
            }
            if (this._resultObjectPool.DbcAndMessageIdMap.ContainsKey(messageId))
            {
                return this._resultObjectPool.DbcAndMessageIdMap[messageId];
            }
            return null;
        }

        /// <summary>
        /// 获取所有结果集
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,ResultObject> GetAllResultObject()
        {
            return this._resultObjectPool.ResultObjectMap;
        }

        /// <summary>
        /// 根据DBC文件路径名获取DBC解析结果集
        /// </summary>
        /// <param name="path">DBC文件路径名</param>
        /// <returns></returns>
        public ResultObject GetResultObjectByFilePath(string path)
        {
            if(this._resultObjectPool.ResultObjectMap.ContainsKey(path))
            {
                return this._resultObjectPool.ResultObjectMap[path];
            }
            return null;
        }
        

        /// <summary>
        /// 根据结果集对象以及类名对象来获取结果集中对应的列表集合。
        /// </summary>
        /// <param name="resultObject">结果集对象</param>
        /// <param name="classFullName">类全名</param>
        /// <returns></returns>
        public List<BaseKeyModelOpe> GetBaseKeyModelOpesByClassFullName(ResultObject resultObject, string classFullName)
        {
            if (_resultObject.BaseKeyModelOpeMap.ContainsKey(classFullName))
            {
                return _resultObject.BaseKeyModelOpeMap[classFullName];
            }
            return null;
        }

        /// <summary>
        /// 根据类BaseKeyModelOpe对象的类全名来获取当前被执行结果集中对应的列表集合，该方法在解析过程中使用，在操作结果集时将不使用。
        /// </summary>
        /// <param name="classFullName">类全名</param>
        /// <returns></returns>
        public List<BaseKeyModelOpe> GetCurrentBaseKeyModelOpesByClassFullName(string classFullName)
        {
            if (this._resultObject.BaseKeyModelOpeMap.ContainsKey(classFullName))
            {
                return this._resultObject.BaseKeyModelOpeMap[classFullName];
            }
            return null;
        }

        /// <summary>
        /// 获取当前结果集对象
        /// </summary>
        /// <returns></returns>
        public ResultObject GetCurrentResultObject()
        {
            return this._resultObject;
        }

    }
}
