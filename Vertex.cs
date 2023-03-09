using System;

public class Vertex
{
	/* Attributes */

	/* Koordinat pada Peta */
	public int x;
	public int y;

	/* isTreasure menandakan peta: default false;
	 * isAvailable menandakan apakah vertex dapat diinjak: default false
	 */
	private bool IsTreasure;
	private bool IsAvailable;

	public Vertex() { this.x = 0; this.y = 0; IsTreasure = false; IsAvailable = false; }

	public Vertex(int x, int y, bool t, bool a) { this.x = x; this.y = y; this.IsTreasure = t; this.IsAvailable = a; }

	public bool GetStatusTreasure() { return IsTreasure; }

	public bool GetStatusMove() { return IsAvailable; }
	
}
