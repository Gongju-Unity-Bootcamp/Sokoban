using System;
using System.Runtime.InteropServices;

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
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            /// Update 이동 처리 변수
            int playerX = 10;
            int playerY = 20;

            /// Player 방향 처리 변수
            /// 0 = None, 1 = Left, 2 = Right, 3 = Up, 4 = Down

            Direction playerDirection = Direction.None;

            /// Box는 Player와 충돌했을 때, 플레이어가 이동한 방향으로 한 칸 이동한다.
            /// 알고 있는 데이터 : Player 좌표와 Box 좌표
            int[] goalPositionX = new int[3] { 15, 8, 2 };
            int[] goalPositionY = new int[3] { 5, 4, 6 };
            int goalCount = goalPositionX.Length;

            int[] wallPositionX = new int[5] { 8, 9, 13, 5, 10 };
            int[] wallPositionY = new int[5] { 8, 1, 6, 9, 3 };
            int wallCount = wallPositionX.Length;

            int[] boxPositionX = new int[3] { 7, 7, 6 };
            int[] boxPositionY = new int[3] { 7, 6, 4 };
            int boxCount = boxPositionX.Length;

            bool[] isBoxOnGoal = new bool[3];

            while (true)
            {
                /// Render
                Console.Clear();
                Console.CursorVisible = false;
                for (int i = 0; i < goalCount; ++i)
                {
                    Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                    Console.Write("G");
                }
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");
                for (int i = 0; i < boxCount; ++i)
                {
                    if (isBoxOnGoal[i])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(boxPositionX[i], boxPositionY[i]);
                        Console.Write("B");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxPositionX[i], boxPositionY[i]);
                        Console.Write("B");
                    }
                }
                for (int i = 0; i < wallCount; ++i)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write("X");
                }

                /// Process Input
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                /// ArgumentOutOfRange 예외 처리 변수
                int newPlayerX = playerX;
                int newPlayerY = playerY;

                /// Player 좌표를 Update하여 이동시킨다.
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    newPlayerX -= 1;
                    playerDirection = Direction.Left; // Left
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    newPlayerX += 1;
                    playerDirection = Direction.Right; // Right
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    newPlayerY -= 1;
                    playerDirection = Direction.Up; // Up
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    newPlayerY += 1;
                    playerDirection = Direction.Down; // Down
                }

                int[] newBoxX = new int[boxCount];
                int[] newBoxY = new int[boxCount];

                /// ArgumentOutOfRange 예외 처리 변수
                boxPositionX.CopyTo(newBoxX, 0);
                boxPositionY.CopyTo(newBoxY, 0);


                int pushedBoxIndex = 0;

                /// Player와 Box가 충돌했을 때, Box는 Player가 이동한 방향으로 한 칸 이동한다.
                for (int i = 0; i < boxCount; ++i)
                {
                    if (false == (newPlayerX == newBoxX[i] && newPlayerY == newBoxY[i]))
                    {
                        continue;
                    }

                    pushedBoxIndex = i;

                    switch (playerDirection)
                    {
                        case Direction.Left: /// Left
                            newBoxX[i] -= 1;
                            break;
                        case Direction.Right: /// Right
                            newBoxX[i] += 1;
                            break;
                        case Direction.Up: /// Up
                            newBoxY[i] -= 1;
                            break;
                        case Direction.Down: /// Down
                            newBoxY[i] += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"Wrong direction data : {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                bool checkWall = false;

                /// 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다.
                for (int i = 0; i < wallCount; ++i)
                {
                    if (wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY
                    || wallPositionX[i] == newBoxX[pushedBoxIndex] && wallPositionY[i] == newBoxY[pushedBoxIndex])
                    {
                        checkWall = true;
                        break;
                    }
                }

                bool checkBox = false;

                for (int i = 0; i < boxCount; ++i)
                {
                    if (i != pushedBoxIndex && (newBoxX[pushedBoxIndex] == newBoxX[i] && newBoxY[pushedBoxIndex] == newBoxY[i]))
                    {
                        checkBox = true;
                        break;
                    }
                }

                if (checkBox)
                {
                    continue;
                }

                if (checkWall)
                {
                    continue;
                }

                /// 예외 처리를 위한 유효성 검사
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                /// 예외 처리를 위한 유효성 검사
                for (int i = 0; i < boxCount; ++i)
                {
                    if (0 <= newBoxX[i] && newBoxX[i] < Console.BufferWidth)
                    {
                        boxPositionX[i] = newBoxX[i];
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
                    if (0 <= newBoxY[i] && newBoxY[i] < Console.BufferHeight)
                    {
                        boxPositionY[i] = newBoxY[i];
                    }
                    else
                    {
                        switch (playerDirection)
                        {
                            case Direction.Up:
                                playerY += 1;
                                break;
                            case Direction.Right:
                                playerY -= 1;
                                break;
                        }
                    }
                }

                isBoxOnGoal[pushedBoxIndex] = false;

                for (int i = 0; i < goalCount; ++i)
                {
                    for (int j = 0; j < boxCount; ++j)
                    {
                        if (boxPositionX[i] == goalPositionX[j] && boxPositionY[i] == goalPositionY[j])
                        {
                            isBoxOnGoal[i] = true;
                        }
                    }
                }

                bool isClear = true;

                for (int i = 0; i < isBoxOnGoal.Length; ++i)
                {
                    isClear &= isBoxOnGoal[i];
                }

                if (isClear)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("축하합니다. 소코반 성공!");
        }

        // Render
        // Input
        // CheckWall
        // CheckBox
        // CheckPlayer
    }
}