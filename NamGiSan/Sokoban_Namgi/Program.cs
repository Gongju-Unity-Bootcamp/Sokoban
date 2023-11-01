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


            int playerX = 10;
            int playerY = 5;

            while(true)
            {
                // 출력 : 지속적으로 화면을 지우고 출력
                Console.Clear();    
                Console.CursorVisible = false;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("◎"); 

                // 입력
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // 처리
                if (keyInfo.Key == ConsoleKey.LeftArrow) playerX -= 1;  //왼쪽
                if (keyInfo.Key == ConsoleKey.RightArrow) playerX += 1; //오른쪽
                if (keyInfo.Key == ConsoleKey.UpArrow) playerY -= 1;    //위    
                if (keyInfo.Key == ConsoleKey.DownArrow) playerY += 1;  //아래

                if (playerX == -1)
                {
                    playerX++;
                }
                else if (playerX >= Console.BufferWidth)
                {
                    playerX--;
                }
                else if (playerY == -1)
                {
                    playerY++;
                }
                else if (playerY >= Console.BufferHeight)
                {
                    playerY--;
                }           
            }
        }
    }
}