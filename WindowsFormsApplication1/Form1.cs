using System;
using System.Linq;
using System.Windows.Forms;
//using w = Microsoft.Office.Interop.Word;
//using p = Microsoft.Office.Interop.PowerPoint;

using Aspose.Words;

using System.IO;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //protected Microsoft.Office.Interop.Word.Application word;
        //protected Microsoft.Office.Interop.PowerPoint.Application powerpoint;
        //protected object oMissing = System.Reflection.Missing.Value;

        String inDir = @"D:\_ДО";
        String outDir = @"D:\_ДО_TEST";
        String htmlTree;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < taskList.Items.Count; i++ ) taskList.SetItemChecked(i, true);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //STEP 0: Проверка
            if (String.IsNullOrWhiteSpace(txtSource.Text))
            {
                MessageBox.Show("Не указана исходная папка!");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtDest.Text))
            {
                MessageBox.Show("Не указана целевая папка!");
                return;
            }

            inDir = txtSource.Text;
            outDir = txtDest.Text;

            //STEP 1: Очистка целевой папки
            if (taskList.GetItemChecked(0))
            {
                emptyDir(outDir);
            }

            //STEP 2: Преобразование в PDF
            if (taskList.GetItemChecked(1))
            {


                button1.Visible = false;
                button2.Visible = false;
                progressBar1.Visible = true;

                //word = new Microsoft.Office.Interop.Word.Application();
                //powerpoint = new Microsoft.Office.Interop.PowerPoint.Application();

                DirectoryInfo dirInfo = new DirectoryInfo(inDir);
                FileInfo[] wordFiles = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

                progressBar1.Maximum = wordFiles.Count();

                //word.Visible = false;
                //word.ScreenUpdating = false;
                //            powerpoint.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;


                var count = wordFiles.Count();

                var i = 0;

                label1.Text = "";
                label1.Visible = true;


                foreach (FileInfo wordFile in wordFiles)
                {
                    try
                    {
                        try
                        {

                            Directory.CreateDirectory(wordFile.DirectoryName.Replace(inDir, outDir));
                        }
                        catch (Exception ex) { ; }

                        if (wordFile.Name.StartsWith("~"))
                        {
                            continue;
                        }

                        if (wordFile.Extension.ToLower() == ".doc" || wordFile.Extension.ToLower() == ".docx" || wordFile.Extension.ToLower() == ".rtf")
                        {
                            DocToPdf(wordFile);
                        }
                        /*else if (wordFile.Extension.ToLower() == ".ppt" || wordFile.Extension.ToLower() == ".pptx" || wordFile.Extension.ToLower() == ".pps" || wordFile.Extension.ToLower() == ".ppsx")
                        {
                            PptToPdf(wordFile);
                        }*/
                        else if (wordFile.Extension.ToLower() != ".db")
                        {
                            //Подшаг 2.1 Копируем непреобразованный хлам
                            if (taskList.GetItemChecked(2))
                            {
                                File.Copy(wordFile.FullName, wordFile.FullName.Replace(inDir, outDir));
                            }
                        }

                        progressBar1.Value = ++i;
                        label1.Text = String.Format("Готово {0} из {1}", i.ToString(), count.ToString());
                        System.Windows.Forms.Application.DoEvents();



                    }
                    catch (Exception error)
                    {
                        ;
                    }


                }

                //((w._Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
                //word = null;
                //powerpoint.Quit();
                //powerpoint = null;

            }

            if (taskList.GetItemChecked(3))
            {
                CreateMenu(outDir);

                var dirs = Directory.GetDirectories(outDir);
                foreach (var dir in dirs)
                {
                    CreateMenu(dir);
                }
            }

            button1.Visible = true;
            button2.Visible = true;
            progressBar1.Visible = false;
        }

        protected void DocToPdf(FileInfo wordFile)
        {
            var document = new Document(wordFile.FullName);

            document.Save(wordFile.FullName.Replace(wordFile.Extension, ".pdf").Replace(inDir, outDir), SaveFormat.Pdf);

            /*Object filename = (Object)wordFile.FullName;

            w.Document doc = word.Documents.Open(ref filename, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            doc.Activate();

            object outputFileName = wordFile.FullName.Replace(wordFile.Extension, ".pdf").Replace(inDir, outDir);
            object fileFormat = w.WdSaveFormat.wdFormatPDF;

            // Save document into PDF Format
            doc.SaveAs(ref outputFileName,
                ref fileFormat, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            object saveChanges = w.WdSaveOptions.wdDoNotSaveChanges;
            ((w._Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
            doc = null;*/
        }

        protected void PptToPdf(FileInfo pptFile)
        {
            /*String filename = pptFile.FullName;
            p.Presentation ppt = powerpoint.Presentations.Open(filename);
            powerpoint.Activate();

            String outputFileName = pptFile.FullName.Replace(pptFile.Extension, ".pdf").Replace(".pptx", ".pdf").Replace(inDir, outDir);
            ppt.SaveAs(outputFileName, p.PpSaveAsFileType.ppSaveAsPDF);

            ppt.Close();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        protected void CreateMenu(string rootFolder)
        {
            if (rootFolder.Contains(@"\menu")) return;

            htmlTree = "";

            outDir = rootFolder;

            var dirs = Directory.GetDirectories(outDir);
            foreach (var dir in dirs)
            {
                if(dir.Replace(outDir, "") != @"\menu")
                    WalkDirectoryTree(new DirectoryInfo(dir));
            }
            var files = Directory.GetFiles(outDir);

            var currentDir = new DirectoryInfo(outDir);

            if (currentDir.GetFiles().Count() > 0)
            {
                htmlTree += "<ul>";
                foreach (System.IO.FileInfo fi in currentDir.GetFiles())
                {
                    htmlTree += "<li><span class='file'><a href='" + fi.FullName.Replace(outDir + @"\", @"../").Replace(@"\", @"/") + "' target='mainFrame'>" + fi.Name.Replace(fi.Extension, "") + "</a></span></li>";
                }
                htmlTree += "</ul>";
            }

            CopyFolder(@"menu_template", outDir + @"\menu");

            var template = File.ReadAllText(@"menu_template\menu.html");

            template = template.Replace("{tree}", htmlTree.Substring(4).Replace(@"</ul><ul>", @"</ul><ul class='filetree treeview-famfamfam'>"));
            template = template.Replace("{title}", currentDir.Name);
           

            File.WriteAllText(outDir + @"\menu\menu.html", template);
        }

        protected void CopyFolder(string source, string target)
        {
            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);

            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(target, name);
                File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(source);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(target, name);
                CopyFolder(folder, dest);
            }
        }

        //Спасибо примерам из MSDN за то, что не заставляют нас думать =)
        private void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {

            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            htmlTree += "<ul><li><span class='folder'>" + root.Name + "</span>";

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (Exception e)
            {
                ;
                
            }

            if (files != null)
            {

                htmlTree += "<ul>";

                foreach (System.IO.FileInfo fi in files)
                {
                    htmlTree += "<li><span class='file'><a href='" + fi.FullName.Replace(outDir +@"\", @"../").Replace(@"\", @"/") + "' target='mainFrame'>" + fi.Name.Replace(fi.Extension, "") + "</a></span></li>";
                }

                htmlTree += "</ul>";

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    if (dirInfo.Name == "menu") continue; 
                    WalkDirectoryTree(dirInfo);
                }

                
            }
            htmlTree += "</li></ul>";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSource.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDest.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        protected void emptyDir(string dirPath)
        {
            System.IO.DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }

        }
    }
}
