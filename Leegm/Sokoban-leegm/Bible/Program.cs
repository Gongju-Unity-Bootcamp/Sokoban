using System;
using System.Runtime.InteropServices;

namespace Bible
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
    internal class Program
    {

        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I am 믿습니다.";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            int playerX = 10;
            int playerY = 20;
            Direction playerDirection = Direction.None;

            int[] boxPositionX = { 7, 1, 4 };
            int[] boxPositionY = { 5, 2, 3 };
            bool[] isBoxOnGoal = new bool[3];

            int[] wallPositionX = new int[5] { 8, 9, 13, 5, 10 };
            int[] wallPositionY = new int[5] { 8, 1, 6, 9, 3 };

            int[] goalPositionX = new int[3] { 15, 8, 2 };
            int[] goalPositionY = new int[3] { 15, 4, 5 };

            while (true)
            {
                //// ------------------------------ Render ---------------------------
                Console.Clear();
                Console.CursorVisible = false;

                Console.SetCursorPosition(playerX, playerY);
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("P");
                Console.ForegroundColor= prevColor;

                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(goalPositionX[index], goalPositionY[index]);
                    Console.Write("G");
                }
                for (int index = 0; index < isBoxOnGoal.Length; ++index)
                {
                    if (isBoxOnGoal[index])
                    {
                        Console.SetCursorPosition(boxPositionX[index], boxPositionY[index]);
                        prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B");
                        Console.ForegroundColor = prevColor;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxPositionX[index], boxPositionY[index]);
                        Console.Write("B");
                    }
                }

                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(wallPositionX[index], wallPositionY[index]);
                    Console.Write("#");
                }

                // ------------------------------ ProcessInput ---------------------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // ------------------------------ Update ---------------------------
                int newPlayerX = playerX;
                int newPlayerY = playerY;
                playerDirection = Direction.None;

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

                // 플레이어와 박스가 충돌했을 때 => (플레이어 좌표) == (박스 좌표)
                // int newBoxX = boxX;
                // boxPosition들을 모두 newBox에 복사하는 것
                int[] newBoxPositionX = new int[boxPositionX.Length];
                boxPositionX.CopyTo(newBoxPositionX, 0);
                int[] newBoxPositionY = new int[boxPositionY.Length];
                boxPositionY.CopyTo(newBoxPositionY, 0);

                int pushedBoxIndex = 0;
                for (int index = 0; index < boxPositionX.Length; index++)
                {
                    // ! (NOT)
                    // true -> false
                    // false -> true
                    //if (!(newPlayerX == newBoxPositionX[index] && newPlayerY == newBoxPositionY[index]))
                    //if (false == (newPlayerX == newBoxPositionX[index] && newPlayerY == newBoxPositionY[index]))
                    if (newPlayerX != newBoxPositionX[index] || newPlayerY != newBoxPositionY[index])
                    {
                        continue;
                    }

                    pushedBoxIndex = index;
          
                    // 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            newBoxPositionX[index] -= 1;
                            break;
                        case Direction.Right:
                            newBoxPositionX[index] += 1;
                            break;
                        case Direction.Up:
                            newBoxPositionY[index] -= 1;
                            break;
                        case Direction.Down:
                            newBoxPositionY[index] += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어의 좌표)
                bool isCollidedToWall = false;
                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    if (wallPositionX[index] == newPlayerX && wallPositionY[index] == newPlayerY ||
                    wallPositionX[index] == newBoxPositionX[pushedBoxIndex] && wallPositionY[index] == newBoxPositionY[pushedBoxIndex])
                    {
                        isCollidedToWall = true;
                        break;
                    }
                }

                if (isCollidedToWall)
                {
                    continue;
                }

                bool isCollidedToBox = false;
                for (int index = 0; index < newBoxPositionX.Length; ++index)
                {
                    if (index == pushedBoxIndex)
                    {
                        continue;
                    }

                    if (newBoxPositionX[index] == newBoxPositionX[pushedBoxIndex] &&
                        newBoxPositionY[index] == newBoxPositionY[pushedBoxIndex])
                    {
                        isCollidedToBox = true;
                        break;
                    }
                }

                if (isCollidedToBox)
                {
                    continue;
                }

                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }

                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                newBoxPositionX.CopyTo(boxPositionX, 0);
                newBoxPositionY.CopyTo(boxPositionY, 0);

                isBoxOnGoal[pushedBoxIndex] = false;
                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    if (boxPositionX[pushedBoxIndex] == goalPositionX[index] && boxPositionY[pushedBoxIndex] == goalPositionY[index])
                    {
                      isBoxOnGoal[pushedBoxIndex] = true;

                      break;
                    }
                }


                bool isClear = true;
                for (int index = 0; index < isBoxOnGoal.Length; ++index)
                {
                    isClear &= isBoxOnGoal[index];
                }
                if (isClear)
                {
                    break;
                }


            }
        }
    }
}