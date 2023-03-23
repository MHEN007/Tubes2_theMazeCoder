using System;
using System.Security.Cryptography.X509Certificates;

public class Solver
{
	public Map m;

    public int nodesChecked;

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

        // Safe Route Stack
        Stack<Vertex> safeRoute = new Stack<Vertex>();

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
        /* Proses: Periksa semua arah pada peta hingga jumlah treasureHitung = treasurePeta
         * Iterasikan dengan Stack hingga tidak ada arah yang bisa dilanjutkan.
         * Setiap iterasi node, catat dalam stack sudah dikunjungi
         * Ketika hal tsb. terjadi, lakukan backtrack hingga ada arah yang bisa dilanjutkan
         * Lanjutkan hingga kondisi while menjadi false
         */

        // Current vertex
        Vertex current;

        // Neighbour vertices
        Vertex down;
        Vertex up;
        Vertex left;
        Vertex right;

        // Signal for backtracking
        bool signal;

        // Path contains treasure
        bool pathContainTreasure;

        // Path string
        string paths = "";

        // Reverse path stack
        Stack<char> reversePath = new Stack<char>();

        while (stack.Count > 0 && treasureFound != treasure) {
            c++;
            do {
                current = stack.Pop();
            } while (visited.Contains(current) && stack.Count > 0);

            backtrack.Push(current);
            visited.Push(current);
            if (current.GetStatusTreasure()) {
                treasureFound++;
            }

            /* Proses pencarian titik tetangga yang dapat dikunjungi */
            if (this.m.isDownValid(current, this.m.getMap(), visited)) {
                down = this.m.getVertex(current.x, current.y + 1);
                stack.Push(down);
                nodesChecked++;
            }

            if (this.m.isUpValid(current, this.m.getMap(), visited)) {
                up = this.m.getVertex(current.x, current.y - 1);
                stack.Push(up);
                nodesChecked++;
            }

            if (this.m.isLeftValid(current, this.m.getMap(), visited)) {
                left = this.m.getVertex(current.x - 1, current.y);
                stack.Push(left);
                nodesChecked++;
            }

            if (this.m.isRightValid(current, this.m.getMap(), visited)) {
                right = this.m.getVertex(current.x + 1, current.y);
                stack.Push(right);
                nodesChecked++;
            }

            signal = !this.m.isBackTrack(current, this.m.getMap(), visited);
            pathContainTreasure = false;

            /* Pencarian path jalur normal */
            if (temp != current){
                path = BacktrackerDFS(path, temp, current);
                temp = current;
            }

            /* Pencarian path backtracking */
            while (this.m.isBackTrack(current, this.m.getMap(), visited) && treasureFound < treasure) {
                temp = current;
                current = backtrack.Pop();
                
                if (current.GetStatusTreasure() && !pathContainTreasure){
                    pathContainTreasure = true;
                } else if (!pathContainTreasure && safeRoute.Contains(current)){
                    pathContainTreasure = true;
                } else if (!pathContainTreasure) {
                    if (this.m.isBackTrack(current, this.m.getMap(), visited)){
                        path.Pop();
                    }
                } else if (pathContainTreasure) {
                    BacktrackerDFS(path, temp, current);
                }
                if (pathContainTreasure && !this.m.isBackTrack(current, this.m.getMap(), visited)){
                    safeRoute.Push(current);
                }
            }

            if (!signal){
                temp = current;
                backtrack.Push(current);
            }
            
        }

        while (path.Count > 0) {
            reversePath.Push(path.Pop());
        }
        while (reversePath.Count > 0) {
            paths += reversePath.Pop();
        }   

        return paths;
    }

    public string DFSV2()
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

        // Safe Route Stack
        Stack<Vertex> safeRoute = new Stack<Vertex>();

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
        /* Proses: Periksa semua arah pada peta hingga jumlah treasureHitung = treasurePeta
         * Iterasikan dengan Stack hingga tidak ada arah yang bisa dilanjutkan.
         * Setiap iterasi node, catat dalam stack sudah dikunjungi
         * Ketika hal tsb. terjadi, lakukan backtrack hingga ada arah yang bisa dilanjutkan
         * Lanjutkan hingga kondisi while menjadi false
         */

        // Current vertex
        Vertex current;

        // Neighbour vertices
        Vertex down;
        Vertex up;
        Vertex left;
        Vertex right;

        // Signal for backtracking
        bool signal;

        // Path contains treasure
        bool pathContainTreasure;

        // Path string
        string paths = "";

        // Reverse path stack
        Stack<char> reversePath = new Stack<char>();

        while (stack.Count > 0 && treasureFound != treasure) {
            c++;
            do {
                current = stack.Pop();
            } while (visited.Contains(current) && stack.Count > 0);

            backtrack.Push(current);
            visited.Push(current);
            if (current.GetStatusTreasure()) {
                treasureFound++;
            }

            /* Proses pencarian titik tetangga yang dapat dikunjungi */
            if (this.m.isDownValid(current, this.m.getMap(), visited)) {
                down = this.m.getVertex(current.x, current.y + 1);
                stack.Push(down);
                nodesChecked++;
            }

            if (this.m.isUpValid(current, this.m.getMap(), visited)) {
                up = this.m.getVertex(current.x, current.y - 1);
                stack.Push(up);
                nodesChecked++;
            }

            if (this.m.isLeftValid(current, this.m.getMap(), visited)) {
                left = this.m.getVertex(current.x - 1, current.y);
                stack.Push(left);
                nodesChecked++;
            }

            if (this.m.isRightValid(current, this.m.getMap(), visited)) {
                right = this.m.getVertex(current.x + 1, current.y);
                stack.Push(right);
                nodesChecked++;
            }

            signal = !this.m.isBackTrack(current, this.m.getMap(), visited);
            pathContainTreasure = false;

            /* Pencarian path jalur normal */
            if (temp != current){
                path = BacktrackerDFS(path, temp, current);
                temp = current;
            }

            /* Pencarian path backtracking */
            while (this.m.isBackTrack(current, this.m.getMap(), visited) && treasureFound < treasure) {
                temp = current;
                current = backtrack.Pop();
                
                if (current.GetStatusTreasure() && !pathContainTreasure && temp != current){
                    pathContainTreasure = true;
                    path.Push('B');
                    path = BacktrackerDFS(path, temp, current);
                } else if (current.GetStatusTreasure() && !pathContainTreasure){
                    pathContainTreasure = true;
                } else if (!pathContainTreasure && safeRoute.Contains(current)){
                    pathContainTreasure = true;
                    path.Push('B');
                    path = BacktrackerDFS(path, temp, current);
                } else if (!pathContainTreasure) {
                    if (this.m.isBackTrack(current, this.m.getMap(), visited) && temp != current){
                        path.Push('B');
                        path = BacktrackerDFS(path, temp, current);
                    }
                } else if (pathContainTreasure) {
                    path = BacktrackerDFS(path, temp, current);
                }
                if (pathContainTreasure && !this.m.isBackTrack(current, this.m.getMap(), visited)){
                    safeRoute.Push(current);
                } else if (!pathContainTreasure && !this.m.isBackTrack(current, this.m.getMap(), visited)){
                    path.Push('B');
                    path = BacktrackerDFS(path, temp, current);
                }
            }

            if (!signal){
                temp = current;
                backtrack.Push(current);
            }
            
        }

        while (path.Count > 0) {
            reversePath.Push(path.Pop());
        }
        while (reversePath.Count > 0) {
            paths += reversePath.Pop();
        }   
        MessageBox.Show("Path : " + paths);
        return paths;
    }

    public Stack<char> BacktrackerDFS (Stack<char> path, Vertex temp, Vertex current)
    {
        if (this.m.isRight(temp, current)) {
            path.Push('R');
        } else if (this.m.isLeft(temp, current)) {
            path.Push('L');
        } else if (this.m.isUp(temp, current)) {
            path.Push('U');
        } else if (this.m.isDown(temp, current)) {
            path.Push('D');
        } else {
            MessageBox.Show("Error temp: " + temp.x + "," + temp.y + " current: " + current.x + "," + current.y);
        }
        return path;
    }


    public string BFS()
    {
        nodesChecked = 0;
        Queue<String> queue = new Queue<String>();
        queue.Enqueue("");
        String paths = "";
        /* Proses: Dengan queue, iterasikan gerakan yang memungkinkan dari suatu titik
         * Jika ada yang bisa digerakkan, masukkan ke pathnya dan masukkan ke stack
         * visited nodes.
         * Untuk path yang dienqueue dari queue, lakukan pemeriksaan apakah berhasil
         * mencari semua treasure atau tidak, dengan memerhatikan aturan gerakan.
         * Pada proses pencarian, jika ditemukan node treasure, kosongkan visited Nodes dan catat
         * lokasi treasure
         */
        while (!FindTreasure(paths))
        {
            paths = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                Vertex start = m.getStartingPoint(m.getMap());
                Stack<Vertex> AlreadyVisited = new Stack<Vertex>();
                Stack<Vertex> Treasure = new Stack<Vertex>();
                bool notValid = false;

                /* Periksa untuk setiap gerakan, apakah valid atau tidak
                 * Jika valid, enqueue ke queue
                 * Gerakan valid: Tidak melanggar peta, belum mengunjungi node
                 */
                foreach (Char move in paths + move[i])
                {
                    if (move == 'R')
                    {
                        if (!m.isRightValid(start, m.getMap(), AlreadyVisited))
                        {
                            notValid = true;
                            break;
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
                        }
                    }
                    else if (move == 'L')
                    {
                        if (!m.isLeftValid(start, m.getMap(), AlreadyVisited))
                        {
                            notValid = true;
                            break;
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
                        }
                    }
                    else if (move == 'U')
                    {
                        if (!m.isUpValid(start, m.getMap(), AlreadyVisited))
                        {
                            notValid = true;
                            break;
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
                        }
                    }
                    else if (move == 'D')
                    {
                        if (!m.isDownValid(start, m.getMap(), AlreadyVisited))
                        {
                            notValid = true;
                            break;
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
                        }
                    }
                }
                if (!notValid)
                {
                    queue.Enqueue(paths + move[i]);
                }
            }
            nodesChecked++;
        }
        nodesChecked--;
        return paths;
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
}
