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
            /// Render 초기화
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I am 믿습니다! A-Men~.";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();


            // 플레이어 좌표
            // 박스의 기능 : 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
            int playerX = 10;
            int playerY = 20;

            Direction playerMoveDirection = Direction.None;
            //int playerDirection = 0; // 0 : None, 1 : Left, 2 : Right, 3 : Up, 4 : Down
            //
            //const int LeftDiection = 1;
            //const int RightDiection = 2;
            //const int UpDiection = 3;
            //const int DownDiection = 4;

            //박스 좌표
            int boxX = 15;
            int boxY = 10;

            //벽 좌표
            //int wallX = 7;
            //int wallY = 7;
            int[] wallpositionsX = new int[5] { 7, 7, 7, 7, 7 };
            int[] wallpositionsY = new int[5] { 7, 8, 9, 10, 11 };

            //골 좌표
            //int goalX = 15;
            //int goalY = 15;
            int[] goalpositionsX = new int[5] { 12, 13, 14, 15, 16 };
            int[] goalpositionsY = new int[5] { 13, 14, 15, 16, 17 };

            while (true)
            {
                /// --------------------------------Render---------------------------------
                Console.Clear();
                Console.CursorVisible = false;

                //플레이어를 그렸음
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");


                //목표를 그렸음
                for (int i = 0; i < goalpositionsX.Length; ++i)
                {
                    Console.SetCursorPosition(goalpositionsX[i], goalpositionsY[i]);
                    Console.Write("G");
                }

                //벽을 만듦
                //Console.SetCursorPosition(wallX, wallY);
                //Console.Write("#");
                int wallCount = wallpositionsX.Length;
                for(int i = 0; i < wallCount; i++)
                {
                    Console.SetCursorPosition(wallpositionsX[i], wallpositionsY[i]);
                    Console.Write("W");
                }

                //박스가 골에 들어갔을 때 색이 변한다.
                int goalCount = goalpositionsX.Length;
                for(int i = 0; i < goalCount; i++)
                {
                    if (boxX == goalpositionsX[i] && boxY == goalpositionsY[i])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(boxX, boxY);
                        Console.Write("B");
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxX, boxY);
                        Console.Write("B");
                    }
                }

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
                //if (wallX == newPlayerX && wallY == newPlayerY || wallX == newBoxX && wallY == newBoxY)
                //{
                //    continue;
                //}
                bool hitwall = false;

                for (int i = 0; i < wallCount; ++i)
                {
                    if (wallpositionsX[i] == newPlayerX && wallpositionsY[i] == newPlayerY
                        || wallpositionsX[i] == newBoxX && wallpositionsY[i] == newBoxY)
                    {
                        hitwall = true;
                        break;
                    }
                }

                if (hitwall)
                {
                    continue;
                }
                //

                //플레이어 콘솔 밖으로 나갔을때 오류 해결
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }
                // 박스 콘솔 밖으로 나갔을때 오류 해결
                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    boxX = newBoxX;
                }
                else
                {
                    switch (playerDirection) //플레이어가 콘솔 밖으로 나가지못하게 플레이어의 좌표를 0로 잡아준다 .
                    {
                        case Direction.Left:
                            playerX += 1;
                            break;
                        case Direction.Right:
                            playerX -= 1;
                            break;
                    }
                }

                //박스가 콘솔밖으로 나갔을때 오류 해결
                if (0 <= newBoxY && newBoxY < Console.BufferHeight)
                {
                    boxY = newBoxY;
                }
                else
                {
                    switch (playerDirection) //박스가 콘솔 밖으로 나가는 것을 방지하기위해 박스를 0으로 잡아준다.
                    {
                        case Direction.Up:
                            playerY += 1;
                            break;

                        case Direction.Down:
                            playerY -= 1;
                            break;
                    }
                }

                //if (playerX == wallX && playerY == wallY)
                //{
                //    switch (playerMoveDirection)
                //    {
                //        case Direction.Left:
                //            playerX = wallX + 1;
                //            break;
                //
                //        case Direction.Right:
                //            playerX = wallX - 1;
                //            break;
                //
                //        case Direction.Up:
                //            playerY = wallY + 1;
                //            break;
                //
                //        case Direction.Down:
                //            playerY = wallY - 1;
                //            break;
                //    }
                //}

                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerMoveDirection)
                    {
                        case Direction.Left:
                            playerX = boxX + 1;
                            break;

                    }
                }

                bool goalin = false;
                for (int i = 0; i < goalCount; i++)
                {
                    if (newBoxX == goalpositionsX[i] && newBoxY == goalpositionsY[i]
                        || goalpositionsX[i] == newBoxX && goalpositionsY[i] == newBoxY)
                    {
                        goalin = true;
                        break;
                    }

                    //Console.Clear();
                    //Console.WriteLine($"GameOver : {playerMoveDirection}");
                    //Environment.Exit(1); //프로그램을 종료한다
                }
                


            }
        }
    }
}

