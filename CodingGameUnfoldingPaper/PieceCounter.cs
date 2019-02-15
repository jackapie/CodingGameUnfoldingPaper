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


        private void CheckChars(CharToCheck charToCheck, List<CharToCheck> charList)
        {            
            if (Sheet.Pattern[charToCheck.Y][charToCheck.X] == '#')
            {
                Sheet.Pattern[charToCheck.Y][charToCheck.X] = '.';

                AddNeighbours(charToCheck.Y, charToCheck.X, charList);
            }
        }



        private void AddNeighbours(int lineIndex, int charIndex, List<CharToCheck> charList)
        {

            if (charIndex + 1 < Sheet.Pattern[lineIndex].Count)
            {
                var charToCheck = new CharToCheck()
                {
                    Y = lineIndex,
                    X = charIndex + 1
                };
                charList.Add(charToCheck);
            }
            if (lineIndex + 1 < Sheet.Pattern.Count)
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



        private void CheckInitialIsHash(int lineIndex, int charIndex)
        {
            var initialCharacter = Sheet.Pattern[lineIndex][charIndex];
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
                CheckChars(character, checkList);               
                
            }
        }

        private void LoopOverChars(int lineIndex)
        {
            var nOfChars = Sheet.Pattern[lineIndex].Count;
            for (int i = 0; i < nOfChars; i++)
            {
                CheckInitialIsHash(lineIndex, i);
            }
        }

        private void LoopOverLines()
        {
            var nOfLines = Sheet.Pattern.Count;

            for (int i = 0; i < nOfLines; i++)
            {
                LoopOverChars(i);
            }
        }



        public void CountPieces()
        {
            
            LoopOverLines();
        }



    }
}
