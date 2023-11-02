using System.Data;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Sokoban
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
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I am 믿습니다.";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            int playerX = 10;
            int playerY = 20;

            int cnt = 0;

            Direction playerDirection = Direction.None;

            int isBoxOnGoal = 0;
            int isBoxOnGoal2 = 0;
            int isBoxOnGoal3 = 0;


            int[] boxX = new int[3] { 5, 7, 9 };
            int[] boxY = new int[3] { 5, 7, 9 };

            int[] wallPositionX = new int[5] { 8, 9, 13, 5, 10 };
            int[] wallPositionY = new int[5] { 8, 1, 6, 9, 3 };

            int[] goalPositionX = new int[3] { 15, 8, 2 };
            int[] goalPositionY = new int[3] { 15, 4, 5 };

            int[] newboxX = new int[3] { 0, 0, 0};
            int[] newboxY = new int[3] { 0, 0, 0};

            int[] preboxX = new int[3] { 0, 0, 0 };
            int[] preboxY = new int[3] { 0, 0, 0 };

            while (true)
            {
                //// ------------------------------ Render ---------------------------
                Console.Clear();
                Console.CursorVisible = false;

                cnt = 0;

                Console.SetCursorPosition(playerX, playerY);
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("P");
                Console.ForegroundColor = prevColor;

               

                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(goalPositionX[index], goalPositionY[index]);
                    Console.Write("G");
                }
                for (int index = 0; index < boxX.Length; index++)
                {
                    if (isBoxOnGoal == 1)
                    {
                        Console.SetCursorPosition(boxX[0], boxY[0]);
                        prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B");
                        Console.ForegroundColor = prevColor;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxX[0], boxY[0]);
                        Console.Write("B");
                    }
                    if (isBoxOnGoal2 == 1)
                    {
                        Console.SetCursorPosition(boxX[1], boxY[1]);
                        prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B");
                        Console.ForegroundColor = prevColor;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxX[1], boxY[1]);
                        Console.Write("B");
                    }
                    if (isBoxOnGoal3 == 1)
                    {
                        Console.SetCursorPosition(boxX[2], boxY[2]);
                        prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B");
                        Console.ForegroundColor = prevColor;
                    }
                    else
                    {
                        Console.SetCursorPosition(boxX[2], boxY[2]);
                        Console.Write("B");
                    }
                }

                isBoxOnGoal = 0;
                isBoxOnGoal2 = 0;
                isBoxOnGoal3 = 0;


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
                for (int index = 0; index < boxX.Length; index++)
                {
                    newboxX[index] = boxX[index];
                    newboxY[index] = boxY[index];

                    if (newPlayerX == newboxX[index] && newPlayerY == newboxY[index])
                    {
                        // 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
                        switch (playerDirection)
                        {
                            case Direction.Left:
                                newboxX[index] -= 1;
                                break;
                            case Direction.Right:
                                newboxX[index] += 1;
                                break;
                            case Direction.Up:
                                newboxY[index] -= 1;
                                break;
                            case Direction.Down:
                                newboxY[index] += 1;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                                Environment.Exit(0);
                                break;
                        }
                    }
                }

                // 박스의 기능 : 박스의 위치로는 어떤 오브젝트도 위치할 수 없다. =>(박스의 좌표) !=(박스의 좌표) &&

                if (newboxX[0] == newboxX[1] && newboxY[0] == newboxY[1] ||
                newboxX[0] == newboxX[2] && newboxY[0] == newboxY[2])
                { continue; }
                else if (newboxX[1] == newboxX[2] && newboxY[1] == newboxY[2] ||
                    newboxX[1] == newboxX[0] && newboxY[1] == newboxY[0])
                { continue; }
                else if (newboxX[2] == newboxX[1] && newboxY[2] == newboxY[1] ||
                newboxX[2] == newboxX[0] && newboxY[2] == newboxY[0])
                { continue; }










                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어의 좌표)
                bool isCollidedToWall = false;
                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    if (wallPositionX[index] == newPlayerX && wallPositionY[index] == newPlayerY ||
                    wallPositionX[index] == newboxX[0] && wallPositionY[index] == newboxY[0])
                    {
                        isCollidedToWall = true;
                        break;
                    }
                    else if (wallPositionX[index] == newPlayerX && wallPositionY[index] == newPlayerY ||
                    wallPositionX[index] == newboxX[1] && wallPositionY[index] == newboxY[1])
                    {
                        isCollidedToWall = true;
                        break;
                    }
                    else if (wallPositionX[index] == newPlayerX && wallPositionY[index] == newPlayerY ||
                    wallPositionX[index] == newboxX[2] && wallPositionY[index] == newboxY[2])
                    {
                        isCollidedToWall = true;
                        break;
                    }

                }

                if (isCollidedToWall)
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

              
              
  
          

                   for (int index = 0; index < boxX.Length; index++)
                     {
                         boxX[index] = newboxX[index];
                         boxY[index] = newboxY[index];
                     }
                

                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    if (boxX[0] == goalPositionX[index] && boxY[0] == goalPositionY[index])
                    {
                        isBoxOnGoal = 1;
                    }
                   
                    if(boxX[1] == goalPositionX[index] && boxY[1] == goalPositionY[index])
                    {
                        isBoxOnGoal2 = 1;
                    }
                 
                    if (boxX[2] == goalPositionX[index] && boxY[2] == goalPositionY[index])
                    {
                        isBoxOnGoal3 = 1;
                    }
                  
                }

                if (isBoxOnGoal + isBoxOnGoal2 + isBoxOnGoal3 ==3)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("축하합니다. 소코반을 깼습니다.");
        }

    }
}