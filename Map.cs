using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public static int MapX, MapY;

	/* Gerakan yang mungkin
	 * Up, Right, Down, Left */
	int[] MoveX = { 0, 1, 0, -1 };
	int[] MoveY = { 1, 0, -1, 0 };

	/* Ini buat DFS BFS */
	Vertex[] Buffer = new Vertex[MapX*MapY];
	char[,] map = new char[MapY,MapX];

	/* MAP Matrix of what */
	/* x dan y posisi, map peta, */

	/* Validator */
	bool isUpValid(Vertex point, char[][] map)
	{
		if(map[point.y+MoveY[0]][point.x+MoveX[0]] != 'X' && point.x + MoveX[0] <= MapX && point.y + MoveY[0] <= MapY){ 
			return true; 
		} else { 
			return false; 
		}
	}

	bool isDownValid(Vertex point, char[][] map)
	{
		if(map[point.y+MoveY[2]][point.x+MoveX[2]] != 'X' && point.x + MoveX[0] <= MapX && point.y + MoveY[0] <= MapY ){ return true; } else { return false; }
	}
	bool isRightValid(Vertex point, char[][] map)
	{
		if(map[point.y+MoveY[1]][point.x+MoveX[1]] != 'X' && point.x + MoveX[0] <= MapX && point.y + MoveY[0] <= MapY ){ return true; } else { return false; }
	}
	bool isLeftValid(Vertex point, char[][] map)
	{
		if(map[point.y+MoveY[0]][point.x+MoveX[0]] != 'X' && point.x + MoveX[0] <= MapX && point.y + MoveY[0] <= MapY ){ return true; } else { return false; }
	}

	public Map()
	{
		MapX = 0;
		MapY = 0;
	}

	/* Baca Peta dari sebuah file */
	public Map(string file)
	{
		string[] lines = System.IO.File.ReadAllLines(file);
		int county = 0;
		int countx = 1;
		foreach(string line in lines){
			county++;

			if(county == 1){
				foreach(char word in line){
					if(word == ' '){
						countx++;
					}
				}
			}

		}
		MapX = countx;
		MapY = county;
		Console.WriteLine(MapX);
		Console.WriteLine(MapY);
	}
}
