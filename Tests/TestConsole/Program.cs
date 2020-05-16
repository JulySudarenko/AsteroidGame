using System;
using System.Collections.Generic;
using System.Globalization;
using TestConsole.Loggers;
using TestConsole.Service;
using System.Linq;
using System.IO;
using AngleSharp.Common;
using System.Collections;
using static TestConsole.Program;


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

        private const string __NamesFile = "..\\..\\Names.txt";
        private const string __NamesFile12 = "..\\..\\covid-19-addresses[2020-04-12].txt";
      
        static void Main(string[] args)
        {
            #region Lesson 3 Шаблоны, методы расширения,  

            //var decanat = new Decanat();
            //var rnd = new Random();
            //decanat.SubscribeToAdd(RateStudent);
            //decanat.SubscribeToAdd(PrintStudent);

            //decanat.ItemRemoved += OnStudentRemoved;



            //for (var i = 1; i <= 100; i++)
            //    decanat.Add(new Student
            //    {
            //        Name = $"Name {i}",
            //        Surname = $"Surname {i}",
            //        Patronymic = $"Patronymic {i}",
            //        //Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
            //    });

            ////foreach (var student in decanat)
            ////{
            ////    Console.WriteLine(student.Name);
            ////}

            //var student_to_remove = decanat[0];

            //decanat.Remove(student_to_remove);


            //var random_student = new Student { Surname = rnd.GetValue<string>("Иванов", "Петров", "Сидоров") };

            ////var random_rating = rnd.GetValue<int>(2, 3, 4, 5);

            //decanat.SaveToFile("decanat.csv");

            //var decanat2 = new Decanat();
            //decanat2.LoadFromFile("decanat.csv");

            //StringProcessor str_rocessor = new StringProcessor(GetStringLength);

            //var length = str_rocessor("Hello World");

            ////StudentProcessor process = new StudentProcessor(PrintStudent);

            ////process(random_student);

            ////process = RateStudent;

            ////process(random_student);

            ////process = PrintStudent;
            ////process(random_student);

            ////ProcessStudents(decanat2, PrintStudent);
            //ProcessStudents(decanat2, RateStudent);
            //ProcessStudents(decanat2, PrintStudent);

            //var decanat3 = new Decanat();

            //ProcessStudents(decanat2, decanat3.Add);

            //Console.ReadLine();

            #endregion

            #region Lesson 4 Списки

            //    //foreach(var student in GetStudents(__NamesFile))
            //    //    Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            //    //List<Student> students_list = new List<Student>(100);
            //    //students_list.Count
            //    //students_list.Capacity = students_list.Count;

            //    //var id = 1;
            //    //foreach (var student in GetStudents(__NamesFile))
            //    //{
            //    //    student.Id = id++;
            //    //    students_list.Add(student);
            //    //}

            //    //var student_2 = students_list[2];
            //    //students_list.Remove(student_2);
            //    //students_list.RemoveAt(4);

            //    //var index = students_list.IndexOf(student_2);

            //    //students_list.BinarySearch();

            //    //students_list.Clear();

            //    // Упорядочивание студентов по возрастанию фамилии
            //    //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Surname, s2.Surname));

            //    //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2.Name, s1.Name));

            //    //students_list.Clear();

            //    //students_list.AddRange(GetStudents(__NamesFile));

            //    //Student[] students_array = students_list.ToArray();

            //    //var new_students_list = new List<Student>(students_array);
            //    //var new_students_list2 = new List<Student>(GetStudents(__NamesFile));


            //    //var list = new ArrayList(new_students_list2);

            //    //list.Add(42);
            //    //list.Add("Hello World!");

            //    ////list.OfType<Student>();
            //    //list.Cast<Student>();

            //    //foreach (var student in list.OfType<Student>())
            //    //{
            //    //    Console.WriteLine(student);
            //    //}

            //    //var new_students_list3 = GetStudents(__NamesFile).ToList();
            //    //var new_students_array3 = GetStudents(__NamesFile).ToArray();

            //    //foreach (var student in new_students_list2.ToArray())
            //    //{
            //    //    if (student.Surname.StartsWith("А"))
            //    //        new_students_list2.Remove(student);
            //    //}

            //    //if (new_students_list2.Exists(student => student.Surname.StartsWith("А")))
            //    //{
            //    //    Console.WriteLine("В списке есть хотя бы один студент, фамилия которого начинается на А");
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("Всех на А отчислили...");
            //    //}

            //    //Stack<Student> students_stack = new Stack<Student>(100);
            //    //foreach (var student in GetStudents(__NamesFile))
            //    //{
            //    //    students_stack.Push(student);
            //    //}

            //    //var last_student = students_stack.Pop();

            //    //while (students_stack.Count > 0)
            //    //{
            //    //    Console.WriteLine(students_stack.Pop());
            //    //}

            //    //Queue<Student> students_queue = new Queue<Student>(100);
            //    //while (students_stack.Count > 0)
            //    //    students_queue.Enqueue(students_stack.Pop());

            //    //while (students_queue.Count > 0)
            //    //    Console.WriteLine(students_queue.Dequeue());

            //    //Dictionary<string, List<Student>> surename_students = new Dictionary<string, List<Student>>();

            //    //surename_students.Add("qwe", new List<Student>());

            //    //var dict_data = surename_students.ToArray();

            //    //foreach (var student in GetStudents(__NamesFile))
            //    //{
            //    //    var surname = student.Surname;

            //    //    if(surename_students.ContainsKey(surname))
            //    //        surename_students[surname].Add(student);
            //    //    else
            //    //    {
            //    //        var new_list = new List<Student>();
            //    //        new_list.Add(student);
            //    //        surename_students.Add(surname, new_list);
            //    //    }
            //    //}

            //    //Console.WriteLine(new string('-', Console.BufferWidth));

            //    //if (surename_students.TryGetValue("Хвостовский", out var students))
            //    //    foreach (var student in students)
            //    //        Console.WriteLine(student);

            //    //IEnumerable<Student> students = GetStudents(__NamesFile);

            //    //students = students.Where(student => student.Surname.StartsWith("А"));

            //    //var student_names = students.Select(student => student.Name);

            //    //var student_surnames_names = students.Select(s => $"{s.Surname} {s.Name}");

            //    //foreach (var student in student_surnames_names)
            //    //{
            //    //    Console.WriteLine(student);
            //    //}

            //    //var ilyushkin = students.First(s => s.Surname == "Илюшкин1");
            //    //var ilyushkin = Enumerable.Empty<Student>().First();
            //    //var ilyushkin = students.FirstOrDefault(s => s.Surname == "Илюшкин1");

            //    var rated_studetns = GetStudents(__NamesFile).ToArray();
            //    //rated_studetns.OrderBy(s => s.Surname)

            //    var top_students = rated_studetns.Where(s => s.AverageRating >= 4);
            //    var bad_studets = rated_studetns.Where(s => s.AverageRating <= 3);

            //    var grouped_students = rated_studetns.GroupBy(s => s.GroupId);

            //    var surnames_groups = rated_studetns.GroupBy(s => s.Surname);

            //    foreach (var surnames_group in surnames_groups)
            //    {
            //        Console.WriteLine("Все студенты с фамилией {0}", surnames_group.Key);
            //        foreach (var student in surnames_group)
            //            Console.WriteLine("\t{0}", student);
            //    }

            //    var groups = GetGroups(10).ToArray();

            //    var groupped_students = rated_studetns.Join(
            //        groups,
            //        student => student.GroupId,
            //        group => group.Id,
            //        (student, group) => new
            //        {
            //            Student = student,
            //            Group = group
            //        }
            //    );

            //    var groupped_students2 = rated_studetns.Join(
            //        groups,
            //        student => student.GroupId,
            //        group => group.Id,
            //        (student, group) => (Studend: student, Group: group)
            //    );

            //    foreach (var groupped_student in groupped_students)
            //    {
            //        Console.WriteLine("Студент {0} группы {1}",
            //            groupped_student.Student,
            //            groupped_student.Group.Name);
            //    }

            //    foreach (var (Student, Group) in groupped_students2)
            //    {
            //        Console.WriteLine("Студент {0} группы {1}",
            //            Student,
            //            Group.Name);
            //    }

            //    Console.ReadLine();



            //}
            //private static IEnumerable<Group> GetGroups(int count)
            //{
            //    foreach (var index in Enumerable.Range(1, count))
            //        yield return new Group { Id = index, Name = $"Группа {index}" };
            //}

            //private static IEnumerable<Student> GetStudents(string FileName)
            //{
            //    //yield break;
            //    var rnd = new Random();
            //    //File.AppendAllText();

            //    using (var file = File.OpenText(FileName))
            //    {
            //        while (!file.EndOfStream)
            //        {
            //            var line = file.ReadLine();

            //            if (string.IsNullOrWhiteSpace(line)) continue;

            //            var components = line.Split(' ');
            //            if (components.Length != 3) continue;

            //            var student = new Student();
            //            student.Surname = components[0];
            //            student.Name = components[1];
            //            student.Patronymic = components[2];
            //            student.Ratings = rnd.GetValues(20, 2, 6);
            //            student.GroupId = rnd.Next(1, 11);
            //            yield return student;
            //        }
            //    }

            #endregion

            ///<summary> Task 2 Lesson 4 
            ///2.Дана коллекция List<T>, требуется подсчитать, 
            ///сколько раз каждый элемент встречается в данной коллекции:
            ///а) для целых чисел;
            ///б) *для обобщенной коллекции;
            ///в) *используя Linq.
            ///</summary>

            //IEnumerable<Adress> Adresses = GetAdresses(__NamesFile12);
            var Adresses = GetAdresses(__NamesFile12).ToList();

            Adresses.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Street, s2.Street));
            //foreach (var adress in Adresses)
            //    Console.WriteLine(adress);



            Quantity(Adresses);

            List<Street> Streets = new List<Street>();

            Streets.Add(new Street(Adresses[0].Street, 1));
            for (int i = 0; i < Adresses.Count - 1; i++) 
            {
                if (Adresses[i].Street != Adresses[i + 1].Street)
                    Streets.Add(new Street(Adresses[i + 1].Street, 1));
                else
                    Streets[Streets.Count - 1].Counter++;
            }

            foreach (var s in Streets)
                Console.WriteLine(s);


            #region Task 3 Lesson 4
            ///<summary> 
            ///* Дан фрагмент программы:
            ///а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
            ///б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
            ///</summary>

            Dictionary<string, int> dict = new Dictionary<string, int>()
                {
                    {"four",4 },
                    {"two",2 },
                    {"one",1 },
                    {"three",3 },
                };

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            var d = dict.OrderBy(pair => pair.Value);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            #endregion

            Console.ReadLine();
        }

        private static void Quantity(List<Adress> adresses)
        {
            int count = 1;
            for (int i = 0; i < adresses.Count; i++)
            {
                if (i == adresses.Count - 1)
                {
                    Console.WriteLine($"{count} - {adresses[i].Street}");
                    break;
                }
                if (adresses[i].Street != adresses[i + 1].Street)
                {
                    Console.WriteLine($"{count} - {adresses[i].Street}");
                    count = 1;
                }
                if (adresses[i].Street == adresses[i + 1].Street)
                    count++;
            }
        }

        private static IEnumerable<Adress> GetAdresses(string FileName)
        {
            //StreamReader sr = new StreamReader(FileName);
            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(';');
                    if (components.Length != 3) continue;

                    var adress = new Adress();
                    adress.Date = DateTime.Parse(components[0]);
                    adress.Street = components[1];
                    adress.House = components[2];

                    yield return adress;
                }
            }
        }

        #region Lesson 4 Списки

        internal class Group
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => $"[{Id}] {Name}";
        }

        internal class Adress : IComparable<Adress>, IEquatable<Adress>, IEquatable<string>
        {
            public DateTime Date { get; set; }
            public string Street { get; set; }
            public string House { get; set; }

            public Adress(DateTime Date, string Street, string House)
            {
                this.Date = Date;
                this.Street = Street;
                this.House = House;
            }

            public Adress()
            { }

            public override string ToString() => $"{Date} {Street} {House}";

            public int CompareTo(Adress other)
            {
                return Street.CompareTo(other.Street);
            }

            public bool Equals(Adress other)
            {
                if (other is null) return false;

                return Street == other.Street;
            }

            public bool Equals(string other)
            {
                if (other is null) return false;

                return Street == other;
            }
        }
        #endregion
    }

    internal class Street : IComparable<string>, IEquatable<string>
    {
        public string St { get; set; }
        public int Counter { get; set; }

        public Street(string St, int Counter)
        {
            this.St = St;
            this.Counter = Counter;
        }
        public Street(string St)
        {
            this.St = St;
            this.Counter = 1;
        }

        public override string ToString() => $"{Counter} - {St}";

        public int CompareTo(string other)
        {
            return St.CompareTo(other);
        }

        public bool Equals(string other)
        {
            if (other is null) return false;

            return St == other;
        }
    }
}



