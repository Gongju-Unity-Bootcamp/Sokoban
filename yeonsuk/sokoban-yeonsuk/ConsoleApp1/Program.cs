using System;
using System.ComponentModel;

namespace Sokoban
{
    public class Program
    {
        enum Direction
        {
            None = 0,
            Left = 1,
            Right = 2,
            Up = 3,
            Down = 4
        }

        public static void Main()
        {
            /// Render
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I am 믿습니다.";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            // 플레이어 좌표
            // 박스의 기능 : 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
            int playerX = 10;
            int playerY = 20;

            Direction playerMoveDirection = Direction.None;
            //int playerDirection = 0; // 0 : None, 1 : Left, 2 : Right, 3 : Up, 4 : Down

            //const int LeftDiection = 1;
            //const int RightDiection = 2;
            //const int UpDiection = 3;
            //const int DownDiection = 4;

            //박스 좌표
            int boxX = 10;
            int boxY = 10;

            //벽 좌표
            int wallX = 7;
            int wallY = 7;

            //골 좌표
            int goalX = 15;
            int goalY = 15;


            while (true)
            {
                /// --------------------------------Render---------------------------------
                Console.Clear();
                Console.CursorVisible = false;

                //플레이어를 그렸음
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");

                //박스를 그렸음
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");

                //벽을 만듦

                Console.SetCursorPosition(wallX, wallY);
                Console.Write("#");

                //골을 만듦
                Console.SetCursorPosition(goalX, goalY);
                Console.Write("G");

                /// -----------------------------ProcessInput-------------------------------
                ConsoleKeyInfo keyInfo = Console.ReadKey(); //유저로부터 입력 받는다.

                /// ArgumentOutOfRange 예외 처리 변수
                int newPlayerX = playerX;
                int newPlayerY = playerY;
                Direction playerDirection = Direction.Left;

                ///------------------------------- Update----------------------------------

                //캐릭터 이동
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

                // 플레이어와 박스가 충돌했을 때 > 플레이어 좌표 == 박스좌표

                // 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
                int newBoxX = boxX;
                int newBoxY = boxY;


                //박스 이동
                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
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
                            Console.WriteLine($"잘못된 방향 데이터입니다.실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                // 벽의 기능
                if (wallX == newPlayerX && wallY == newPlayerY || wallX == newBoxX && wallY == newBoxY)
                {
                    continue;
                }
                //
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    boxX = newBoxX;
                }
                else
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            playerX += 1;
                            break;
                        case Direction.Right:
                            playerX -= 1;
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
                            playerY += 1;
                            break;

                        case Direction.Down:
                            playerY -= 1;
                            break;
                    }
                }

                if (playerX == wallX && playerY == wallY)
                {
                    switch (playerMoveDirection)
                    {
                        case Direction.Left:
                            playerX = wallX + 1;
                            break;

                        case Direction.Right:
                            playerX = wallX - 1;
                            break;

                        case Direction.Up:
                            playerY = wallY + 1;
                            break;

                        case Direction.Down:
                            playerY = wallY - 1;
                            break;
                    }
                }

                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerMoveDirection)
                    {
                        case Direction.Left:
                            playerX = boxX + 1;
                            break;

                    }
                }
                if (boxX == goalX && boxY == goalY)
                {
                    Console.Clear();
                    Console.WriteLine($"GameOver : {playerMoveDirection}");
                    Environment.Exit(1); //프로그램을 종료한다
                    break;
                }


            }
        }
    }
}

