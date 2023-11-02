using System;

namespace Sokoban
{
    public class Program
    {
        public static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I am 믿습니다.";
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int playerX = 10;
            int playerY = 20;

            while (true)
            {
                /// Render
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");

                /// ProcessInput
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                /// 처음
                if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                {
                    if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 2)
                    {
                        playerX -= 2;
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 3 < Console.BufferWidth)
                    {
                        playerX += 2;
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 2)
                    {
                        playerY -= 2;
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow && playerY + 3 < Console.BufferHeight)
                    {
                        playerY += 2;
                    }
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                    {
                        playerX -= 1;
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 1 < Console.BufferWidth)
                    {
                        playerX += 1;
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
                    {
                        playerY -= 1;
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow && playerY + 1 < Console.BufferHeight)
                    {
                        playerY += 1;
                    }
                }
                /// 끝
            }
        }
    }
}