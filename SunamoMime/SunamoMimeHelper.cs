namespace SunamoMime;

/// <summary>
/// Helper class for determining MIME types and file formats from byte arrays.
/// </summary>
public class SunamoMimeHelper
{
    private static readonly Dictionary<string, List<byte>> mimeSignatures = new();

    /// <summary>
    /// Initializes known MIME type signatures.
    /// Currently supports: WEBP format.
    /// </summary>
    public static void Init()
    {
        mimeSignatures.Add("webp", new List<byte>(new byte[] { 82, 73, 70, 70 }));
    }

    /// <summary>
    /// Determines the file type from a byte array by analyzing file signatures.
    /// </summary>
    /// <param name="bytes">The byte array containing file data to analyze.</param>
    /// <returns>The file extension corresponding to the detected file format.</returns>
    public static string FileType(byte[] bytes)
    {
        var firstFourBytes = bytes.Take(4);
        foreach (var signature in mimeSignatures)
            if (firstFourBytes.SequenceEqual(signature.Value))
                return signature.Key;

        FileFormatInspector inspector = new();
        MemoryStream memoryStream = new(bytes);
        var format = inspector.DetermineFileFormat(memoryStream);
        return format?.Extension ?? string.Empty;
    }
}