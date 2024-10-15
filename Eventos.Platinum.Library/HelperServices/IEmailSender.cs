namespace Eventos.Platinum.Library.HelperServices
{
    public interface IEmailSender
    {
        bool Send(List<string> emailAccounts, string subject, string message, string senderName);
    }
}