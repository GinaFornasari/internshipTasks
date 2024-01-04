using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using ScintillaNET;

namespace TextDisplay
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //Scintilla scintilla; 
        public Form1()
        {
            //scintilla = new Scintilla();
            InitializeComponent();
            InitializeScintillaMarkers();
            //ReadInFile();          
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
                formatText(); 
            }
        }

        public void formatText()
        {
            int counter = 0;
            while (counter < scintilla.Lines.Count)
            {
                string line = scintilla.Lines[counter].Text;
                int countLines = 0;
                if (line.Equals(""))
                {
                    continue;
                }
                while (!line.Substring(0, 4).Equals("This") && counter < scintilla.Lines.Count )
                {
                    countLines++;
                    counter++;
                    line = scintilla.Lines[counter].Text;
                    if (line.Equals(""))
                    {
                        break ;
                    }
                }

                Fold(counter - countLines - 1, countLines + 1);
                counter++;
            }

        }

        public void Fold(int startLine, int numLines)
        {
            if (numLines == 1)
            {
                return;
            }

            scintilla.Lines[startLine].FoldLevelFlags = FoldLevelFlags.Header;
            var foldLevel = scintilla.Lines[startLine].FoldLevel;
            scintilla.Lines[startLine+1].FoldLevel = ++foldLevel;
            for (int i = 2; i <numLines; i++)
            {
                scintilla.Lines[startLine + i].FoldLevel = foldLevel;
            }

            scintilla.Lines[startLine + numLines].FoldLevel = --foldLevel;

        }

 

        private void scintilla_MarginClick(object sender, MarginClickEventArgs e)
        {
            var line = scintilla.LineFromPosition(e.Position);
            scintilla.Lines[line].ToggleFold();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scintilla.ReadOnly = false;
            ReadInFile();
            scintilla.ReadOnly = true;
        }
    }
}