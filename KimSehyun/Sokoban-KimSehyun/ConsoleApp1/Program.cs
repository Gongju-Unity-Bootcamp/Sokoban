using System;

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
            int goalX = 9;
            int goalY = 9;

            int wallX = 12;
            int wallY = 12;

            int boxX = 7;
            int boxY = 7;

            while (true)
            {
                /// Render
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(goalX, goalY);
                Console.Write("G");
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");
                if (boxX == goalX && boxY == goalY)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("B");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("B");
                }
                Console.SetCursorPosition(wallX, wallY);
                Console.Write("X");

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

                /// ArgumentOutOfRange 예외 처리 변수
                int newBoxX = boxX;
                int newBoxY = boxY;

                /// Player와 Box가 충돌했을 때, Box는 Player가 이동한 방향으로 한 칸 이동한다.
                if (newBoxX == newPlayerX && newBoxY == newPlayerY)
                {
                    switch (playerDirection) { 
                        case Direction.Left: /// Left
                            newBoxX -= 1;
                            break;
                        case Direction.Right: /// Right
                            newBoxX += 1;
                            break;
                        case Direction.Up: /// Up
                            newBoxY -= 1;
                            break;
                        case Direction.Down: /// Down
                            newBoxY += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"Wrong direction data : {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                /// 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다.
                if (wallX == newPlayerX && wallY == newPlayerY
                    || wallX == newBoxX && wallY == newBoxY)
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
                        case Direction.Right:
                            playerY -= 1;
                            break;
                    }
                }
            }
            //Console.Clear();
            //Console.WriteLine("축하합니다. 소코반 성공!");
        }
    }
}