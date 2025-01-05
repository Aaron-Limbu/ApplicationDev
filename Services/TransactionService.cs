using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MauiApp1.Models;

public class TransactionService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "Transactions.json");
    public List<Transactions> LoadTransactions()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Transactions>();

        }
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Transactions>>(json) ?? new List<Transactions>();
    }
    public void SaveTransactions(List<Transactions> transactions)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

}