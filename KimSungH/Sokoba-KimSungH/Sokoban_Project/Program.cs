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

            Random rand = new Random();

            int boxX = 7;
            int boxY = 7;

            int wallX = 10;
            int wallY = 10;

            int goalX = 60;
            int goalY = 20;


            while (true)
            {
                //------------------Reander------------------
                Console.Clear();
                Console.CursorVisible = false;

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("@");

                //Console.SetCursorPosition(objectX, objectY);
                //Console.Write("@");

                Console.SetCursorPosition(boxX, boxY);
                Console.Write('B');

                Console.SetCursorPosition(wallX, wallY);
                Console.Write('W');

                Console.SetCursorPosition(goalX, goalY);
                Console.Write("G");

                //----------------ProcessInput-------------
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey Key = keyInfo.Key;

                //----------------Update--------------------

                PlayerDirection = Direction.None;

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                if (Key == ConsoleKey.LeftArrow )
                {
                    newPlayerX -= 1;
                    PlayerDirection = Direction.Left;
                }
                if (Key == ConsoleKey.RightArrow )
                {
                    newPlayerX += 1;
                    PlayerDirection = Direction.Right;
                }
                if (Key == ConsoleKey.UpArrow )
                {
                    newPlayerY -= 1;
                    PlayerDirection = Direction.Up;
                }
                if (Key == ConsoleKey.DownArrow)
                {
                    newPlayerY += 1;
                    PlayerDirection = Direction.Down;
                }

                int newBoxX = boxX;
                int newBoxY = boxY;

                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
                {
                    switch (PlayerDirection)
                    {
                        case (Direction)1:
                            newBoxX -= 1;

                            break;
                        case (Direction)2:
                            newBoxX += 1;

                            break;
                        case (Direction)3:
                            newBoxY -= 1;

                            break;
                        case (Direction)4:
                            newBoxY += 1;

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

                if (wallX == newPlayerX && wallY == newPlayerY ||
                wallX == newBoxX && wallY == newBoxY)
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

                if (0 <= newBoxX && newBoxX < Console.BufferWidth)
                {
                    boxX = newBoxX;
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

                if (0 <= newBoxY && newBoxY < Console.BufferHeight)
                {
                    boxY = newBoxY;
                }
                else
                {
                    switch(PlayerDirection)
                    {
                        case Direction.Up:
                            playerY += 1;
                            break;
                        case Direction.Down:
                            playerY -= 1;
                            break;
                    }
                }
                if (boxX == goalX && boxY == goalY)
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