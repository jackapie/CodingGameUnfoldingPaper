using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameUnfoldingPaper
{
    public class Sheet
    {
        public List<List<Char>> Pattern { get; set; }

        public void UnfoldDownToUp()
        {
            var newLines = new List<List<Char>>(Pattern);
            newLines.Reverse();
            Pattern = newLines.Concat(Pattern).ToList();
        }

        public void UnfoldRightToLeft()
        {
            var nOfLines = Pattern.Count;
            
            for (int i = 0; i < nOfLines; i++)
            {
                char[] charArray = Pattern[i].ToArray();
                Array.Reverse(charArray);
                Pattern[i] = charArray.Concat(Pattern[i]).ToList();
                
            }
        }

        public void Unfold()
        {
            UnfoldDownToUp();
            UnfoldRightToLeft();
            
        }

        
    }
}
