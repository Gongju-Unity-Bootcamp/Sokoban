using System;
using System.IO;

namespace Jinkoban
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    class Sokoban
    {
        static void Main()
        {
            //기본 설정
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "Jinkoban";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Direction playerDirection = Direction.None;

            //객체의 설정 값
            int playerX = 1;
            int playerY = 1;
            int[] boxPositionX = new int[2] { 5, 6 };
            int[] boxPositionY = new int[2] { 5, 6 };
            int[] wallPositionX = new int[5] { 10, 11, 12, 13, 14 };
            int[] wallPositionY = new int[5] { 10, 11, 12, 13, 14 };
            int[] goalPositionX = new int[2] { 7, 9 };
            int[] goalPositionY = new int[2] { 16, 18 };

            //---------------------------Render
            while (true)

            {
                Console.Clear();
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("O");

                //---------------boxs
                for (int index = 0; index < boxPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(boxPositionX[index], boxPositionY[index]);
                    Console.Write("@");
                }

                //---------------walls
                for (int index = 0; index < wallPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(wallPositionX[index], wallPositionY[index]);
                    Console.Write("%");
                }

                //---------------goal
                for (int index = 0; index < goalPositionX.Length; ++index)
                {
                    Console.SetCursorPosition(goalPositionX[index], goalPositionY[index]);
                    Console.Write("G");
                }

                //-------------------player 이동	
                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                int newplayerX = playerX;
                int newplayerY = playerY;
                playerDirection = Direction.None;

                if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    newplayerX -= 1;
                    playerDirection = Direction.Left;
                }
                if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    newplayerX += 1;
                    playerDirection = Direction.Right;
                }
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

                //------------------box1 이동
                int newboxX = boxPositionX[0];
                int newboxY = boxPositionY[0];

                if (newplayerX == newboxX && newplayerY == newboxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            newboxX -= 1;
                            break;
                        case Direction.Right:
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
                            Console.WriteLine($"큰일큰일큰일 에러가 발생했습니다");
                            Environment.Exit(0);
                            break;
                    }
                }

                // -----------------box2 이동
                int newbox2X = boxPositionX[1];
                int newbox2Y = boxPositionY[1];

                if (newplayerX == newboxX && newplayerY == newboxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:
                            newbox2X -= 1;
                            break;
                        case Direction.Right:
                            newbox2X += 1;
                            break;
                        case Direction.Up:
                            newbox2Y -= 1;
                            break;
                        case Direction.Down:
                            newbox2Y += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"큰일큰일큰일 에러가 발생했습니다");
                            Environment.Exit(0);
                            break;
                    }
                }


                if (0 < newplayerX && newplayerX < Console.BufferWidth)
                {
                    playerX = newplayerX;
                }
                if (0 < newplayerY && newplayerY < Console.BufferHeight)
                {
                    playerY = newplayerY;
                }
                if (0 < newboxX && newboxX < Console.BufferWidth)
                {
                    boxPositionX[0] = newboxX;
                }
                if (0 < newboxY && newboxY < Console.BufferHeight)
                {
                    boxPositionY[0] = newboxY;
                }
                if (0 < newbox2X && newbox2X > Console.BufferWidth)
                {
                    boxPositionX[1] = newbox2X;
                }
                if (0 <newbox2Y && newbox2Y > Console.BufferHeight)
                {
                    boxPositionY[1] = newbox2Y;
                }

                //--------------------벽아 뭐하는 애니
                //                if (wallPositionX == playerX && wallPositionY == playerY || boxPositionX == wallPositionX && boxPositionY == wallPositionY)
                //                {
                //                    contiune;
                //                }
            }
        }
    }
}



