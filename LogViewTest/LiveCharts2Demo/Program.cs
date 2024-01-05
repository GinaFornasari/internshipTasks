using LiveCharts2Demo.LogView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace LiveCharts2Demo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LiveCharts.Configure(config =>
           config
               // you can override the theme 
                //.AddDarkTheme()  

               // In case you need a non-Latin based font, you must register a typeface for SkiaSharp
               //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('?')) // <- Chinese 
               //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('?')) // <- Japanese 
               //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('?')) // <- Korean 
               //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('?'))  // <- Russian 

               //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('?'))  // <- Arabic 
               //.UseRightToLeftSettings() // Enables right to left tooltips 

               // finally register your own mappers
               // you can learn more about mappers at:
               // https://livecharts.dev/docs/winforms/2.0.0-rc2/Overview.Mappers

               // here we use the index as X, and the population as Y 
               .HasMap<City>((city, index) => new(index, city.Population))
       // .HasMap<Foo>( .... ) 
       // .HasMap<Bar>( .... ) 
       );

            _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new LogViewForm());
        }

        public record City(string Name, double Population);
    }
}
    
