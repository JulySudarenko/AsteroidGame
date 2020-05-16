using System;

//July_Sudarenko
namespace AsteroidGame.GameLoggers
{
    /// <summary> Tasks 2 Lesson 3
    /// Доработать игру «Астероиды». 
    /// а) Добавить ведение журнала в консоль с помощью делегатов;
    /// б) *Добавить это и в файл.
    /// </summary>
    internal class GameLogger
    {
        public static GameLogger CreateFileLogger(string FileName)
        {
            return new TextFileGameLog(FileName);
        }

        public virtual void GameLog(string Message)
        {
            Console.WriteLine(Message);
        }

        public void LogGameStart(int Count)
        {
            GameLog(string.Format("{0:s}[info]:{1}{2}", DateTime.Now, "Начало игры. Счёт: ", Count));
        }
         
        public void LogAsteroidShotDown(int Count)
        {
            GameLog(string.Format("{0:s}[info]:{1}{2}", DateTime.Now, "Попадание в астероид. Счёт: ", Count));
        }

        public void LogEnergyDown(int Count)
        {
            GameLog(string.Format("{0:s}[info]:{1}{2}", DateTime.Now, "Столкновение корабля с астероидом. Счёт: ", Count));
        }

        public void LogEnergyUp(int Count)
        {
            GameLog(string.Format("{0:s}[info]:{1}{2}", DateTime.Now, "Пополенение энергии. Счёт: ", Count));
        }

        public void LogGameOver(int Count)
        {
            GameLog(string.Format("{0:s}[info]:{1}{2}", DateTime.Now, "Игра окончена. Счёт: ", Count));
        }

        public virtual void Flush() { }

    }
}
