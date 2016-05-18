using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tetris_2016_05_17
{
    class Program
    {

        static void Main(string[] args)
        {
            Board board = new Board(24, 10);
            var score = 0;
            while (true)
            {
                board.CurrentPiece.Draw(board);
                board.Draw();
                Console.WriteLine("Score: {0}", score);
                Thread.Sleep(100);
                board.CurrentPiece.UnDraw(board);
                if (!board.CurrentPiece.Locked)
                {
                    board.CurrentPiece.MoveDown();
                }
                score += 100;
            }
        }
    }
}
