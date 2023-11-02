using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace sokoban
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "game";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            //플레이어 좌표
            int playerX = 10;
            int playerY = 20;
            Direction playerDirection = Direction.None;

            //벽
            int[] wallPositionX = {11,12,13,14,15};
            int[] wallPositionY = {11,12,13,14,15};
            //int wallX = 5;
            //int wallY = 5;

            //박스 좌표
            int boxX = 7;
            int boxY = 7;

            int[] goalPositionX = {9,22,15};
            int[] goalPositionY = {9,22,20};

            while(true)
            {
                //-----------render-------------------
                Console.Clear(); //창 매번 초기화
                Console.CursorVisible = false; //창 커서 매번 지워주기


                //플레이어를 출력한다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("I");

                //벽 출력
                for(int i = 0; i < wallPositionX.Length; i++)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write("#");
                }

                //박스 출력
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("@");

                //골 지점\
                for(int i = 0; i < goalPositionX.Length; i++)
                {
                    Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                    Console.Write("G");
                }
                

                
                

                //----------processInput-----------
                ConsoleKeyInfo keyInfo = Console.ReadKey(); //입력한 키 정보 담기
                ConsoleKey key = keyInfo.Key;

                //-------------update--------------
                //Console.WriteLine($"입력한 키: {keyInfo.Key}");
                //Console.WriteLine($"입력한 한정자: {keyInfo.Modifiers}");

                //플레이어 이동
                if (key == ConsoleKey.LeftArrow) {
                    // playerX -= 1; //왼쪽으로 한 칸 이동,, 창 경계 지정x
                    playerX = (int)Math.Max(0, playerX -1);
                    //Math.Max() 두 개의 정수 중 더 큰 숫자 반환
                    playerDirection = Direction.Left;
                }

                if(key == ConsoleKey.RightArrow)
                {
                    //playerX += 1;
                    playerX = (int)Math.Min(playerX + 1, Console.BufferWidth - 1);
                    playerDirection = Direction.Right;
                }

                if(key == ConsoleKey.UpArrow) {
                    //playerY -= 1;
                    playerY = (int)Math.Max(0, playerY - 1);
                    playerDirection = Direction.Up;
                }

                if(key == ConsoleKey.DownArrow) {
                    //playerY += 1;  
                    playerY = (int)Math.Min(playerY + 1, Console.BufferHeight - 1);
                    playerDirection = Direction.Down;
                }

                /**벽 충돌
                
                    if (wallPositionX[i] == playerX && wallPositionY[i] == playerY || wallPositionX[i] == boxX && wallPositionY[i] == boxY)
                    {
                        continue;
                    }
                }
                **/

                //플레이어, 벽 충돌
                for (int i = 0; i < wallPositionX.Length; i++)
                {
                    if (playerX == wallPositionX[i] && playerY == wallPositionY[i])
                    {
                        switch (playerDirection)
                        {
                            case Direction.Left:
                                playerX = wallPositionX[i] + 1;
                                break;

                            case Direction.Right:
                                playerX = wallPositionX[i] - 1;
                                break;

                            case Direction.Up:
                                playerY = wallPositionY[i] + 1;
                                break;

                            case Direction.Down:
                                playerY = wallPositionY[i] - 1;
                                break;

                            default:
                                Console.WriteLine("잘못된 데이터입니다.");
                                break;
                        }
                    }
                }
               
                //플레이어, 박스 충돌 시 박스는 플레이어가 이동한 방향으로 한 칸 이동
                if (playerX == boxX && playerY == boxY){
                    switch(playerDirection){
                        case Direction.Left:
                            boxX = Math.Max(0, boxX -1);
                            playerX = boxX + 1;
                            break;

                        case Direction.Right:
                            boxX = Math.Min(boxX + 1, Console.BufferWidth - 1);
                            playerX = boxX - 1;
                            break;

                        case Direction.Up:
                            boxY= Math.Max(0, boxY -1);
                            playerY = boxY + 1;
                            break;

                        case Direction.Down:
                            boxY = Math.Min(boxY + 1, Console.BufferHeight - 1);
                            playerY = boxY - 1;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                //벽, 박스 충돌
                for (int i = 0; i < wallPositionX.Length; i++)
                {
                    if (boxX == wallPositionX[i] && boxY == wallPositionY[i])
                    {
                        switch (playerDirection)
                        {
                            case Direction.Left:
                                boxX = wallPositionX[i] + 1;
                                playerX = boxX + 1;
                                break;

                            case Direction.Right:
                                boxX = wallPositionX[i] - 1;
                                playerX = boxX - 1;
                                break;

                            case Direction.Up:
                                boxY = wallPositionY[i] + 1;
                                playerY = boxY + 1;
                                break;

                            case Direction.Down:
                                boxY = wallPositionY[i] - 1;
                                playerY = boxY - 1;
                                break;

                            default:
                                Console.WriteLine("잘못된 데이터입니다.");
                                break;
                        }
                    }
                }

                /**
                for (int i = 0; i < goalPositionX.Length; i++)
                {
                    if (boxX == goalPositionX[i] && boxY == goalPositionY[i])
                    {
                        break;
                    }
                }
                **/
                Console.Clear();
                Console.WriteLine("성공");
            }
            
        }
    }
}