﻿using System;

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

	public Vertex() { this.x = 0; this.y = 0; IsTreasure = false; IsAvailable = false; }

	public Vertex(int x, int y, bool t, bool a) { this.x = x; this.y = y; this.IsTreasure = t; this.IsAvailable = a;}
	
    public bool GetStatusTreasure() { return IsTreasure; }

	public bool GetStatusMove() { return IsAvailable; }
	
	public int getRow() { return x; }

	public int getCol() { return y; }

	public char getValue() { return IsTreasure ? 'T' : ' '; }

	public void diableTreasure() { IsTreasure = false; }

	/* Edit Contains */
    public override bool Equals(object obj)
    {
        if(obj == null || GetType() != obj.GetType())
		{
			return false;
		}

		Vertex v = (Vertex)obj;
		return (x == v.x && y == v.y);
    }

    public override int GetHashCode()
    {
        return (x + y).GetHashCode();
    }
}
