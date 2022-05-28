using System;
using System.Collections.Generic;

namespace cse210_03.Game
{
    public class Puzzle
    {
        private List<string> _words = new List<string>{};

        public Puzzle()
        {
            this._words.Add("Pizza");
            this._words.Add("Chocolate");
            this._words.Add("Mountain");
            this._words.Add("Airplane");
            this._words.Add("Hamburger");
        }

        public string GetWord()
        {
            Random random = new Random();
            int randonNumber = random.Next(this._words.Count);
            return this._words[randonNumber];
        }
    }
}
