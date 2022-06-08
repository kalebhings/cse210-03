using System;
using System.Collections.Generic;

namespace cse210_03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private string word;
        private string person;
        private bool _isPlaying = true;
        private bool _checkInput;
        private Puzzle puzzle = new Puzzle();
        private Parachute parachute = new Parachute();
        private TerminalService terminalService = new TerminalService();
        public List<char> guessedLetters = new List<char>();
        public string currentGuess = "test";
        public int numberOfGuesses = 0;
        public int tries = 0;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {

        }

        /// <summary>
        /// Starts the game
        /// </summary>
        public void StartGame()
        {
          word = puzzle.GetWord();
          puzzle.WordLength(word);
          puzzle.CreateSecretWord();
          puzzle.PrintGuess();

            while(_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }

        }

        private void GetInputs()
        {
            terminalService.WriteText("\n");
            parachute.PrintParachute(tries);
            _checkInput = true;

            while (_checkInput)
            {
                currentGuess = terminalService.ReadText("\nGuess a letter [a-z]: ");
                _checkInput = parachute.CheckInput(guessedLetters, currentGuess);
            }
            guessedLetters.Add(currentGuess[0]);
        }

        private void DoUpdates()
        {
            numberOfGuesses = guessedLetters.Count;
            int usedTries = puzzle.Compare(guessedLetters, numberOfGuesses);
            tries = tries + usedTries;
            _isPlaying = parachute.CheckParachute(puzzle._guess, tries);
        }

        private void DoOutputs()
        {
            terminalService.WriteText("");

            if (_isPlaying)
            {
                puzzle.PrintGuess();
            }
            else
            {
                parachute.PrintParachute(tries);
                puzzle.PrintAnswer();
                terminalService.WriteText("\n");
            }
        }
    }
}
