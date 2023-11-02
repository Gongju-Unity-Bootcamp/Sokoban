using System;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
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

            // 박스 정보
            int boxX = 7;
            int boxY = 7;

            // 도착장소 정보
            int goalX = 30;
            int goalY = 13;

            // 맵 정보
            const int minMapX = 0;
            const int minMapY = 0;
            const int maxMapX = 25;
            const int maxMapY = 21;




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
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("★");

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


                // 박스의 이동
                if(playerX == boxX && playerY == boxY)
                {
                   switch(playerDirection)
                    {
                        case 1: // 왼쪽
                            if (minMapX < boxX)
                            {
                                boxX--;

                                // 박스가 왼쪽 벽에 닿았을 떄
                                if(boxX == minMapX)
                                {
                                    boxX = minMapX + 1;
                                    playerX = boxX + 1;
                                }
                            }
                            break;

                        case 2: // 오른쪽
                            if (boxX <= (maxMapX * 2) - 2)
                            {
                                boxX++;

                                // 박스가 오른쪽 벽에 닿았을 떄
                                if (boxX == (maxMapX * 2) - 2)
                                {
                                    boxX = (maxMapX * 2) - 3;
                                    playerX = boxX - 1;
                                }
                            }
                            break;

                        case 3: // 위쪽
                            if(minMapY <= boxY)
                            {
                                boxY--;

                                // 박스가 위쪽 벽에 닿았을 떄
                                if (boxY == minMapY)
                                {
                                    boxY = minMapY + 1;
                                    playerY = boxY +1;
                                }
                            }
                            break;

                        case 4: // 아래쪽
                            if(boxY <= maxMapY)
                            {
                                boxY++;

                                // 박스가 위쪽 벽에 닿았을 떄
                                if (boxY == maxMapY)
                                {
                                    boxY = maxMapY - 1;
                                    playerY = boxY - 1;
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
                if(boxX == goalX && boxY == goalY)
                {
                    Console.Clear();
                    Console.WriteLine($"Game Clear");
                    Environment.Exit(0);
                }

            }
        }
    }
}