using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Core.BeanManage
{
    class BeanOpe
    {
        private static BeanOpe BEAN_OPE;
        private BeanPool _beanPool;
        public BeanOpe()
        {
            this._beanPool = new BeanPool();
        }

        #region 获取ObjectPool对象
        public static BeanOpe GetBeanOpe()
        {
            if (BeanOpe.BEAN_OPE == null)
            {
                BeanOpe.BEAN_OPE = new BeanOpe();
            }
            return BeanOpe.BEAN_OPE;
        }
        #endregion
        
        #region 获取对象
        /// <summary>
        /// 可通过该方法获取单例模式的对象。第一次获取对象时会先创建出对象，然后将其暂存。后续获取以暂存的对象时将不会在重新创建对象。
        /// </summary>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns>返回对象</returns>
        public T GetObject<T>()where T:new()
        {
            T obj = new T();
            if(!this._beanPool.BeanPoolMap.ContainsKey(obj.GetType().FullName))
            {
                this._beanPool.BeanPoolMap.Add(obj.GetType().FullName, obj);
            }
            return (T)this._beanPool.BeanPoolMap[obj.GetType().FullName];
        }
        #endregion
    }
}
