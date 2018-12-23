using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(AssemblyInfo.AppName)]
[assembly: AssemblyDescription("A small wrapper that converts selected Adobe style command line parameters to SumatraPDF parameters. This project is primarily focussed on adding support for SumatraPDF to Citavi.")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyCompany("https://github.com/ironjan/CitaviSumatraWrapper")]
[assembly: AssemblyProduct(AssemblyInfo.AppName)]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6DFED69D-11D9-4B6C-9C2B-A51055CE276E")]

// Follow http://semver.org/, ignore 4th digit...
[assembly: AssemblyVersion(AssemblyInfo.Version)]
[assembly: AssemblyFileVersion(AssemblyInfo.Version)]

public static class AssemblyInfo {
  public const string Version = "0.6.3.0";
  public const string AppName = "CitaviSumatraWrapper - " + Version;
}