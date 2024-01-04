using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using log4net;
using ScintillaNET;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static log4net.Appender.ColoredConsoleAppender;

namespace TextDisplay
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        LogLineManager loglineManager; 
        public Form1()
        {
            
            log.Info("Initializing Components and markers"); 
            InitializeComponent();
            InitializeScintillaMarkers();
            loglineManager = new LogLineManager();
            scintilla.MouseClick += Scintilla_MouseClick;
            textBoxLineNum.KeyDown += Scintilla_KeyDown;
        }
        private void InitializeScintillaMarkers()
        {
            scintilla.Margins[0].Type = MarginType.RightText;
            scintilla.Margins[0].Width = 35;
            scintilla.Margins[0].Sensitive = true;

            scintilla.Margins[2].Sensitive = true; 
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.Control);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Lexer = Lexer.Cpp;
        }
        private void ReadInFile()
        {
            log.Info("Reading in file"); 
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = "log";
                openFileDialog.Filter = "Log files (*.log*)|*.log*|All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    writeOut(filePath); 
                    ReadToManager(filePath);
                    formatText();
                }
            }
            catch(Exception ex) 
            {
                log.Error("Couldn't open file dialog");
                log.Error(ex.ToString());
            }
            UpdateLineNumbers();
        }
        public void writeOut(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    scintilla.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                log.Error("Could not read in file");
                log.Error(ex.ToString());
            }
        }
        public void ReadToManager(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if ((line.Length < 1))
                        {
                            string msg = loglineManager.logLinesList[loglineManager.logLinesList.Count - 1].message;
                            msg += "\n\t" + line;
                            loglineManager.logLinesList[loglineManager.logLinesList.Count - 1].message = msg;
                            loglineManager.logLinesList[loglineManager.logLinesList.Count - 1].multiline = true;
                            loglineManager.logLinesList[loglineManager.logLinesList.Count - 1].NumberOfLines = loglineManager.logLinesList[loglineManager.logLinesList.Count - 1].NumberOfLines + 1;
                            continue;
                        }
                        loglineManager.AddLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Could not read in file");
                log.Error(ex.ToString());
            }
        }
        public void formatText()
        {
            log.Info("Formatting text");
            List<int[]> diagnostics = new List<int[]>();
            int numLines = 0;
            int diagCount = 0;
            foreach(LogLine log in loglineManager.logLinesList)
            {
                if (log.type.Equals(LogType.ERROR))
                {
                    HighlightWord(numLines, log.ToString().Length);
                }
                if (log.message.Contains("Started Diagnostic Test"))
                {
                    diagnostics.Add(new int[]{numLines, 0});
                }
                if (log.message.Contains("Completed Diagnostic Test Succesfully."))
                {
                    diagnostics[diagCount][1] = numLines - diagnostics[diagCount][0];
                    diagCount++;
                }
                if (log.multiline)
                {
                    Fold(numLines, log.NumberOfLines);
                    numLines += log.NumberOfLines;
                }
                if(!log.multiline)
                {
                    numLines++;
                }
            }
            foldUp(diagnostics); 
        }
        public void foldUp(List<int[]> folds)
        {
            log.Info("Foldingup"); 
            foreach (int[] fold in folds)
            {
                Fold(fold[0], fold[1]); 
            }
            scintilla.FoldAll(FoldAction.Contract);
        }
        public void Fold(int startLine, int numLines)
        {
            log.Info("Creating fold"); 
            scintilla.Lines[startLine].FoldLevelFlags = FoldLevelFlags.Header;
            var foldLevel = scintilla.Lines[startLine].FoldLevel;
            scintilla.Lines[startLine+1].FoldLevel = ++foldLevel;
            for (int i = 2; i <numLines; i++)
            {
                scintilla.Lines[startLine + i].FoldLevel = foldLevel;
            }
            scintilla.Lines[startLine + numLines].FoldLevel = --foldLevel;
        }
        private void HighlightWord(int start, int end)
        {
            log.Info("Highlighting lines"); try
            {
                int startPosition = scintilla.Lines[start].Position;
                scintilla.Lexer = Lexer.Null;
                scintilla.Styles[1].ForeColor = Color.Red;
                scintilla.StartStyling(startPosition);
                scintilla.SetStyling(end, 1);
            }
            catch(Exception e)
            {
                log.Error("Could not highlight");
                log.Error(e.Message); 
            }
        }
        private void scintilla_MarginClick(object sender, MarginClickEventArgs e)
        {
            log.Info("Clicked in margin"); 
            var line = scintilla.LineFromPosition(e.Position);
            scintilla.Lines[line].ToggleFold();
            textBoxLineNum.Text = "Line: "+ (line+1).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scintilla.ReadOnly = false;
            try
            {
                ReadInFile();
            }
            catch(Exception ex)
            {
                log.Error("Couldn't read in file");
                log.Error(ex.ToString());
            }
            scintilla.ReadOnly = true;
        }
        public void UpdateLineNumbers()
        {
            for (int i = 0; i < scintilla.Lines.Count; i++)
            {
                scintilla.Lines[i].MarginStyle = ScintillaNET.Style.LineNumber;
                scintilla.Lines[i].MarginText = (i + 1).ToString();
            }
        }
        private void Scintilla_MouseClick(object sender, MouseEventArgs e)
        {
            int leftMarginWidth = scintilla.Margins[0].Width; 
            int rightMarginWidth = scintilla.Margins[2].Width;
            if (e.X < leftMarginWidth || e.X > scintilla.Width - rightMarginWidth){}
            else
            {
                textBoxLineNum.Text = "Line: " + (scintilla.CurrentLine + 1).ToString();
            }
        }

        private void Scintilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string txt = textBoxLineNum.Text;
                int num = 0;
                if (int.TryParse(txt, out num))
                {
                    GoToLine(num);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number");
                }
            }
        }
        private void textBoxLineNum_TextChanged(object sender, EventArgs e)
        {
       
        }
        private void GoToLine(int lineNumber)
        {
            if(lineNumber > scintilla.Lines.Count)
            {
                MessageBox.Show("Number too high");
                return;
            }
            if (lineNumber <=0)
            {
                MessageBox.Show("Number too low");
                return; 
            }

            scintilla.LineScroll(scintilla.Top, 0);
            scintilla.LineScroll(lineNumber-1, 0); 
        }
    }
}