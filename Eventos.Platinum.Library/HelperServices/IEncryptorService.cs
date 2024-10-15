namespace Eventos.Platinum.Library.HelperServices
{
    public interface IEncryptorService
    {
        string Decrypt(string textoADesencriptar);
        string Encrypt(string textoAEncriptar);
    }
}