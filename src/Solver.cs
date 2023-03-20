using System;
using System.Security.Cryptography.X509Certificates;

public class Solver
{
	public Map m;

	public Solver() { m = new Map("./test/config.txt"); }

	public Solver(string fileName)
	{
		m = new Map(fileName);
	}

	/* Prioritas Arah untuk DFS dan BFS
	 * 1. Kanan
	 * 2. Kiri
	 * 3. Atas
	 * 4. Bawah
	 */
	public int DFS()
	{
		Stack<Vertex> stack = new Stack<Vertex>();
		Stack<Vertex> alreadyVisited = new Stack<Vertex>();
				
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
            Console.WriteLine(c + "\nX: " + current.x + " Y: " + current.y);
            if (current.GetStatusTreasure())
            {
                treasureFound++;
                Console.Write("Treasure found at " + current.x + " " + current.y + "\n");
            }
            if (m.isDownValid(current, m.getMap(), alreadyVisited))
            {
                Vertex down = m.getVertex(current.x, current.y + 1);
                stack.Push(down);
                Console.Write("Going down\n");
            }else{				// backtrack
				Console.Write("Backtracking down\n");
			}
			if (m.isUpValid(current, m.getMap(), alreadyVisited))
			{
				Vertex up = m.getVertex(current.x, current.y - 1);
				stack.Push(up);
				Console.Write("Going up\n");
			}else{				// backtrack
				Console.Write("Backtracking Up\n");
			}
            if (m.isLeftValid(current, m.getMap(), alreadyVisited))
            {
                Vertex left = m.getVertex(current.x - 1, current.y);
                stack.Push(left);
                Console.Write("Going left\n");
            }
            else
            {               // backtrack
                Console.Write("Backtracking Left\n");
            }
            if (m.isRightValid(current, m.getMap(), alreadyVisited))
            {
                Vertex right = m.getVertex(current.x + 1, current.y);
                stack.Push(right);
                Console.Write("Going right\n");
            }
            else
            {           // backtrack
                Console.Write("Backtracking Right\n");
            }
            // backtrack
            if (m.isBackTrack(current, m.getMap(), alreadyVisited))
            {
                Vertex backtrack = m.getVertex(current.x, current.y);
                stack.Push(backtrack);
                Console.Write("Backtracking\n");
            }
        }
        return c;
	}

	public int BFS()
	{
		Queue<Vertex> queue = new Queue<Vertex>();
		Stack<Vertex> AlreadyVisited = new Stack<Vertex>();

        int treasureCount = m.getTreasureCount();
        int treasureFound = 0;
        Vertex start = m.getStartingPoint(m.getMap());
        queue.Enqueue(start);
        int c = 0;

		while (queue.Count > 0 && treasureCount != treasureFound)
		{
			c++;
			Vertex current = queue.Dequeue();
			AlreadyVisited.Push(current);
            Console.WriteLine(c + "\nX: " + current.x + " Y: " + current.y);
            if (current.GetStatusTreasure())
            {
                treasureFound++;
                Console.Write("Treasure found at " + current.x + " " + current.y + "\n");
            }
            if (m.isRightValid(current, m.getMap(), AlreadyVisited) && !AlreadyVisited.Contains(m.getVertex(current.x + 1, current.y)))
            {
                Vertex right = m.getVertex(current.x + 1, current.y);
                queue.Enqueue(right);
                Console.Write("Going right\n");
            }
            if (m.isLeftValid(current, m.getMap(), AlreadyVisited) && !AlreadyVisited.Contains(m.getVertex(current.x - 1, current.y)))
            {
                Vertex left = m.getVertex(current.x - 1, current.y);
                queue.Enqueue(left);
                Console.Write("Going left\n");
            }
            if (m.isUpValid(current, m.getMap(), AlreadyVisited) && !AlreadyVisited.Contains(m.getVertex(current.x, current.y - 1)))
            {
                Vertex up = m.getVertex(current.x, current.y - 1);
                queue.Enqueue(up);
                Console.Write("Going up\n");
            }
            if (m.isDownValid(current, m.getMap(), AlreadyVisited) && !AlreadyVisited.Contains(m.getVertex(current.x, current.y + 1)))
            {
                Vertex down = m.getVertex(current.x, current.y + 1);
                queue.Enqueue(down);
                Console.Write("Going down\n");
            }
        }
        return c;

    }
	
}
