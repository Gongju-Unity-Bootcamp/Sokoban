namespace Socoban1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "의영이의 소코반";
            Console.BackgroundColor = ConsoleColor.Black; //배경색
            Console.ForegroundColor = ConsoleColor.Cyan; //글꼴색
            Console.Clear();

            //플레이어 좌표
            int playerX = 0;
            int playerY = 0;
             
            while (true)
            {

                //창 초기화 시 커서가 다시 보이므로 초기화 해주기
                Console.CursorVisible = false;
                // Render

                //방향키 입력데이터 가져오기
                //keyinfo.key --> 입력 키
                //keyinfo.Modifiers --> ctrl, alt, shift (키를 누르면서 다른 키를 눌렀을 때 값이 나오지만 누르지 않을 경우 0)
                
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                Console.Clear();

                switch (keyinfo.Key.ToString())
                {
                    case "A":
                        if (playerX > 0)
                            playerX--;
                        break;
                    case "D":
                        playerX++; break;
                    case "W":
                        if (playerY > 0)
                            playerY--; break;
                    case "S":
                        playerY++;
                        break;
                    default:
                        break;
                }


                ////커서 옮기기 (이동좌표로 이동후 플레이어 출력)
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("PLAYER") ;

                // ProcessInput
                if(keyinfo.Key== ConsoleKey.LeftArrow )
                {

                }
                // Update
            }


        }
    }
}