using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Auth
{
    public class TokenStore
    {
        private readonly string _filePath;
        public TokenStore(string fileName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appFolder = Path.Combine(folder, "EmployeeMgmt");
            if (!Directory.Exists(appFolder)) Directory.CreateDirectory(appFolder);
            _filePath = Path.Combine(appFolder, fileName);
        }

        public void Save(TokenModel token)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(token);
            File.WriteAllText(_filePath, json);
        }

        public TokenModel? Load()
        {
            if (!File.Exists(_filePath)) return null;
            var json = File.ReadAllText(_filePath);
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<TokenModel>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void Delete()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
        }
    }
}
