using System;
using System.Net.Sockets;
enum Direction
{
    None,
    Left,
    Right,
    Up,
    Down
 }

namespace Bible
{
    internal class Program
    {

        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "My Sokonan";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();                                    

            // 플레이어
            int playerX = 10;
            int playerY = 5;
            // int speed = 1;

            // 박스
            int boxX = 7;
            int boxY = 7;

            // 골~
            int goalX = 30;
            int goalY = 30;

            Direction playerDirection = Direction.None;

            while (true)
            {
                // ---------------------- Render ----------------------
                Console.Clear();
                Console.CursorVisible = false;

                // 플레이어를 출력한다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("★");

                // 박스를 출력한다.
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("□");

                // ---------------------- ProcessInput ----------------------
                // 유저로부터 입력을 받는다.
                ConsoleKeyInfo keyInfo = Console.ReadKey();


                // ---------------------- Update ----------------------
                int newPlayerX = playerX;
                int newPlayerY = playerY;

                int newBoxX = boxX;
                int newBoxY = boxY;


                // 플레이어 이동
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    newPlayerX -= 1;
                    playerDirection = Direction.Left;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    newPlayerX += 1;
                    playerDirection = Direction.Right;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    newPlayerY -= 1;
                    playerDirection = Direction.Up;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    newPlayerY += 1;
                    playerDirection = Direction.Down;
                }

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                // }

                // 플레이어와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
                if ( newPlayerX == newBoxX  && newPlayerY == newBoxY ) 
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            newBoxX -= 1;
                            break;
                        case Direction.Right:
                            newBoxX += 1;
                            break;
                        case Direction.Up:
                            newBoxY -= 1;
                            break;
                        case Direction.Down:
                            newBoxY += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                // 박스 유효성
                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    boxX = newBoxX;
                }
                else
                {
                    switch(playerDirection)
                    {
                        case Direction.Left:
                            newPlayerX += 1;
                            break;
                        case Direction.Right:
                            newPlayerX -= 1;
                            break;
                    }
                }
                if (0 <= newBoxY && newBoxY < Console.BufferHeight)
                {
                    boxY = newBoxY;
                }
                else
                {
                    switch (playerDirection)
                    {
                        case Direction.Up:
                            newPlayerY += 1;
                            break;
                        case Direction.Down:
                            newPlayerY -= 1;
                            break;

                    }
                }

                //플레이어 유효성
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }




                /*
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
                { */
            }
        }
    }
}