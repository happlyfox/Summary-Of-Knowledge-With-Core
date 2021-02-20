//using FactoryPattern.FactoryMethod;
using FactoryPattern.AbstractFactory;
using FactoryPattern.Pattern;
using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory();
        }

        static void AbstractFactory()
        {
            IFruitFactory fac = new AFactory();
            Fruit a_Apple = fac.CreateApple("a工厂");
            Fruit a_Orange = fac.CreateOrange("a工厂");
            a_Apple.PrintfName();
            a_Orange.PrintfName();

            IFruitFactory b_fac = new BFactory();
            Fruit b_Apple = b_fac.CreateApple("b工厂");
            Fruit b_Orange = b_fac.CreateOrange("b工厂");
            b_Apple.PrintfName();
            b_Orange.PrintfName();
        }

        //static void FactoryMethod()
        //{
        //    IFruitFactory appleFac = new AFactory();
        //    Fruit apple = appleFac.CreateFruit();
        //    apple.PrintfColor();
        //    apple.PrintfName();

        //    IFruitFactory orangeFac = new OrangeFactory();
        //    Fruit orage = orangeFac.CreateFruit();
        //    orage.PrintfColor();
        //    orage.PrintfName();
        //}


        void SimpleFactory()
        {
            Console.WriteLine("请选择操作符号(+、-、*、/)");
            string operateStr = Console.ReadLine();
            Operate operate = OperateFactory.GetOperateFactory(operateStr);
            operate.NumberA = 10;
            operate.NumberB = 4;
            double result = operate.GetResult();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        void Opreate()
        {
            Console.WriteLine("请输入数字A");
            string a = Console.ReadLine();
            Console.WriteLine("请输入数字B");
            string b = Console.ReadLine();
            Console.WriteLine("请选择操作符号(+、-、*、/)");
            string operate = Console.ReadLine();

            Calculator box = new Calculator();
            double result = box.GetResult(Convert.ToDouble(a), Convert.ToDouble(b), operate);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
