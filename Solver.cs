using System;
// using System.Thhreading;

public class Solver
{
	public Solver() { }

	public async void DFS()
	{
		Stack<Vertex> stack = new Stack<Vertex>();
		Stack<Vertex> alreadyVisited = new Stack<Vertex>();
		
		// Vertex buffer telah didapatkan
		Map m = new Map("config.txt");
		
		int treasureCount = m.getTreasureCount();
		int treasureFound = 0;
		Vertex start = m.getStartingPoint(m.getMap());
		Vertex temp;
		stack.Push(start);

		Vertex current = new Vertex(0, 0, false, false);
		while (stack.Count != 0 && treasureFound != treasureCount)
		{
			Thread.Sleep(2000);
		
			Console.Write("=========================================================\n");
			current = stack.Pop();
			if (current.GetStatusTreasure() && !alreadyVisited.Contains(current))
			{
				Console.Write("Treasure found!\n");
				treasureFound++;
				current.treasureAlreadyFound();
			}
			stack.Push(current);
			alreadyVisited.Push(current);
			Console.Write("Current: " + current.getX() + " " + current.getY() + "\n");

			if (m.isDownValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.getX() + 1, current.getY())))
			{
				Vertex down = m.getVertex(current.getX() + 1, current.getY());
				stack.Push(down);
				Console.WriteLine("Down: " + down.getX() + " " + down.getY());

				// Console.Write("Going down\n");
			}
			if (m.isRightValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.getX(), current.getY() + 1)))
			{
				Vertex right = m.getVertex(current.getX(), current.getY() + 1);
				stack.Push(right);

				// Console.Write("Going right\n");
			}
			if (m.isLeftValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.getX(), current.getY() - 1)))
			{
				Vertex left = m.getVertex(current.getX(), current.getY() - 1);
				stack.Push(left);

				// Console.Write("Going left\n");
			}
			if (m.isUpValid(current, m.getMap()) && !alreadyVisited.Contains(m.getVertex(current.getX() - 1, current.getY())))
			{
				Vertex up = m.getVertex(current.getX() - 1, current.getY());
				stack.Push(up);

				// Console.Write("Going up\n");
			}

			temp = stack.Pop(); 
			Console.Write("Temp: " + temp.getX() + " " + temp.getY() + "\n");

			if	(current.getX() + 1 == temp.getX() && current.getY() == temp.getY()){
				Console.Write("Going down\n");
				stack.Push(temp);
			} else if (current.getX() - 1 == temp.getX() && current.getY() == temp.getY()){
				Console.Write("Going up\n");
				stack.Push(temp);
			} else if (current.getX() == temp.getX() && current.getY() - 1 == temp.getY()){
				Console.Write("Going left\n");
				stack.Push(temp);
			} else if (current.getX() == temp.getX() && current.getY() + 1 == temp.getY()){
				Console.Write("Going right\n");
				stack.Push(temp);
			} else {
				Console.Write("Backtracking\n");
				Console.Write("		Current: " + current.getX() + " " + current.getY() + "\n");
				Console.Write("		Temp: " + temp.getX() + " " + temp.getY() + "\n");
			}
				

		}	
	}

	public void BFS()
	{

	}
	
}
