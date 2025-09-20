class Word
{
	private char[] wordcharacters;
	private char[] Knowncharacters;
	private int wordLength;
	public Word(string word)
	{
		if (string.IsNullOrEmpty(word))
		{
			wordLength = 0;
			wordcharacters = new char[wordLength];
			Knowncharacters = new char[wordLength];
			Console.WriteLine("Word_class: constructer Error, the chosen world is empty or null");
			return;
		}
		wordLength = word.Length;
		wordcharacters = new char[wordLength];
		Knowncharacters = new char[wordLength];
		for (int i = 0; i < wordLength; i++)
		{
			wordcharacters[i] = word[i];
			Knowncharacters[i] = '_';
		}
	}

	public bool FindCharInWord(char c)
	{
		bool correctChar = false;
		for (int i = 0; i < wordLength; i++)
		{
			if (wordcharacters[i] == c)
			{
				Knowncharacters[i] = c;
				correctChar = true;
			}
		}
		return correctChar;
	}
	public string getknownWord() => string.Join(" | ", Knowncharacters);
	public string getWord() => string.Join("", wordcharacters);
	public bool isWordDone() => !Knowncharacters.Contains('_');
}