using System;
using Mirea_Andreea_Proiect.Data;
using System.IO;

namespace Mirea_Andreea_Proiect;

public partial class App : Application
{
	static Database database;
	
	public static Database Database
	{
		get
		{
			if (database == null)
			{
				database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SecretList.db3"));
			}
			return database;
		}
	}

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

}