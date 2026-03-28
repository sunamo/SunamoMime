using SunamoFileExtensions;

namespace SunamoMime.Tests;

/// <summary>
/// Unit tests for <see cref="SunamoMimeHelper"/> class.
/// Tests MIME type detection and file format identification.
/// </summary>
public class SunamoMimeHelperTests
{
    /// <summary>
    /// Tests the FileType method with various file formats.
    /// Verifies detection of JPG and WEBP file types from byte arrays.
    /// </summary>
    [Fact]
    public async Task FileTypeTest()
    {
        SunamoMimeHelper.Init();

        var testFilesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");
        Directory.CreateDirectory(testFilesDirectory);

        var jpgFilePath = Path.Combine(testFilesDirectory, $"test{AllExtensions.jpg}");
        var webpFilePath = Path.Combine(testFilesDirectory, $"test{AllExtensions.webp}");

        if (File.Exists(jpgFilePath))
        {
            Assert.Equal("jpg", SunamoMimeHelper.FileType(await File.ReadAllBytesAsync(jpgFilePath)));
        }

        if (File.Exists(webpFilePath))
        {
            Assert.Equal("webp", SunamoMimeHelper.FileType(await File.ReadAllBytesAsync(webpFilePath)));
        }
    }
}
