using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    [AppDbContext("MySql2ConnectionString", DbProvider.MySql)]
    public class Test2DbContext : AppDbContext<Test2DbContext, Test2DbLocator>
    {
        public Test2DbContext(DbContextOptions<Test2DbContext> options) : base(options)
        {
        }

    }
}
