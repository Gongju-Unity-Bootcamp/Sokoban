 using System;

enum Direction
{
    None,
    Left,
    Rigth,
    Up,
    Down
}

class pro
{
    static void Main()
    {

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        int playerX = 49;
        int playerY = 20;

        int boxX = 50;
        int boxY = 25;

        Direction playerDirection = Direction.None;

        int[] wallPositionX = new int[5] { 10, 11, 12, 13, 14 };
        int[] wallPositionY = new int[5] { 10, 11, 12, 13, 14 };

        int[] goalPosition = new int[2] { 23, 24 };
        int[] goalDirection = new int[2] { 23, 24 };


        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(playerX, playerY);
            Console.Write("O");
            Console.SetCursorPosition(boxX, boxY);
            Console.Write("B");


            for (int index = 0; index < wallPositionX.Length; ++index)
            {
                Console.SetCursorPosition(wallPositionX[index], wallPositionY[index]);
                Console.Write("X");

            }


            for (int index = 0; index < goalPosition.Length; ++index)
            {
                Console.SetCursorPosition(goalPosition[index], goalPosition[index]);
                Console.Write("G");
            }


            ConsoleKeyInfo KeyInfo = Console.ReadKey();

            int newplayerX = playerX;
            int newplayerY = playerY;

            if (KeyInfo.Key == ConsoleKey.UpArrow)
            {
                newplayerY -= 1;
                playerDirection = Direction.Up;
            }

            if (KeyInfo.Key == ConsoleKey.DownArrow)
            {
                newplayerY += 1;
                playerDirection = Direction.Down;
            }

            if (KeyInfo.Key == ConsoleKey.LeftArrow)
            {
                newplayerX -= 1;
                playerDirection = Direction.Left;
            }

            if (KeyInfo.Key == ConsoleKey.RightArrow)
            {
                newplayerX += 1;
                playerDirection = Direction.Rigth;
            }

            int newboxX = boxX;
            int newboxY = boxY;

            if (newplayerX == newboxX && newplayerY == newboxY)
            {
                switch (playerDirection)
                {
                    case Direction.Left:
                        newboxX -= 1;
                        break;

                    case Direction.Rigth:
                        newboxX += 1;

                        break;

                    case Direction.Up:
                        newboxY -= 1;

                        break;

                    case Direction.Down:
                        newboxY += 1;

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"잘못된 방향 데이터 입니다. 실제 데이터는{playerDirection}");
                        Environment.Exit(0);
                        break;
                }
            }
            bool iscollidedToWall = false;
            for (int indexw = 0; indexw < wallPositionX.Length; ++indexw)
            {
                if (wallPositionX[indexw] == newplayerX && wallPositionY[indexw] == newplayerY || wallPositionY[indexw] == boxY && wallPositionX[indexw] == boxX)
                {
                    iscollidedToWall = true;
                    break;
                }
            }

            if (iscollidedToWall)
            {
                continue;
            }

            if (0 < newplayerX && newplayerX < Console.BufferWidth)
            {
                playerX = newplayerX;
            }

            if (0 < newplayerY && newplayerY < Console.BufferHeight)
            {
                playerY = newplayerY;
            }

            if (0 <= newboxX && newboxX < Console.BufferWidth)
            {
                boxX = newboxX;
            }

            if (0 <= newboxY && newboxY < Console.BufferHeight)
            {
                boxY = newboxY;
            }


            //            bool iscollidedTogoal = false;
            //            for (int index = 0; index < wallPositionY.Length; ++index)
            //            {
            //                if (boxX == wallPositionX[index] && boxY == wallPositionY[index])
            //                {
            //                    break;
            //                }
            //            }
        }
        //Console.Clear();
        //Console.WriteLine("끝");
    }
}