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
        int playerY = 10;
        int newplayerX = playerX;
        int newplayerY = playerY;
        Direction playerDirection = Direction.None;

        int boxX = 50;
        int boxY = 25;
        int newboxX = 50;
        int newboxY = 20;



        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("O");
            Console.SetCursorPosition(boxX, boxY);
            Console.Write("B");
            Console.SetCursorPosition(newboxX, newboxY);

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
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

            if (0 < newplayerX && newplayerX < Console.BufferWidth)
            {
                playerX = newplayerX;
            }

            if (0 < newplayerY && newplayerY < Console.BufferHeight)
            {
                playerY = newplayerY;
            }

            if (playerX == boxX && playerY == boxY)
            {
                switch (playerDirection)
                {
                    case Direction.Left:
                        boxX -= 1;
                        break;

                    case Direction.Rigth:
                        boxX += 1;
                        
                        break;

                    case Direction.Up:
                        boxY -= 1;
                        
                        break;

                    case Direction.Down:
                        boxY += 1;
                        
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
