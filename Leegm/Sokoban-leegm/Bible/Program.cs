using System;
using System.Net.Sockets;

namespace Bible
{
    internal class Program
    {
        enum Direction
        {
            None,
            Left,
            Right,
            Up,
            Down
        }

        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "My Sokonan";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            ConsoleColor prevColor = Console.ForegroundColor;

            // 플레이어
            int playerX = 0;
            int playerY = 0;
            // int speed = 1;

            // 박스
            int boxX = 7;
            int boxY = 7;
            bool isBoxOnGoal = false;

            // 골~
            int[] wallPositionX = new int[5] { 12, 13, 14, 15, 16 };
            int[] wallPositionY = new int[5] { 12, 12, 12, 12, 12 };

            int[] goalPositionX = new int[3] { 1, 6, 5};
            int[] goalPositionY = new int[3] { 2, 4, 3 };


            Direction playerDirection = Direction.None;
            

            while (true)
            {
                // ---------------------- Render ----------------------
                Console.Clear();
                Console.CursorVisible = false;

                // 플레이어를 출력한다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("★");
                // 골 지점을 출력한다.
                for (int i = 0; i < goalPositionX.Length; ++i)
                {
                    Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                    Console.Write("⊙");
                }
                // 박스를 출력한다.
                if (isBoxOnGoal)
                {
                    Console.SetCursorPosition(boxX, boxY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("◆");
                    Console.ForegroundColor = prevColor;
                }
                else
                {
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("◆");
                }
                // 벽을 출력한다.
                for (int i = 0; i < wallPositionX.Length; ++i)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write("▣");
                }

                // ---------------------- ProcessInput ----------------------
                // 유저로부터 입력을 받는다.
                ConsoleKeyInfo keyInfo = Console.ReadKey();


                // ---------------------- Update ----------------------
                int newPlayerX = playerX;
                int newPlayerY = playerY;



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

                int newBoxY = boxY;
                int newBoxX = boxX;
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

                // 벽
                bool wallCheck = false;
                for (int i = 0; i < wallPositionX.Length; i++) 
                {
                    if (wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY ||
                        wallPositionX[i] == newBoxX && wallPositionY[i] == newBoxY)
                    {
                        wallCheck = true;
                        break;
                    }
                }
                if (wallCheck)
                {
                    continue;
                }
                        
                // 박스 골 위치 채크.
                for (int i = 0; i < goalPositionX.Length; i++)
                {
                    if (boxX == goalPositionX[i] && boxY == goalPositionY[i])
                    {
                        isBoxOnGoal = true;
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

                // // 골~
                // if ( newBoxX == goalX &&  newBoxY == goalY)
                // {
                //     break;
                // }                
            }
            Console.Clear();
            Console.WriteLine("ㅊㅊㅊㅊㅊ");
        }
    }
}