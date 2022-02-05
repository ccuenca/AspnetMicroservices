using Ordering.Applicaction.Model;

namespace Ordering.Applicaction.Contracts.Infrastructure
{
  public interface IEmailService
  {
    Task<bool> SendEmail(Email email);
  }
}
