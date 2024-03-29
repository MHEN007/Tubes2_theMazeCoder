﻿using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public static int MapX, MapY;
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
	public bool isUpValid(Vertex point, char[,] map, Stack<Vertex> stack)
	{
		if (point.y + MoveY[0] < MapY && point.y + MoveY[0] >= 0 && !stack.Contains(this.getUp(point)))
		{
			return (map[point.y+MoveY[0],point.x] != 'X');
		} else {
			return false;
		}
	}

	public bool isDownValid(Vertex point, char[,] map, Stack<Vertex> stack)
	{
		if (point.y + MoveY[2] < MapY && point.y + MoveY[2] >= 0 && !stack.Contains(this.getDown(point)))
        {
			return (map[point.y + MoveY[2],point.x] != 'X');
		} else {
			return false;
		}
	}	
	public bool isRightValid(Vertex point, char[,] map, Stack<Vertex> stack)
	{
		if (point.x + MoveX[1] < MapX && point.x + MoveX[1] >= 0 && !stack.Contains(this.getRight(point)))
        {
			return (map[point.y,point.x + MoveX[1]] != 'X');
		} else {
			return false;
		}	}
	public bool isLeftValid(Vertex point, char[,] map, Stack<Vertex> stack)
	{
		if (point.x + MoveX[3] < MapX && point.x + MoveX[3] >= 0 && !stack.Contains(this.getLeft(point)))
        {
			return (map[point.y,point.x + MoveX[3]] != 'X');
		} else {
			return false;
		}
	}
	public bool isBackTrack(Vertex point, char[,] map, Stack<Vertex> stack)
	{
		if (!isUpValid(point, map, stack) && !isDownValid(point, map, stack) && !isLeftValid(point, map, stack) && !isRightValid(point, map, stack))
		{
            return true;
        } else
		{
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
		Buffer = new Vertex[MapY,MapX];
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

		Buffer = new Vertex[countY,countX];
		Console.Write(countX + " " + countY + "\n");
		for (int i = 0; i < countY; i++){
			for (int j = 0; j < countX; j++){
				if (map[i,j] == 'X'){
					Buffer[i,j] = new Vertex(j, i, false, false);
				} else if (map[i,j] == 'T'){
					Buffer[i,j] = new Vertex(j, i, true, true);
					treasureCount++;
				} else { /* K atau R */
					Buffer[i, j] = new Vertex(j, i, false, true);
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
		return Buffer[y, x];
	}

	public Vertex getRight(Vertex point)
	{
		return Buffer[point.y, point.x + 1];
	}

	public Vertex getLeft(Vertex point)
	{
		return Buffer[point.y, point.x - 1];
	}

	public Vertex getUp(Vertex point)
	{
		return Buffer[point.y - 1, point.x];
	}

	public Vertex getDown(Vertex point)
	{
		return Buffer[point.y + 1, point.x];
	}

	public Vertex getVertex(Vertex point)
	{
		return Buffer[point.y, point.x];
	}

	public void setVertex(Vertex point)
	{
		Buffer[point.y, point.x] = point;
	}

	public bool isRight(Vertex p1, Vertex p2)
	{
		return (p1.y == p2.y && p1.x + 1 == p2.x);
	}

	public bool isLeft(Vertex p1, Vertex p2)
	{
		return (p1.y == p2.y && p1.x - 1 == p2.x);
	}

	public bool isUp(Vertex p1, Vertex p2)
	{
		return (p1.y - 1 == p2.y && p1.x == p2.x);
	}

	public bool isDown(Vertex p1, Vertex p2)
	{
		return (p1.y + 1 == p2.y && p1.x == p2.x);
	}
}
