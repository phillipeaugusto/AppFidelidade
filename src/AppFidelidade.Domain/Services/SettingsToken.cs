using System.Text;

namespace AppFidelidade.Core.Services
{
    public class SettingsToken
    {
        public static string Secret = "6bd57c4899c52c1fa84fff0a8adf550e";
        public static byte[] Key = Encoding.ASCII.GetBytes(Secret);
    }
}