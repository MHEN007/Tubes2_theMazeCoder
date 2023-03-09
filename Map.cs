using System;

public class Map
{
	/* Ukuran Peta: x dan y */
	public static int MapX, MapY;

	/* Gerakan yang mungkin
	 * Up, Right, Down, Left */
	int[] MoveX = { 0, 1, 0, -1 };
	int[] MoveY = { 1, 0, -1, 0 };

	Vertex[] Buffer = new Vertex[MapX*MapY];

	public Map()
	{
		MapX = 0;
		MapY = 0;
	}

	/* Baca Peta dari sebuah file */
	public Map(string file)
	{

	}
}
