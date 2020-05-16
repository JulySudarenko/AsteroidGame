using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using TestConsole.Loggers;
using System.Diagnostics;
using System.Runtime.Serialization;
using TestConsole.Service;
using TestConsole.Workers;

//July_Sudarenko
namespace TestConsole
{
    internal delegate int StringProcessor(string str);

    internal delegate void StudentProcessor(Student student);
    class Program
    {
        private static void OnStudentRemoved(Student student)
        {
            Console.WriteLine("Студент {0} был отчислен!", student.Surname);
        }

        static void Main(string[] args)
        {
            #region Lesson 3 Шаблоны, методы расширения,  

            var decanat = new Decanat();
             var rnd = new Random();           
            decanat.SubscribeToAdd(RateStudent);
            decanat.SubscribeToAdd(PrintStudent);

            decanat.ItemRemoved += OnStudentRemoved;



            for (var i = 1; i <= 100; i++)
                decanat.Add(new Student
                {
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Patronymic = $"Patronymic {i}",
                    //Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
                });

            //foreach (var student in decanat)
            //{
            //    Console.WriteLine(student.Name);
            //}

            var student_to_remove = decanat[0];

            decanat.Remove(student_to_remove);


            var random_student = new Student { Surname = rnd.GetValue<string>("Иванов", "Петров", "Сидоров") };

            //var random_rating = rnd.GetValue<int>(2, 3, 4, 5);

            decanat.SaveToFile("decanat.csv");

            var decanat2 = new Decanat();
            decanat2.LoadFromFile("decanat.csv");

            StringProcessor str_rocessor = new StringProcessor(GetStringLength);

            var length = str_rocessor("Hello World");

            //StudentProcessor process = new StudentProcessor(PrintStudent);

            //process(random_student);

            //process = RateStudent;

            //process(random_student);

            //process = PrintStudent;
            //process(random_student);

            //ProcessStudents(decanat2, PrintStudent);
            ProcessStudents(decanat2, RateStudent);
            ProcessStudents(decanat2, PrintStudent);

            var decanat3 = new Decanat();

            ProcessStudents(decanat2, decanat3.Add);

            Console.ReadLine();

            #endregion

            #region Task 1 Lesson 2
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
            Worker w2 = new HourlyPayWorker("Петров", 600);
            Worker w3 = new FixPayWorker("Сидоров", 110000);
            Worker w4 = new FixPayWorker("Васечкин", 100000);
            Worker w5 = new HourlyPayWorker("Пупкин", 500);
            Worker w6 = new HourlyPayWorker("Волков", 400);
            Worker w7 = new HourlyPayWorker("Зайцев", 5500);

            w1.AveragePayment();
            w2.AveragePayment();

            Worker[] workers = new Worker[7] { w1, w2, w3, w4, w5, w6, w7 };
            Array.Sort(workers);

            for (int i = 0; i < workers.Length; i++)
                Console.WriteLine(workers[i].Name);

            JoinWorker w8 = new JoinWorker();
            w8.Add(w1);
            w8.Add(w2);
            w8.Add(w3);
            w8.Add(w4);
            w8.Add(w5);
            w8.Add(w6);
            w8.Add(w7);

            w8.AveragePayment();

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

            #region Интерфейсы, Исключения

            //Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            //Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            //CombineLogger combine_log = new CombineLogger();
            //combine_log.Add(new ConsoleLogger());
            //combine_log.Add(new DebugOutputLogger());
            //combine_log.Add(new TraceLogger());
            //combine_log.Add(new TextFileLogger("new_log.log"));

            //combine_log.LogInformation("Message1");
            //combine_log.LogWarning("Info message");
            //combine_log.LogError("Error message");

            //Student student = new Student { Name = "Иванов" };

            //ILogger log = combine_log;
            //ComputeLongDataValue(100, student);

            //Console.WriteLine("Программа завершена!");

            //using (var file_logger = new TextFileLogger("another.log"))
            //{
            //    file_logger.LogInformation("123");
            //}

            //try
            //{
            //    ComputeLongDataValue(600, log);
            //}
            //catch (ArgumentNullException error)
            //{
            //    combine_log.LogError(error.ToString());
            //    combine_log.LogError(error.Message);
            //    throw new ComputeExceptionException("Ошибка в значении входного параметра", error);

            //}
            //catch (InvalidOperationException)
            //{
            //    Console.WriteLine("Число итераций слишком велико!");
            //    throw;
            //}
            //catch (Exception error)
            //{
            //    combine_log.LogError(error.ToString());
            //    combine_log.LogError(error.Message);
            //    throw new ComputeExceptionException("Произошла неизвестная ошибка при вычислении", error);
            //}


            //combine_log.Flush();
            #endregion

            Console.ReadLine();
        }
        #region Lesson 2 Интерфейсы, Исключения
        private static double ComputeLongDataValue(int Count, ILogger Log)
        {
            if (Log is null)
                //throw new ArgumentNullException("Log");
                throw new ArgumentNullException(nameof(Log));

            if (Count <= 0)
                throw new ArgumentOutOfRangeException(nameof(Count), Count, "Число итераций обязано быть больше нуля!");

            var result = 0;
            for (var i = 0; i < Count; i++)
            {
                result++;
                Log.Log($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(10);

                if (i > 500)
                    throw new InvalidOperationException("Число итераций оказалось слишком большим!",
                        new ArgumentException($"Число итераций было указано больше 500 и равно {Count}", nameof(Count)));
            }

            return result;
        }
        #endregion

        #region Lesson 3 Делегаты
        private static int GetStringLength(string str)
        //int GetStringLength(string str)
        {
            return str.Length;
        }

        private static void PrintStudent(Student student)
        //void PrintStudent(Student student)
        {
            Console.WriteLine("[{0}]{1} {2} {3} - {4}",
                student.Id,
                student.Surname, student.Name, student.Patronymic, student.AverageRating);
        }

        private static void RateStudent(Student student)
        //void RateStudent(Student student)
        {
            var rnd = new Random();
            student.Ratings.AddRange(rnd.GetValues(5, 2, 6));
        }

        private static void ProcessStudents(IEnumerable<Student> students, StudentProcessor Processor)
        //void ProcessStudents(IEnumerable<Student> students, StudentProcessor Processor)
        {
            foreach (var student in students)
                Processor(student);
        }
        #endregion
    }
}



