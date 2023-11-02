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
        int[] playerPos = { 0, 0 };
        int[,] portalPos = { { 10, 10 }, { 4, 6 }, { 17, 2 } };
        int[,] transPos = { { 27, 13 }, { 20, 6 }, { 5, 15 } };
        string[] directionCode = { " ", "←", "→", "↑", "↓" };
        Direction playerDirection = Direction.None; //0: None, 1: Left, 2: Right, 3: Up, 4: Down
                                                    //enumerate로 정리하면 깔끔해짐


        //박스의 기능: 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
        //우리가 알고 있는 데이터: 플레이어 좌표, 박스 좌표
        int boxX = 7;
        int boxY = 7;

        int wallX = 8;
        int wallY = 8;

        int goalX = 12;
        int goalY = 12;

        //int flag = 0;

        while (true)
        {
            /// Render
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.Write("◆");

            Console.SetCursorPosition(boxX, boxY);
            Console.Write("▲");

            Console.SetCursorPosition(wallX, wallY);
            Console.Write("○");

            Console.SetCursorPosition(goalX, goalY);
            Console.Write("△");


            //Process Input
            //key 입력 값 받기
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            ConsoleModifiers modifiers = keyInfo.Modifiers;

            //Update
            int newPlayerX = playerPos[0];
            int newPlayerY = playerPos[1];

            //box
            //플레이어와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
            int newBoxX = boxX;
            int newBoxY = boxY;


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

            if (newPlayerX == newBoxX && newPlayerY == newBoxY)
            {
                switch (playerDirection)
                {
                    case Direction.Left: //left
                        newBoxX -= 1;
                        break;
                    case Direction.Right: //right
                        newBoxX += 1;
                        break;
                    case Direction.Up: //Up
                        newBoxY -= 1;
                        break;
                    case Direction.Down: //Down
                        newBoxY += 1;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Wrong direction data!\nPlayer Direction: {playerDirection}");
                        Environment.Exit(1);
                        break;

                        ;
                }
            }


            //벽 기능: 벽의 위치에는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어 좌표)
            if (wallX == newPlayerX && wallY == newPlayerY || wallX == newBoxX && wallY == newBoxY)
                continue;


            if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
            {
                playerPos[0] = newPlayerX;
            }

            if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
            {
                playerPos[1] = newPlayerY;
            }

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
                Thread.Sleep(150);
                Console.SetCursorPosition(15, 15);
                Console.WriteLine("Congratulation! You clear this stage!");
                break;
            }

            if (key == ConsoleKey.R)
            {
                playerPos[0] = 0;
                playerPos[1] = 0;
                boxX = 7;
                boxY = 7;
            }

            if (key == ConsoleKey.Escape)
                return;

        }
    }
}