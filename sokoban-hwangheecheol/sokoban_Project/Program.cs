namespace sokoban_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "beliver";
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            int playerX = 40;
            int playerY = 7;

            while (true)
            {
                //------------------------------Render-------------------
                Console.Clear();                //이전 화면을 지운다
                Console.CursorVisible = false;  //커서를 숨긴다.
                ////플레이어를 출력한다
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("*");
                ////------------------------------processInput-------------------
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                //ConsoleKey key = keyinfo.Key;
                //------------------------------update-------------------
                //ConsoleKeyInfo keyinfo = Console.ReadKey(true);
                //Console.Clear();
                //Console.WriteLine($"니가 입력한 키 : {keyinfo.Key}");
                //Console.WriteLine($"니가 입력한 한정자 : {keyinfo.Modifiers}");
                // playerX -= 1;
                //플레이어를 움직인다.

                //명령어는

                if (keyinfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                }
                if (keyinfo.Key == ConsoleKey.RightArrow && playerX +1 < Console.BufferWidth)
                {
                    playerX += 1;
                }
                if (keyinfo.Key == ConsoleKey.UpArrow && playerX > 0)
                {
                    playerX -= 1;
                }
                if (keyinfo.Key == ConsoleKey.RightArrow && playerX + 1 < Console.BufferWidth)
                {
                    playerX += 1;
                }
                }
            //게임 제작 시 프레임 워크를 먼저 작성
        }
    }
}