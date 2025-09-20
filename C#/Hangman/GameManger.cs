class GameManager
{
	private Word MyWord;
	private Man MyMan;
	public GameManager(string word)
	{
		MyWord = new Word(word);
		MyMan = new Man();
	}
	public void PlayGame()
	{
		DisplayGameStatus("");
		while (true)
		{
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input) || input.Length > 1)
			{
				DisplayGameStatus("ERORR: Please Enter Valid Input");
				continue;
			}
			if (MyWord.FindCharInWord(char.ToLower(input[0])))
			{
				if (!MyWord.isWordDone())
				{
					DisplayGameStatus($"GOOD GEUSS, {input[0]} is in the word");
				}
				else
				{
					DisplayWinner();
					break;
				}
			}
			else
			{
				MyMan.decreaseTries();
				if (!MyMan.isOver())
				{
					DisplayGameStatus($"Oops it's wrong guess, {input[0]} isn't in the word");
				}
				else
				{
					DisplayGameOver();
					break;
				}
			}
		}

	}
	public void DisplayGameStatus(string msg)
	{
		Console.Clear();
		Console.WriteLine(Drawings.header);
		if (!string.IsNullOrEmpty(msg)) Console.WriteLine(msg);
		MyMan.DrawHangMan();
		Console.WriteLine("the Word:");
		Console.WriteLine(MyWord.getknownWord());
		Console.WriteLine("\nEnter a letter:");
	}
	public void DisplayGameOver()
	{
		Console.Clear();
		MyMan.DrawHangMan();
		Console.WriteLine(Drawings.end[0]);
		Console.WriteLine(MyWord.getWord());

	}
	public void DisplayWinner()
	{
		Console.WriteLine(Drawings.end[1]);
	}

}


