using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MauiApp1.Models;

public class CashinService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "Cashins.json");
    public List<CashinFlow> LoadCIFs()
    {
        if (!File.Exists(FilePath))
        {
            return new List<CashinFlow>();

        }
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<CashinFlow>>(json) ?? new List<CashinFlow>();
    }
    public void AddCashin(List<CashinFlow> CIFs)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(CIFs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

}