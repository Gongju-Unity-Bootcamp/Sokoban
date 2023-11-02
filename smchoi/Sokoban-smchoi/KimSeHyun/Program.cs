using System.Data;

namespace KimSeHyun
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
            Direction playerDirection = Direction.None;

            int boxX = 7;
            int boxY = 7;

            int wallX = 8;
            int wallY = 8;

            int goalX = 15;
            int goalY = 15;
            
            while (true)
            {
                //// ------------------------------ Render ---------------------------
                Console.Clear();              
                Console.CursorVisible = false;

                Console.SetCursorPosition(playerX, playerY);
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("P");
                Console.ForegroundColor = prevColor;

                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");

                Console.SetCursorPosition(wallX, wallY);
                Console.Write("#");

                Console.SetCursorPosition(goalX, goalY);
                Console.Write("G");

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
                int newBoxX = boxX;
                int newBoxY = boxY;
                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
                {
                    // 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
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

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어의 좌표)
                if (wallX == newPlayerX && wallY == newPlayerY ||
                    wallX == newBoxX && wallY == newBoxY)
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

                boxX = newBoxX;
                boxY = newBoxY;

                if (boxX == goalX && boxY == goalY)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("축하합니다. 소코반을 깼습니다.");
        }

    }
}