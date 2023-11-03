using System;
using System.IO;

namespace Jinkoban
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    class Sokoban
    {
        static void Main()
        {
            //기본 설정
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "Jinkoban";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Direction playerDirection = Direction.None;

            //객체의 설정 값
            int playerX = 1;
            int playerY = 1;
            int[] boxPositionX = new int[3] { 5, 21, 27 };
            int[] boxPositionY = new int[3] { 5, 3, 27 };
            bool[] isboxOngoal = new bool[3];


            int[] wallPositionX = new int[5] { 10, 11, 12, 13, 14 };
            int[] wallPositionY = new int[5] { 10, 11, 12, 13, 14 };
            int[] goalPositionX = new int[3] { 7, 9, 17};
            int[] goalPositionY = new int[3] { 16, 17, 18 };
            bool isBoxonGoal = false;

            //---------------------------Render
            while (true)

            {
                Console.Clear();
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("O");

                //---------------boxs
                for (int index = 0; index < boxPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(boxPositionX[index], boxPositionY[index]);
                    Console.Write("@");
                }

                //---------------walls
                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(wallPositionX[index], wallPositionY[index]);
                    Console.Write("%");
                }

                //---------------goal
                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(goalPositionX[index], goalPositionY[index]);
                    Console.Write("G");
                }

                //-------------------player 이동	
                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                int newplayerX = playerX;
                int newplayerY = playerY;
                playerDirection = Direction.None;

                if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    newplayerX -= 1;
                    playerDirection = Direction.Left;
                }
                if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    newplayerX += 1;
                    playerDirection = Direction.Right;
                }
                if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    newplayerY -= 1;
                    playerDirection = Direction.Up;
                }
                if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    newplayerY += 1;
                    playerDirection = Direction.Down;
                }

                //------------------box 이동
                int[] newboxPositionX = new int[boxPositionX.Length];
                boxPositionX.CopyTo(newboxPositionX, 0);
                int[] newboxPositionY = new int[boxPositionY.Length];
                boxPositionY.CopyTo(newboxPositionY, 0);

                int pushdeBoxIndex = 0;
                for (int index = 0; index < boxPositionX.Length; index++)
                {
                    if (newplayerX != newboxPositionX[index] || newplayerY != newboxPositionY[index])
                    {
                        continue;
                    }

                    pushdeBoxIndex = index;

                    switch (playerDirection)
                    {
                        case Direction.Left:
                            newboxPositionX[index] -= 1;
                            break;
                        case Direction.Right:
                            newboxPositionX[index] += 1;
                            break;
                        case Direction.Up:
                            newboxPositionY[index] -= 1;
                            break;
                        case Direction.Down:
                            newboxPositionY[index] += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"큰일큰일큰일 에러가 발생했습니다");
                            Environment.Exit(0);
                            break;
                    }

                }

                bool isCollidedtoWall = false;
                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    if (wallPositionX[index] == newplayerX && wallPositionY[index] == newplayerY ||
                        wallPositionX[index] == boxPositionX[pushdeBoxIndex] && wallPositionY[index] == boxPositionY[pushdeBoxIndex])
                    {
                        isCollidedtoWall = true;
                        break;
                    }
                }

                if (isCollidedtoWall)
                {
                    continue;
                }

                bool isCollidedToBox = false;
                for (int index = 0; index < newboxPositionX.Length; ++index)
                {
                    if (index == pushdeBoxIndex)
                    {
                        continue;
                    }

                    if (newboxPositionX[index] == newboxPositionX[pushdeBoxIndex] && newboxPositionY[index] == newboxPositionY[pushdeBoxIndex])
                    {
                        isCollidedToBox = true;
                        break;
                    }
                }

                if (isCollidedToBox)
                {
                    continue;
                }



                if (0 < newplayerX && newplayerX < Console.BufferWidth)
                {
                    playerX = newplayerX;
                }
                if (0 < newplayerY && newplayerY < Console.BufferHeight)
                {
                    playerY = newplayerY;
                }

                for (int index = 0; index < boxPositionX.Length; ++index)
                {
                    if (0 < newboxPositionX[index] && newboxPositionX[index] < Console.BufferWidth)
                    {
                        boxPositionX[index] = newboxPositionX[index];
                    }
                    if (0 < newboxPositionY[index] && newboxPositionY[index] < Console.BufferHeight)
                    {
                        boxPositionY[index] = newboxPositionY[index];
                    }
                }

                //
                newboxPositionX.CopyTo(boxPositionX, 0);
                newboxPositionY.CopyTo(boxPositionY, 0);

                isboxOngoal[pushdeBoxIndex] = false;
                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    if (boxPositionX[pushdeBoxIndex] == goalPositionX[index] && boxPositionY[pushdeBoxIndex] == goalPositionY[index])
                    {
                        isboxOngoal[pushdeBoxIndex] = true;
                        break;
                    }
                }


                goalPositionX.CopyTo(goalPositionX, 0);
                goalPositionY.CopyTo(goalPositionY, 0);

                bool isClear = true;
                for (int index = 0; index < isboxOngoal.Length; ++index)
                {
                    isClear &= isboxOngoal[index];
                }

                if (isClear)
                {
                    break;
                }

            }
            Console.Clear();
            Console.WriteLine("끝이당헤헿");

        }
    }
}

