using System;
using System.Security.Cryptography.X509Certificates;

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
        int c = 0;
		while (stack.Count != 0 && treasureFound != treasureCount)
		{
			c++;
			Vertex current = stack.Pop();
            alreadyVisited.Push(current);
            Console.WriteLine(c+"\nX: " + current.x + " Y: " + current.y);
            if (current.GetStatusTreasure())
            {
                treasureFound++;
                Console.Write("Treasure found at " + current.x + " " + current.y + "\n");
            }
            if (m.isDownValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x, current.y + 1)))
			{
				Vertex down = m.getVertex(current.x, current.y + 1);
				stack.Push(down);
				Console.Write("Going down\n");
			}
			else{				// backtrack
				Console.Write("Backtracking down\n");
			}
			if (m.isRightValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x + 1, current.y)))
			{
				Vertex right = m.getVertex(current.x + 1, current.y);
				stack.Push(right);
				Console.Write("Going right\n");
			}else{			// backtrack
				Console.Write("Backtracking Right\n");
			}
            if (m.isLeftValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x - 1, current.y)))
			{
				Vertex left = m.getVertex(current.x - 1, current.y);
				stack.Push(left);
				Console.Write("Going left\n");
			}else{				// backtrack
				Console.Write("Backtracking Left\n");
			}
			if (m.isUpValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.x, current.y - 1)))
			{
				Vertex up = m.getVertex(current.x, current.y - 1);
				stack.Push(up);
				Console.Write("Going up\n");
			}else{				// backtrack
				Console.Write("Backtracking Up\n");
			}

		}	
	}

	public void BFS()
	{

	}
	
}
