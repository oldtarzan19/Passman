using Newtonsoft.Json;
using Passman.Core.Data;
using Passman.Core.Models;
using Passman.Models;


namespace Passman.Core.dao;

public class Dao
{
    private EncryptedType encryptedType;
    
    public bool RegisterUser(string username, string password, string email, string firstName, string lastName)
    {
        try
        {
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); 

            
            var user = new User(username, encryptedType.Hash(password), email, firstName, lastName);
            
            
            context.Users.Add(user);

            
            context.SaveChanges();
            
            // Alap adatok elmentése a userinfo.json fájlba
            UserInfo userInfo = new UserInfo
            {
                UserId = user.Id, 
                Email = user.Email 
            };
            
            string json = JsonConvert.SerializeObject(userInfo);
            var jsonPath = Path.Combine("..","Passman.Core", "res", "userinfo.json");
            File.WriteAllText(jsonPath, json);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return false;
    }
    
    // -1 el tér vissza ha hibás a felhasználónév egyéb esetben a userId-vel
    public int LoginUser(string username, string password)
    {
        try
        {
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); 

            
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            
            if (user == null)
            {
                return -1;
            }

            
            if (user.Password != encryptedType.Hash(password))
            {
                return -1;
            }
            // Alap adatok elmentése a userinfo.json fájlba
            UserInfo userInfo = new UserInfo
            {
                UserId = user.Id, 
                Email = user.Email 
            };
            
            string json = JsonConvert.SerializeObject(userInfo);
            var jsonPath = Path.Combine("..","Passman.Core", "res", "userinfo.json");
            File.WriteAllText(jsonPath, json);
            return user.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // Új vaultentry létrehozása (id, userid, username, password, website)
    public void CreateVaultEntry(string username, string password, string website)
    {
        try
        {
            UserInfo? userInfo = new UserInfo();
            // UserInfo kiolvasása 
            string jsonPath = Path.Combine("..","Passman.Core", "res", "userinfo.json");
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath); 
                userInfo = JsonConvert.DeserializeObject<UserInfo>(json);
            }
            
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); 

            
            var vaultEntry = new VaultEntry(userInfo.UserId, username, encryptedType.Encrypt(userInfo.Email,password).Secret, website);
            
            
            context.VaultEntries.Add(vaultEntry);

            
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // VaultEntry lekérdezése userId segítségével és az adatok decryptelése
    public List<VaultEntry> GetVaultEntries()
    {
        try
        {
            UserInfo? userInfo = new UserInfo();
            // UserInfo kiolvasása 
            string jsonPath = Path.Combine("..","Passman.Core", "res", "userinfo.json");
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath); 
                userInfo = JsonConvert.DeserializeObject<UserInfo>(json);
            }
            
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); 

            
            var vaultEntries = context.VaultEntries.Where(v => v.UserId == userInfo.UserId).ToList();
            foreach (var vaultEntry in vaultEntries)
            {
                vaultEntry.Password = encryptedType.Decrypt(userInfo.Email, vaultEntry.Password).Secret;
            }

            List<VaultEntry> vault2 = new List<VaultEntry>();
            foreach (var vaultEntry in vaultEntries)
            {
                vault2.Add(new VaultEntry(vaultEntry.Username, vaultEntry.Password, vaultEntry.Website));
            }

            
            return vault2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}