using System;
using System.Collections.Generic;

namespace cse210_03.Game
{
    public class Parachute
    {
        public TerminalService terminalServices = new TerminalService();
        private int _count = 0;
        private int _trueTries = 0;
        private List<string>_parachute = new List<string>();

        public Parachute()
        {
            this._parachute.Add("  ___");
            this._parachute.Add(" /___\\");
            this._parachute.Add(" \\   /");
            this._parachute.Add("  \\ /");
            this._parachute.Add("   O");
            this._parachute.Add("  /|\\");
            this._parachute.Add("  / \\");
        }

        public string DisplayParachute()
        {
            for (int i = 0; i < _parachute.Count; i++)
            {
                terminalServices.WriteText(_parachute[i]);
            }
            return "";
        }

        public bool CheckInput(List<char> guesses, string currentGuess)
        {
            if (guesses.Contains(currentGuess[0]))
            {
                terminalServices.WriteText("You already guessed that letter. Please try again");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckParachute(List<char> wordGuess, int tries)
        {
            for (int i = 0; i < wordGuess.Count; i++)
            {
                if (wordGuess[i] != '_')
                {
                    _count++;
                }
                else
                {

                }
            }
            if (_count == wordGuess.Count)
            {
                return false;
            }
            else if (tries == 4)
            {
                return false;
            }    
            else
            {
                return false;
            }
        }

        public void PrintParachute(int tries)
        {
            if (tries == _trueTries)
            {

            }
            else if (tries == 4)
            {
                _parachute.RemoveRange(0, 1);
                _parachute[0] = "   X";
            }
            else
            {
                _parachute.RemoveRange(0, 1);
                _trueTries++;
            }
            terminalServices.WriteText(string.Format("{0}", string.Join("\n", _parachute)));
        }

    }
}
