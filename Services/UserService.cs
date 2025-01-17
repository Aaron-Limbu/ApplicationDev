using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using MauiApp1.Models;
public class UserService
{
    private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    private static readonly string FolderPath = Path.Combine(DesktopPath, "LocalDB");
    private static readonly string FilePath = Path.Combine(FolderPath, "users.json");
    public int userId {  get; set; }
    
    public List<User> LoadUsers()
    {
        if (!File.Exists(FilePath))
            return new List<User>();  // Return an empty list if no users exist

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }
    public void SaveUsers(List<User> users)
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }

        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);  // Return hashed password
    }
    public bool ValidatePassword(string inputPassword, string storedPassword)
    {
        var hashedInputPassword = HashPassword(inputPassword);
        return hashedInputPassword == storedPassword;
    }
    public int GetId(string username)
    {
        var json = File.ReadAllText(FilePath);
        var Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        var id = Users.FirstOrDefault(u => u.Username == username);
        return id?.UserId ?? 0;
    }
    public int GetId2(string email)
    {
        var json = File.ReadAllText(FilePath);
        var Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        var id = Users.FirstOrDefault(u => u.Email == email);
        return id?.UserId ?? 0;
    }

    public void sessionId(int userid)
    {
        userId = userid;
        
    }
    public int getses()
    {
        return userId;
    }
    public decimal getBalance()
    {
        var users=LoadUsers();
        int id = getses();
        var user = users.FirstOrDefault(u => u.UserId == id);
        return user != null ? user.balance : 0;
    }
    public void StoreBalance(string username, decimal balance)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            user.balance = balance; 
            SaveUsers(users);        
        }
    }
    public void cashin(int id, decimal amount,bool isCleared)
    {
        if (!isCleared)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                user.balance += amount;
                StoreBalance(user.Username, user.balance);
            }
        }
    }
    public void cashout(int id, decimal amount)
    {
        var user = LoadUsers().FirstOrDefault(u => u.UserId == id);
        if (user == null)
            throw new Exception("User not found.");

        if (user.balance < amount)
            throw new Exception("Insufficient balance.");

        user.balance -= amount;
        StoreBalance(user.Username, user.balance);
    }

}
