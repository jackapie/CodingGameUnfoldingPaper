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
    public class PieceCounterTests
    {
        [TestMethod()]
        public void CountPiecesTest()
        {
            var sheet = new Sheet();
            sheet.Pattern = new List<string>()
            {
                "###",
                "#..",
                "#.#"
            }.Select(e => e.ToCharArray().ToList()).ToList();

            var pieceCounter = new PieceCounter();
            pieceCounter.Sheet = sheet;
            pieceCounter.CountPieces();
            var counter = pieceCounter.Counter;
            Assert.AreEqual(2, counter);
        }
    }
}