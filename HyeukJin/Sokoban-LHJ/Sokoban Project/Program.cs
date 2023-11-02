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

            int CircleX = 20;
            int CircleY = 20;
            Direction playerDirection = Direction.None;

            // 콘솔크기
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            //박스의 기능 : 플레이어와 충돌했을때, 플레이어가 이동한 방향으로 박스도 한 칸 이동한다.
            // 우리가 알고 있는 데이터 : 플레이어 좌표, 박스 좌표

            //int playerDirection = 0; // 0 : None, 1 : Left, 2 : Right, 3 : Up, 4 : Down

              
              
        

            while (true)
            {
                // ----------------------------- Render ------------------------------

                Console.Clear();
       
                for(int i = 10; i<25; i++)
                {
                    Console.SetCursorPosition(i, 10);
                    Console.Write("―");
                    Console.SetCursorPosition(i, 25);
                    Console.Write("―");
                }
                for (int i = 10; i < 25; i++)
                {
                    Console.SetCursorPosition(10, i);
                    Console.Write("|");
                    Console.SetCursorPosition(25 , i);
                    Console.Write("|");
                }


                //이전 화면을 지운다.
                Console.CursorVisible = false;    //커서를 숨긴다.
                                                  //플레이어를 출력한다.
                Console.SetCursorPosition(CircleX, CircleY);
                Console.Write("O");
                if (boxX == 10)
                {
                    boxX = 11;
                }

                if (boxX == 25)
                {
                    boxX = 24;
                }
                if (boxY == 10)
                {
                    boxY = 11;
                }
                if( boxY == 25)
                {
                    boxY = 24;
                }

                if (boxX == CircleX && boxY == CircleY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("□");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("□");
                }
                
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("A");

                
                // ----------------------------- ProcessInput------------------------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //keyinfo.key : BackSpace, Space, LeftArrow
                //keyInfo.Modifiers : Ctrl, Shift, Alt

                // ----------------------------- Update ------------------------------

                if (keyInfo.Key == ConsoleKey.A && playerX > 11)
                {
                    playerX -= 1;
                    playerDirection = Direction.Left;

    }
                if (keyInfo.Key == ConsoleKey.D && playerX + 1 < 25)
                {
                    playerX += 1;
                    playerDirection = Direction.Right;
                }
                if (keyInfo.Key == ConsoleKey.W && playerY>11)
                {
                    playerY -= 1;
                    playerDirection = Direction.Up;

                }
                if (keyInfo.Key == ConsoleKey.S && playerY + 1 < 25)
                {
                    playerY += 1;
                    playerDirection = Direction.Down;
                }
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    playerY = 0;
                    playerX = 0;
                }
                //플레이와 박스가 충돌했을 때, 박스는 플레이어가 이동한 방향으로 한칸 이동한다.
                if (playerX == boxX && playerY == boxY)
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

                




            }




        }
    }
}
