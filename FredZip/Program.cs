using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace FredZip
{
  internal class Program
  {
    static void Main(string[] arguments)
    {
      Action<string> Display = Console.WriteLine;
      Display($"Program FredZip.exe written by Freddy Juhel on the 15/09/2026, version {GetAssemblyVersion()}");
      Display(string.Empty);
      if (arguments.Length == 0 || arguments[0].ToLower().Contains("help") || arguments[0].Contains("?"))
      {
        DisplayUsage();
        return;
      }

      var argumentDictionary = new Dictionary<string, string>
      {
        // Initialization of the argument dictionary with default values
        {"OneZipFilePerFile", "true" },
        {"directory", "."},
        {"includesubdirectories", "false"},
        {"extensionfilenamepattern", "txt" },
        {"exclusionextensionfilenamepattern", ".exe,.dll,.config" },
        {"compressionlevel", "maximum9" },
        {"deleteaftercompression", "false" },
        {"addextensionifnone", "false" },
        {"extensiontobeaddedifnone", "txt" },
        {"log", "false"}
      };

      // the variable numberOfInitialDictionaryItems is used for the log to list all non-standard arguments passed in.
      int numberOfInitialDictionaryItems = argumentDictionary.Count;
      int numberOfFilesZipped = 0;
      int numberOfFilesDeletedAfterBeingZipped = 0;
      bool hasExtraArguments = false;
      string datedLogFileName = $"FredZipLogFile-{DateTime.Now.ToShortDateString().Replace('/', '-')}.log";
      bool deleteFileAfterBeingZipped = false;

      Display("Press any key to exit...");
      Console.ReadKey();
    }

    private static void DisplayUsage()
    {
      Action<string> display = Console.WriteLine;
      display(string.Empty);
      display("FredZip is a console application written by Freddy Juhel on the 15th of September 2026.");
      display($"FredZip.exe is in version {GetAssemblyVersion()}");
      display("FredZip needs Microsoft .NET framework 4.8 to run, if you don't have it, download it from www.microsoft.com.");
      string copyrightYear = $"-{DateTime.Now.Year}";
      if (DateTime.Now.Year <= 2026)
      {
        copyrightYear = string.Empty;
      }

      display($"Copyrighted (c) MIT 2026{copyrightYear} by Freddy Juhel.");
      display(string.Empty);
      display("Usage of this program:");
      display(string.Empty);
      display("List of arguments:");
      display(string.Empty);
      display("/help (this help)");
      display("/? (this help)");
      display(string.Empty);
      display("/OneZipFilePerFile=<true or false> default is true");
      display(string.Empty);
      display("You can write argument name (not its value) in uppercase or lowercase or a mixed of them (case insensitive)");
      display("/compressionlevel is the same as /Compressionlevel or /CompressionLevel or /COMPRESSIONLEVEL");
      display(string.Empty);
      display("/directory=<name of the directory where files will be zipped> default is where FredZip.exe is");
      display(string.Empty);
      display("/includesubdirectories=<true or false> false by default");
      display(string.Empty);
      display("/log=<true or false> false by default");
      display(string.Empty);
      display("/extensionfilenamepattern=<any kind of extension file name> default is txt");
      display(string.Empty);
      display("/exclusionextensionfilenamepattern=<any kind of extension file name> default is .exe,.dll,.config");
      display(string.Empty);
      display("/compressionlevel=<any number between 0 to 9>, default is 9");
      display(string.Empty);
      display("/deleteaftercompression=<true or false> default is false");
      display(string.Empty);
      display("/addextensionifnone=<true or false> default is false");
      display(string.Empty);
      display("/extensiontobeaddedifnone=<any kind of extension file name> default is txt");
      display(string.Empty);
      display("/log=<true or false> default is false");
      display(string.Empty);
      display("Examples:");
      display(string.Empty);
      display(@"FredZip /directory=. /extensionfilenamepattern=txt /log=true");
      display(string.Empty);
      display("FredZip /help (this help)");
      display("FredZip /? (this help)");
      display(string.Empty);
    }

    public static string GetAssemblyVersion()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      return string.Format("V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }
  }
}
