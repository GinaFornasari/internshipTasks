using log4net;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDisplay
{
    public class ScintillaHandler
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); 
        public Scintilla scintilla { get; set; }
        public delegate void MarginClickHandler(object sender, MarginClickEventArgs e);
        public event MarginClickHandler MarginClickEvent;
        protected virtual void OnMarginClickEvent(object sender, MarginClickEventArgs e)
        {
            // MarginClickEvent?.Invoke(sender, e);
            var line = scintilla.LineFromPosition(e.Position);
            scintilla.Lines[line].ToggleFold();

        }

        public ScintillaHandler() 
        {
            log.Info("ScintillaHandler started");
            scintilla = new Scintilla();
            scintilla.Dock = DockStyle.Fill;
            InitializeScintillaMarkers();
            /*
            scintilla.MarginClick += (s, mcea) =>
            {
                var line = scintilla.LineFromPosition(mcea.Position);
                scintilla.Lines[line].ToggleFold();
            };*/

            ReadInFile(); 
        }
        private void InitializeScintillaMarkers()
        {
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.Control);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
        }

        private void ReadInFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get the selected file name
                string filePath = openFileDialog.FileName;
                string fileContents = File.ReadAllText(filePath);
                scintilla.Text = fileContents;
                FormatText(); 
            }
        }
        public void FormatText()
        {
            int counter = 0;
            while (counter < scintilla.Lines.Count)
            {
                string line = scintilla.Lines[counter].Text;
                int countLines = 0;
                while (!line.Substring(0, 4).Equals("This"))
                {
                    countLines++;
                    counter++;
                    line = scintilla.Lines[counter].Text;
                }

                Fold(counter-countLines-1, countLines+1);
                counter++; 
            }
        }


        public void Fold(int startLine, int numLines)
        {
            if (numLines == 0)
            {
                return;
            }

            scintilla.Lines[startLine].FoldLevelFlags = FoldLevelFlags.Header;
            var foldLevel = scintilla.Lines[startLine].FoldLevel;
            scintilla.Lines[startLine + 1].FoldLevel = ++foldLevel;
            for (int i = 2; i < numLines; i++)
            {
                scintilla.Lines[startLine + i].FoldLevel = ++foldLevel;
            }

            scintilla.Lines[startLine + numLines].FoldLevel = --foldLevel;


        }


    }
}
