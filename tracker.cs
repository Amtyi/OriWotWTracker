// Program.cs
class Program
{
	[STAThread]
    static void Main()
    {
        GameState model = new GameState();
        TrackerWindow view = new TrackerWindow();
        Controler controler = new Controler(model, view);

        FileWatcher Watcher = new FileWatcher(controler);

        Watcher.Run();

        Application app = new Application();
        app.Run(view);
    }
}




//GameState.cs
public class GameState
{
	public bool HasBash = false;
	public bool HasSword = false;
	[...]
	public bool HasLaunch = false;
	public bool HasWater = false;
	public bool HasVoiceWisp = false;

	public int SLCount = 0;
	public int OreCount = 0;
}



//Controler.cs
public class Controler
{
	private GameState Model;
	private TrackerWindow View;

	private string bashObtainPath = "C:/bash.png";
  	private string bashNotObtainPath= "C:/bashObtained.png";

	public Controler(GameState model, TrackerWindow view)
	{
		Model = model;
		View = view;
	}

	public ClickedOnBash() //manual tracking, called when player click on the bash image
	{
		Model.HasBash = !Model.HasBash; // If player don't have bash -> give it and if he don't -> remove it 
	    UpdateBash(Model.HasBash);
	}

	public UpdateBash(bool state)
	{
		Model.HasBash = state;
		if(state)
		{
		  View.Bash.Source = bashObtainPath;
		}
		else{
		  View.Bash.Source = bashNotObtainPath;
		}
  	}

  	public UpdateOre(int count)
  	{
  		Model.OreCount=count;
  		View.GorlekOre_amount.Text = count.ToString();
  	}
}



//FileWatcher.cs
public class FileWatcher
{
	private Controler controler;

	public FileWatcher(Controler Controler)
	{
		controler = Controler;
	}

	ParseChanges()
	{
		if(bash changed)
		{
			controler.UpdateBash(bash state);
		}
		if(ore changed)
		{
			Controler.UpdateOre(ore count);
		}
	}
}