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
        Direction playerDirection = Direction.None; //0: None, 1: Left, 2: Right, 3: Up, 4: Down
                                                    //enumerate로 정리하면 깔끔해짐


        //박스의 기능: 플레이어와 충돌했을 때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
        //우리가 알고 있는 데이터: 플레이어 좌표, 박스 좌표
        int[] boxPositionX = { 7 };
        int[] boxPositionY = { 7 };

        int[] wallPositionX = { 1, 2, 3, 4, 5 };
        int[] wallPositionY = { 5, 5, 5, 5, 5 };

        int[] goalPositionX = { 12, 13, 14 };
        int[] goalPositionY = { 12, 13, 14 };

        //int flag = 0;

        while (true)
        {
            /// Render
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(playerPosition[0], playerPosition[1]);
            Console.Write("◆");


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

            Console.SetCursorPosition(boxPositionX[0], boxPositionY[0]);
            Console.Write("▲");


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
            int newBoxX = boxPositionX[0];
            int newBoxY = boxPositionY[0];

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
                }
            }


            //벽 기능: 벽의 위치에는 어떤 오브젝트도 위치할 수 없다. => (벽의 좌표) != (박스의 좌표) && (벽의 좌표) != (플레이어 좌표)
            bool isCollidedToWall = false;
            for (int i = 0; i < wallPositionX.Length; i++)
            {
                if (wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY || wallPositionX[i] == newBoxX && wallPositionY[i] == newBoxY)
                {
                    isCollidedToWall = true;
                    break;
                }

            }

            if (isCollidedToWall)
                continue;


            if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
            {
                playerPosition[0] = newPlayerX;
            }

            if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
            {
                playerPosition[1] = newPlayerY;
            }

            //if (wallX == newBoxX && wallY == newBoxY)
            //continue;

            if (0 <= newBoxX && newBoxX < Console.BufferWidth)
            {
                boxPositionX[0] = newBoxX;
            }

            if (0 <= newBoxY && newBoxY < Console.BufferHeight)
            {
                boxPositionY[0] = newBoxY;
            }


            if (key == ConsoleKey.R)
            {
                playerPosition[0] = 0;
                playerPosition[1] = 0;
                boxPositionX[0] = 7;
                boxPositionY[0] = 7;
            }

            if (key == ConsoleKey.Escape)
                return;

        }
    }
}