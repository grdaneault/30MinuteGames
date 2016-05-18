using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_2016_05_17
{
    class Piece
    {
        private int row;
        private int col;
        private char shape;
        private int rotation;
        
        public bool Locked { get; private set; }

        public Piece(int row, int col, char shape)
        {
            this.row = row;
            this.col = col;
            this.shape = shape;
            this.rotation = 0;
            Locked = false;
        }

        public void Draw(Board board)
        {
            char toDraw = shape;
            Fill(board, toDraw);
        }

        public void UnDraw(Board board)
        {
            Fill(board, ' ');
        }

        public void MoveDown()
        {
            row++;
        }

        private bool FillAndCheck(Board board, int row, int col, char toDraw)
        {
            board.State[row, col] = toDraw;
            if (row + 1 >= board.NumRows || board.State[row + 1, col] != ' ')
            {
                return true;
            }
            return false;
        }

        private bool Fill(Board board, char toDraw)
        {
            bool final = false;
            switch (shape)
            {
                case 'I':
                    switch (rotation)
                    {
                        case 0:
                        case 2:
                            final = final || FillAndCheck(board, row, col, toDraw);
                            final = final || FillAndCheck(board, row, col + 1, toDraw);
                            final = final || FillAndCheck(board, row, col + 2, toDraw);
                            final = final || FillAndCheck(board, row, col + 3, toDraw);
                            break;
                        case 1:
                        case 3:
                            final = final || FillAndCheck(board, row - 1, col + 1, toDraw);
                            final = final || FillAndCheck(board, row, col + 1, toDraw);
                            final = final || FillAndCheck(board, row + 1, col + 1, toDraw);
                            final = final || FillAndCheck(board, row + 2, col + 1, toDraw);
                            break;
                    }
                    break;
            }

            return final;
        }

    }
}
