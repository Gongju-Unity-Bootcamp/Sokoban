namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "사랑은 움직이는 거야";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            // 플레이어 위치 좌표
            int playerX = 0;
            int playerY = 0;
            // 플레이어의 이동 방향
            int playerMoveDirection = 0;
            // 박스 좌표
            int boxX = 5;
            int boxY = 5;
            // 게임 루프
            while (true)
            {
                //Render
                // 이전 프레임을 지운다
                Console.Clear();
                Console.CursorVisible = false;

                // 플레이어를 그린다
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(">.<");

                // 박스를 그린다
                Console.SetCursorPosition(boxX, boxY);
                Console.Write("-.-");

                //Input
                //입력을 받는다
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                //Update
                // 플레이어 이동 처리
                if (key == ConsoleKey.LeftArrow)
                {
                    playerX = (int)Math.Max(0, playerX - 1);

                    playerMoveDirection = 1;
                }
                if (key == ConsoleKey.RightArrow)
                {
                    playerX = (int)Math.Min(playerX + 1, 15);
                    playerMoveDirection = 2;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    playerY = (int)Math.Max(0, playerY - 1);
                    playerMoveDirection = 3;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    playerY = (int)Math.Min(playerY + 1, 20);
                    playerMoveDirection = 4;
                }

                // 박스 업데이트
                if (playerX == boxX && playerY == boxY)
                {
                    switch (playerMoveDirection)
                    {
                        case 1: // Left
                            boxX = Math.Max(0, boxX - 1);
                            playerX = boxX + 1;
                            break;
                        case 2: // Right
                            boxX = Math.Min(boxX + 1, 15);
                            playerX = boxX - 1;
                            break;
                        case 3: // Up
                            boxY = Math.Max(0, boxY - 1);
                            playerY = boxY + 1;
                            break;
                        case 4: // Down
                            boxY = Math.Min(boxY + 1, 20);
                            playerY = boxY - 1;
                            break;
                        default: // Error

                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 방향 : {playerMoveDirection}");
                            Environment.Exit(1); // 프로그램을 종료한다.
                            break;
                    }
                }
            }
        }
    }
}
        
    