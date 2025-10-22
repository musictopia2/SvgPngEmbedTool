namespace SvgPngEmbedTool;
public class ResolverClass : IFileResolver
{
    BasicList<string> IFileResolver.ExtensionsAllowed =>
        [
        ".svg",
        ".png"
        ];
    string IFileResolver.GetGlobalName => "SvgPngImageResource";
    async Task<string> IFileResolver.ResolveDataAsync(string path)
    {
        var bb = await ff1.ReadAllBytesAsync(path);
        string data = Convert.ToBase64String(bb);
        string others = "";
        if (path.ToLower().EndsWith(".svg"))
        {
            others = "data:image/png;base64,";
        }
        else if (path.ToLower().EndsWith(".png"))
        {
            others = "data:image/svg+xml;base64,";
        }
        else
        {
            throw new CustomBasicException("Only svg and png are allowed");
        }
        return $"{others}{data}";
    }
}