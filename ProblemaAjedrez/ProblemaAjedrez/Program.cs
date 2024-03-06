
char[,] tablero = new char[8, 8];
for (int i = 0; i < tablero.GetLength(0); i++)
{
    for (int j = 0; j < tablero.GetLength(0); j++)
    {
        if (i % 2 == 0)
            tablero[i, j] = (j % 2 == 0) ? 'R' : 'B';
        else
            tablero[i, j] = (j % 2 == 0) ? 'B' : 'R';
    }
}

for (int i = 0; i < tablero.GetLength(0); i++)
{
    for (int j = 0; j < tablero.GetLength(0); j++)
    {
        Console.Write(tablero[i, j] + "\t");
        
    }
    Console.Write("\n");
}


Console.ReadKey();