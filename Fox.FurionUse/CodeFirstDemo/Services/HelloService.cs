using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Services
{
    public interface IHelloService
    {
        string SayHello();
    }

    public class HelloService : IHelloService, ITransient
    {
        private readonly DefaultDbContext _context;
        private readonly Test2DbContext _test2DbContext;

        public HelloService(DefaultDbContext context, Test2DbContext test2DbContext)
        {
            _context = context;
            _test2DbContext = test2DbContext;
        }

        public string SayHello()
        {
            _context.Add(new Person()
            {
                Name = "name",
                Age = 10,
                Address = "地址"
            });
            _context.SaveChanges();

            _test2DbContext.Add(new CodeFirstDemo.Entity2.Person()
            {
                Name = "name_test2",
                Age = 12,
                Address = "地址2"
            });
            _test2DbContext.SaveChanges();

            return "Hello Furion.";
        }
    }
}
