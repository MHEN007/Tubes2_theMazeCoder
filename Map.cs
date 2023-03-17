using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public static int MapX, MapY;
	public static int treasureCount = 0;

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
		if (point.y + MoveY[0] < MapY && point.y + MoveY[0] >= 0){
			return (map[point.y+MoveY[0],point.x] != 'X');
		} else {
			return false;
		}
	}

	public bool isDownValid(Vertex point, char[,] map)
	{
		if (point.y + MoveY[2] < MapY && point.y + MoveY[2] >= 0){
			return (map[point.y + MoveY[2],point.x] != 'X');
		} else {
			return false;
		}
	}	
	public bool isRightValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[1] < MapX && point.x + MoveX[1] >= 0){
			return (map[point.y,point.x + MoveX[1]] != 'X');
		} else {
			return false;
		}	}
	public bool isLeftValid(Vertex point, char[,] map)
	{
		if (point.x + MoveX[3] < MapX && point.x + MoveX[3] >= 0){
			return (map[point.y,point.x + MoveX[3]] != 'X');
		} else {
			return false;
		}
	}


	public bool isStartingPoint(Vertex point, char[,] map)
	{
		return (map[point.y,point.x] == 'K');
	}

	public Vertex getStartingPoint (char[,] map)
	{
		for (int i = 0; i < MapY; i++){
			for (int j = 0; j < MapX; j++){
				if (map[i,j] == 'K'){
					return new Vertex(j, i, false, true);
				}
			}
		}
		return new Vertex(0, 0, false, false);
	}

	public Map()
	{
		MapX = 0;
		MapY = 0;
		map = new char[MapY, MapX];
		Buffer = new Vertex[MapX * MapY];
	}
	
	public int getTreasureCount()
	{
		return treasureCount;
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
					Buffer[i * countY + j] = new Vertex(j, i, false, false);
				} else if (map[i,j] == 'T'){
					Buffer[i * countY + j] = new Vertex(j, i, true, true);
					treasureCount++;
				} else { /* K atau R */
					Buffer[i * countY + j] = new Vertex(j, i, false, true);
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
		Console.Write("Treasure Count: " + treasureCount + "\n");
	}

	public char[,] getMap()
	{
		return map;
	}

	public Vertex getVertex(int x, int y)
	{
		return Buffer[y * MapY + x];
	}
}
