using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodingGameUnfoldingPaper;

class Solution
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);

        var sheet = new Sheet();
        sheet.Pattern = new List<List<Char>>();

        for (int i = 0; i < H; i++)
        {
            string row = Console.ReadLine();
            sheet.Pattern.Add(row.ToList());
        }

        for (int i = 0; i < N; i++)
        {
            sheet.Unfold();
        }

        var pieceCounter = new PieceCounter();
        pieceCounter.Sheet = sheet;
        pieceCounter.CountPieces();


        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(pieceCounter.Counter);
    }
}