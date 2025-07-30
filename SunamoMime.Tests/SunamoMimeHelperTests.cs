using SunamoFileExtensions;

namespace SunamoMime.Tests;

public class SunamoMimeHelperTests
{
    //[Fact]
    public async Task FileTypeTest()
    {
        SunamoMimeHelper.Init();
        var f = @"D:\_Test\sunamo\win\Helpers\MImeHelper\GetMimeFromFile\Real";
        //application/octet-stream>
        Assert.Equal("jpg", SunamoMimeHelper.FileType((await File.ReadAllBytesAsync(f + AllExtensions.jpg))));
        Assert.Equal("webp", SunamoMimeHelper.FileType((await File.ReadAllBytesAsync(f + AllExtensions.webp))));
    }
}


