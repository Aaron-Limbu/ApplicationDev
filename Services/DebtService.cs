﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MauiApp1.Models;
using MauiApp1.Components.Pages;


public class DebtService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "Debts.json");
    public List<MauiApp1.Models.Debts> LoadDebts()
    {
        if (!File.Exists(FilePath))
        {
            return new List<MauiApp1.Models.Debts>();

        }
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<MauiApp1.Models.Debts>>(json) ?? new List<MauiApp1.Models.Debts>();
    }
    public void SaveDebts(List<MauiApp1.Models.Debts> debts)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(debts  , new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

}