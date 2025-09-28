using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace wlt_helper
{
    internal class DataStorage
    {
        private static readonly byte[] s_additionalEntropy = Encoding.UTF8.GetBytes("asdasd");
        public static void SaveCredentials(string username, string password)
        {
            try
            {
                // 1. 将用户名和密码组合为一个字符串（或使用更结构化的方式，如JSON）
                string credentials = $"{username}|{password}";
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(credentials);

                // 2. 使用DPAPI加密数据。DataProtectionScope.CurrentUser 确保只有当前用户能解密。
                byte[] encryptedData = ProtectedData.Protect(plaintextBytes, s_additionalEntropy, DataProtectionScope.CurrentUser);

                // 3. 将加密后的数据保存到文件（也可存到注册表）
                string filePath = "credential";
                File.WriteAllBytes(filePath, encryptedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存凭据时出错：{ex.Message}");
            }
        }
        public static string? LoadSavedCredentials()
        {
            string filePath = "credential";
            if (!File.Exists(filePath)) return null;

            try
            {
                byte[] encryptedData = File.ReadAllBytes(filePath);
                byte[] decryptedData = ProtectedData.Unprotect(encryptedData, s_additionalEntropy, DataProtectionScope.CurrentUser);

                string credentials = Encoding.UTF8.GetString(decryptedData);
                return credentials;
            }
            catch (CryptographicException)
            {
                File.Delete(filePath);
                MessageBox.Show("保存的登录信息已失效，请重新输入。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载凭据时出错：{ex.Message}");
            }
            return null;
        }
    }
}
