using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Drawing.Text;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel.Sketches;
using System.Globalization;
using LiveCharts2Demo.LogView;

namespace LiveCharts2Demo
{
    public partial class Form1 : Form
    {

        private LogFile logFile;
        private MiniLogCreator miniLogCreator;
        private LineSeries<ObservablePoint> unsuccessfulSessions;
        private LineSeries<ObservablePoint> successfulSessions;
        private LineSeries<ObservablePoint> offline;
        private LineSeries<ObservablePoint> diagnostics;
        private LineSeries<ObservablePoint> error;
        public Form1()
        {
            InitializeComponent();
            logFile = new LogFile();
            miniLogCreator = new MiniLogCreator(logFile.logData);
            LoadChart();
            clbOptions.ItemCheck += CheckedListBox_ItemCheck;



            clbOptions.SetItemChecked(0, true);
            clbOptions.SetItemChecked(1, true);
            clbOptions.SetItemChecked(2, true);
            clbOptions.SetItemChecked(3, true);
            clbOptions.SetItemChecked(4, true);

        }

        private void LoadChart()
        {
            cartesianChart1.Series = new ISeries[]

        {
                 unsuccessfulSessions = new LineSeries<ObservablePoint>
        {
                     YToolTipLabelFormatter = point => $"({point.Model?.Y}, {point.Model?.X})",
                    // Values = GeneratePointsForSeries(unsuccessfulSessionsLogs),
            /*Values = new ObservablePoint[]
            {
                new ObservablePoint(0, 0),
                new ObservablePoint(0, 1),
                new ObservablePoint(1, 1),
                new ObservablePoint(2, 1),
                new ObservablePoint(2, 0)
            },*/
            LineSmoothness = 0,
            Fill = new SolidColorPaint(SKColors.MistyRose),
            Stroke = new SolidColorPaint(SKColors.Red) {StrokeThickness = 1},
            GeometrySize = 0,
            GeometryStroke = new SolidColorPaint(SKColors.Red) {StrokeThickness = 3}

        },
                successfulSessions = new LineSeries<ObservablePoint>
        {
                    YToolTipLabelFormatter = point => $"({point.Model?.Y}, {point.Model?.X})",
                    //Values = GeneratePointsForSeries(miniLogCreator.successfulSessionsLogs),
            /*Values = new List<ObservablePoint>()
            {
                new ObservablePoint(3, 0),
                new ObservablePoint(3, 1),
                new ObservablePoint(4, 1),
                new ObservablePoint(5, 1),
                new ObservablePoint(5, 0)
            },*/
            LineSmoothness = 0,
            Fill = new SolidColorPaint(SKColors.LightGreen),
            Stroke = new SolidColorPaint(SKColors.Green) {StrokeThickness = 1},
            GeometrySize = 0,
            GeometryStroke = new SolidColorPaint(SKColors.Green) {StrokeThickness = 3}
        },
                offline = new LineSeries<ObservablePoint>
        {
                    YToolTipLabelFormatter = point => $"({point.Model?.Y}, {point.Model?.X})",
                    Values = GeneratePointsForSeries(miniLogCreator.OfflineLogs),
            /*Values = new ObservablePoint[]
            {
                new ObservablePoint(0.25, 0),
                new ObservablePoint(0.25, 1),
                new ObservablePoint(0.5, 1),
                new ObservablePoint(1.25, 1),
                new ObservablePoint(1.25, 0)


            },*/
            LineSmoothness = 0,
            Fill = new SolidColorPaint(SKColors.LightGray),
            Stroke = new SolidColorPaint(SKColors.Gray) {StrokeThickness = 1},
            GeometrySize = 0,
            GeometryStroke = new SolidColorPaint(SKColors.Gray) {StrokeThickness = 3}
        },
                  diagnostics = new LineSeries<ObservablePoint>
        {
                      Values = GeneratePointsForSeries(miniLogCreator.DiagnosticsLogs),
            /*Values = new ObservablePoint[]
            {
                new ObservablePoint(1, 0),
                new ObservablePoint(1, 1),
                new ObservablePoint(null, null),
                new ObservablePoint(4.5, 0),
                new ObservablePoint(4.5, 1),


            },*/
            LineSmoothness = 0,
            Fill = null,
            Stroke = new SolidColorPaint(SKColors.Blue) {StrokeThickness = 1},
            GeometrySize = 0,
            GeometryStroke = new SolidColorPaint(SKColors.Blue) {StrokeThickness = 3}
        },
                  error = new LineSeries<ObservablePoint>
        {
                      Values = GeneratePointsForSeries(miniLogCreator.ErrorLogs),
            /*Values = new ObservablePoint[]
            {
                new ObservablePoint(1.5, 0),
                new ObservablePoint(1.5, 1),
                new ObservablePoint(null, null),
                new ObservablePoint(3.5, 0),
                new ObservablePoint(3.5, 1),
                new ObservablePoint(null, null),
                new ObservablePoint(4, 0),
                new ObservablePoint(4, 1),


            },*/
            LineSmoothness = 0,
            Fill = null,
            Stroke = new SolidColorPaint(SKColors.DarkRed) {StrokeThickness = 1},
            GeometrySize = 0,
            GeometryStroke = new SolidColorPaint(SKColors.DarkRed) {StrokeThickness = 3}
        },


        };


        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the checked status of the item
            bool isChecked = e.NewValue == CheckState.Checked;


            if (e.Index == 0)
            {
                unsuccessfulSessions.IsVisible = isChecked;
            }
            else if (e.Index == 1)
            {
                successfulSessions.IsVisible = isChecked;
            }
            else if (e.Index == 2)
            {
                offline.IsVisible = isChecked;
            }
            else if (e.Index == 3)
            {
                diagnostics.IsVisible = isChecked;
            }
            else if (e.Index == 4)
            {
                error.IsVisible = isChecked;
            }
        }

        private void cartesianChart1_Click(object sender, MouseEventArgs e)
        {
            var chart = (CartesianChart)sender;

            // scales the UI coordinates to the corresponding data in the chart.
            // var dataCoordinates = chart.ScalePixelsToData(new LvcPointD(e.Location.X, e.Location.Y));
            //var visuals = chart.GetVisualsAt(new LvcPoint(e.Location.X, e.Location.Y));
            var points = chart.GetPointsAt(new LvcPoint(e.Location.X, e.Location.Y));
            if (points != null && points.Any())
            {
                string pointInfo = "Points found at:";

                foreach (var point in points)
                {
                    pointInfo += $"\nPointCoordinates: {point.Coordinate}";

                }

                MessageBox.Show(pointInfo, "Points Information");
            }
            else
            {
                MessageBox.Show("No points found at this location", "Points Information");
            }

            //MessageBox.Show($"You clicked at X: {dataCoordinates.X} and Y: {dataCoordinates.Y}");

        }






        private List<ObservablePoint> GeneratePointsForSeries(Dictionary<DateTime, string> logs)
        {
            var points = new List<ObservablePoint>();

            foreach (var log in logs.OrderBy(log => log.Key))
            {
                var xValue = GetXValueFromLog(log.Key); // Determine the constant x-value
                var yValue = GetYValueFromLog(log.Value); // Determine y-value based on log content

                points.Add(new ObservablePoint(xValue, 0)); // Start point with y = 0
                points.Add(new ObservablePoint(xValue, yValue)); // End point with determined y-value
                points.Add(new ObservablePoint(null, null)); // Add a null point to create a gap
            }

            return points;
        }

        private double GetXValueFromLog(DateTime timestamp)
        {
            // Define the range for x-values
            double minValue = 1; // Set the minimum x-value
            double maxValue = 5; // Set the maximum x-value

            // Calculate the total range between maxValue and minValue
            double totalRange = maxValue - minValue;

            // Assuming you have a specific time range you're working with
            // For example, let's consider a time span from the earliest to the latest timestamp
            DateTime earliestTimestamp = DateTime.Parse("2023-12-31T10:10:10Z"); // Replace this with your actual earliest timestamp
            DateTime latestTimestamp = DateTime.Parse("2023-12-31T23:59:59Z"); // Replace this with your actual latest timestamp

            TimeSpan totalDuration = latestTimestamp - earliestTimestamp;

            // Calculate the fractional time span from the earliest timestamp to the given timestamp
            TimeSpan timeFromEarliest = timestamp - earliestTimestamp;

            // Calculate the fraction of the total range covered by the given timestamp
            double fraction = timeFromEarliest.TotalSeconds / totalDuration.TotalSeconds;

            // Calculate the corresponding x-value within the defined range
            double mappedValue = minValue + (totalRange * fraction);

            return mappedValue;
        }

        private double MapTimestampToRange(DateTime timestamp, double minValue, double maxValue)
        {
            // Implement your logic to map the timestamp to the desired range
            // You can use TimeSpan calculations, date arithmetic, or other methods
            // For example, you might scale the timestamp within the range based on its distance from a specific date or time
            // Here's a simple example using a linear mapping assuming a specific time range
            DateTime minTimestamp = DateTime.Parse("2023-12-31T00:00:00Z"); // Example minimum timestamp
            DateTime maxTimestamp = DateTime.Parse("2023-12-31T23:59:59Z"); // Example maximum timestamp

            double range = (maxValue - minValue);
            double elapsedTicks = timestamp.Ticks - minTimestamp.Ticks;
            double totalTicks = maxTimestamp.Ticks - minTimestamp.Ticks;

            double mappedValue = minValue + (range * elapsedTicks / totalTicks);

            return mappedValue;
        }
        private int GetYValueFromLog(string logEntry)
        {
            // Convert log entry to corresponding Y value (e.g., based on log content)
            if (logEntry.Contains("App Started"))
            {
                return 2; // App Started state
            }
            else if (logEntry.Contains("App Ended"))
            {
                return 2; // App Ended state
            }
            else if (logEntry.Contains("Offline"))
            {
                return 1; // Offline state
            }
            else if (logEntry.Contains("Warning"))
            {
                return 1; // Offline state
            }
            else if (logEntry.Contains("Error"))
            {
                return 1; // Offline state
            }
            else
            {
                return 0; // Other states or no activity
            }
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            LogViewForm secondForm = new LogViewForm();
            secondForm.Show();
        }
    }
}


