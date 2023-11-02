using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sokobanhyeok
{
    enum Direction
    {

        // 0 : none, 1 : Left, 2 : Right, 3 : Up, 4 : Down
        None, Left, Right, Up, Down
    }
    internal class Program
    {
        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "Highway to Hell";
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            int playerX = 0;
            int playerY = 0;

            int boxX = 1;
            int boxY = 1;

            int wallX = 4;
            int wallY = 4;

            int goalX = 6;
            int goalY = 6;

            Direction playerDirection = Direction.None;

            while (true)
            {
                // while문 안에서 Clear, CursorVisible 초기화를 한번 더 실행한다.
                Console.Clear();
                Console.CursorVisible = false;
                
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("O");

                Console.SetCursorPosition(boxX, boxY);
                Console.Write("X");

                Console.SetCursorPosition(wallX, wallY);
                Console.Write("#");

                Console.SetCursorPosition(goalX, goalY);
                Console.Write("G");
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                // newPlayer와 같은 임시 데이터로 다루어야 한다.
                int newBoxX = boxX;
                int newBoxY = boxY;


                playerDirection = Direction.None;

                // 플레이어가 콘솔 화면을 이동한다.
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

                // Box의 기능 : 플레이어와 충돌했을 때(if), 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
                // 충돌 : player, box의 좌표값이 같다.
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
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }
                if (wallX == newPlayerX && wallY == newPlayerY || wallX == newBoxX && wallY == newBoxY)
                {
                    continue;
                }

                // newPlayer Console 화면
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                // newBox Console 화면
                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    boxX = newBoxX;
                }
                if (0 <= newBoxY && newBoxY < Console.BufferHeight)
                {
                    boxY = newBoxY;
                }

                if (boxX == goalX && boxY == goalY)
                {
                    break;
                }

                // Shift 빠른 이동 구현 중..
                // if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.LeftArrow)
                // {
                //     newPlayerX -= 5;
                // }
                // if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.RightArrow)
                // {
                //     newPlayerX += 5;
                // }
            }
            Console.Clear();
            Console.WriteLine("축하합니다. 클리어");
        }
    }
}