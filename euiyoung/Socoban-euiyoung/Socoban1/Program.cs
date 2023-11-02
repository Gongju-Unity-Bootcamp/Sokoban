using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks.Sources;
using System.Linq;

namespace Socoban1
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
        static void Main(string[] args)
        {
            Program pg = new Program();
            Direction PlayerDirection = new Direction();
            PlayerDirection = Program.Direction.None;

            //플레이어 위치, 스피드
            int PlayerX = 7;
            int PlayerY = 7;
            int Speed = 1;
            int Score = 0;
            //화면 초기화
            pg.InitScreen();

            //벽그리기
            const int wallMin = 5;
            const int wallMax = 20;
            
            //벽예시
            int[] wallX = {8,9,10};
            int[] wallY = {12,12,12};

            for (int i = 0; i < wallX.Length; i++){
                Console.SetCursorPosition(wallX[i], wallY[i]);
                Console.Write("#");
            }


            //위치를 바로 바꾸는 것이 아니라 아래에 범위에 유효하다면 좌표를 변경시키도록 변경할 수 있음
            int newPlayerX = PlayerX;
            int newPlayerY = PlayerY;

            //박스그리기
            int boxX = 10;
            int boxY = 10;
            int newBoxX = boxX;
            int newBoxY = boxY;

            //골 지점
            Random random = new Random();

            int[] goalX = new int[3];
            int[] goalY = new int[3]; 

            for(int i =0; i< goalX.Length; i++)
            {
                goalX[i] =random.Next(wallMin + 1, wallMax * 2);
                goalY[i] =random.Next(wallMin + 1, wallMax);
            }
            //1. 벽생성, 2.플레이어생성, 3. 박스생성 4. 골 생성
            pg.DrawWall(wallMin, wallMax);
            pg.DrawPlayer(PlayerX, PlayerY);
            pg.DrawBox(boxX, boxY);
            pg.DrawGoal(goalX, goalY);

            Console.SetCursorPosition(4, 2);
            Console.Write($"SCORE : {Score} !!!!");

            while (true)
            {
                //키 입력
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                Console.Clear();

                //플레이어 이동 위치 초기화
                newPlayerX = PlayerX;
                newPlayerY = PlayerY;

                Console.SetCursorPosition(4, 2);
                Console.Write($"SCORE : {Score} !!!!");
                for (int i = 0; i < wallX.Length; i++)
                {
                    Console.SetCursorPosition(wallX[i], wallY[i]);
                    Console.Write("#");
                }

                pg.DrawWall(wallMin, wallMax);
                pg.DrawGoal(goalX, goalY);

                //shift 입력 시 스피드 
                if (keyinfo.Modifiers == ConsoleModifiers.Shift)
                {
                    Speed = 3;
                }
                else
                {
                    Speed = 1;
                }

                //플레이어 이동
                if (keyinfo.Key == ConsoleKey.LeftArrow || keyinfo.Key == ConsoleKey.A)
                {
                    newPlayerX -= Speed;
                    PlayerDirection = Program.Direction.Left;
                }
                if (keyinfo.Key == ConsoleKey.RightArrow || keyinfo.Key == ConsoleKey.D)
                {
                    newPlayerX += Speed;
                    PlayerDirection = Program.Direction.Right;
                }
                if (keyinfo.Key == ConsoleKey.UpArrow || keyinfo.Key == ConsoleKey.W)
                {
                    newPlayerY -= Speed;
                    PlayerDirection = Program.Direction.Up;
                }
                if (keyinfo.Key == ConsoleKey.DownArrow || keyinfo.Key == ConsoleKey.S)
                {
                    newPlayerY += Speed;
                    PlayerDirection = Program.Direction.Down;
                }

                //박스랑 플레이어 충돌
                if (newPlayerX == newBoxX && newPlayerY == newBoxY)
                {
                    switch (PlayerDirection)
                    {
                        case Program.Direction.Left:
                            newBoxX -= 1; break;
                        case Program.Direction.Right:
                            newBoxX += 1; break;
                        case Program.Direction.Up:
                            newBoxY -= 1; break;
                        case Program.Direction.Down:
                            newBoxY += 1; break;
                        default: break;
                    }
                }

                //박스랑 벽이랑 충돌
                if (newBoxX == wallMin || newBoxX == wallMax * 2 || newBoxY == wallMin || newBoxY == wallMax)
                {
                    switch (PlayerDirection)
                    {
                        case Program.Direction.Left:
                            newBoxX += 1;
                            newPlayerX = newBoxX + 1;
                            break;
                        case Program.Direction.Right:
                            newBoxX -= 1;
                            newPlayerX = newBoxX - 1;
                            break;
                        case Program.Direction.Up:
                            newBoxY += 1;
                            newPlayerY = newBoxY + 1;
                            break;
                        case Program.Direction.Down:
                            newBoxY -= 1;
                            newPlayerY = newBoxY - 1;
                            break;
                        default: break;
                    }
                }

                if ((Array.IndexOf(wallX, newPlayerX) == Array.IndexOf(wallY, newPlayerY) && Array.IndexOf(wallX, newPlayerX)>-1)
                    || (Array.IndexOf(wallX, newBoxX) == Array.IndexOf(wallY, newBoxY) &&Array.IndexOf(wallX, newBoxX) > -1))
                {
                    break;
                }

                boxX = newBoxX;
                boxY = newBoxY;

                //플레이어와 벽 충돌
                if (wallMin == newPlayerX || wallMax * 2 == newPlayerX || wallMin == newPlayerY || wallMax == newPlayerY)
                {
                    switch (PlayerDirection)
                    {
                        case Program.Direction.Left:
                            newPlayerX += 1; break;
                        case Program.Direction.Right:
                            newPlayerX -= 1; break;
                        case Program.Direction.Up:
                            newPlayerY += 1; break;
                        case Program.Direction.Down:
                            newPlayerY -= 1; break;
                        default: break;
                    }
                }
                PlayerX = newPlayerX;
                PlayerY = newPlayerY;


                bool getScore = false;
                //박스 골인
                if (Array.IndexOf(goalX, boxX) == Array.IndexOf(goalY,boxY) && Array.IndexOf(goalX, boxX)>-1)
                {
                    Score += 1;
                    getScore = true;
                    goalX[Array.IndexOf(goalX, boxX)] = random.Next(wallMin + 1, wallMax * 2);
                    goalY[Array.IndexOf(goalY, boxY)] = random.Next(wallMin + 1, wallMax);
                    Console.SetCursorPosition(4, 2);
                    Console.Write($"SCORE : {Score} !!!!");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                }
                //박스 위치 업데이트
                pg.DrawBox(boxX, boxY);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                //플레이어 이동
                pg.DrawPlayer(PlayerX, PlayerY);
            }
        }
        private void InitScreen()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "의영이의 소코반";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
        }
        private void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("♥");
        }
        private void DrawWall(int min, int max)
        {
            for(int i  = min; i <= max; i++ )
            {
                for(int j = min; j<=max*2; j++)
                {
                    if( i == min || i == max)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("#");
                    }
                    else
                    {
                        if( j == min || j == max * 2)
                        {
                            Console.SetCursorPosition(j,  i);
                            Console.Write("#");
                        }
                    }
                }

            }
        }
        private void DrawBox(int x, int y)
        {
            
            Console.SetCursorPosition(x,y);
            Console.Write("■");
        }
        private void DrawGoal(int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write("@");
            }
        }
    }
}