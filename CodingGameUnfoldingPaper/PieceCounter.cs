using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameUnfoldingPaper
{
    public class PieceCounter
    {
        public int Counter = 0;

        public Sheet Sheet { get; set; }


        private void CheckChars(List<List<Char>> pattern, CharToCheck charToCheck, List<CharToCheck> charList)
        {            
            if (pattern[charToCheck.Y][charToCheck.X] == '#')
            {
                pattern[charToCheck.Y][charToCheck.X] = '.';

                AddNeighbours(pattern, charToCheck.Y, charToCheck.X, charList);
            }
        }



        private void AddNeighbours(List<List<Char>> pattern, int lineIndex, int charIndex, List<CharToCheck> charList)
        {

            if (charIndex + 1 < pattern[lineIndex].Count)
            {
                var charToCheck = new CharToCheck()
                {
                    Y = lineIndex,
                    X = charIndex + 1
                };
                charList.Add(charToCheck);
            }
            if (lineIndex + 1 < pattern.Count)
            {
                var charToCheck = new CharToCheck()
                {
                    Y = lineIndex + 1,
                    X = charIndex
                };
                charList.Add(charToCheck);
            }
            if (charIndex > 0)
            {
                var charToCheck = new CharToCheck()
                {
                    Y = lineIndex,
                    X = charIndex - 1
                };
                charList.Add(charToCheck);
            }
            if (lineIndex > 0)
            {
                var charToCheck = new CharToCheck()
                {
                    Y = lineIndex - 1,
                    X = charIndex
                };
                charList.Add(charToCheck);
            }

        }



        private void CheckInitialIsHash(List<List<Char>> pattern, int lineIndex, int charIndex)
        {
            var initialCharacter = pattern[lineIndex][charIndex];
            var checkList = new List<CharToCheck>();
            var charToCheck = new CharToCheck()
            {
                Y = lineIndex,
                X = charIndex
            };
            if (initialCharacter == '#')
            {
                checkList.Add(charToCheck);
                Counter += 1;
            }
            while(checkList.Count > 0)
            {
                var character = checkList.First();
                checkList.Remove(character);
                CheckChars(pattern, character, checkList);

                
                
            }
        }

        private void LoopOverChars(List<List<Char>> pattern, int lineIndex)
        {
            var nOfChars = pattern[lineIndex].Count;
            for (int i = 0; i < nOfChars; i++)
            {
                CheckInitialIsHash(pattern, lineIndex, i);
            }
        }

        private void LoopOverLines(List<List<Char>> pattern)
        {
            var nOfLines = pattern.Count;

            for (int i = 0; i < nOfLines; i++)
            {
                LoopOverChars(pattern, i);
            }
        }



        public void CountPieces()
        {
            var pattern = Sheet.Pattern;
            LoopOverLines(pattern);
        }



    }
}
