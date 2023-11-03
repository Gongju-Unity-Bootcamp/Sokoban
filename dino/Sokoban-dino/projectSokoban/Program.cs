using System;
using System.ComponentModel;

class Program
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    static void Main()
    {
        //Initialize
        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Title = "YELLOW";
        Console.CursorVisible = false;
        Console.Clear();


        //player 위치
        int[] playerPosition = { 0, 0 };
        int[,] portalPosition = { { 10, 10 }, { 4, 6 }, { 17, 2 } };
        int[,] transPosition = { { 27, 13 }, { 20, 6 }, { 5, 15 } };
        string[] directionCode = { " ", "←", "→", "↑", "↓" };
        Direction playerDirection = Direction.None; //0: None, 1: Left, 2: Right, 3: Up, 4: Down
                                                    //enumerate로 정리하면 깔끔해짐


        //박스의 기능: 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
        //우리가 알고 있는 데이터: 플레이어 좌표, 박스 좌표
        int[] boxPositionX = { 7, 8, 9 };
        int[] boxPositionY = { 9, 9, 9 };

        bool[] isBoxOnGoal = new bool[3]; //box와 연관된 객체이므로 똑같이 배열화


        int[] wallPositionX = { 1, 2, 3, 4, 5 };
        int[] wallPositionY = { 5, 5, 5, 5, 5 };


        int[] goalPositionX = { 12, 13, 14 };
        int[] goalPositionY = { 12, 13, 14 };


        bool isCollidedToWall = false;
        int pushedBoxIndex = 0;

        ConsoleColor prevColor = Console.ForegroundColor;

        while (true)
        {
            /// Render
            Console.Clear();
            Console.CursorVisible = false;


            for (int i = 0; i < wallPositionX.Length; i++)
            {
                Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                Console.Write("*");
            }

            for (int i = 0; i < goalPositionX.Length; i++)
            {
                Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                Console.Write("△");
            }

            Console.SetCursorPosition(playerPosition[0], playerPosition[1]);
            Console.Write("◆");

            for (int i = 0; i < boxPositionX.Length; i++)
            {
                Console.SetCursorPosition(boxPositionX[i], boxPositionY[i]);
                Console.Write("▲");
            }

            for (int i = 0; i < boxPositionY.Length; i++)
            {
                if (isBoxOnGoal[i])
                {
                    //Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(boxPositionX[pushedBoxIndex], boxPositionY[pushedBoxIndex]);
                    Console.Write("▲");
                    Console.ForegroundColor = prevColor;
                    //Console.WriteLine("Congratulation! You clear this stage!");
                }
            }


            //Process Input
            //key 입력 값 받기
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            ConsoleModifiers modifiers = keyInfo.Modifiers;

            //Update
            int newPlayerX = playerPosition[0];
            int newPlayerY = playerPosition[1];

            //box
            //플레이어와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
            int[] newBoxPositionX = new int[boxPositionX.Length];
            boxPositionX.CopyTo(newBoxPositionX, 0);
            int[] newBoxPositionY = new int[boxPositionY.Length];
            boxPositionY.CopyTo(newBoxPositionY, 0);

            if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
            {
                newPlayerX -= 1;
                playerDirection = Direction.Left;
            }

            if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                newPlayerX += 1;
                playerDirection = Direction.Right;
            }

            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                newPlayerY -= 1;
                playerDirection = Direction.Up;
            }

            if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                newPlayerY += 1;
                playerDirection = Direction.Down;
            }

            //box system
            for (int i = 0; i < boxPositionX.Length; i++)
            {
                //false == (newPlayerX == newBoxPositionX[i] && newPlayerY == newBoxPosition[i])
                //!(newPlayerX == newBoxPositionX[i] && newPlayerY == newBoxPositionY[i])
                if (newPlayerX != newBoxPositionX[i] || newPlayerY != newBoxPositionY[i]) //드모르간 법칙
                {
                    continue;
                }

                switch (playerDirection)
                {
                    case Direction.Left: //left
                        newBoxPositionX[i] -= 1;
                        break;
                    case Direction.Right: //right
                        newBoxPositionX[i] += 1;
                        break;
                    case Direction.Up: //Up
                        newBoxPositionY[i] -= 1;
                        break;
                    case Direction.Down: //Down
                        newBoxPositionY[i] += 1;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Wrong direction data!\nPlayer Direction: {playerDirection}");
                        Environment.Exit(1);
                        break;
                }

            }


            //벽 기능: 벽의 위치에는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어 좌표)
            //여러가지 박스 중에 플레이어가 움직일 수 있는 박스는 1개
            //그 박스를 특정할 수 있으면?

            for (int i = 0; i < newBoxPositionX.Length; i++)
            {
                if (newBoxPositionX[i] != boxPositionX[i] || newBoxPositionY[i] != boxPositionY[i])
                {
                    pushedBoxIndex = i;
                }
            }

            for (int i = 0; i < wallPositionX.Length; i++)
            {
                if (wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY ||
                    wallPositionX[i] == newBoxPositionX[pushedBoxIndex] && wallPositionY[i] == newBoxPositionY[pushedBoxIndex])
                {
                    isCollidedToWall = true;
                    break;
                }

            }

            if (isCollidedToWall)
            {
                isCollidedToWall = false;
                continue;
            }

            bool isCollidedToBox = false;
            for (int i = 0; i < newBoxPositionX.Length; i++)
            {
                if (i == pushedBoxIndex)
                    continue;

                if (newBoxPositionX[i] == newBoxPositionX[pushedBoxIndex] &&
                    newBoxPositionY[i] == newBoxPositionY[pushedBoxIndex])
                {
                    isCollidedToBox = true;
                    break;
                }
            }

            if (isCollidedToBox)
                continue;


            if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
            {
                playerPosition[0] = newPlayerX;
            }

            if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
            {
                playerPosition[1] = newPlayerY;
            }


            for (int i = 0; i < goalPositionX.Length; i++)
            {
                if (newBoxPositionX[pushedBoxIndex] == goalPositionX[i] && newBoxPositionY[pushedBoxIndex] == goalPositionY[i])
                {
                    isBoxOnGoal[i] = true;
                    break;
                }
                else
                {
                    isBoxOnGoal[i] = false;
                }
            }

            newBoxPositionX.CopyTo(boxPositionX, 0);
            newBoxPositionY.CopyTo(boxPositionY, 0);

            for (int i = 0; i < newBoxPositionX.Length; i++)
            {
                if (0 <= newBoxPositionX[i] && newBoxPositionX[i] < Console.BufferWidth)
                {
                    boxPositionX[i] = newBoxPositionX[i];
                }
            }

            for (int i = 0; i < newBoxPositionY.Length; i++)
            {
                if (0 <= newBoxPositionY[i] && newBoxPositionY[i] < Console.BufferHeight)
                {
                    boxPositionY[i] = newBoxPositionY[i];
                }
            }

            if (key == ConsoleKey.Escape)
                return;

        }
    }
}