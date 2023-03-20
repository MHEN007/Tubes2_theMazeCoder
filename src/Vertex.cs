using System;

public class Vertex
{
	/* Attributes */

	/* Koordinat pada Peta */
	public int x;
	public int y;

	/* isTreasure menandakan treasure: default false;
	 * isAvailable menandakan apakah vertex dapat diinjak: default false
	 */
	private bool IsTreasure;
	private bool IsAvailable;
	private Vertex? previous;

	public Vertex() { this.x = 0; this.y = 0; IsTreasure = false; IsAvailable = false; previous = null; }

	public Vertex(int x, int y, bool t, bool a) { this.x = x; this.y = y; this.IsTreasure = t; this.IsAvailable = a; previous = null; }

    public Vertex(int x, int y, bool t, bool a, Vertex prev) { this.x = x; this.y = y; this.IsTreasure = t; this.IsAvailable = a; previous = null; previous = prev; }

    public bool GetStatusTreasure() { return IsTreasure; }

	public bool GetStatusMove() { return IsAvailable; }
	
	public int getRow() { return x; }

	public int getCol() { return y; }

	public char getValue() { return IsTreasure ? 'T' : ' '; }
}
