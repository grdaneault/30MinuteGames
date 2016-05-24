using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird_2016_05_23
{
    class Screen
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int PlayerY { get; private set; }
        private int _playerVelocity;
        private int _playerAcceleration;

        public List<Obscatcle> Obscatcles { get; private set; }

        public Screen(int width, int height)
        {
            Width = width;
            Height = height;
            PlayerY = height/2;
            _playerAcceleration = 0;
            _playerVelocity = 1;
            Obscatcles = new List<Obscatcle>();
            for (var i = 0; i < 100; i++)
            {
                Obscatcles.Add(new Obscatcle(height / 4, 10 * i, Direction.Down));
                Obscatcles.Add(new Obscatcle(height - height / 4, 10 * i, Direction.Up));
            }
        }

        public void Tick()
        {
            _playerVelocity += _playerAcceleration;
            PlayerY += _playerVelocity;
            Obscatcles.RemoveAll(obs => obs.Update());
            Console.SetCursorPosition(2, 1);

            for (var col = 0; col < Width; col++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
            for (var row = 0; row < Height; row++)
            {
                Console.Write("|");
                for (var col = 0; col < Width; col++)
                {
                    if (row == PlayerY && col == 0)
                    {
                        Console.Write("^^");
                    }
                    else if (Obscatcles.Any(obs => obs.Here(row, col)))
                    {
                        Console.Write("##");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine("|");
            }
            for (var col = 0; col < Width; col++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
        }

        public bool IsGG()
        {
            return PlayerY <= 0 || PlayerY >= Height || Obscatcles.Any(obj => obj.Here(PlayerY, 0));
        }

        public void BeamMeUp()
        {
            PlayerY -= 1;
        }
    }
}
