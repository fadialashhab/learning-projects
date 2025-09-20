
class Man
{
	public int tries;
	private const int MaxTries = 6;
	public Man()
	{
		tries = MaxTries;
	}
	public void DrawHangMan()
	{
		if (tries > 0)
		{
			switch (tries)
			{

				case 6:
					Console.WriteLine(Drawings.hangman[0]);
					break;
				case 5:
					Console.WriteLine(Drawings.hangman[1]);
					break;
				case 4:
					Console.WriteLine(Drawings.hangman[2]);
					break;
				case 3:
					Console.WriteLine(Drawings.hangman[3]);
					break;
				case 2:
					Console.WriteLine(Drawings.hangman[4]);
					break;
				case 1:
					Console.WriteLine(Drawings.hangman[5]);
					break;
				case 0:
					Console.WriteLine(Drawings.hangman[6]);
					break;
			}
		}

	}
	public bool isOver() => tries <= 0;
	public int getTries() => tries;
	public void decreaseTries()
	{
		tries--;
	}
}