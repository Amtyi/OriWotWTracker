using System;


class Program
{
    public string OldFileContents;
        
    static void Main()
    {
        // Start the filewatcher 
        Watcher.Run();

        // Wait for the user to quit the program.
        Console.WriteLine("Press 'q' to quit the sample.");
        while (Console.Read() != 'q') ;
    }
}
