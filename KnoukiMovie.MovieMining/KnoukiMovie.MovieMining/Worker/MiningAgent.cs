using System;
using System.IO;
using System.Windows.Forms;

namespace KnoukiMovie.MovieMining.Worker
{
	public class MiningAgent : IMiningAgent
	{

		public void StartMiningLocally(TextBox display)
		{
			string startPath = @"C:\Users\clefay";
			string searchFormat = "mp4";
			string[] oDirectories = Directory.GetFiles(startPath, "*." + searchFormat, SearchOption.AllDirectories);

			display.AppendText(String.Format("startPath {0}\n", startPath));
			display.AppendText(String.Format("search format {0}\n", searchFormat));
			display.AppendText(String.Format("Directory {0}\n", oDirectories));

			Console.WriteLine(String.Format("Start mining at : {0}\n", startPath));
			Console.WriteLine(oDirectories.Length.ToString());

			foreach (string oCurrent in oDirectories)
			{
				Console.WriteLine(oCurrent);
				display.AppendText("-" + oCurrent + "\n");
			}
			Console.ReadLine();
		}
	}
}
