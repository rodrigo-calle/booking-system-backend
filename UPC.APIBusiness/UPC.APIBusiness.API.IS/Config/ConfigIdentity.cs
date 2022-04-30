using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IS
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigIdentity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResources = new List<ApiResource>();
            apiResources.Add(
                new ApiResource(
                    "API-APP-UPC",
                    "API-APP-UPC",
                    new[]
                    {
                            JwtClaimTypes.Email,
                            JwtClaimTypes.Expiration,
                            JwtClaimTypes.Id,
                            JwtClaimTypes.IdentityProvider,
                            JwtClaimTypes.Name,
                            JwtClaimTypes.PhoneNumber,
                            JwtClaimTypes.SessionId,
                            JwtClaimTypes.ClientId
                    }
                    )
                { Scopes = new List<string>() { "email"} }
                );

            return apiResources;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            List<Client> lstReturn = new List<Client>();
                lstReturn.Add(
                    new Client()
                    {
                        ClientId = "71BB7236-C97F-46F8-A0CB-395AA0FCADDF",
                        ClientSecrets = { new Secret("AF5D9F51-276D-4D24-9E82-31A90A88C4FF".ToSha256()) },
                        AllowedGrantTypes = { GrantType.ClientCredentials },
                        AllowedScopes =  { "email", IdentityServerConstants.StandardScopes.Email }
                    }
                    );
            return lstReturn;
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[] {
                new ApiScope(name: "email", displayName: "email"),
            };
        }

       
    }
}
