using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Abstractions
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string apiKey);
    }
}
