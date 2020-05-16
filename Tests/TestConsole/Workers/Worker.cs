using System;
using System.Collections;

//July Sudarenko
namespace TestConsole.Workers
{
    ///<summary> Task 1
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
    internal abstract class Worker : IComparable
    {
        public string Name { get; set; }
        public decimal Payment { get; set; }

        public Worker(string Name, decimal Payment)
        {
            this.Name = Name;
            this.Payment = Payment;
        }

        public Worker()
        {
        }

        public abstract void AveragePayment();

        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            else
            {
                Worker w = obj as Worker;
                return Name.CompareTo(w.Name);
            }
        }
    }
}



