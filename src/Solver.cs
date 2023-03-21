using System;
using System.Security.Cryptography.X509Certificates;

public class Solver
{
	public Map m;

    public int nodesChecked = 0;

    private String[] move = { "R", "L", "U", "D" };

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
        nodesChecked = 0;
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
                nodesChecked++;
            }

            if (this.m.isUpValid(current, this.m.getMap(), visited))
            {
                Vertex up = this.m.getVertex(current.x, current.y - 1);
                stack.Push(up);
                nodesChecked++;
            }

            if (this.m.isLeftValid(current, this.m.getMap(), visited))
            {
                Vertex left = this.m.getVertex(current.x - 1, current.y);
                stack.Push(left);
                nodesChecked++;
            }

            if (this.m.isRightValid(current, this.m.getMap(), visited))
            {
                Vertex right = this.m.getVertex(current.x + 1, current.y);
                stack.Push(right);
                nodesChecked++;
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

    public string BFS()
    {
        nodesChecked = 0;
        Queue<String> queue = new Queue<String>();
        queue.Enqueue("");
        String moves = "";
        while (!FindTreasure(moves))
        {
            moves = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                if (ValidMove(moves + move[i]))
                {
                    queue.Enqueue(moves + move[i]);
                }
            }
        }
        return moves;
    }

    /* Untuk menentukan apakah gerakan sudah dapat memenuhi syarat
     * Syarat: Semua harta karun ditemukan 
     */
    public bool FindTreasure(String moves)
    {
        int treasureCount = m.getTreasureCount();
        int treasureFound = 0;
        Vertex start = m.getStartingPoint(m.getMap());
        Stack<Vertex> Treasure = new Stack<Vertex>();
        foreach (Char move in moves)
        {
            if (move == 'R')
            {
                start.x++;
            }
            else if (move == 'L')
            {
                start.x--;
            }
            else if (move == 'U')
            {
                start.y--;
            }
            else if (move == 'D')
            {
                start.y++;
            }

            if (m.getVertex(start).GetStatusTreasure() && !Treasure.Contains(m.getVertex(start)))
            {
                treasureFound++;
                Treasure.Push(m.getVertex(start));
            }
        }
        if (treasureCount == treasureFound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* Untuk menentukan apakah gerakan sudah valid atau belum
     * Gerakan valid: Tidak melanggar peta, belum mengunjungi node
     */
    public bool ValidMove(String moves)
    {
        Vertex start = m.getStartingPoint(m.getMap());
        Stack<Vertex> AlreadyVisited = new Stack<Vertex>();
        Stack<Vertex> Treasure = new Stack<Vertex>();
        int check = 0;
        foreach (Char move in moves)
        {
            if (move == 'R')
            {
                if (!m.isRightValid(start, m.getMap(), AlreadyVisited))
                {
                    return false;
                }
                else
                {
                    start.x += 1;
                    if (m.getVertex(start).GetStatusTreasure() && !Treasure.Contains(m.getVertex(start)))
                    {
                        AlreadyVisited.Clear();
                        Treasure.Push(m.getVertex(start));
                    }
                    AlreadyVisited.Push(m.getVertex(start));
                    check++;
                }
            }
            else if (move == 'L')
            {
                if (!m.isLeftValid(start, m.getMap(), AlreadyVisited))
                {
                    return false;
                }
                else
                {
                    start.x -= 1;
                    if (m.getVertex(start).GetStatusTreasure() && !Treasure.Contains(m.getVertex(start)))
                    {
                        AlreadyVisited.Clear();
                        Treasure.Push(m.getVertex(start));
                    }
                    AlreadyVisited.Push(m.getVertex(start));
                    check++;
                }
            }
            else if (move == 'U')
            {
                if (!m.isUpValid(start, m.getMap(), AlreadyVisited))
                {
                    return false;
                }
                else
                {
                    start.y -= 1;
                    if (m.getVertex(start).GetStatusTreasure() && !Treasure.Contains(m.getVertex(start)))
                    {
                        AlreadyVisited.Clear();
                        Treasure.Push(m.getVertex(start));
                    }
                    AlreadyVisited.Push(m.getVertex(start));
                    check++;
                }
            }
            else if (move == 'D')
            {
                if (!m.isDownValid(start, m.getMap(), AlreadyVisited))
                {
                    return false;
                }
                else
                {
                    start.y += 1;
                    if (m.getVertex(start).GetStatusTreasure() && !Treasure.Contains(m.getVertex(start)))
                    {
                        AlreadyVisited.Clear();
                        Treasure.Push(m.getVertex(start));
                    }
                    AlreadyVisited.Push(m.getVertex(start));
                    check++;
                }
            }
        }
        nodesChecked += check;
        return true;
    }

}
