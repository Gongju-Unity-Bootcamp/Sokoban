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

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.Write("◆");

            Console.SetCursorPosition(boxX, boxY);
            Console.Write("▲");

            Console.SetCursorPosition(10, 10);
            Console.Write("△");

            Console.SetCursorPosition(4, 6);
            Console.Write("△");

            Console.SetCursorPosition(17, 2);
            Console.Write("△");


            //key 입력 값 받기
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            ConsoleModifiers modifiers = keyInfo.Modifiers;

            int newPlayerX = playerPos[0];
            int newPlayerY = playerPos[1];

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

            //Portal1
            if (playerPos[0] == portalPos[0, 0] && playerPos[1] == portalPos[0, 1])
            {
                newPlayerX = portalPos[0, 0] + 1;
            }

            if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
            {
                playerPos[0] = newPlayerX;
            }

            if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
            {
                playerPos[1] = newPlayerY;
            }

            if (key == ConsoleKey.R)
            {
                playerPos[0] = 0;
                playerPos[1] = 0;
                boxX = 7;
                boxY = 7;
            }

            //Portal2
            if (playerPos[0] == 4 && playerPos[1] == 6)
            {
                Thread.Sleep(150);
                playerPos[0] = transPos[1, 0];
                playerPos[1] = transPos[1, 1];
            }

            //Portal3
            if (playerPos[0] == 17 && playerPos[1] == 2)
            {
                Thread.Sleep(150);
                playerPos[0] = transPos[2, 0];
                playerPos[1] = transPos[2, 1];
            }

            //box
            //플레이어와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한 칸 이동한다.
            int newBoxX = boxX;
            int newBoxY = boxY;

            if (playerPos[0] == newBoxX && playerPos[1] == newBoxY)
            {
                switch (playerDirection)
                {
                    case Direction.Left: //left
                        newBoxX = Math.Clamp(newBoxX - 1, 0, Console.BufferWidth - 1);
                        newPlayerX = newBoxX + 1;
                        break;
                    case Direction.Right: //right
                        newBoxX = Math.Clamp(newBoxX + 1, 0, Console.BufferWidth - 1);
                        newPlayerX = newBoxX - 1;
                        break;
                    case Direction.Up: //Up
                        newBoxY = Math.Clamp(newBoxY - 1, 0, Console.BufferHeight - 1);
                        newPlayerY = newBoxY + 1;
                        break;
                    case Direction.Down: //Down
                        newBoxY = Math.Clamp(newBoxY + 1, 0, Console.BufferHeight - 1);
                        newPlayerY = newBoxY - 1;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Wrong direction data!\nPlayer Direction: {playerDirection}");
                        Environment.Exit(1);
                        break;
                }
             
            }

            boxX = newBoxX;
            boxY = newBoxY;

            if (key == ConsoleKey.Escape)
                return;

        }
    }
}