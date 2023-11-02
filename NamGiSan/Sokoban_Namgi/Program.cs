using System;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"생성할 오브젝트 갯수 >> ");
            int num = int.Parse(Console.ReadLine());


            // 초기 세팅     
            Console.ResetColor();                               //컬러를 초기화한다.
            Console.CursorVisible = false;                      // 커서를 숨긴다.
            Console.Title = "First Project Sokoban";            // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.White;       // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Black;       // 글꼴색을 설정한다.
            Console.Clear();                                    // 콘솔 창에 출력된 내용을 모두 지운다.

            // 플레이어 정보
            int playerX = 2;
            int playerY = 1;
            int playerDirection = 0;                            // 0 : None, 1 : left, 2 : right, 3 : up, 4 : down

            // 맵 정보
            const int minMapX = 0;
            const int minMapY = 0;
            const int maxMapX = 25;
            const int maxMapY = 21;

            // 박스 정보
            // 랜덤 위치 생성

            int[] boxsX = new int[num];
            int[] boxsY = new int[num];

            Random ran = new Random();
            for(int i = 0; i < num; i++)
            {
                int X = ran.Next(2, maxMapX - 2);
                int Y = ran.Next(2, maxMapY - 2);

                boxsX[i] = X;
                boxsY[i] = Y;
            }
            
            // 도착장소 정보
            int goalX = 24;
            int goalY = 10;


            while (true)
            {
                // 출력 : 지속적으로 화면을 지우고 출력
                Console.Clear();
                Console.CursorVisible = false;
                
                // 게임 맵 출력
                Console.SetCursorPosition(minMapX, minMapY);
                for (int i = minMapY; i <= maxMapY; i++)
                {
                    Console.WriteLine("■                                               ■");
                }

                Console.SetCursorPosition(minMapX, maxMapY);
                for (int i = minMapX; i <= maxMapX - 1; i++)
                {
                    Console.Write("■ ");
                }

                Console.SetCursorPosition(minMapX, minMapY);
                for (int i = minMapX + 1; i<= maxMapX; i++)
                {
                    Console.Write("■ ");
                }

                // 플레이어 출력
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("◎");

                // 박스 출력
                for(int i = 0; i < num; i ++)
                {
                    Console.SetCursorPosition(boxsX[i], boxsY[i]);
                    Console.Write("★");
                }

                // 도착장소 출력
                Console.SetCursorPosition(goalX, goalY);
                Console.Write("☆");

                // 방향키 입력
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey Key = keyInfo.Key;

                // 플레이어 이동
                if (Key == ConsoleKey.LeftArrow)
                {
                    playerX -= 1;  //왼쪽
                    playerDirection = 1;
                }
                if (Key == ConsoleKey.RightArrow)
                { 
                    playerX += 1; //오른쪽
                    playerDirection = 2;
                }
                if (Key == ConsoleKey.UpArrow)
                {
                    playerY -= 1;    //위
                    playerDirection = 3;
                }
                if (Key == ConsoleKey.DownArrow)
                {
                    playerY += 1;  //아래
                    playerDirection = 4;
                }

                // 화면 밖으로 벗어날경우 되돌리기
                if (playerX <= minMapX) playerX++;
                if (playerX >= (maxMapX * 2)-2) playerX--;
                if (playerY <= minMapY) playerY++;             
                if (playerY >= maxMapY) playerY--;
             
                /*
                // Shift를 입력한 채로 방향키 입력 : 3칸 이동
                if (Key == ConsoleKey.LeftArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) playerX -= 3;  //왼쪽
                if (Key == ConsoleKey.RightArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) playerX += 3; //오른쪽
                if (Key == ConsoleKey.UpArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) playerY -= 3;    //위    
                if (Key == ConsoleKey.DownArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) playerY += 3;  //아래
                */

                for(int i = 0; i < num; i ++)
                {
                    // 박스의 이동
                    if (playerX == boxsX[i] && playerY == boxsY[i])
                    {
                        switch (playerDirection)
                        {
                            case 1: // 왼쪽
                                if (minMapX < boxsX[i])
                                {
                                    boxsX[i]--;

                                    // 박스가 왼쪽 벽에 닿았을 떄
                                    if (boxsX[i] == minMapX)
                                    {
                                        boxsX[i] = minMapX + 1;
                                        playerX = boxsX[i] + 1;
                                    }
                                    
                                }
                                break;

                            case 2: // 오른쪽
                                if (boxsX[i] <= (maxMapX * 2) - 2)
                                {
                                    boxsX[i]++;

                                    // 박스가 오른쪽 벽에 닿았을 떄
                                    if (boxsX[i] == (maxMapX * 2) - 2)
                                    {
                                        boxsX[i] = (maxMapX * 2) - 3;
                                        playerX = boxsX[i] - 1;
                                    }
                                    
                                }
                                break;

                            case 3: // 위쪽
                                if (minMapY <= boxsY[i])
                                {
                                    boxsY[i]--;

                                    // 박스가 위쪽 벽에 닿았을 떄
                                    if (boxsY[i] == minMapY)
                                    {
                                        boxsY[i] = minMapY + 1;
                                        playerY = boxsY[i] + 1;
                                    }
                                    
                                }
                                break;

                            case 4: // 아래쪽
                                if (boxsY[i] <= maxMapY)
                                {
                                    boxsY[i]++;

                                    // 박스가 위쪽 벽에 닿았을 떄
                                    if (boxsY[i] == maxMapY)
                                    {
                                        boxsY[i] = maxMapY - 1;
                                        playerY = boxsY[i] - 1;
                                    }
                                    
                                }
                                break;

                            default:    // 오류처리
                                Console.Clear();
                                Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                                Environment.Exit(0);
                                break;
                        }


                    }

                    // 게임 종료
                    if (boxsX[i] == goalX && boxsY[i] == goalY)
                    {
                        Console.Clear();
                        Console.WriteLine($"Game Clear");
                        Environment.Exit(0);
                    }
                } 
            }
        }
    }
}