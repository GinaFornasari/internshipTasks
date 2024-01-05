using Microsoft.VisualBasic.Logging;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace LiveCharts2Demo.LogView
{
    public partial class LogViewForm : Form
    {
        LogLineManager loglineManager;
        public LogViewForm()
        {
            InitializeComponent();
            InitializeScintillaMarkers();
            loglineManager = new LogLineManager();
            scintilla.MouseClick += Scintilla_MouseClick;
            scintilla.MarginClick += scintilla_MarginClick; 
            textBoxLineNum.KeyDown += Scintilla_KeyDown;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            scintilla.ReadOnly = false;
            try
            {
                ReadInFile();
               
            }
            catch (Exception ex)
            {
                //log.Error("Couldn't read in file");
                //log.Error(ex.ToString());
            }
            scintilla.ReadOnly = true;
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
            //scintilla.Lexer = Lexer.Cpp;
        }
        private void ReadInFile()
        {
            //log.Info("Reading in file");
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
            catch (Exception ex)
            {
               // log.Error("Couldn't open file dialog");
               // log.Error(ex.ToString());
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
                //log.Error("Could not read in file");
               // log.Error(ex.ToString());
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
               // log.Error("Could not read in file");
               // log.Error(ex.ToString());
            }
        }
        public void formatText()
        {
            List<RunTime> diagnostics = new List<RunTime>();
            List<RunTime> sessions = new List<RunTime>();
            int numLines = 0;
            int diagCount = 0;
            int sessionCount = 0;
            foreach (LogLine log in loglineManager.logLinesList)
            {
                if (log.type.Equals(LogType.ERROR))
                {
                    HighlightWord(numLines, log.ToString().Length, Color.Red);
                }
                if (log.message.Contains("Started Diagnostic Test"))
                {
                    diagnostics.Add(new RunTime(numLines, RunType.Diagnosic)); 
                    HighlightWord(numLines, log.ToString().Length, Color.Green);
                }
                if (log.message.Contains("Completed Diagnostic Test Succesfully."))
                {
                    diagnostics[diagCount].AddEnd(numLines);
                    diagCount++;
                }
                if (log.message.Contains("App Starting..."))
                {
                    sessions.Add(new RunTime(numLines, RunType.Session));
                    HighlightWord(numLines, log.ToString().Length, Color.Blue);
                    
                }
                if (log.message.Contains("App Ended."))
                {
                    sessions[sessionCount].AddEnd(numLines);
                    sessionCount++;
                }
                if (log.multiline)
                {
                    Fold(numLines, log.NumberOfLines);
                    numLines += log.NumberOfLines;
                }
                if (!log.multiline)
                {
                    numLines++;
                }
            }
            foldUp(diagnostics);
            foldUp(sessions);
        }
        public void foldUp(List<RunTime> folds)
        {
           // log.Info("Foldingup");
            foreach (var fold in folds)
            {
                Fold(fold.start, fold.end - fold.start);
            }
            scintilla.FoldAll(FoldAction.Contract);
        }
        public void Fold(int startLine, int numLines)
        {
           // log.Info("Creating fold");
            scintilla.Lines[startLine].FoldLevelFlags = FoldLevelFlags.Header;
            var foldLevel = scintilla.Lines[startLine].FoldLevel;
            scintilla.Lines[startLine + 1].FoldLevel = ++foldLevel;
            for (int i = 2; i < numLines; i++)
            {
                scintilla.Lines[startLine + i].FoldLevel = foldLevel;
            }
            scintilla.Lines[startLine + numLines].FoldLevel = --foldLevel;
        }
        private void HighlightWord(int start, int end, Color color)
        {
           //log.Info("Highlighting lines");
           try
            {
                int startPosition = scintilla.Lines[start].Position;
                //scintilla.Lexer = Lexer.Null;
                scintilla.Styles[1].ForeColor = color;
                scintilla.StartStyling(startPosition);
                scintilla.SetStyling(end, 1);
            }
            catch (Exception e)
            {
                //log.Error("Could not highlight");
                //log.Error(e.Message);
            }
        }

        private void scintilla_MarginClick(object sender, MarginClickEventArgs e)
        {
            //log.Info("Clicked in margin");
            var line = scintilla.LineFromPosition(e.Position);
            scintilla.Lines[line].ToggleFold();
            textBoxLineNum.Text = "Line: " + (line + 1).ToString();
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
            if (e.X < leftMarginWidth || e.X > scintilla.Width - rightMarginWidth) {
                
            }
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

        private void GoToLine(int lineNumber)
        {
            if (lineNumber > scintilla.Lines.Count)
            {
                MessageBox.Show("Number too high");
                return;
            }
            if (lineNumber <= 0)
            {
                MessageBox.Show("Number too low");
                return;
            }

            scintilla.LineScroll(scintilla.Top, 0);
            scintilla.LineScroll(lineNumber - 1, 0);
        }
    }

    public class RunTime
    {
        public int start { get; set; }
        public int end { get; set; }
        bool complete { get; set; }
        RunType runtype { get; set; }

        public RunTime(int start, RunType runtype)
        {
            this.start = start; 
            complete = false;
            this.runtype = runtype;
        }
        
        public void AddEnd(int end)
        {
            this.end = end;
            complete = true; 
        }

    }


    public enum RunType
    {
        Diagnosic, 
        Session
    }
}