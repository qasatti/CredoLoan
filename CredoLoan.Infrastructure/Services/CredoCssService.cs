using Microsoft.Extensions.Options;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Infrastructure.Resources;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CredoLoan.Core.Exceptions;

namespace CredoLoan.Infrastructure.Services
{
    public class CredoCssService : ICredoCssService
    {
        private readonly CssApiOptions _cssApiOptions;

        public CredoCssService(
           IOptions<CssApiOptions> cssApiOptions)
        {
            _cssApiOptions = cssApiOptions.Value;
        }
        public async Task<CssFindPersonResponseModel> FindPerson(string personNumber)
        {
            return await FindPersonCall(personNumber);
        }
        public async Task<string> CssAuthorize()
        {
            return await AuthorizeCall();
        }

        private async Task<CssFindPersonResponseModel> FindPersonCall(string personNumber)
        {
            var token = await AuthorizeCall();
            var uri = _cssApiOptions.PersonEndpoint;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var body = new
            {
                personalN = personNumber
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
                throw new BadRequestException(StringResources.ErrorCssFindPerson);

            var findPersonResponse = JsonConvert.DeserializeObject<CssFindPersonResponseModel>(await response.Content.ReadAsStringAsync());
            
            return findPersonResponse;

        }
        private async Task<string> AuthorizeCall()
        {
            var uri = _cssApiOptions.AuthEndpoint;
            var client = new HttpClient();

            var data = new[]
            {
                new KeyValuePair<string, string>("client_id", "css"),
                new KeyValuePair<string, string>("client_secret", "secret"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _cssApiOptions.UserName),
                new KeyValuePair<string, string>("password",_cssApiOptions.Password),
            };

            var response = await client.PostAsync(uri, new FormUrlEncodedContent(data));
            if (!response.IsSuccessStatusCode)
                throw new BadRequestException(StringResources.ErrorCssToken);

            var authResponse = JsonConvert.DeserializeObject<CssAuthResponseModel>(await response.Content.ReadAsStringAsync());
            
            return authResponse.AccessToken;
        }
    }
}
