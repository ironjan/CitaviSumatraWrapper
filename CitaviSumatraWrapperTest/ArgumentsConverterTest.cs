using NUnit.Framework;
using CitaviSumatraWrapper;

namespace CitaviSumatraWrapperTest
{
  [TestFixture]
  public class ArgumentsConverterTest
  {

    #region Simple cases
    [Test]
    public void EmptyArgsGetConvertedToEmptyArgString()
    {
      var args = new string[]{};
      var expected = "";
      var result = ArgumentsConverter.Convert(args);
      Assert.AreEqual(expected, result);
    }
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(13)]
    public void AdobePageArgumentGetsConvertedToPageArgString(int page)
    {
     var path = @"C:\some\file.pdf";
     var args = new[] {"/A", $"page={page}", path};
     var expected = $"-page {page} \"{path}\"";
     var result = ArgumentsConverter.Convert(args);
     Assert.AreEqual(expected, result);
   }

   [Test]
   [TestCase(new string[]{"-page", "5", "\"C:\\some\\file.pdf\""}, "-page 5 \"C:\\some\\file.pdf\"")]
   [TestCase(new string[]{"-page", "5", "-something", "else", "\"C:\\some\\file.pdf\""}, "-page 5 -something else \"C:\\some\\file.pdf\"")]
   [TestCase(new string[]{"-also", "\"in front\"", "-page", "5", "\"C:\\some\\file.pdf\""}, "-also \"in front\" -page 5 \"C:\\some\\file.pdf\"")]
   [TestCase(new string[]{"-before", "and", "-page", "5", "-also", "\"behind\"", "\"C:\\some\\file.pdf\""}, "-before and -page 5 -also \"behind\" \"C:\\some\\file.pdf\"")]
   public void NonAdobeArgumentsGetConcatenatedAndPassedOn(string[] args, string sumatraArgs)
   {
     var expected = sumatraArgs;
     var result = ArgumentsConverter.Convert(args);
     Assert.AreEqual(expected, result);
   }
   
   [Test]
   [TestCase(@"C:\some\file.pdf")]
   [TestCase(@"C:\file.pdf")]
   [TestCase(@"D:\file.pdf")]
   [TestCase("\"C:\\some\\file with spaces.pdf\"")]
   public void SingeArgumentGetsPassedOn(string arg){
     Assert.AreEqual(arg, ArgumentsConverter.Convert(new []{arg}));
   }
   #endregion


   #region non-official cases 
   [Test]
   [TestCase("something=else&page=2",2)]
   [TestCase("page=5&something=else",5)]
   [TestCase("something=else&page=7&comment=commentId",7)]
   public void NonPageAdobeArgumentGetIgnoredWhenPassedWithPage(string otherArg, int page)
   { 
    var path = @"C:\some\file.pdf";
    var args = new[] {"/A",otherArg, path};
    var expected = $"-page {page} \"{path}\"";
    var result = ArgumentsConverter.Convert(args);
    Assert.AreEqual(expected, result);
  }

  [Test]
  [TestCase("something=else")]
  [TestCase("something=else&comment=commentId")]
  public void NonPageAdobeArgumentGetIgnoredWhenPassedWithoutPage(string otherArg)
  { 
    var path = @"C:\some\file.pdf";
    var args = new[] {"/A",otherArg, path};
    var expected = $"\"{path}\"";
    var result = ArgumentsConverter.Convert(args);
    Assert.AreEqual(expected, result);
  }
  #endregion

  [Test]
  [TestCase("page=")]
  [TestCase("page=&nameddest=destination")]
  [TestCase("nameddest=destination&page=")]
  [TestCase("nameddest=destination&page=&comment=commentId")]
  public void IncompletePageArgumentGetsIgnored(string adobeArg){
    var path = @"C:\some\file.pdf";
    var args = new[] {"/A",adobeArg, path};
    var expected = $"\"{path}\"";
    var result = ArgumentsConverter.Convert(args);
    Assert.AreEqual(expected, result);
  }


}
}