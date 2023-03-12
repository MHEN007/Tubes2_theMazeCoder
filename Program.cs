// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Map m = new Map("config.txt");
Vertex p = new Vertex(3, 3, false, false);
if (m.isDownValid(p, m.getMap())){
    Console.Write("Down is valid\n");
}

if (m.isRightValid(p, m.getMap())){
    Console.Write("Right is valid\n");
}

if (m.isLeftValid(p, m.getMap())){
    Console.Write("Left is valid\n");
}

if (m.isUpValid(p, m.getMap())){
    Console.Write("Up is valid\n");
}