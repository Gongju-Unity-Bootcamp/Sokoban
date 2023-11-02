using System.Data;
using System.Diagnostics;

namespace Sokobanhyeok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "Highway to Hell";
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            int playerX = 0;
            int playerY = 0;

            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            while (true)
            {
                // 이전 화면을 지운다. - 깜빡이는 현상의 원인
                Console.Clear();
                Console.CursorVisible = false;
                
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("^O^");
                // Write : 플레이어 모양
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                // 플레이어가 콘솔 화면을 이동한다.
                if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerX -= 5;
                    }
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 3 < WindowWidth)
                {
                    // playerX + 3 : 오른쪽 콘솔 창에서 내가 입력한 ^O^(3)을 나가지 못하게 값을 추가한다.
                    playerX += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerX + 5 < WindowWidth)
                    {
                        // ConsoleModifiers.Shift(Alt/Ctrl) : Shift를 입력받아 내부 명령을 수행한다.
                        playerX += 5;
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerY -= 5;
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && playerY + 1 < WindowHeight)
                {
                    playerY += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerY + 5 < WindowHeight)
                    {
                        playerY += 5;
                    }
                }

                
                // 1. 안보고 플레이어 이동 구현
                // 2. 화면 바깥 오류 수정
                // 3. 이동과 관련된 기능 하나 이상 구현

                // ConsoleKeyInfo keyInfo = Console.ReadKey();
                // Console.Clear(); // 이전 화면(입력내용)을 지운다.
                // Console.WriteLine($"니가 입력한 키 : {keyInfo.Key}");
                // Console.WriteLine($"니가 입력한 한정자 : {keyInfo.Modifiers}");
                // Ctrl, Shift, Alt : Modifiers에 저장된다.
            }
        }
    }
}