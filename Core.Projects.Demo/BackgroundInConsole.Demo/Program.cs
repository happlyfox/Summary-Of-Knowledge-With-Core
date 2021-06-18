using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BackgroundInConsole.Demo
{

    //string box = HttpUtility.HtmlDecode("&#x7A0B;&#x5E8F;&#x88AB;&#x52A8;&#x7EC8;&#x6B62;");

    class Program
    {
        static void Main(string[] args)
        {

            string box = "123";
            Console.WriteLine(box.Split("|").Length);
            Console.ReadKey();


        }
    }
}
