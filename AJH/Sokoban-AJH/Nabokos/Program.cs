namespace Nabokos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "NABOKOS";
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // 플레이어 좌표
            int playerX = 60;
            int playerY = 15;

            // 플레이어 이동 속도
            int moveSpeed = 1;

            Direction playerDirection = Direction.None;    // 0 : None, 1 : Left, 2 : Right, 3 : Up, 4 : Down

            // 박스의 기능 : 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
            int[] box = { new Random().Next(0, Console.BufferWidth), new Random().Next(0, Console.BufferHeight) };  // 박스의 위치 랜덤으로

            int[] wallPositionX = new int[5];
            int[] wallPositionY = new int[5];
            // 벽의 위치
            for (int i=0; i<wallPositionX.Length; i++)
            {
                wallPositionX[i] = new Random().Next(0, Console.BufferWidth);
                wallPositionY[i] = new Random().Next(0, Console.BufferHeight);
            }

            int[] goalX = new int[5];
            int[] goalY = new int[5];

            for (int i = 0; i < goalX.Length; i++)
            {
                goalX[i] = new Random().Next(0, Console.BufferWidth);
                goalY[i] = new Random().Next(0, Console.BufferHeight);
            }

            while (true)
            {
                // ---------------- Render -------------------

                Console.Clear();
                Console.CursorVisible = false;

                ConsoleColor prevColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                for(int i=0; i<goalX.Length; i++)
                {
                    Console.SetCursorPosition(goalX[i], goalY[i]);
                    Console.Write("□");
                }
                Console.ForegroundColor = prevColor;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for(int i=0; i<wallPositionX.Length; i++)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write("▥");
                }
                Console.ForegroundColor = prevColor;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(box[0], box[1]);
                Console.Write("▣");
                Console.ForegroundColor = prevColor;

                // 박스가 골에 들어갈 경우 박스의 색상 변경
                for (int i = 0; i < goalX.Length; i++)
                {
                    if (goalX[i] == box[0] && goalY[i] == box[1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(box[0], box[1]);
                        Console.Write("▣");
                        Console.ForegroundColor = prevColor;
                    }
                }

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("¶");

                // ------------- Process Input ---------------

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // ---------------- Update -------------------

                // 쉬프트 대쉬(2칸 이동)
                if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                {
                    moveSpeed = 2;
                    if (playerX - moveSpeed < 0) moveSpeed = 1;
                    if (playerX + moveSpeed < 0) moveSpeed = 1;
                    if (playerY - moveSpeed > Console.BufferWidth) moveSpeed = 1;
                    if (playerY + moveSpeed > Console.BufferHeight) moveSpeed = 1;
                }
                else
                {
                    moveSpeed = 1;
                }

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                playerDirection = Direction.None;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    newPlayerX -= moveSpeed;
                    playerDirection = Direction.Left;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    newPlayerX += moveSpeed;
                    playerDirection = Direction.Right;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    newPlayerY -= moveSpeed;
                    playerDirection = Direction.Up;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    newPlayerY += moveSpeed;
                    playerDirection = Direction.Down;
                }

                // 플레이어와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
                int newBoxX = box[0];
                int newBoxY = box[1];

                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:         // LEFT
                            newBoxX -= 1;
                            break;
                        case Direction.Right:         // RIGHT
                            newBoxX += 1;
                            break;
                        case Direction.Up:           // UP
                            newBoxY -= 1;
                            break;
                        case Direction.Down:         // DOWN
                            newBoxY += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                bool isWall = false;

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (플레이어 좌표) && (벽의 좌표) != (박스 좌표)
                // 플레이어가 벽을 향해 이동하려 할 때
                for(int i=0; i<wallPositionX.Length; i++)
                {
                    if ((wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY) || (wallPositionX[i] == newBoxX && wallPositionY[i] == newBoxY))
                    {
                        isWall = true;
                        break;
                    }
                }

                if (isWall)
                {
                    continue;
                }

                int[] newGoalX = new int[5];
                int[] newGoalY = new int[5];

                for(int i=0; i<newGoalX.Length; i++)
                {
                    newGoalX[i] = goalX[i];
                    newGoalY[i] = goalY[i];
                }

                bool toGoal = false;
                
                // 플레이어가 골을 향해 이동하려 할 때
                for(int i=0; i<newGoalX.Length; i++)
                {
                    if (newPlayerX == newGoalX[i] && newPlayerY == newGoalY[i])
                    {
                        toGoal = true;
                        break;
                    }
                }

                if (toGoal)
                {
                    continue;
                }

                // 플레이어가 박스를 이동하다 박스가 콘솔창의 끝에 도달했을 때
                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    box[0] = newBoxX;
                }
                else
                {
                    continue;
                }
                if (0 <= newBoxY && newBoxY < Console.BufferHeight)
                {
                    box[1] = newBoxY;
                }
                else
                {
                    continue;
                }

                // 플레이어가 콘솔창을 나가지 못하게
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                for(int i=0; i<newGoalX.Length; i++)
                {
                    // 박스가 골에 도달했을 시
                    if (newBoxX == newGoalX[i] && newBoxY == newGoalY[i])
                    {
                        break;
                    }
                }
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("!!CLEAR!!");
        }
    }
}

enum Direction
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 3,
    Down = 4
}