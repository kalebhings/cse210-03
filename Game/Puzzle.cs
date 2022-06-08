using System;
using System.Collections.Generic;

namespace cse210_03.Game
{
    public class Puzzle
    {
        private List<string> _words = new List<string>{};
        public List<char> _guess = new List<char>();
        public List<char> _answer = new List<char>();
        public TerminalService terminalServices = new TerminalService();

        public Puzzle()
        {
            this._words.Add("Pizza");
            this._words.Add("Chocolate");
            this._words.Add("Mountain");
            this._words.Add("Airplane");
            this._words.Add("Hamburger");
            this._words.Add("Lightsaber");
            this._words.Add("Cookies");
            this._words.Add("Apple");
            this._words.Add("Banana");
        }

        public string GetWord()
        {
            Random random = new Random();
            int randomNumber = random.Next(this._words.Count);
            return this._words[randomNumber];
        }

        public void DisplaySecretWord()
        {
            foreach (int i in _answer)
            {
                _guess.Add('_');
            }
        }

        public void WordLength(string ripWord)
        {
            _answer.AddRange(ripWord.ToLower());
        }

        public void CreateSecretWord()
        {
            foreach (int i in _answer)
            {
                _guess.Add('_');
            }
        }

        public void PrintGuess()
        {
            terminalServices.WriteText(string.Format("{0}", string.Join(" ", _guess)));
        }

        public int Compare(List<char> listPreviousGuesses, int numberOfGuesses)
        {
            for (int i = 0; i < _answer.Count; i++)
            {
                if (listPreviousGuesses.Contains(_answer[i]))
                {
                    _guess[i] = _answer[i];
                }
            }    
            if (_answer.Contains(listPreviousGuesses[numberOfGuesses - 1]))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void PrintAnswer()
        {
            terminalServices.WriteText(string.Format("{0}", string.Join(" ", _answer)));
        }
    }
}
