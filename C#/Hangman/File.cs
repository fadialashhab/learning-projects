class FileHandle {
	private string path;
	private long fileSize;
	public FileHandle(string p)
	{
		
		if (File.Exists(p))
		{
			fileSize = File.ReadLines(p).Count(); 
			path = p;
		}
		else
		{
			Console.WriteLine("FileHandle: constructer Error, the file does not exist");
			fileSize = 0;
			path = null;
		}

	}
	public long getFileSize() => fileSize;
	public string getLine(int lineNumber) { 
		if(path!=null && lineNumber<fileSize) 
			return File.ReadLines(path).Skip(lineNumber - 1).First();
		return "error";			
	}
}

