using System;

class Program
{
    static void Main()
    {
        //Initialize
        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Title = "YELLOW";
        Console.CursorVisible = false;
        Console.Clear();

        //player 위치
        int[] playerPos = { 0, 0 };
        int playerAcc = 1;

        while(true)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(10, 10);
            Console.Write("□");

            Console.SetCursorPosition(4, 6);
            Console.Write("□");

            Console.SetCursorPosition(17, 2);
            Console.Write("□");

            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.Write("■");

            //key 입력 값 받기
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            ConsoleModifiers modifiers = keyInfo.Modifiers;

            if(key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
            {
                playerPos[0] = Math.Clamp(--playerPos[0] * playerAcc, 0, Console.BufferWidth - 1);
            }

            if(key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                playerPos[0] = Math.Clamp(++playerPos[0] * playerAcc, 0, Console.BufferWidth - 1);
            }

            if(key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                playerPos[1] = Math.Clamp(--playerPos[1] * playerAcc, 0, Console.BufferHeight - 1);
            }

            if(key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                playerPos[1] = Math.Clamp(++playerPos[1] * playerAcc, 0, Console.BufferHeight - 1);
            }

            if(key == ConsoleKey.R)
            {
                playerPos[0] = 0;
                playerPos[1] = 0;
            }

            if(modifiers == ConsoleModifiers.Shift)
            {
                playerAcc = 2;
            }
            else
            {
                playerAcc = 1;
            }

            if (playerPos[0] == 10 && playerPos[1] == 10)
            {
                Thread.Sleep(150);
                playerPos[0] = 27;
                playerPos[1] = 13;
            }
            
            if (playerPos[0] == 4 && playerPos[1] == 6)
            {
                Thread.Sleep(150);
                playerPos[0] = 20;
                playerPos[1] = 6;
            }

            if (playerPos[0] == 17 && playerPos[1] == 2)
            {
                Thread.Sleep(150);
                playerPos[0] = 5;
                playerPos[1] = 15;
            }

            if (key == ConsoleKey.Escape)
                return;

        }
    }
}