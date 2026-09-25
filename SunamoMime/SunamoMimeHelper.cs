namespace SunamoMime;

public class SunamoMimeHelper
{
    private static readonly Dictionary<string, List<byte>> mimeSignatures = new();

    public static void Init()
    {
        mimeSignatures.Add("webp", new List<byte>(new byte[] { 82, 73, 70, 70 }));
    }

    public static string FileType(byte[] array)
    {
        var firstFourBytes = array.Take(4);
        foreach (var signature in mimeSignatures)
            if (firstFourBytes.SequenceEqual(signature.Value))
                return signature.Key;

        FileFormatInspector inspector = new();
        MemoryStream memoryStream = new(array);
        var format = inspector.DetermineFileFormat(memoryStream);
        return format?.Extension ?? string.Empty;
    }
}