using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Entity1
{
    public class Children : Entity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Children()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 外键
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// 主表
        /// </summary>
        public Person Person { get; set; }
    }
}
