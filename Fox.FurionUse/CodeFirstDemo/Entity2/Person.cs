using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Entity2
{
    public class Person : Entity<int, Test2DbLocator>, IEntityTypeBuilder<Person, Test2DbLocator>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Person()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public void Configure(EntityTypeBuilder<Person> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(u => u.Name).HasComment("姓名");
        }
    }
}
