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

        
        private void CheckChar(List<List<Char>> pattern, int lineIndex, int charIndex)
        {
            var character = pattern[lineIndex][charIndex];
            if (character == '#')
            {
                pattern[lineIndex][charIndex] = '.';
                CheckNeighbouringChars(pattern, lineIndex, charIndex);
            }
        }

        

        private void CheckNeighbouringChars(List<List<Char>> pattern, int lineIndex, int charIndex)
        {
            if (charIndex + 1 < pattern[lineIndex].Count)
            {
                CheckChar(pattern, lineIndex, charIndex + 1);
            }
            if (lineIndex + 1 < pattern.Count)
            {
                CheckChar(pattern, lineIndex + 1, charIndex);
            }
            if (charIndex > 0)
            {
                CheckChar(pattern, lineIndex, charIndex - 1);
            }
            if (lineIndex > 0)
            {
                CheckChar(pattern, lineIndex - 1, charIndex);
            }
        }



        private void CheckInitialIsHash(List<List<Char>> pattern, int lineIndex, int charIndex)
        {
            var initialCharacter = pattern[lineIndex][charIndex];
            if (initialCharacter == '#')
            {
                Counter += 1;
                pattern[lineIndex][charIndex] = '.';
                CheckNeighbouringChars(pattern, lineIndex, charIndex);
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
