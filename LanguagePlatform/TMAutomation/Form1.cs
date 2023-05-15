using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Sdl.SDK.LanguagePlatform.TMAutomation
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void B_Start_Click(object sender, EventArgs e)
		{
			tb_Results.Text = "";
			BackgroundWorker worker = new BackgroundWorker();

			worker.DoWork += delegate (object source, DoWorkEventArgs workArgs)
			{
				if (rb_file.Checked)
				{
					RoundtripFileBased();
				}
				else
				{
					RoundtripServerBased();
				}

			};

			worker.RunWorkerAsync();
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			MessageBox.Show("Roundtrip finished.");
		}

		private void RoundtripServerBased()
		{
			ServerBasedTMHelper serverBasedHelper = new ServerBasedTMHelper(tb_Results);
			UpdateResult("Listing all DB servers: \r\n");
			serverBasedHelper.GetAllDBServers();
			UpdateResult("Listing all containers in all DB servers: \r\n");
			serverBasedHelper.GetAllContainers();
			UpdateResult("Listing all TMs in all containers on all DB servers: \r\n");
			serverBasedHelper.GetAllTMs();

			UpdateResult("Create a new TM in new testing container: \r\n");
			serverBasedHelper.CreateNewTM();

			UpdateResult("Scheduled TM import: \r\n");
			serverBasedHelper.ImportTMX("WorkbenchFlavor.tmx");

			UpdateResult("Delete the TM: \r\n");
			serverBasedHelper.DeleteTM();
			UpdateResult("Delete the container: \r\n");
			serverBasedHelper.DeleteContainer();
			UpdateResult("Delete the language resource template: \r\n");
			serverBasedHelper.DeleteLanguageTemplate();
		}

		private void RoundtripFileBased()
		{
			if (string.IsNullOrWhiteSpace(tb_output.Text) || !Directory.Exists(tb_output.Text))
			{
				return;
			}

			FileBasedTMHelper fileBasedHelper = new FileBasedTMHelper(tb_Results);

			string tmPath = tb_output.Text + @"SDKTest.sdltm";

			tb_Results.Text = "";

			if (File.Exists(tmPath))
			{
				File.Delete(tmPath);
				UpdateResult("Old TM deleted\r\n");
			}

			UpdateResult("TM creation: \r\n");
			fileBasedHelper.CreateNewFileBasedTM(tmPath);
			UpdateResult("TMX import: \r\n");
			fileBasedHelper.ImportTMXFile(tmPath, "WorkbenchFlavor.tmx");
			UpdateResult("SDL XLIFF import: \r\n");
			fileBasedHelper.ImportSDLXLIFFFile(tmPath, "SamplePhotoPrinter.doc.sdlxliff");
			UpdateResult("TM lookup: \r\n");
			fileBasedHelper.SearchForTU(tmPath, "This is a simple test.");
			UpdateResult("Add new TU: \r\n");
			fileBasedHelper.AddTU(tmPath);
			UpdateResult("Adapt existing TU: \r\n");
			fileBasedHelper.AdaptTU(tmPath, "This is a simple test.", "This is a changed simple test.");
			UpdateResult("Create new TU and delete it at once: \r\n");
			fileBasedHelper.DeleteTU(tmPath);
			UpdateResult("TM export: \r\n");
			fileBasedHelper.ExportTMXFile(tmPath, tmPath + @"first_exported.tmx");
			UpdateResult("Set password protection: \r\n");
			fileBasedHelper.SetTMPassword(tmPath);
			UpdateResult("Open password protected TM: \r\n");
			fileBasedHelper.OpenProtectedTM(tmPath);
			UpdateResult("Roundrip finished.\r\n");
		}

		public delegate void UpdateResultDelegate(string progress);

		public void UpdateResult(string progress)
		{
			//If not on UI thread
			if (tb_Results.InvokeRequired)
			{
				tb_Results.Invoke(new UpdateResultDelegate(UpdateResult), new object[] { progress });
			}
			else
			{
				//Do work here - called on UI thread
				tb_Results.Text += progress;
				tb_Results.Refresh();
			}
		}

		private void Rb_file_CheckedChanged(object sender, EventArgs e)
		{
			if (rb_file.Checked)
			{
				tb_output.Enabled = true;
				b_Browse.Enabled = true;
			}
			else
			{
				tb_output.Enabled = false;
				b_Browse.Enabled = false;
			}
		}

		private void B_Browse_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				tb_output.Text = folderBrowserDialog1.SelectedPath + Path.DirectorySeparatorChar;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			tb_output.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;
		}
	}
}