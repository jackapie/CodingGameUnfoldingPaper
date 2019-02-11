using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameUnfoldingPaper
{
    public class Sheet
    {
        public List<string> Pattern { get; set; }

        private void UnfoldDownToUp()
        {
            throw new NotImplementedException();
        }

        private void UnfoldRightToLeft()
        {
            throw new NotImplementedException();
        }

        public void Unfold()
        {
            UnfoldDownToUp();
            UnfoldRightToLeft();
            
        }

        
    }
}
