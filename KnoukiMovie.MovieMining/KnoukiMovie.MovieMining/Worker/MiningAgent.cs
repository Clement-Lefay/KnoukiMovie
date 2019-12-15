using KnoukiMovie.MovieMining.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnoukiMovie.MovieMining.Worker
{
	public class MiningAgent : IMiningAgent
	{

		/**
		 * Step to do
		 * 1. search all hardDrive as startPath
		 * 2. search all files that match the format
		 * 3. retrieve all information about those files
		 * 4. store it in a file (JSON format)
		 * 5. with a movie DB (IMDB for instance), math movie content and update/correct it
		 *
		 * */

		/// <summary>
		/// Retrieve all files that match the searched format and display it on the screens.
		/// - find all reachable files
		/// - display the result
		/// </summary>
		/// <param name="display"></param>
		public void StartMiningLocally(TextBox display)
		{
			// was working
			//firstTry(display);

			// second try that didn't work
			//secondTry(display);

			// Trird try
			thirdTry(display);

		}

		private void firstTry(TextBox display)
		{
			// first try
			string startPath = @"C:\Users";
			display.AppendText(String.Format("startPath {0}\n", startPath));

			display.AppendText("Searching available files\n");
			List<string> accessibleFiles = GetAllAccessibleFiles(startPath);
			display.AppendText(string.Format("Search complet. {0} files can be reached\n", accessibleFiles.Count));

			accessibleFiles.ForEach((file) => {
				display.AppendText(string.Format("{0}\n", file));
			});

			display.AppendText("Done\n");
		}

		/// <summary>
		/// Don't remember if it works ^^
		/// </summary>
		/// <param name="display"></param>
		private void secondTry(TextBox display)
		{
			display.AppendText("search everywhere\n");
			string searchedFormat = "*.mp4";
			List<string> accessibleFiles = SearchFiles(searchedFormat);
			display.AppendText("search complet\n");
			foreach (var files in accessibleFiles)
			{
				display.AppendText(files);
			}
			display.AppendText("done");
		}


		private void thirdTry(TextBox display)
		{
			List<string> driveNameList = searchAllDriveName();

			display.AppendText(string.Format("result - number of drive found {0}.\n", driveNameList.Count));
			foreach (var drive in driveNameList)
			{
				display.AppendText(drive + "\n");

				string startPath = string.Format(@"{0}", drive);
				display.AppendText(string.Format("startPath {0}\n", startPath));

				display.AppendText("Searching available files\n");
				List<string> accessibleFiles = GetAllAccessibleFiles(startPath);
				display.AppendText(string.Format("Search complet. {0} files can be reached\n", accessibleFiles.Count));

				accessibleFiles.ForEach((file) => {
					display.AppendText(string.Format("{0}\n", file));
				});
			}





			display.AppendText("Done\n");

		}


		// got to  improve it with a do loop so it will not stops at each exception/noAccess and keep going
		private List<string> GetAllAccessibleFiles(string rootPath, List<string> alreadyFound = null)
		{
			if (alreadyFound == null)
				alreadyFound = new List<string>();
			DirectoryInfo di = new DirectoryInfo(rootPath);
			var dirs = di.EnumerateDirectories();
			foreach (DirectoryInfo dir in dirs)
			{
				if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
				{
					alreadyFound = GetAllAccessibleFiles(dir.FullName, alreadyFound);
				}
			}

			string[] movieFormat = Enum.GetNames(typeof(MovieFormat));

			foreach (var format in movieFormat)
			{
				var files = Directory.GetFiles(rootPath, string.Format("*.{0}",format));
				foreach (string s in files)
				{
					alreadyFound.Add(s);
				}
			}

			return alreadyFound;
		}

		private List<string> searchAllDriveName()
		{
			int i = 0;
			List<string> driveList = new List<string>();
			DriveInfo[] TotalDrives = DriveInfo.GetDrives();

			foreach (DriveInfo drvinfo in TotalDrives)
			{
				if(drvinfo.DriveType == DriveType.Fixed || drvinfo.DriveType == DriveType.Removable)
				{
					driveList.Add(drvinfo.Name);
					i++;
				}
			}

			return driveList;
		}



		static List<string> SearchFiles(string pattern)
		{
			var result = new List<string>();
			// got to try how long it runs
			foreach (string drive in Directory.GetLogicalDrives())
			{
				var watch = System.Diagnostics.Stopwatch.StartNew();

				Console.WriteLine("searching " + drive);
				var files = FindAccessableFiles(drive, pattern, true);
				Console.WriteLine(files.Count().ToString() + " files found.");
				result.AddRange(files);

				watch.Stop();
				Console.WriteLine(String.Format("Time elapsed: {0}ms", watch.ElapsedMilliseconds));
			}

			return result;
		}

		private static IEnumerable<String> FindAccessableFiles(string path, string file_pattern, bool recurse)
		{
			//Console.WriteLine(path);
			var list = new List<string>();
			var required_extension = "mp4";

			if (File.Exists(path))
			{
				yield return path;
				yield break;
			}

			if (!Directory.Exists(path))
			{
				yield break;
			}

			if (null == file_pattern)
				file_pattern = "*." + required_extension;

			var top_directory = new DirectoryInfo(path);

			// Enumerate the files just in the top directory.
			IEnumerator<FileInfo> files;
			try
			{
				files = top_directory.EnumerateFiles(file_pattern).GetEnumerator();
			}
			catch (Exception ex)
			{
				files = null;
			}

			while (true)
			{
				FileInfo file = null;
				try
				{
					if (files != null && files.MoveNext())
						file = files.Current;
					else
						break;
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				catch (PathTooLongException)
				{
					continue;
				}

				yield return file.FullName;
			}

			if (!recurse)
				yield break;

			IEnumerator<DirectoryInfo> dirs;
			try
			{
				dirs = top_directory.EnumerateDirectories("*").GetEnumerator();
			}
			catch (Exception ex)
			{
				dirs = null;
			}


			while (true)
			{
				DirectoryInfo dir = null;
				try
				{
					if (dirs != null && dirs.MoveNext())
						dir = dirs.Current;
					else
						break;
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				catch (PathTooLongException)
				{
					continue;
				}

				foreach (var subpath in FindAccessableFiles(dir.FullName, file_pattern, recurse))
					yield return subpath;
			}
		}
	}
}
