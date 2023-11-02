using System;

namespace SokoBanWooJeong
{
    internal class Program
    {
        enum Direction
        {
            None,
            Left,
            Right,
            Up,
            Down
        }
        static void Main()
        {
            // 콘솔 창 꾸미기
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "세현전도사";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();


            // 박스의 기능 : 플레이어와 충돌했을 때(= 좌표가 같다), 플레이어가 이동한 방향(??? > 우리가 설정)으로 박스도 한 칸 이동한다.
            // 우리가 알고 있는 데이터 : 플레이어 좌표, 박스 좌표
            int playerX = 10;
            int playerY = 5;

            // 플레이어가 이동할 방향의 데이터
            Direction playerDirection = Direction.None;

            int boxX = 7;
            int boxY = 7;

            bool isBoxOnGoal = false;

            // 벽의 좌표 => 벽의 기능
            int[] wallPositonX = new int[5] { 8, 9, 13, 5, 10 };
            int[] wallPositonY = new int[5] { 3, 6, 11, 14, 15 };

            // goal의 좌표

            int[] goalPositionX = new int[5] { 10, 14, 17, 18, 19 };
            int[] goalPositionY = new int[5] { 4, 11, 15, 13, 20 };
            

            while (true)
            {
                //-----------------------------Render-------------------------------------

                Console.Clear();
                Console.CursorVisible = false;

                // 플레이어 위치
                Console.SetCursorPosition(playerX, playerY);
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("p");
                Console.ForegroundColor = prevColor;

                for (int i = 0; i < goalPositionX.Length; ++i)
                {
                    Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                    Console.Write("G");
                }

                //박스가 골 위로 올라갔는지 체크
                if (isBoxOnGoal)
                {
                    Console.SetCursorPosition(boxX, boxY);
                    prevColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("■");
                    Console.ForegroundColor = prevColor;
                }
                else
                {
                    // 박스 위치
                    Console.SetCursorPosition(boxX, boxY);
                    Console.Write("■");
                }


                // 벽의 위치
                for (int i = 0; i < wallPositonX.Length; ++i) // wallPositonX와 Y와 배열의 길이가 같기 때문에 y를 굳이 쓰지 않아도 된다.
                {
                    Console.SetCursorPosition(wallPositonX[i], wallPositonY[i]);
                    Console.Write("#");
                }

                // ===================== procesInput======================

                // 키 호출
                ConsoleKeyInfo keyInfo = Console.ReadKey(); //readKey는 키의 정보가 없음 => .key로 불러올 수 있음
                ConsoleKey key = keyInfo.Key;  // 참고 : key.Modifier == ConsoleModifier.Shift

                // ======================= Update =========================


                // 0. ------- 콘솔 벽 기능 검증을 위해 새로 선언 ----------

                int newPlayerX = playerX;
                int newPlayerY = playerY;


                // 1. -------------키 작성 (기능만 작성)-------------------

                if (key == ConsoleKey.LeftArrow)
                {
                    newPlayerX -= 1;
                    playerDirection = Direction.Left;
                }
                if (key == ConsoleKey.RightArrow)
                {
                    newPlayerX += 1;
                    playerDirection = Direction.Right;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    newPlayerY -= 1;
                    playerDirection = Direction.Up;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    newPlayerY += 1;
                    playerDirection = Direction.Down;
                }

                // 1-1. 플레이이와 박스가 충돌했을 때 => (플레이어 좌표) == (박스 좌표)
                int newBoxX = boxX; // newPlayerX가 임시 데이터니까 newBoxX를 만들어야 기능이 출동하지 않는다.
                int newBoxY = boxY;

                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
                {
                    switch (playerDirection)
                    {
                        case Direction.Left:           //left
                            newBoxX -= 1;
                            break;
                        case Direction.Right:          //Right
                            newBoxX += 1;
                            break;
                        case Direction.Up:             //up
                            newBoxY -= 1;
                            break;
                        case Direction.Down:           //down
                            newBoxY += 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터입니다. 실제 데이터는 {playerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                // 2. ===== 콘솔 창 벽 막아주기 (기능 검증) ====

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다.
                // => (벽의 좌표) != (박의 좌표) && (벽의 좌표) != (플레이어의 좌표)
                // => 벽의 기능은 플레이어와 박스가 움직인 후에 작동되어야 한다. (=> 움직인 후 부딪혀서 벽이 기능하기 때문)

                bool isCollidedToWall = false;

                for (int i = 0; i < wallPositonX.Length; ++i)
                {
                    if (wallPositonX[i] == newPlayerX && wallPositonY[i] == newPlayerY || wallPositonX[i] == newBoxX && wallPositonY[i] == newBoxY)
                    {
                        isCollidedToWall = true;
                        break;
                    }
                }

                if (isCollidedToWall)
                {
                    continue;
                }

                // 콘솔 안에서 기능하도록
                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth) // 왼쪽 && 오른쪽
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight) // 위 && 아래
                {
                    playerY = newPlayerY;
                }
                                                                             
                boxX = newBoxX;
                boxY = newBoxY;


                // 박스를 골에 넣었을 때 색상이 변경
                for (int i = 0; i < goalPositionX.Length; ++i)
                {
                    if (newBoxX == goalPositionX[i] && newBoxY == goalPositionY[i])
                    {
                        isBoxOnGoal = true;
                        break;
                    }
                }
                //if (boxX == goalX && boxY == goalY)
                //{
                //    break;
                //}
            }

            Console.Clear();
            Console.Write("축하합니다. 소코반을 깼습니다.");
        }
    }
}

