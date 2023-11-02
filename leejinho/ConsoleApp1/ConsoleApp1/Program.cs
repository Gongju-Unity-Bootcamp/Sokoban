using System;

class Sokoban
{
    static void Main()
    {
        Console.ResetColor();
        Console.CursorVisible = false;
        Console.Title = "bravearc";
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        int playerY = 5;
        int playerX = 10;
        int boxX = 25;
        int boxY = 25;
        int T = 75;
        int T2 = 25;
        

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(playerY, playerX);
            Console.Write("O");
            Console.SetCursorPosition(boxX, boxY);
            Console.Write("B");
            ConsoleKeyInfo KeyInfo = Console.ReadKey();


            if (KeyInfo.Modifiers == ConsoleModifiers.Shift)
            {
                if (KeyInfo.Key == ConsoleKey.UpArrow && playerX > 2)
                {
                    playerX -= 2;
                }

                if (KeyInfo.Key == ConsoleKey.DownArrow && playerX + 3 < Console.BufferHeight)
                {
                    playerX += 2;
                }

                if (KeyInfo.Key == ConsoleKey.LeftArrow && playerY > 2)
                {
                    playerY -= 2;
                }

                if (KeyInfo.Key == ConsoleKey.RightArrow && playerY + 3 < Console.BufferWidth)
                {
                    playerY += 2;
                }
            }
            else
            {
                if (KeyInfo.Key == ConsoleKey.UpArrow && playerX > 0)
                {
                    playerX -= 1;
                }

                if (KeyInfo.Key == ConsoleKey.DownArrow && playerX + 1 < Console.BufferHeight)
                {
                    playerX += 1;
                }

                if (KeyInfo.Key == ConsoleKey.LeftArrow && playerY > 0)
                {
                    playerY -= 1;
                }

                if (KeyInfo.Key == ConsoleKey.RightArrow && playerY + 1 < Console.BufferWidth)
                {
                    playerY += 1;
                }
            }
            
            if (playerX == boxX && playerY == boxY)
            {
                playerY = T;
                playerX = T2;
            }
        }
    }
}