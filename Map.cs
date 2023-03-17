using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public int MapX, MapY;
	public int treasureCount = 0;

	/* Gerakan yang mungkin
	 * Up, Right, Down, Left */
	int[] MoveX = { 0, 1, 0, -1 };
	int[] MoveY = { -1, 0, 1, 0 };

	/* Ini buat DFS BFS */
	Vertex[,] Buffer;
	char[,] map;

	/* MAP Matrix of what */
	/* x dan y posisi, map peta, */

	/* Validator */
	public bool isUpValid(Vertex point, char[,] map)
	{
		if (point.getX() - 1 < MapX && point.getX() - 1 >= 0){
			return (map[point.getX() - 1, point.getY()] != 'X');
		} else {
			return false;
		}
	}

	public bool isDownValid(Vertex point, char[,] map)
	{
		if (point.getX() + 1 < MapX && point.getX() + 1 >= 0){
			return (map[point.getX() + 1, point.getY()] != 'X');
		} else {
			return false;
		}
	}	
	public bool isRightValid(Vertex point, char[,] map)
	{
		if (point.getX() + 1 < MapY && point.getY() + 1 >= 0){
			return (map[point.getX(), point.getY() + 1] != 'X');
		} else {
			return false;
		}	
	}
	public bool isLeftValid(Vertex point, char[,] map)
	{
		if (point.getY() - 1 < MapY && point.getY() - 1 >= 0){
			return (map[point.getX(), point.getY() - 1] != 'X');
		} else {
			return false;
		}
	}


	public bool isStartingPoint(Vertex point, char[,] map)
	{
		return (map[point.getY(),point.getX()] == 'K');
	}

	public Vertex getStartingPoint (char[,] map)
	{
		for (int i = 0; i < MapX; i++){
			for (int j = 0; j < MapY; j++){
				if (map[i,j] == 'K'){
					return new Vertex(i, j, false, true);
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
		Buffer = new Vertex[MapY, MapX];
	}
	
	public int getTreasureCount()
	{
		return treasureCount;
	}
	public Map(string file)
	{
		string[] lines = System.IO.File.ReadAllLines(file);
		int countX = 0;
		int countY = 1;
		foreach(string line in lines){
			countX++;

			if(countX == 1){
				foreach(char word in line){
					if(word == ' '){
						countY++;
					}
				}
			}

		}
		MapY = countY;
		MapX = countX;
		Console.WriteLine("X: {0}, Y: {1}", MapX, MapY);

		map = new char[countX, countY];
		for (int y = 0; y < countX; y++)
		{
			string line = lines[y];
			int j = 0;
			for (int x = 0; x < line.Length; x+=2)
			{
				char c = line[x];
				map[y, j] = c;
				Console.Write(c + " ");
				j++;
			}
			Console.WriteLine();
		}

		Buffer = new Vertex[MapX , MapY];
		Console.Write(countX + " " + countY + "\n");
		for (int i = 0; i < countX; i++){
			for (int j = 0; j < countY; j++){
				if (map[i,j] == 'X'){
					Buffer[i,j] = new Vertex(i, j, false, false);
				} else if (map[i,j] == 'T'){
					Buffer[i,j] = new Vertex(i, j, true, true);
					treasureCount++;
				} else { /* K atau R */
					Buffer[i,j] = new Vertex(i, j, false, true);
				}
			}
		}



		// Print the matrix for testing purposes
		for (int y = 0; y < countX; y++)
		{
			for (int x = 0; x < countY; x++)
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
		return Buffer[x,y];
	}

	public Vertex[,] getBuffer()
	{
		return Buffer;
	}

	public void printBuffer()
	{
		for (int i = 0; i < MapX; i++){
			for (int j = 0; j < MapY; j++){
				Buffer[i,j].print();
			}
			Console.Write("\n");
		}
	}

	public int getMapX(){
		return MapX;
	}

	public int getMapY(){
		return MapY;
	}
}
