using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Entity1
{
    public class Post : Entity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Post()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Person 集合
        /// </summary>
        public ICollection<Person> Persons { get; set; }
    }
}
