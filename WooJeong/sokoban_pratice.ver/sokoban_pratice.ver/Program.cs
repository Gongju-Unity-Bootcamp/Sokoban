using System;

namespace SokoBanWooJeong
{
    internal class Program
    {
        static void Main()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "세현전도사";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            int playerX = 10;
            int playerY = 5;

            int[,] portal = new int[,] { { 5, 10 }, { 15, 15 } };

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("p");

                Console.SetCursorPosition(portal[0, 0], portal[0, 1]);
                Console.Write("◎");

                Console.SetCursorPosition(portal[1, 0], portal[1, 1]);
                Console.Write("◎");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;
                ConsoleModifiers Modifiers = keyInfo.Modifiers;
                // key.Modifier == ConsoleModifier.Shift

                if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && Console.BufferWidth > playerX + 2)
                {
                    playerX += 1;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= 1;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && Console.BufferHeight > playerY + 1)
                {
                    playerY += 1;
                }
                if (keyInfo.Modifiers == ConsoleModifiers.Shift && Console.BufferHeight > playerY + 1)
                {
                    playerX += 10;
                    Thread.Sleep(500);
                }
                if (playerX == portal[0, 0] && playerY == portal[0, 1])
                {
                    playerX += 15;
                }
                if (playerX == portal[1, 0] && playerY == portal[1, 1])
                {
                    playerY -= 10;
                }
            } //포탈 위치와 플레이어 위차가 같을 때 즉, 플레이어가 포탈 위에 올랐을 때 어디로 이동한다.
        }
    }
}


//=========배열 증명=========

//using System;

//namespace SokoBanWooJeong
//{
//    internal class Program
//    {
//        static void Main()
//        {

//            int[,] portal = new int[,] { { 5, 10 }, { 15, 15 } };

//                Console.SetCursorPosition(portal[0, 0], portal[0, 1]);
//                Console.Write($"portal[0,0] = {portal[0, 0]}\nportal[0,1] = {portal[0, 1]}");

//                Console.SetCursorPosition(portal[1, 0], portal[1, 1]);
//                Console.Write("◎");
//        }
//    }
//}