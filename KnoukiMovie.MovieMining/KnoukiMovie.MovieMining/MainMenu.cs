using System;
using System.Windows.Forms;
using KnoukiMovie.MovieMining.Worker;

namespace KnoukiMovie.MovieMining
{
	public partial class MainMenu : Form
	{

		private readonly IMiningAgent _mining;

		public MainMenu()
		{
			InitializeComponent();
			_mining = new MiningAgent();
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{
			textBox1.AppendText("start app\n");

		}

		private void ButtonMining_Click(object sender, EventArgs e)
		{
			Button_StartMining.Enabled = false;
			try
			{
				string message = "click button\n";
				Console.WriteLine(message);
				textBox1.AppendText(message);

				_mining.StartMiningLocally(textBox1);
			}
			catch (Exception ex)
			{
				string message = String.Format("Something got wrong : {0}\n", ex.Message);

				textBox1.AppendText(message);
				Console.WriteLine(message);
			}
			Button_StartMining.Enabled = true;
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			if (Button_StartMining.Enabled)
			{
				this.Close();
			}
		}
	}
}
