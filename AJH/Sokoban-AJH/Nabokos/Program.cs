namespace Nabokos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "NABOKOS";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // 플레이어 좌표
            int playerX = 60;
            int playerY = 15;

            while (true)
            {
                // ---------------- Render -------------------

                Console.Clear();                //이전 화면을 지운다.
                Console.CursorVisible = false;  //커서를 숨긴다.

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("¶");

                // ------------- Process Input ---------------

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // ---------------- Update -------------------
                // 플레이어를 움직인다.
                // 왼쪽으로 플레이어를 움직이고 싶다. => 현재 플레이어의 x 좌표에서 1을 뺀다.

                if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 1 < Console.BufferWidth)
                {
                    playerX += 1;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= 1;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && playerY + 1 < Console.BufferHeight)
                {
                    playerY += 1;
                }

            }
        }
    }
}