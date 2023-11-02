using System;


namespace Bible
{
    internal class Program
    {
        static void Main()
        {
            Console.ResetColor();                               // 컬러를 초기화 한다.
            Console.CursorVisible = false;                      // 커서를 숨긴다.
            Console.Title = "My Sokonan";                       // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.DarkBlue;    // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Gray;       // 글꼴색을 설정한다.
            Console.Clear();                                    // 콘솔 창에 출력된 내용을 모두 지운다.

            // 플레이어 좌표
            int playerX = 10;
            int playerY = 5;

            while (true) 
            {
                // ------------------ Render ---------------------
                Console.Clear();
                Console.CursorVisible = false;

                // 플레이어를 출력한다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("◆");

                // ------------------ ProcessInput ---------------
                // 유저로부터 입력을 받는다.
                ConsoleKeyInfo keyInfo = Console.ReadKey();


                // ------------------ Update ---------------------
                if (keyInfo.Key == ConsoleKey.Escape)           // Esc 누를시 종료
                {
                    Environment.Exit(0);
                }
                if (keyInfo.Modifiers == ConsoleModifiers.Control)              
                {
                    if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 1)
                    {
                        playerX -= 2;
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 2 < Console.BufferWidth)
                    {
                        playerX += 2;
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 1)
                    {
                        playerY -= 2;
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow && playerY + 2 < Console.BufferHeight)
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
            }
        }
    }
}