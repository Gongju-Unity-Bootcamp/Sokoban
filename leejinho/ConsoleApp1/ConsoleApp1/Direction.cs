using System.Data;
enum Direction
{
    None,
    Left,
    Rigth,
    Up,
    Down
}
class Sokoban
{
    static void Main()
    {
        Console.ResetColor();
        Console.CursorVisible = false;
        Console.Title = "bravearc";
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        int playerX = 5;
        int playerY = 11;

        int boxX = 50;
        int boxY = 25;

        Direction playerDirection = Direction.None;

        int[] wallPositionX = new int[5] { 10, 11, 12, 13, 14 };
        int[] wallPositionY = new int[5] { 10, 11, 12, 13, 14 };

        int GoalX = 70;
        int GoalY = 5;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(playerX, playerY);
            Console.Write("O");
            Console.SetCursorPosition(boxX, boxY);
            Console.Write("B");

            for (int index = 0; index < wallPositionX.Length; ++index)
            {
                Console.SetCursorPosition(wallPositionX[index], wallPositionY[index]);
                Console.Write("X");

            }


            Console.SetCursorPosition(GoalX, GoalY);
            Console.Write("G");

            ConsoleKeyInfo KeyInfo = Console.ReadKey();

            int newplayerX = playerX;
            int newplayerY = playerY;
            playerDirection = Direction.None;

            if (KeyInfo.Key == ConsoleKey.UpArrow)
            {
                newplayerY -= 1;
                playerDirection = Direction.Up;
            }
            if (KeyInfo.Key == ConsoleKey.DownArrow)
            {
                newplayerY += 1;
                playerDirection = Direction.Down;
            }
            if (KeyInfo.Key == ConsoleKey.LeftArrow)
            {
                newplayerX -= 1;
                playerDirection = Direction.Left;
            }
            if (KeyInfo.Key == ConsoleKey.RightArrow)
            {
                newplayerX += 1;
                playerDirection = Direction.Rigth;
            }

            int newboxX = boxX;
            int newboxY = boxY;
            
            if (newplayerX == newboxX && newplayerY == newboxY)
            {
                switch (playerDirection)
                {
                    case Direction.Left:
                        newboxX -= 1;
                        break;

                    case Direction.Rigth:
                        newboxX += 1;
                        break;

                    case Direction.Up:
                        newboxY -= 1;
                        break;

                    case Direction.Down:
                        newboxY += 1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"잘못된 방향 데이터 입니다. 실제 데이터는{playerDirection}");
                        Environment.Exit(0);
                        break;
                }   
            }
        }
    }
}
