using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Core.BeanManage
{
    class BeanPool
    {
        private Dictionary<string,object> _beanPoolMap = new Dictionary<string, object>();

        public Dictionary<string,object> BeanPoolMap
        {
            get { return _beanPoolMap; }
            set { _beanPoolMap = value; }
        }

    }
}
