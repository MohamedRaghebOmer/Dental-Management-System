using Dental.Licensing.Core;
using System.Security.Cryptography;
using System.Text;

internal static class Program
{
    const string CustomerName = "KarimFattouh";
    const string ProductId = "Dental";

    private static void Main(string[] args)
    {
        //using RSA rsa = RSA.Create(4096);

        //string privateKey = rsa.ExportPkcs8PrivateKeyPem();
        //string publicKey = rsa.ExportSubjectPublicKeyInfoPem();

        //File.WriteAllText("private.pem", privateKey, Encoding.UTF8);
        //File.WriteAllText("public.pem", publicKey, Encoding.UTF8);

        //Console.WriteLine("Keys created successfully.");

        string baseFolder = AppContext.BaseDirectory;
        string privateKeyPath = Path.Combine(baseFolder, "private.pem");
        string publicKeyPath = Path.Combine(baseFolder, "public.pem");

        if (args.Length > 0 && args[0].Equals("--init-keys", StringComparison.OrdinalIgnoreCase))
        {
            CreateKeyPair(privateKeyPath, publicKeyPath);
            return;
        }

        if (!File.Exists(privateKeyPath))
        {
            Console.WriteLine("private.pem not found.");
            Console.WriteLine("Run: Dental.LicenseGenerator --init-keys");
            Console.ReadLine();
            return;
        }

        using RSA rsa = RSA.Create();
        rsa.ImportFromPem(File.ReadAllText(privateKeyPath, Encoding.UTF8));

        Console.Write("Device fingerprint: ");
        string fingerprint = Console.ReadLine()?.Trim() ?? string.Empty;

        LicensePayload payload = new LicensePayload
        {
            CustomerName = CustomerName,
            ProductId = ProductId,
            Fingerprint = fingerprint,
            IssuedAtUtc = DateTime.UtcNow,
            ExpiresAtUtc = null
        };

        string licenseKey = LicenseCrypto.CreateLicenseKey(payload, rsa);

        string safeName = MakeSafeFileName(CustomerName);
        string outputPath = Path.Combine(baseFolder, safeName + "_license.txt");

        File.WriteAllText(outputPath, licenseKey, Encoding.UTF8);

        Console.WriteLine();
        Console.WriteLine("LICENSE KEY:");
        Console.WriteLine(licenseKey);
        Console.WriteLine();
        Console.WriteLine("Saved to: " + outputPath);
        Console.ReadLine();
    }

    private static void CreateKeyPair(string privateKeyPath, string publicKeyPath)
    {
        using RSA rsa = RSA.Create(2048);

        string privatePem = rsa.ExportPkcs8PrivateKeyPem();
        string publicPem = rsa.ExportSubjectPublicKeyInfoPem();

        File.WriteAllText(privateKeyPath, privatePem, Encoding.UTF8);
        File.WriteAllText(publicKeyPath, publicPem, Encoding.UTF8);

        Console.WriteLine("Keys created successfully.");
        Console.WriteLine("Private key: " + privateKeyPath);
        Console.WriteLine("Public key:  " + publicKeyPath);
        Console.WriteLine();
        Console.WriteLine("Copy the public key content into your WinForms app.");
        Console.ReadLine();
    }

    private static string MakeSafeFileName(string text)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
        {
            text = text.Replace(c, '_');
        }

        return string.IsNullOrWhiteSpace(text) ? "license" : text;
    }
}