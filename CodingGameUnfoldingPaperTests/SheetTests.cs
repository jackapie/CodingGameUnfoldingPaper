using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingGameUnfoldingPaper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameUnfoldingPaper.Tests
{
    [TestClass()]
    public class SheetTests
    {
        [TestMethod()]
        public void UnfoldTest()
        {
            var sheet = new Sheet();
            sheet.Pattern = new List<string>()
            {
                "###",
                "#..",
                "#.#"
            };

            sheet.Unfold();

            Assert.AreEqual(6, sheet.Pattern.Count);
            Assert.AreEqual("#.##.#", sheet.Pattern[0]);
            Assert.AreEqual("#.##.#", sheet.Pattern[5]);
        }
    }
}