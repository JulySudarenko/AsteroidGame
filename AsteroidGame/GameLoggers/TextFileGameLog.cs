using System.IO;
using System;

//July_Sudarenko
namespace AsteroidGame.GameLoggers

{
    /// <summary> Tasks 2 Lesson 3
    /// Доработать игру «Астероиды». 
    /// а) Добавить ведение журнала в консоль с помощью делегатов;
    /// б) *Добавить это и в файл.
    /// </summary>
    internal class TextFileGameLog : GameLogger, IDisposable
    {
        private readonly TextWriter _Writer;

        public TextFileGameLog(string FileName)
        {
            _Writer = File.CreateText(FileName);
            ((StreamWriter)_Writer).AutoFlush = true;
        }

        private int _Counter;
        public override void GameLog(string Message)
        {
            _Writer.WriteLine("{0}>{1}", _Counter++, Message);
        }

        public override void Flush() { _Writer.Flush(); }

        public void Dispose()
        {
            _Writer.Dispose();
        }
    }
}
