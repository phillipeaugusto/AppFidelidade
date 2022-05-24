using System.Security.Cryptography;
using System.Text;

namespace AppFidelidade.Domain.Functions;

public static class Function
{
    public static string GenerateMd5(string value)
    {
        var md5Hasher = MD5.Create();
        var valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        var strBuilder = new StringBuilder();
        foreach (var t in valorCriptografado)
        {
            strBuilder.Append(t.ToString("x2"));
        }
        return strBuilder.ToString();
    }
}