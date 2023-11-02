namespace Nabokos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reset:
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
            int[] boxX = new int[5];
            int[] boxY = new int[5];

            // 범위가 2, Console.Buffer@#!@ -2 인 이유는 박스, 벽 골이 벽에 붙어서 생성되지 않도록 하기 위해
            for (int i = 0; i < boxX.Length; i++)
            {
                boxX[i] = new Random().Next(2, Console.BufferWidth - 2);
                boxY[i] = new Random().Next(2, Console.BufferHeight - 2);
            }

            bool[] isBoxOnGoal = new bool[boxX.Length];
            int pushedBox = default; // 밀어낸 박스
            int boxOnGoal = 0;

            int[] wallPositionX = new int[15];
            int[] wallPositionY = new int[15];

            // 벽의 위치
            for (int i = 0; i < wallPositionX.Length; i++)
            {
                wallPositionX[i] = new Random().Next(2, Console.BufferWidth - 2);
                wallPositionY[i] = new Random().Next(2, Console.BufferHeight - 2);
            }

            int[] goalX = new int[5];
            int[] goalY = new int[5];

            for (int i = 0; i < goalX.Length; i++)
            {
                goalX[i] = new Random().Next(2, Console.BufferWidth - 2);
                goalY[i] = new Random().Next(2, Console.BufferHeight - 2);
            }

            while (true)
            {
                // ---------------- Render -------------------

                Console.Clear();
                Console.CursorVisible = false;

                ConsoleColor prevColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 0; i < goalX.Length; i++)
                {
                    Console.SetCursorPosition(goalX[i], goalY[i]);
                    Console.Write("□");
                }
                Console.ForegroundColor = prevColor;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < wallPositionX.Length; i++)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write("▥");
                }
                Console.ForegroundColor = prevColor;

                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 0; i < boxX.Length; i++)
                {
                    Console.SetCursorPosition(boxX[i], boxY[i]);
                    Console.Write("▣");
                }
                Console.ForegroundColor = prevColor;

                // 박스가 골에 들어갈 경우 박스의 색상 변경
                for (int i = 0; i < boxX.Length; i++)
                {
                    if (isBoxOnGoal[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(boxX[i], boxY[i]);
                        Console.Write("▣");
                        Console.ForegroundColor = prevColor;
                    }
                }

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("¶");

                // ------------- Process Input ---------------

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // ---------------- Update -------------------

                // R키를 눌러 재시작
                // Reset: 부분으로 이동하여 처음부터 다시 시작한다.
                if(keyInfo.Key == ConsoleKey.R)
                {
                    goto Reset;
                }

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
                int[] newBoxX = new int[5];
                int[] newBoxY = new int[5];

                for (int i = 0; i < newBoxX.Length; i++)
                {
                    newBoxX[i] = boxX[i];
                    newBoxY[i] = boxY[i];
                }

                for (int i = 0; i < newBoxX.Length; i++)
                {
                    if (newPlayerX == newBoxX[i] && newPlayerY == newBoxY[i])
                    {
                        switch (playerDirection)
                        {
                            case Direction.Left:         // LEFT
                                newBoxX[i] -= 1;
                                break;
                            case Direction.Right:         // RIGHT
                                newBoxX[i] += 1;
                                break;
                            case Direction.Up:           // UP
                                newBoxY[i] -= 1;
                                break;
                            case Direction.Down:         // DOWN
                                newBoxY[i] += 1;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                                Environment.Exit(0);
                                break;
                        }
                        pushedBox = i;      // 어떤 박스를 밀었는지 저장
                        break;
                    }
                }

                // 박스를 미는 도중 이동 방향으로 박스가 존재할 시 밀 수 없도록
                for (int i = 0; i < newBoxX.Length; i++)
                {
                    if (pushedBox == i)
                    {
                        continue;
                    }
                    if (newBoxX[pushedBox] == newBoxX[i] && newBoxY[pushedBox] == newBoxY[i])
                    {
                        switch (playerDirection)
                        {
                            case Direction.Left:
                                newPlayerX += 1;
                                newBoxX[pushedBox] += 1;
                                break;
                            case Direction.Right:
                                newPlayerX -= 1;
                                newBoxX[pushedBox] -= 1;
                                break;
                            case Direction.Up:
                                newPlayerY += 1;
                                newBoxY[pushedBox] += 1;
                                break;
                            case Direction.Down:
                                newPlayerY -= 1;
                                newBoxY[pushedBox] -= 1;
                                break;
                        }
                    }
                }

                bool isWall = false;

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (플레이어 좌표) && (벽의 좌표) != (박스 좌표)
                // 플레이어가 벽을 향해 이동하려 할 때
                for (int i = 0; i < wallPositionX.Length; i++)
                {
                    if ((wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY) || (wallPositionX[i] == newBoxX[pushedBox] && wallPositionY[i] == newBoxY[pushedBox]))
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

                for (int i = 0; i < newGoalX.Length; i++)
                {
                    newGoalX[i] = goalX[i];
                    newGoalY[i] = goalY[i];
                }

                bool toGoal = false;

                // 플레이어가 골을 향해 이동하려 할 때
                for (int i = 0; i < newGoalX.Length; i++)
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

                bool isSide = false;

                // 플레이어가 박스를 이동하다 박스가 콘솔창의 끝에 도달했을 때
                for (int i = 0; i < newBoxX.Length; i++)
                {
                    if (0 <= newBoxX[i] && newBoxX[i] < Console.BufferWidth)
                    {
                        boxX[i] = newBoxX[i];
                    }
                    else
                    {
                        isSide = true;
                        break;
                    }
                    if (0 <= newBoxY[i] && newBoxY[i] < Console.BufferHeight)
                    {
                        boxY[i] = newBoxY[i];
                    }
                    else
                    {
                        isSide = true;
                        break;
                    }
                }

                if (isSide)
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

                for (int i = 0; i < newGoalX.Length; i++)
                {
                    // 박스가 골에 도달했을 시
                    if (newBoxX[pushedBox] == newGoalX[i] && newBoxY[pushedBox] == newGoalY[i])
                    {
                        if (!isBoxOnGoal[pushedBox]) // 이미 골에 들어간 박스는 더이상 증가하지 않도록
                        {
                            ++boxOnGoal;
                            isBoxOnGoal[pushedBox] = true;
                        }
                        break;
                    }
                }

                if (boxOnGoal == goalX.Length)
                {
                    break;
                }
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Congratulations, You Won!");
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