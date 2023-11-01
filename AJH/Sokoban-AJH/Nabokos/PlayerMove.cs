using System;

namespace Nabokos
{
    class PlayerMove
    {
        public static void Move()
        {
            // 기존 코드를 보지 않고 플레이어 이동 구현 + 이동 관련 기능 하나 추가

            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Title = "NABOKOS";
            Console.Clear();

            // 플레이어 좌표
            int playerX = 60;
            int playerY = 15;

            // 플레이어 이동 속도
            int moveSpeed = 1;

            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("▣");

                // 입력 데이터 받아서 getKey에 저장
                // getKey.Key => 방향키, wasd 등
                // getKey.Modifiers => 쉬프트, 컨트롤, 알트
                ConsoleKeyInfo getKey = Console.ReadKey();
                Console.Clear();

                // 플레이어 이동
                if (getKey.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= moveSpeed;
                }
                if (getKey.Key == ConsoleKey.RightArrow && playerX + moveSpeed < Console.BufferWidth)
                {
                    playerX += moveSpeed;
                }
                if (getKey.Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= moveSpeed;
                }
                if (getKey.Key == ConsoleKey.DownArrow && playerY + moveSpeed < Console.BufferHeight)
                {
                    playerY += moveSpeed;
                }

                // 쉬프트 대쉬(2칸 이동)
                if (getKey.Modifiers == ConsoleModifiers.Shift)
                {
                    moveSpeed = 2;
                    if (playerX - moveSpeed < 0) moveSpeed = 1;
                    if (playerX + moveSpeed < 0) moveSpeed = 1;
                    if (playerY - moveSpeed > Console.BufferWidth) moveSpeed = 1;
                    if (playerY + moveSpeed > Console.BufferHeight) moveSpeed = 1;
                }
                else
                {
                    moveSpeed = 1;
                }


                /* 난 스위치보다 if문이 더 편해...
                switch (getKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0)
                        {
                            playerX -= 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerX + 1 < Console.BufferWidth)
                        {
                            playerX += 1;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (playerY > 0)
                        {
                            playerY -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerY + 1 < Console.BufferHeight)
                        {
                            playerY += 1;
                        }
                        break;
                }*/
            }
        }
    }
}