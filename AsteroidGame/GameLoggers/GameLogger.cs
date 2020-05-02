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

        public void LogGameStart()
        {
            GameLog($"{DateTime.Now:s}[info]:{"Начало игры"}");
        }
         
        public void LogAsteroidShotDown(string Message)
        {
            GameLog($"{DateTime.Now:s}[info]:{Message}");
        }

        public void LogEnergyDown(string Message)
        {
            GameLog($"{DateTime.Now:s}[info]:{Message}");
        }

        public void LogEnergyUp(string Message)
        {
            GameLog($"{DateTime.Now:s}[info]:{Message}");
        }

        public void LogGameOver(string Message)
        {
            GameLog(string.Format("{0:s}[info]:{1}", DateTime.Now, Message));
        }

        public virtual void Flush() { }

    }
}
