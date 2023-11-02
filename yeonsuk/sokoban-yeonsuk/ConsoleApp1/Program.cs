using System;

public class Program
{
    public static void Main()
    {
        Console.ResetColor();
        Console.CursorVisible = false;
        Console.Title = "I am 믿습니다.";
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        int playerX = 50;
        int playerY = 15;
        
        while (true)
        {
          
            Console.Clear();                
            Console.CursorVisible = false;  
            
            
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("S");
           
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerX > 0) 
            {
                playerX -= 10;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0)
            {
                playerX -= 1;
            }
            if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerX + 11 < Console.BufferWidth)
            {
                playerX += 10;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow && playerX + 1 < Console.BufferWidth)
            {
                playerX += 1;
            }
            if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerY > 0 )
            {
                playerY -= 10;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0)
            {
                playerY -= 1;
            }
            if (keyInfo.Modifiers == ConsoleModifiers.Shift && playerY + 1 < Console.BufferHeight)
            {
                playerY += 10;
            }
            else if(keyInfo.Key == ConsoleKey.DownArrow && playerY + 1 < Console.BufferHeight)
            {
                playerY += 1;
            }
           
            
        }
    }
}
