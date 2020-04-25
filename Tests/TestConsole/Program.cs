using System;
using TestConsole.Workers;
using TestConsole.Loggers;
using System.Diagnostics;

namespace TestConsole
{
    class Program_July_Sudarenko
    {
        static void Main(string[] args)
        {
            #region Task 1
            ///<summary>
            ///1.Построить три класса(базовый и 2 потомка), описывающих двух работников: 
            ///с почасовой оплатой(один из потомков) 
            ///и фиксированной оплатой(второй потомок).
            ///а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
            ///Для «повременщиков» формула для расчета такова: 
            ///«среднемесячная заработная плата = 20.8 * 8 * почасовая ставка». 
            ///Для работников с фиксированной оплатой: 
            ///«среднемесячная заработная плата = фиксированная месячная оплата».
            ///б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
            ///в) *Реализовать интерфейсы для возможности сортировки массива, 
            ///используя Array.Sort().
            ///г) *Создать класс, содержащий массив сотрудников, 
            ///и реализовать возможность вывода данных с использованием foreach.
            /// </summary>

            Worker w1 = new FixPayWorker("Иванов", 120000);
            Worker w2 = new HourlyPayWorker("Петров", 500);

            w1.AveragePayment();
            w2.AveragePayment();

            JoinWorker w3 = new JoinWorker();
            w3.Add(w1);
            w3.Add(w2);

            w3.AveragePayment();

            #endregion

            #region Logger Абстракции
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            //Logger log = new DebugOutputLogger();
            //Logger log = new TraceLogger();

            //Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            //Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            //CombineLogger log = new CombineLogger();
            //log.Add(new TraceLogger());
            //log.Add(new ConsoleLogger());
            //log.Add(new DebugOutputLogger());
            //log.Add(new TextFileLogger("new_log.log"));

            //log.LogInformation("Message1");
            //log.LogWarning("Info message");
            //log.LogError("Error message");

            //log.Flush();

            #endregion

            #region Player
            //Player player1 = new Player();
            //player1.Name = "Иванов";
            //player1.Birthday = new DateTime(1974, 12, 21, 0, 0, 0);

            //Player player1 = new Player("Empty", new DateTime(1974, 12, 21));

            //Console.Write("Введите фамилию > ");
            //player1.Name = Console.ReadLine();

            //Console.WriteLine(player1.Name);
            #endregion

            #region Vector implicit
            //Vector2D v1 = new Vector2D(5, 7);
            //Vector2D v2 = new Vector2D(-7, 2);

            //Vector2D v3 = v1 + v2;
            //Vector2D v4 = v1 - v2;

            //Vector2D v5 = v3 + 3.14159265358979;

            #endregion

            #region CultureInfo

            //CultureInfo ru = new CultureInfo("ru-ru");
            //CultureInfo en_us = new CultureInfo("en-us");
            //CultureInfo invariant = CultureInfo.InvariantCulture;
            //CultureInfo current = CultureInfo.CurrentCulture; //узнать какая установлена
            //CultureInfo currentUI = CultureInfo.CurrentUICulture;

            //double pi = double.Parse("3,1415", ru);

            //int i = (int)pi;

            //Console.WriteLine(pi);

            //double length = v4;
            #endregion

            #region Printer Наследование
            //Printer printer = new Printer();
            //PrefixPrinter prefix_printer = new PrefixPrinter();
            //prefix_printer.Prefix = "!!!!!-----!!!!!";

            //prefix_printer.Print("QWE");

            //printer.Print("Hello World!");
            //prefix_printer.PrintData(3.14);

            //printer.Print("123");

            //printer = prefix_printer;
            //Printer printer1 = new PrefixPrinter();

            //printer.Print("345");
            //printer1.Print("678");
            #endregion

            Console.ReadLine();
        }
    }
}



