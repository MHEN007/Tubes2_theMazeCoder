using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public static int MapX, MapY;

	/* Gerakan yang mungkin
	 * Up, Right, Down, Left */
	int[] MoveX = { 0, 1, 0, -1 };
	int[] MoveY = { -1, 0, 1, 0 };

	/* Ini buat DFS BFS */
	Vertex[] Buffer;
	char[,] map;

	/* MAP Matrix of what */
	/* x dan y posisi, map peta, */

	/* Validator */
	public bool isUpValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[0] <= MapX && point.y + MoveY[0] <= MapY && point.x + MoveX[0] >= 0 && point.y + MoveY[0] >= 0){
			return (map[point.y-MoveY[0],point.x+MoveX[0]] != 'X');
		} else {
			return false;
		}
	}

	public bool isDownValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[2] <= MapX && point.y + MoveY[2] <= MapY && point.x + MoveX[2] >= 0 && point.y + MoveY[2] >= 0){
			return (map[point.y + MoveY[2],point.x + MoveX[2]] != 'X');
		} else {
			return false;
		}
	}	
	public bool isRightValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[1] <= MapX && point.y + MoveY[1] <= MapY && point.x + MoveX[1] >= 0 && point.y + MoveY[1] >= 0){
			return (map[point.y + MoveY[1],point.x + MoveX[1]] != 'X');
		} else {
			return false;
		}	}
	public bool isLeftValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[3] <= MapX && point.y + MoveY[3] <= MapY && point.x + MoveX[3] >= 0 && point.y + MoveY[3] >= 0){
			return (map[point.y + MoveY[3],point.x + MoveX[3]] != 'X');
		} else {
			return false;
		}
	}

	public Map()
	{
		MapX = 0;
		MapY = 0;
		map = new char[MapY, MapX];
		Buffer = new Vertex[MapX * MapY];
	}
	
	public Map(string file)
	{
		string[] lines = System.IO.File.ReadAllLines(file);
		int countY = 0;
		int countX = 1;
		foreach(string line in lines){
			countY++;

			if(countY == 1){
				foreach(char word in line){
					if(word == ' '){
						countX++;
					}
				}
			}

		}
		MapX = countX;
		MapY = countY;

		map = new char[countY, countX];
		for (int y = 0; y < countY; y++)
		{
			string line = lines[y];
			int j = 0;
			for (int x = 0; x < line.Length; x+=2)
			{
				char c = line[x];
				map[y, j] = c;
				j++;
			}
		}

		Buffer = new Vertex[countY * countX];
		Console.Write(countX + " " + countY + "\n");
		for (int i = 0; i < countY; i++){
			for (int j = 0; j < countX; j++){
				if (map[i,j] == 'X'){
					Buffer[i * countY + j] = new Vertex(i, j, false, false);
				} else if (map[i,j] == 'T'){
					Buffer[i * countY + j] = new Vertex(i, j, true, true);
				} else { /* K atau R */
					Buffer[i * countY + j] = new Vertex(i, j, false, true);
				}
			}
		}



		// Print the matrix for testing purposes
		for (int y = 0; y < countY; y++)
		{
			for (int x = 0; x < countX; x++)
			{
				Console.Write(map[y, x] + " ");
			}
			Console.WriteLine();
		}
	}

	public char[,] getMap()
	{
		return map;
	}
}
