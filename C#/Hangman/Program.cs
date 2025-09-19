using System;
using HangMan;
using System.IO;
namespace HangMan
{

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
						Console.WriteLine(@"
________
|      |
|       
|      
|       
|         
|__________");
						break;
					case 5:
						Console.WriteLine(@"
________
|      |
|      O    
|      
|       
|         
|__________");
						break;
					case 4:
						Console.WriteLine(@"
________
|      |
|      O    
|      |      
|       
|         
|__________");
						break;
					case 3:
						Console.WriteLine(@"
________
|      |
|      O    
|     /|    
|       
|         
|__________");
						break;
					case 2:
						Console.WriteLine(@"
________
|      |
|      O    
|     /|\\ 
|       
|         
|__________");
						break;
					case 1:
						Console.WriteLine(@"
________
|      |
|      O    
|     /|\\ 
|     / 
|         
|__________");
						break;
					case 0:
						Console.WriteLine(@"
________
|      |
|      O    
|     /|\\ 
|     / \\
|         
|__________");
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
			if (!string.IsNullOrEmpty(msg)) Console.WriteLine(msg);
			Console.WriteLine("##############################");
			Console.WriteLine("##############################");
			Console.WriteLine("          HangMan Game");
			Console.WriteLine("##############################\n\n");
			MyMan.DrawHangMan();
			Console.WriteLine("the Word:");
			Console.WriteLine(MyWord.getknownWord());
			Console.WriteLine("\nEnter a letter:");
		}
		public void DisplayGameOver()
		{
			Console.Clear();
			MyMan.DrawHangMan();
			Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░█▀▀░█▀█░█▄█░█▀▀░░░█▀█░█░█░█▀▀░█▀▄░░░░░░░░░
░░░░░░░░░░█░█░█▀█░█░█░█▀▀░░░█░█░▀▄▀░█▀▀░█▀▄░░░░░░░░░
░░░░░░░░░░▀▀▀░▀░▀░▀░▀░▀▀▀░░░▀▀▀░░▀░░▀▀▀░▀░▀░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                ");
		}
		public void DisplayWinner()
		{
			Console.WriteLine(@"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
         __        ___                       
         \ \      / (_)_ __  _ __   ___ _ __ 
          \ \ /\ / /| | '_ \| '_ \ / _ \ '__|
           \ V  V / | | | | | | | |  __/ |   
            \_/\_/  |_|_| |_|_| |_|\___|_|   

░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                ");
		}

	}

}
static class ChooseWord
{
	public static int randomNumber(int max_num)
	{
		Random random = new Random();
		return random.Next(1, max_num);
	}
	public static string getRandomWord()
	{

		string specificLine = File.ReadLines("../../../words.txt").Skip(randomNumber(860) - 1).First();
		return specificLine;
	}
}
class Program
{

	static void Main(string[] args)
	{
		GameManager game = new GameManager(ChooseWord.getRandomWord());
		game.PlayGame();

	}

}
