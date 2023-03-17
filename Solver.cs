using System;

public class Solver
{
	public Solver() { }

	public void DFS()
	{
		Stack<Vertex> stack = new Stack<Vertex>();
		Stack<Vertex> alreadyVisited = new Stack<Vertex>();
		
		// Vertex buffer telah didapatkan
		Map m = new Map("config.txt");
		
		int treasureCount = m.getTreasureCount();
		int treasureFound = 0;
		Vertex start = m.getStartingPoint(m.getMap());
		stack.Push(start);

		while (stack.Count != 0 && treasureFound != treasureCount)
		{
			Vertex current = stack.Pop();
			alreadyVisited.Push(current);
			if (m.isDownValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x, current.y + 1)))
			{
				Vertex down = m.getVertex(current.x + 1, current.y);
				if (down.GetStatusTreasure())
				{
					treasureFound++;
					Console.Write("Treasure found at " + down.x + " " + down.y + "\n");
				}
				stack.Push(down);
				Console.Write("Going down\n");
			}
			if (m.isRightValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x + 1, current.y)))
			{
				Vertex right = m.getVertex(current.x + 1, current.y);
				if (right.GetStatusTreasure())
				{
					treasureFound++;
					Console.Write("Treasure found at " + right.x + " " + right.y + "\n");
				}
				stack.Push(right);
				Console.Write("Going right\n");
			}
			if (m.isLeftValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x - 1, current.y)))
			{
				Vertex left = m.getVertex(current.x - 1, current.y);
				if (left.GetStatusTreasure())
				{
					treasureFound++;
					Console.Write("Treasure found at " + left.x + " " + left.y + "\n");
				}
				stack.Push(left);
				Console.Write("Going left\n");
			}
			if (m.isUpValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x, current.y - 1)))
			{
				Vertex up = m.getVertex(current.x, current.y - 1);
				if (up.GetStatusTreasure())
				{
					treasureFound++;
					Console.Write("Treasure found at " + up.x + " " + up.y + "\n");
				}
				stack.Push(up);
				Console.Write("Going up\n");
			}
			if (!m.isDownValid(current, m.getMap()) && !m.isLeftValid(current, m.getMap()) && !m.isRightValid(current, m.getMap()) && !m.isUpValid(current, m.getMap())) {
				// backtrack
				Console.Write("Backtracking\n");
			}

		}	
	}

	public void BFS()
	{

	}
	
}
