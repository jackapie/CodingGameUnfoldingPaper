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
            }.Select(e => e.ToCharArray().ToList()).ToList();

            sheet.Unfold();
            var line0 = new string(sheet.Pattern[0].ToArray());
            var line5 = new string(sheet.Pattern[5].ToArray());
            var line1 = new string(sheet.Pattern[1].ToArray());

            Assert.AreEqual(6, sheet.Pattern.Count);
            Assert.AreEqual("#.##.#", line0);
            Assert.AreEqual("#.##.#", line5);
            Assert.AreEqual("..##..", line1);
        }

        [TestMethod()]
        public void UnfoldDownToUpTest()
        {
            var sheet = new Sheet();
            sheet.Pattern = new List<string>()
            {
                "###",
            }.Select(e => e.ToList()).ToList();

            sheet.UnfoldDownToUp();

            var line0 = new string(sheet.Pattern[0].ToArray());
            var line1 = new string(sheet.Pattern[1].ToArray());

            Assert.AreEqual(2, sheet.Pattern.Count);
            Assert.AreEqual("###", line0);
            Assert.AreEqual("###", line1);
        }

        [TestMethod()]
        public void UnfoldRightToLeftTest()
        {
            var sheet = new Sheet();
            sheet.Pattern = new List<string>()
            {
                "##.",
            }.Select(e => e.ToCharArray().ToList()).ToList();

            sheet.UnfoldRightToLeft();

            var line0 = new string(sheet.Pattern[0].ToArray());

            Assert.AreEqual(1, sheet.Pattern.Count);
            Assert.AreEqual(".####.", line0);
        }

        [TestMethod()]
        public void UnfoldTest2()
        {
            var sheet = new Sheet();
            sheet.Pattern = new List<string>()
            {
"############################################",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"#..........................................#",
"############################################"
            }.Select(e => e.ToCharArray().ToList()).ToList();

            for (int i = 0; i < 5; i++)
            {
                sheet.Unfold();
            }

            var pieceCounter = new PieceCounter();
            pieceCounter.Sheet = sheet;
            pieceCounter.CountPieces();



        }
    }
}