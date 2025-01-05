using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MauiApp1.Models;

public class TagService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "Tags.json");
    private List<Tag> tags = new ();
    public List<Tag> LoadTags()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Tag>();

        }
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Tag>>(json) ?? new List<Tag>();
    }
    public void SaveTags(List<Tag> tags)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(tags, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
    public List<Tag> GetTagsByUserId(int userId)
    {

        return tags.Where(t => t.UserId == userId).ToList();
    }
}
