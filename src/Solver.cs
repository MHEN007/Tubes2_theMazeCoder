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
	public string DFS()
	{
        // Stack for DFS
        Stack<Vertex> stack = new Stack<Vertex>();

        // Already visited vertices
        Stack<Vertex> visited = new Stack<Vertex>();

        // Backtracked stack
        Stack<Vertex> backtrack = new Stack<Vertex>();

        // Path stack
        Stack<char> path = new Stack<char>();

        // Start vertex
        // Solver start = new Solver(mazepath);

        // Temporary vertex
        Vertex temp = new Vertex();

        // Treasure found
        int treasureFound = 0;
        int treasure = this.m.getTreasureCount();

        // Add start vertex to queue
        Vertex startVertex = this.m.getStartingPoint(this.m.getMap());
        temp = startVertex;
        stack.Push(startVertex);

        // Add start vertex to visited
        visited.Push(startVertex);

        // Add start vertex to backtrack
        backtrack.Push(startVertex);

        int c = 0;
        while (stack.Count > 0 && treasureFound != treasure)
        {
            c++;
            Vertex current = stack.Pop();
            backtrack.Push(current);
            visited.Push(current);
            if (current.GetStatusTreasure())
            {
                treasureFound++;
            }

            if (this.m.isDownValid(current, this.m.getMap(), visited))
            {
                Vertex down = this.m.getVertex(current.x, current.y + 1);
                stack.Push(down);
            }

            if (this.m.isUpValid(current, this.m.getMap(), visited))
            {
                Vertex up = this.m.getVertex(current.x, current.y - 1);
                stack.Push(up);
            }

            if (this.m.isLeftValid(current, this.m.getMap(), visited))
            {
                Vertex left = this.m.getVertex(current.x - 1, current.y);
                stack.Push(left);
            }

            if (this.m.isRightValid(current, this.m.getMap(), visited))
            {
                Vertex right = this.m.getVertex(current.x + 1, current.y);
                stack.Push(right);
            }

            bool signal = false;
            if (!this.m.isBackTrack(current, this.m.getMap(), visited)){
                signal = true;
            }

            bool isSUS = false;

            if (temp != current){
                if (this.m.isRight(temp, current))
                {
                    path.Push('R');
                }
                else if (this.m.isLeft(temp, current))
                {
                    path.Push('L');
                }
                else if (this.m.isUp(temp, current))
                {
                    path.Push('U');
                }
                else if (this.m.isDown(temp, current))
                {
                    path.Push('D');
                }
                else 
                {
                    MessageBox.Show("Error");
                }
                temp = current;
            }

            while (this.m.isBackTrack(current, this.m.getMap(), visited) && treasureFound < treasure)
            {
                temp = current;
                current = backtrack.Pop();
                if (current.GetStatusTreasure() && !isSUS){
                    isSUS = true;
                } else if (!isSUS) {
                    if (this.m.isBackTrack(current, this.m.getMap(), visited)){
                        path.Pop();
                    }
                } else if (isSUS) {
                    if (this.m.isRight(temp, current))
                    {
                        path.Push('R');
                    }
                    else if (this.m.isLeft(temp, current))
                    {
                        path.Push('L');
                    }
                    else if (this.m.isUp(temp, current))
                    {
                        path.Push('U');
                    }
                    else if (this.m.isDown(temp, current))
                    {
                        path.Push('D');
                    }
                    else 
                    {
                        MessageBox.Show("Error");
                    }
                }
            }

            if (!signal){
                temp = current;
                backtrack.Push(current);
            }

        }

        string paths = "";
        Stack<char> reversePath = new Stack<char>();
        while (path.Count > 0)
        {
            reversePath.Push(path.Pop());
        }
        
        while (reversePath.Count > 0)
        {
            paths += reversePath.Pop();
        }
        
        return paths;
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
