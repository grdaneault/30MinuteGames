using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_2016_05_17
{
    class Board
    {
        public int NumRows { get; private set; }
        public int NumCols { get; private set; }

        public Piece CurrentPiece { get; private set; }


        

        public char[,] State { get; private set; }

        public Board(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            State = new char[rows, cols];
            CurrentPiece = new Piece(0, 5, 'I');
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('+');
            for (int col = 0; col < NumCols; col++)
            {
                Console.Write("--");
            }
            Console.WriteLine('+');
            for (int row = 0; row < NumRows; row++)
            {
                Console.Write('|');
                for (int col = 0; col < NumCols; col++)
                {
                    Console.Write(State[row, col] == 0 ? "  " : "{0}{0}", State[row, col], State[row, col]);
                }
                Console.WriteLine('|');
            }
            Console.Write('+');
            for (int col = 0; col < NumCols; col++)
            {
                Console.Write("--");
            }
            Console.WriteLine('+');
        }

        void Drop()
        {
            
        }

    }
}
