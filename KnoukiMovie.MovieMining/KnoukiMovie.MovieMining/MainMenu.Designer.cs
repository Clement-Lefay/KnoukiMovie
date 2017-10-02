namespace KnoukiMovie.MovieMining
{
	partial class MainMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button_StartMining = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Button_Quit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// Button_StartMining
			//
			this.Button_StartMining.Location = new System.Drawing.Point(47, 12);
			this.Button_StartMining.Name = "Button_StartMining";
			this.Button_StartMining.Size = new System.Drawing.Size(163, 23);
			this.Button_StartMining.TabIndex = 0;
			this.Button_StartMining.Text = "Start Mining";
			this.Button_StartMining.UseVisualStyleBackColor = true;
			this.Button_StartMining.Click += new System.EventHandler(this.ButtonMining_Click);
			//
			// textBox1
			//
			this.textBox1.Location = new System.Drawing.Point(12, 98);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(873, 200);
			this.textBox1.TabIndex = 1;
			//
			// Button_Quit
			//
			this.Button_Quit.Location = new System.Drawing.Point(743, 33);
			this.Button_Quit.Name = "Button_Quit";
			this.Button_Quit.Size = new System.Drawing.Size(75, 23);
			this.Button_Quit.TabIndex = 2;
			this.Button_Quit.Text = "Quit";
			this.Button_Quit.UseVisualStyleBackColor = true;
			this.Button_Quit.Click += new System.EventHandler(this.ButtonQuit_Click);
			//
			// MainMenu
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 338);
			this.Controls.Add(this.Button_Quit);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Button_StartMining);
			this.Name = "MainMenu";
			this.Text = "Movie Mining";
			this.Load += new System.EventHandler(this.MainMenu_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Button_StartMining;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button Button_Quit;
	}
}

