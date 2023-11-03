namespace Sokoban_Project
{
    public enum Direction
    {
        None = 0,
        Left = 1,
        Right =2,
        Up = 3, 
        Down =4
    }
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

            //박스의 기능 : 플레이어와 충돌했을 때, 플레이어가 이동한 박향으로 박스도 한 칸이동.
            int playerX = 30;
            int playerY = 5;

            //int playerDirection = 0;
            Direction PlayerDirection = Direction.None;
            
            // 0: None, 1 : Left, 2: Right, 3 : Up, 4 : Down

            //int objectX = 50;
            //int objectY = 9;

            //Random rand = new Random();

            int[] wallPositionX = new int[5] { 10, 8, 5, 2, 10 };
            int[] wallPositionY = new int[5] { 6, 2, 3, 1, 9 };

            int[] goalPositionX = new int[3] { 3, 32, 23 };
            int[] goalPositionY = new int[3] { 5, 5, 22 };

            int[] BoxPositionX = new int[3] { 3, 5, 11 };
            int[] BoxPositionY = new int[3] { 10, 7, 9 };
            bool[] isBoxOnGoal = new bool[3];

            int goalCount = goalPositionX.Length;
            int wallCount = wallPositionX.Length;
            int boxCount = BoxPositionX.Length;

            while (true)
            {
                //------------------Reander------------------
                Console.Clear();
                Console.CursorVisible = false;

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("@");

                //Console.SetCursorPosition(objectX, objectY);
                //Console.Write("@");

                for (int i = 0; i < goalCount; ++i)
                {
                    Console.SetCursorPosition(goalPositionX[i], goalPositionY[i]);
                    Console.Write("G");
                }
                for (int i = 0; i < boxCount; ++i)
                {
                    
                    if (isBoxOnGoal[i])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(BoxPositionX[i], BoxPositionY[i]);
                        Console.Write("B");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.SetCursorPosition(BoxPositionX[i], BoxPositionY[i]);
                        Console.Write('B');
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                    }

                }
                for (int i = 0; i < wallCount; i++)
                {
                    Console.SetCursorPosition(wallPositionX[i], wallPositionY[i]);
                    Console.Write('W');
                }

                //----------------ProcessInput-------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey Key = keyInfo.Key;

                //----------------Update--------------------

                PlayerDirection = Direction.None;

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                if (Key == ConsoleKey.LeftArrow)
                {
                    newPlayerX -= 1;
                    PlayerDirection = Direction.Left;
                }
                if (Key == ConsoleKey.RightArrow)
                {
                    newPlayerX += 1;
                    PlayerDirection = Direction.Right;
                }
                if (Key == ConsoleKey.UpArrow)
                {
                    newPlayerY -= 1;
                    PlayerDirection = Direction.Up;
                }
                if (Key == ConsoleKey.DownArrow)
                {
                    newPlayerY += 1;
                    PlayerDirection = Direction.Down;
                }
                
                int[] newBoxX = new int[boxCount];
                BoxPositionX.CopyTo(newBoxX, 0);
                int[] newBoxY = new int[boxCount];
                BoxPositionY.CopyTo(newBoxY, 0);

                newBoxX.CopyTo(BoxPositionX, 0);
                newBoxY.CopyTo(BoxPositionY, 0);

                
                
                int index = 0;
                for (int i = 0; i < boxCount; ++i)
                {
                    //if(!(newPlayerX == newBoxX[i] && newPlayerY == newBoxY[i]))
                    //if(false == (newPlayerX == newBoxX[i] && newPlayerY == newBoxY[i]))
                    if (newPlayerX != newBoxX[i] || newPlayerY != newBoxY[i])
                    {
                        continue;
                    }
                    index = i;
                    switch (PlayerDirection)
                    {
                        case (Direction)1:
                            newBoxX[i] -= 1;

                            break;
                        case (Direction)2:
                            newBoxX[i] += 1;

                            break;
                        case (Direction)3:
                            newBoxY[i] -= 1;

                            break;
                        case (Direction)4:
                            newBoxY[i] += 1;

                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"잘못된 방향 데이터 입니다. 실제 데이터는 {PlayerDirection}");
                            Environment.Exit(0);
                            break;
                    }
                }

                // 벽의 기능 : 벽의 위치로는 어떤 오브젝트도 위치할 수 없다.
                // 벽 좌표 != 박스 좌표 && 벽 좌표 != 플레이어 좌표

                bool checkWall = false;
                //박스 3개, 벽 5개
                //플레이어가 동시에 밀 수 있는 박스의 최대 개수는 1개 -> 플레이어가 민 박스만 특정할 수 있다면?
                for (int i = 0; i < wallCount; ++i)
                {
                    if (wallPositionX[i] == newPlayerX && wallPositionY[i] == newPlayerY ||
                        wallPositionX[i] == newBoxX[index] && wallPositionY[i] == newBoxY[index])
                    {
                        checkWall = true;
                        break;
                    }
                }
                if (checkWall)
                {
                    continue;
                }
                //박스끼리 충돌

                bool BoxColide = false;

                for (int i = 0; i < boxCount; ++i)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    if (newBoxX[i] == newBoxX[index] && newBoxY[i] == newBoxY[index])
                    {
                        BoxColide = true;
                        break;
                    }
                }
                if (BoxColide)
                {
                    continue;
                }

                if (0 <= newPlayerX && newPlayerX < Console.BufferWidth)
                {
                    playerX = newPlayerX;
                }
                if (0 <= newPlayerY && newPlayerY < Console.BufferHeight)
                {
                    playerY = newPlayerY;
                }

                for (int i = 0; i < boxCount; ++i)
                {
                    if (0 <= newBoxX[i] && newBoxX[i] < Console.BufferWidth)
                    {
                        BoxPositionX[i] = newBoxX[i];
                    }
                    else
                    {
                        switch (PlayerDirection)
                        {
                            case Direction.Left:
                                playerX += 1;
                                break;
                            case Direction.Right:
                                playerX -= 1;
                                break;
                        }
                    }

                }
                for (int i = 0; i < boxCount; ++i)
                {
                    if (0 <= newBoxY[i] && newBoxY[i] < Console.BufferHeight)
                    {
                        BoxPositionY[index] = newBoxY[index];
                    }
                    else
                    {
                        switch (PlayerDirection)
                        {
                            case Direction.Up:
                                playerY += 1;
                                break;
                            case Direction.Down:
                                playerY -= 1;
                                break;
                        }
                    }

                }

                bool checkGoal = false;
               
                //1개의 박스에 대해서
                
                for (int i = 0; i < goalCount; ++i)
                {
                    if (BoxPositionX[index] == goalPositionX[i] && BoxPositionY[index] == goalPositionY[i])
                    {
                        isBoxOnGoal[index] = true;
                        break;
                    }
                }
                if (checkGoal)
                {
                    continue;
                }
                bool isClear = true;
                for(int i = 0; i < boxCount; ++i)
                {
                    isClear &= isBoxOnGoal[i];
                    
                }
                if (isClear)
                {
                    break;
                }
            }
                Console.Clear();
                Console.WriteLine("축하합니다 클리어입니다.");
                Console.ResetColor();
        } 
    }
}