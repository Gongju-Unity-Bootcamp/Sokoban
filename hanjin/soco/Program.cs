namespace soco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor(); // 컬러를 초기화한다.
            Console.CursorVisible = false; // 커서를 숨긴다.
            Console.Title = "쏠수있어!";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear(); // 콘솔 창에 출력된 내용을 모두 지운다.

            // 플레이어 좌표
            int playerX = 0;
            int playerY = 0;
            // 박스 좌표
            int boxX = 5;
            int boxY = 5;


            //Console.SetCursorPosition(playerX, playerY);
            //Console.WriteLine("P");

            //입력 출력 처리 순으로 한다.
            while (true)
            {
                //-----------------------------------------랜더--------------------------------------
                //플레이어를 출력한다.
                Console.Clear();                     //이전 화면 지움
                Console.CursorVisible = false;       //커서 숨긴다.

                //플레이어를 이동시킨다.
                Console.SetCursorPosition(playerX, playerY);
                Console.WriteLine("P");

                Console.SetCursorPosition(boxX, boxY);
                Console.Write("B");
                //
                ////------------------------인풋=----------------
                //ConsoleKeyInfo currentKeyInfo = Console.ReadKey();
                // keyInfo.key : 백스페이스, 스페이스 레프트에로우, 라이트에로우,A
                // KeyInfo.Modifiers : 컨트롤, 쉬프트, 알트
                //ConsoleKey key = ConsoleKey.Info.Key;

                
                ConsoleKeyInfo keyInfo= Console.ReadKey();

                //---------------------------업데이트---------------------
                //플레이어를 움직인      다
                // 왼쪽으로 플레이어를 움직이고 싶다. => 현재 플레이어의 x좌표에서 1을 뺀다. 

                
                //왼쪽 키 눌렀을때 => 현재 누른 키 == 왼쪽 키
                if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerX -=2;
                    }
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && playerX+1 < Console.BufferWidth)
                {
                    playerX += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerX+2<Console.BufferWidth)
                    {
                        playerX +=2;
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
                {
                    playerY -= 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        playerY -=2;
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && playerY+1 < Console.BufferHeight)
                {
                    playerY += 1;
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerY + 2 < Console.BufferHeight)
                    {
                        playerY +=2;
                    }
                }
                if (playerX == boxX && playerY == boxY)
                {
                    playerX = 10; 
                    playerY = 10;   
                }
               
                
               
                //if (playerY)
                //Console.Clear();
                //Console.WriteLine($"니가 입력한키 : {KeyInfo.Key}");
                //Console.WriteLine($"니가 입력한 한정자 : {KeyInfo.Modifiers}");

                // 이동과 관련된 기능을 하나이상 구현

            }
        }
    }
}