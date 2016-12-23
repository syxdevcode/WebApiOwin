using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiOwin.Services;

namespace WebApiOwin.PersistenceProvider
{
    public class AuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        private IClientService _clientService;

        public AuthorizationServerProvider(IClientService clientService)
        {
            _clientService = clientService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            //省略了return之前context.SetError的代码
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret)) { return; }

            var client = await _clientService.Get(clientId);
            if (client == null) { return; }
            if (client.Secret != clientSecret) { return; }

            context.OwinContext.Set<string>("as:client_id", clientId);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated(clientId);
        }

        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

            context.Validated(oAuthIdentity);
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            //验证context.UserName与context.Password 
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(oAuthIdentity);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));
            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }
    }
}