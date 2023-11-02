using System;

namespace Sokoban
{
    class Program
    {
        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = ("j");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            int PlayerX = 10;
            int PlayerY = 10;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.Write("j");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;
                if (key == ConsoleKey.RightArrow && PlayerX +1<Console.BufferWidth)
                {
                    PlayerX += 1;
                }
                if (key == ConsoleKey.LeftArrow && PlayerX>0)
                {
                    PlayerX -= 1;
                }
                if (key == ConsoleKey.UpArrow && PlayerY>0)
                {
                    PlayerY -= 1;
                }
                if (key == ConsoleKey.DownArrow && PlayerY +1 <Console.BufferHeight)
                {
                    PlayerY += 1;
                }
            }
        }
    }
}
