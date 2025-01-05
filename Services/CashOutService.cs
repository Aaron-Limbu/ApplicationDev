using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MauiApp1.Models;

public class CashOutService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "CashOutFlows.json");
    public List<CashOutFlow> LoadCOFs()
    {
        if (!File.Exists(FilePath))
        {
            return new List<CashOutFlow>();

        }
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<CashOutFlow>>(json) ?? new List<CashOutFlow>();
    }
    public void SaveCashOutFlows(List<CashOutFlow> CFS)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(CFS, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

}
