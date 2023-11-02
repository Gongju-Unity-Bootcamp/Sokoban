using System;

namespace Sokoban_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "LHJ Sokoban";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            // 플레이어 좌표
            int playerX = 10;
            int playerY = 20;

            int boxX = 15;
            int boxY = 15;
            // 콘솔크기
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;


            while (true)
            {
                // ----------------------------- Render ------------------------------

                Console.Clear();                 //이전 화면을 지운다.
                Console.CursorVisible = false;    //커서를 숨긴다.
                                                  //플레이어를 출력한다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");
                // ----------------------------- ProcessInput------------------------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //keyinfo.key : BackSpace, Space, LeftArrow
                //keyInfo.Modifiers : Ctrl, Shift, Alt

                // ----------------------------- Update ------------------------------

                if (keyInfo.Key == ConsoleKey.A && playerX > 0)
                {
                    //playerX = (int)Math.Max(0, playerX - 1);
                    playerX -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerX -= 3;
                    }

                }
                if (keyInfo.Key == ConsoleKey.D && playerX + 1 < WindowWidth)
                {
                    //playerX = (int)Math.Max(0, playerX + 1); ;
                    playerX += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerX += 3;
                    }

                }
                if (keyInfo.Key == ConsoleKey.W && playerY > 0)
                {
                    //playerY = (int)Math.Max(0, playerY - 1);
                    playerY -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerY -= 3;
                    }

                }
                if (keyInfo.Key == ConsoleKey.S && playerY + 1 < WindowHeight)
                {
                    //playerY = (int)Math.Max(0, playerY + 1);
                    playerY += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerY += 3;
                    }

                }
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    playerY = 0;
                    playerX = 0;
                }
                if (playerX == boxX && playerY == boxY)
                {
                    playerY = 10;
                    playerY = 10;
                }





            }




        }
    }
}
