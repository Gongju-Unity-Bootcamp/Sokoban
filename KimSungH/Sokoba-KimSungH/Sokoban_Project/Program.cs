namespace Sokoban_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.ResetColor();
            //Console.CursorVisible = false;
            //Console.Title = "Trust";
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.Clear();

            ////위치를 옮긴 후 출력해야 한다.
            ////프로그램은 데이터를 조작

            ////플레이어를 움직이고 싶으면 플레이어의 좌표를 저장해서 들고 있어야한다.

            ////플레이어 좌표
            //int playerX = 50;
            //int playerY = 10;
            //int objectX = 60;
            //int objectY = 5;

            ////게임 제작 시 프레임워크를 먼저 작성한다.
            ////프로그램의 동작 순서를 정의해준다.


            //while (true)
            //{
            //    //출력 ,입력, 처리 순으로 진행
            //    //입력 = ReadKey() 사용
            //    //Modifiers = Ctrl, Shift 같은 것

            //    //출력
            //    Console.Clear();
            //    Console.CursorVisible = false;
            //    //창을 키우거나 등등 창을 건들면 다시 등장하는 이슈가 생기기 때문에
            //    //클리어와 커서 가시성을 꺼준다.


            //    //플레이어 출력한다.
            //    Console.SetCursorPosition(playerX, playerY);
            //    Console.Write("@");

            //    Console.SetCursorPosition(objectX, objectY);
            //    Console.Write("@");


            //    //입력

            //    ConsoleKeyInfo keyInfo = Console.ReadKey();
            //    //키 값은 keyInfo.key에 있다.
            //    ConsoleKey key = keyInfo.Key;

            //    //누른 키 출력
            //    //ConsoleKeyInfo keyInfo = Console.ReadKey();
            //    //Console.Clear();
            //    //Console.WriteLine($"니가 입력한 키 : {keyInfo.Key}");
            //    //Console.WriteLine($"니가 입력한 한정자 : {keyInfo.Modifiers}");

            //    //Update
            //    //입력 체크할때는 else if 보단 if문을 반복적으로 작성한다.


            //    if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
            //    {
            //        playerX -= 1;
            //    }
            //    if (key == ConsoleKey.RightArrow && playerX + 3 < Console.BufferWidth)
            //    {
            //        playerX += 1;
            //    }
            //    if (key == ConsoleKey.UpArrow && playerY > 0)
            //    {
            //        playerY -= 1;
            //    }
            //    if (key == ConsoleKey.DownArrow && playerY + 1 < Console.BufferHeight)
            //    {
            //        playerY += 1;
            //    }
            //    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
            //    {
            //        if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 4)
            //        {
            //            playerX -= 5;
            //        }
            //        if (key == ConsoleKey.RightArrow && playerX + 8 < Console.BufferWidth)
            //        {
            //            playerX += 5;
            //        }
            //        if (key == ConsoleKey.UpArrow && playerY > 4)
            //        {
            //            playerY -= 5;
            //        }
            //        if (key == ConsoleKey.DownArrow && playerY + 6 < Console.BufferHeight)
            //        {
            //            playerY += 5;
            //        }
            //    }
            //    if(playerX == objectX && playerY == objectY)
            //    {
            //        int objectX1 = 10;
            //        int objectY1 = 10;
            //        Console.SetCursorPosition(objectX1, objectY1);
            //        Console.Write("Game Over!");
            //    }
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "I'M God";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            int playerX = 30;
            int playerY = 5;

            int objectX = 50;
            int objectY = 9;

            Random rand = new Random();



            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("@");

                Console.SetCursorPosition(objectX, objectY);
                Console.Write("@");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey Key = keyInfo.Key;

                if (Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                }
                if (Key == ConsoleKey.RightArrow && playerX + 1 < Console.BufferWidth)
                {
                    playerX += 1;
                }
                if (Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= 1;
                }
                if (Key == ConsoleKey.DownArrow && playerY + 1 < Console.BufferHeight)
                {
                    playerY += 1;
                }
                if (playerX == objectX && playerY == objectY)
                {
                    playerX = rand.Next(0, Console.BufferWidth);
                    playerY = rand.Next(0, Console.BufferHeight);

                }
                //if (Key == ConsoleKey.DownArrow && Key == ConsoleKey.RightArrow)
                //{
                //    playerX += 7;
                //    playerY += 7;

                if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                {
                    if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 4)
                    {
                        playerX -= 5;
                    }
                    if (Key == ConsoleKey.RightArrow && playerX + 8 < Console.BufferWidth)
                    {
                        playerX += 5;
                    }
                    if (Key == ConsoleKey.UpArrow && playerY > 4)
                    {
                        playerY -= 5;
                    }
                    if (Key == ConsoleKey.DownArrow && playerY + 6 < Console.BufferHeight)
                    {
                        playerY += 5;
                    }
                }
            }
        } 
    }
}