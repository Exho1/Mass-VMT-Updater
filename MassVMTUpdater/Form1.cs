using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassVMTUpdater
{
    public partial class Form1 : Form
    {

        string[] folderContents;
        int completedCount = 0;
        int failedCount = 0;
        int fileCount = 0;
        string pathDivider;
        string logPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            completedCount = 0;
            failedCount = 0;
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.ShowDialog();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            completedCount = 1;
            failedCount = 0;
            directoryIterate(folderContents);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tmrWaitForDirectory.Start();

            dlgFolderBrowser.SelectedPath = "";
            btnOpenDialog.Text = "Select Directory";

            if (logPath != null)
            {
                File.WriteAllText(logPath, "");
            }
            txtDebug.Text = "Debug";
        }

        private void tmrWaitForDirectory_Tick(object sender, EventArgs e)
        {
            // Make sure a valid path is selected
            // Hacky workaround because the folder browser doesnt have an event for when a folder is selected
            if (dlgFolderBrowser.SelectedPath != "")
            {
                tmrWaitForDirectory.Stop();

                btnOpenDialog.Text = "Selected!";

                pathDivider = txtPathDivider.Text;
                pathDivider = pathDivider.Replace("/", "");

                folderContents = Directory.GetFiles(dlgFolderBrowser.SelectedPath, "*.vmt", SearchOption.AllDirectories);
                fileCount = folderContents.GetUpperBound(0) + 1;

                debugPrint("Found " + fileCount + " files.");
                debugPrint(dlgFolderBrowser.SelectedPath);
            }
        }

        public void directoryIterate( string[] contents )
        {
            // Get the location of the .exe file
            string programLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            int index = programLocation.LastIndexOf("\\") + 1;
            programLocation = programLocation.Substring(0, index);

            // Format it correctly
            string backslash = "\\";
            string forwardslash = "/";
            programLocation = programLocation.Replace(backslash[0], forwardslash[0]);

            logPath = programLocation + "log.txt";

            // Create a log.txt file
            File.WriteAllText(logPath, "Mass VMT Updater: " + Environment.NewLine);

            // Edit each file
            foreach( string path in contents )
            {
                if (File.Exists(path))
                {
                    logPrint("Editing " + path);
                    editVMT( path );
                }
                else
                {
                    debugPrint("Invalid path: " + path);
                    failedCount++;
                }
            }
        }

        // Modifies the VMT to update the $basetexture path to where the file currently is
        public void editVMT(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string vmtContents = "";

                    int counter = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Recreate the vmt's contents line by line
                        if (vmtContents != "")
                        {
                            vmtContents = vmtContents + Environment.NewLine + line;
                        }
                        else
                        {
                            vmtContents = vmtContents + line;
                        }

                        string lowerLine = line.ToLower();
                        if (lowerLine.Contains("$basetexture"))
                        {
                            // 13 = 12 characters for $basetexture + 1 because 0 indexing
                            int index = lowerLine.IndexOf("$basetexture") + 13;
                            string texturePath = line.Substring(index);
                            texturePath = texturePath.Trim();

                            // Divide the line where the basetexture path starts
                            int dividerIndex = path.IndexOf(pathDivider) + pathDivider.Length;
                            string newPath = path.Substring(dividerIndex);

                            // Stupid hack to trim back slashes from the file path and replace them with forward slashes (when applicable)
                            string backslash = "\\";
                            string forwardslash = "/";
                            newPath = newPath.TrimStart(backslash[0]);
                            newPath = newPath.Replace(backslash[0], forwardslash[0]);

                            // Make sure the path fits the VMT format
                            newPath = '"' + newPath + '"';
                            newPath = newPath.Replace(".vmt", "");

                            // Replace the old path with our new one
                            vmtContents = vmtContents.Replace(texturePath, newPath);

                            debugPrint("Updated " + Path.GetFileName(path) + "! " + completedCount.ToString() + "/" + fileCount.ToString());
                            completedCount++;

                            if (fileCount < completedCount) {
                                completedCount -= 1;

                                debugPrint("----");
                                debugPrint("Finshed updating VMT files!");
                                debugPrint("Completed: " + completedCount.ToString());
                                debugPrint("Failed: " + failedCount.ToString());
                                debugPrint("----");
                                break;
                            }
                        }
                        counter++;
                    }

                    // Close stream reader so we can write
                    sr.Close();

                    // Write new contents
                    File.WriteAllText(path, vmtContents);
                    logPrint("Finished writing file (" + Path.GetFileName(path) + ")");
                }
            }
            catch (Exception e)
            {
                debugPrint("The file (" + Path.GetFileName(path) + ") could not be read:");
                debugPrint(e.Message);
                failedCount++;
            }
        }

        // Appends the message to the text box
        public void debugPrint( string msg )
        {
            txtDebug.AppendText(Environment.NewLine + msg);

            if (File.Exists(logPath))
            {
                File.AppendAllText(logPath, msg + Environment.NewLine);
            }
        }

        public void logPrint(string msg)
        {
            if (File.Exists(logPath))
            {
                File.AppendAllText(logPath, msg + Environment.NewLine);
            }
        }
    }
}
