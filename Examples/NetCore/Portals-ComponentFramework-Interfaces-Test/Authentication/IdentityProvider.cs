using System;
using System.Threading.Tasks;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Configuration;

namespace Portals.ComponentFramework.Interfaces.Test.Authentication
{
    public static class IdentityProvider
    {
        public static async Task<string> GetAccessTokenAsync(IConfiguration configuration, string authority)
        {
            var oidcClientOptions = GetOidcClientOptions(configuration, authority);

            if (oidcClientOptions == null)
            {
                return null;
            }

            var oidcClient = new OidcClient(oidcClientOptions);

            var loginResult = await oidcClient.LoginAsync(new LoginRequest());

            if (loginResult.IsError)
            {
                throw new Exception(loginResult.Error);
            }

            return loginResult.AccessToken;
        }

        private static OidcClientOptions GetOidcClientOptions(IConfiguration configuration, string authority)
        {
            if (string.IsNullOrEmpty(authority))
            {
                throw new Exception("Auth authority configuration is empty");
            }

            var clientId = configuration["SmintIo:Auth:ClientId"];

            if (string.IsNullOrEmpty(clientId))
            {
                throw new Exception("Auth client ID configuration is empty");
            }

            var clientSecret = configuration["SmintIo:Auth:ClientSecret"];

            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new Exception("Identity client secret configuration is empty");
            }

            var redirectUrl = configuration["SmintIo:Auth:RedirectUrl"];

            if (string.IsNullOrEmpty(redirectUrl))
            {
                throw new Exception("Redirect url configuration is empty");
            }

            var redirectUri = new Uri(redirectUrl);

            var port = !redirectUri.IsDefaultPort
                ? redirectUri.Port
                : (int?)null;

            var oidcClientOptions = new OidcClientOptions
            {
                Authority = authority,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = "smintio.portals.frontend openid profile offline_access",
                RedirectUri = redirectUri.ToString(),
                Browser = new SystemBrowser(port),
                FilterClaims = false
            };

            oidcClientOptions.Policy.Discovery.ValidateIssuerName = false;
            oidcClientOptions.Policy.ValidateTokenIssuerName = false;

            return oidcClientOptions;
        }
    }
}
