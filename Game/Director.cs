using System;
using System.Collections.Generic;

namespace cse210_03.Game
{
    public class Director
    {
        private string word;

        public void StartGame()
        {
          Puzzle puzzle = new Puzzle();

          word = puzzle.GetWord();  

          Console.WriteLine(word);
        }
    }
}
