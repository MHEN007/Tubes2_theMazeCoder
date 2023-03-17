using System;

public class Vertex
{
	/* Attributes */

	/* Koordinat pada Peta */
	private int x;
	private int y;

	/* isTreasure menandakan treasure: default false;
	 * isAvailable menandakan apakah vertex dapat diinjak: default false
	 */
	private bool IsTreasure;
	private bool IsAvailable;

	public Vertex() { this.x = 0; this.y = 0; IsTreasure = false; IsAvailable = false; }

	public Vertex(int x, int y, bool t, bool a) { this.x = x; this.y = y; this.IsTreasure = t; this.IsAvailable = a; }

	public bool GetStatusTreasure() { return IsTreasure; }

	public bool GetStatusMove() { return IsAvailable; }
	
	public int getX() { return x; }

	public int getY() { return y; }

	public void print() {
		Console.WriteLine("X: {0}, Y: {1}, Treasure: {2}, Available: {3}", x, y, IsTreasure, IsAvailable);
	}

	public void treasureAlreadyFound() { IsTreasure = false; }
}
