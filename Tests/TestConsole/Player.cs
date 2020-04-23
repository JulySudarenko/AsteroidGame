using System;

namespace TestConsole
{
    internal class Player
    {
        private string _Name;
        private DateTime _Birthday;

        public string Name { get; set; }
        //public string Surname { get; set; }

        public Player()
        {

        }
        public Player(string Name)
        {
            _Name = Name;
            _Birthday = DateTime.Now;
        }

        public Player(string Name, DateTime Birthday)
            : this(Name)
        {
            _Birthday = Birthday;
        }

    }
}
