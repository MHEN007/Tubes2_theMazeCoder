// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Map map = new Map("config.txt");
Console.WriteLine("Map size: {0}x{1}", map.getMapX(), map.getMapY());
Console.WriteLine("Treasure count: {0}", map.getTreasureCount());
Console.WriteLine("Buffer size: {0} x {1}", map.getBuffer().GetLength(0), map.getBuffer().GetLength(1));
map.printBuffer();

Console.WriteLine("DFS");

Solver DFS = new Solver();
DFS.DFS();
