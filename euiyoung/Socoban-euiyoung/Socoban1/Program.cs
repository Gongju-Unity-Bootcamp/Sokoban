namespace Socoban1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //화면 초기화
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title ="의영이의 소코반";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Clear();

            int PlayerX = 0;
            int PlayerY = 0;
            int Speed = 1;

            int Score = 0;

            //아이템 위치
            Random rd = new Random();
            int itemX = rd.Next(0, Console.BufferWidth);
            int itemY = rd.Next(0, Console.BufferHeight);

            while (true)
            {
                //키 입력
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                Console.Clear();

                Console.SetCursorPosition(itemX, itemY);
                Console.Write("!★!");

                //shift 입력 시 스피드 
                if (keyinfo.Modifiers == ConsoleModifiers.Shift)
                {
                    Speed = 3;
                }
                else
                {
                    Speed = 1;
                }

                //이동
                if (keyinfo.Key == ConsoleKey.LeftArrow || keyinfo.Key == ConsoleKey.A)
                {
                    if (PlayerX > 0)
                        PlayerX -= Speed;
                }
                if (keyinfo.Key == ConsoleKey.RightArrow || keyinfo.Key == ConsoleKey.D)
                {
                    if (PlayerX < Console.BufferWidth - Speed)
                        PlayerX += Speed;
                }
                if (keyinfo.Key == ConsoleKey.UpArrow || keyinfo.Key == ConsoleKey.W)
                {
                    if (PlayerY > 0)
                        PlayerY -= Speed;
                }
                if (keyinfo.Key == ConsoleKey.DownArrow || keyinfo.Key == ConsoleKey.S)
                {
                    if (PlayerY < Console.BufferHeight - Speed)
                        PlayerY += Speed;
                }

                if (PlayerX == itemX && PlayerY == itemY)
                {
                    Console.Clear();
                    Score++;
                    itemX = rd.Next(0, Console.BufferWidth);
                    itemY = rd.Next(0, Console.BufferHeight);
                }

                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.Write($"({Score})")
            }

        }
    }
}