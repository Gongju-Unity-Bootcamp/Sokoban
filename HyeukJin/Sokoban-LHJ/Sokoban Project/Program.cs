using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace Sokoban_Project
{
    enum Direction
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4
    }

    internal class Program
    {
   
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "LHJ Sokoban";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
          
            // 플레이어 좌표
            int playerX = 12;
            int playerY = 15;

            int boxX = 15;
            int boxY = 15;

            int box2X = 13;
            int box2Y = 13;

            int CircleX = 20;
            int CircleY = 20;

            int Circle2X = 17;
            int Circle2Y = 17;

            Direction playerDirection = Direction.None;

            // 콘솔크기
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            //박스의 기능 : 플레이어와 충돌했을때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
            // 우리가 알고 있는 데이터 : 플레이어 좌표, 박스 좌표

            //int playerDirection = 0; // 0 : None, 1 : Left, 2 : Right, 3 : Up, 4 : Down

            int wallX = 10;
            int wallY = 10;
            int wallXMax = 25;
            int wallYMax = 25;

            while (true)
            {
                // ----------------------------- Render ------------------------------
                Console.Clear();
       
                for(int i = wallX; i< wallXMax; i++)
                {
                    Console.SetCursorPosition(i, wallY);
                    Console.Write("―");
                    Console.SetCursorPosition(i, 25);
                    Console.Write("―");
                }
                for (int i = wallY; i < wallYMax; i++)
                {
                    Console.SetCursorPosition(wallX, i);
                    Console.Write("|");
                    Console.SetCursorPosition(25 , i);
                    Console.Write("|");
                }

                //이전 화면을 지운다.
                Console.CursorVisible = false;    //커서를 숨긴다.
                                                  //플레이어를 출력한다.
                Console.SetCursorPosition(CircleX, CircleY);
                Console.Write("O");
                Console.SetCursorPosition(Circle2X, Circle2Y);
                Console.Write("O");

                if (boxX == wallX)
                {
                    boxX = wallX + 1;
                    playerX += 1;
                }
                if (boxX == wallXMax)
                {
                    boxX = wallXMax - 1;
                    playerX -= 1;
                }
                if (boxY == wallY)
                {
                    boxY = wallY + 1;
                    playerY += 1;
                }
                if( boxY == wallYMax)
                {
                    boxY = wallYMax - 1;
                    playerY -= 1;
                }
                if (box2X == wallX)
                {
                    box2X = wallX + 1;
                    playerX += 1;
                }
                if (box2X == wallXMax)
                {
                    box2X = wallXMax - 1;
                    playerX -= 1;
                }
                if (box2Y == wallY)
                {
                    box2Y = wallY + 1;
                    playerY += 1;
                }
                if (box2Y == wallYMax)
                {
                    box2Y = wallYMax - 1;
                    playerY -= 1;
                }

                if (boxX == CircleX && boxY == CircleY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("□");

                }
                else if(boxX == Circle2X && boxY == Circle2Y)
                    {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("□");
                }
                else
                {
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("□");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (box2X == CircleX && box2Y == CircleY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(box2X, box2Y);
                    Console.Write("□");
                }
                else if (box2X == Circle2X && box2Y == Circle2Y)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(box2X, box2Y);
                    Console.Write("□");
                }
                else
                { 
                    Console.SetCursorPosition(box2X, box2Y);
                    Console.Write("□");
                }
                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("A");

                
                // ----------------------------- ProcessInput------------------------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //keyinfo.key : BackSpace, Space, LeftArrow
                //keyInfo.Modifiers : Ctrl, Shift, Alt

                // ----------------------------- Update ------------------------------

                if (keyInfo.Key == ConsoleKey.A && playerX > wallX + 1)
                {
                    playerX -= 1;
                    playerDirection = Direction.Left;

    }
                if (keyInfo.Key == ConsoleKey.D && playerX + 1 < wallXMax)
                {
                    playerX += 1;
                    playerDirection = Direction.Right;
                }
                if (keyInfo.Key == ConsoleKey.W && playerY> wallY + 1)
                {
                    playerY -= 1;
                    playerDirection = Direction.Up;

                }
                if (keyInfo.Key == ConsoleKey.S && playerY + 1 < wallYMax)
                {
                    playerY += 1;
                    playerDirection = Direction.Down;
                }
             
                //플레이와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한칸 이동한다.
                if (playerX == boxX && playerY == boxY )
                {

                  
                    switch(playerDirection)
                    {
                        case Direction.Left: boxX -= 1;
                            playerX = boxX + 1;
                            break;
                        case Direction.Right:
                            boxX += 1;
                            playerX = boxX - 1;
                            break;
                        case Direction.Up: boxY -= 1;
                            playerY = boxY + 1;
                            break;
                        case Direction.Down: boxY += 1;
                            playerY = boxY - 1; 
                            break;
                        default:  
                            Console.Clear();
                            Console.WriteLine("잘못된 방향 데이터입니다.");
                            Environment.Exit(0);
                            break;
                    }

                }
                if (playerX == box2X && playerY == box2Y)
                {


                    switch (playerDirection)
                    {
                        case Direction.Left:
                            box2X -= 1;
                            playerX = box2X + 1;
                            break;
                        case Direction.Right:
                            box2X += 1;
                            playerX = box2X - 1;
                            break;
                        case Direction.Up:
                            box2Y -= 1;
                            playerY = box2Y + 1;
                            break;
                        case Direction.Down:
                            box2Y += 1;
                            playerY = box2Y - 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 방향 데이터입니다.");
                            Environment.Exit(0);
                            break;
                    }
                }

                    //벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다 => (벽의 좌표) !=(박스의좌표) && !=(플레이어의 좌표)
                    if (wallX == playerX  && wallY == playerY || wallX == boxY && wallY == boxY)
                {
                    continue;
                }
                if (boxX == CircleX && boxY == CircleY)
                {
                    if((box2X == Circle2X && box2Y == Circle2Y))
                        {
                        break;
                        }
                }
                else if (boxX == Circle2X && boxY == Circle2Y)
                {
                    if ((box2X == CircleX && box2Y == CircleY))
                    {
                        break;
                    }
                }

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    playerX = 12;
                    playerY = 15;

                    boxX = 15;
                    boxY = 15;
                    box2X = 13;
                    box2Y = 13;
                }

            }

            Console.Clear();
            Console.Write("축하합니다. 소코반을 깼습니다.");

        }
    }
}
