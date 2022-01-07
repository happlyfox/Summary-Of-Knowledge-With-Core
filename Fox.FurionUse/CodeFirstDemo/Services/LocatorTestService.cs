using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Services
{
    public class LocatorTestService : IScoped
    {
        private readonly IRepository<CodeFirstDemo.Entity2.Person, Test2DbLocator> _db2PeronRep;

        public LocatorTestService(IRepository<CodeFirstDemo.Entity2.Person, Test2DbLocator> db2PeronRep)
        {
            _db2PeronRep = db2PeronRep;
        }


        public void GetDb2Person()
        {
            var rows = _db2PeronRep.AsQueryable().ToList();

            foreach (var rowItem in rows)
            {
                Console.WriteLine(JsonConvert.SerializeObject(rowItem));
            }
        }

        public void GetDb1Person()
        {
            var rows = _db2PeronRep.Change<Person>().AsQueryable().ToList();

            foreach (var rowItem in rows)
            {
                Console.WriteLine(JsonConvert.SerializeObject(rowItem));
            }
        }

    }
}
