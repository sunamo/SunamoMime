using SunamoFileExtensions;

namespace SunamoMime.Tests;

/// <summary>
/// Unit tests for SunamoMimeHelper class.
/// Tests MIME type detection and file format identification.
/// </summary>
public class SunamoMimeHelperTests
{
    /// <summary>
    /// Tests the FileType method with various file formats.
    /// Verifies detection of JPG and WEBP file types from byte arrays.
    /// </summary>
    //[Fact]
    public async Task FileTypeTest()
    {
        SunamoMimeHelper.Init();

        var testFilesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");
        Directory.CreateDirectory(testFilesDirectory);

        Assert.Equal("jpg", SunamoMimeHelper.FileType(await File.ReadAllBytesAsync(Path.Combine(testFilesDirectory, $"test{AllExtensions.jpg}"))));
        Assert.Equal("webp", SunamoMimeHelper.FileType(await File.ReadAllBytesAsync(Path.Combine(testFilesDirectory, $"test{AllExtensions.webp}"))));
    }
}
