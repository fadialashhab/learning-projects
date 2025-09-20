using System;
using System.IO;
class Program
{

	static void Main(string[] args)
	{
		FileHandle file = new FileHandle("../../../words.txt");
		GameManager game = new GameManager(file.getLine(100));
		game.PlayGame();

	}

}
