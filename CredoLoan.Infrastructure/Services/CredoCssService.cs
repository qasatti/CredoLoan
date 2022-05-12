using AutoMapper;
using Microsoft.Extensions.Options;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Infrastructure.Resources;
using CredoLoan.Core.SharedKernel;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
        public async Task<ResponseResult<CssFindPersonResponseModel>> FindPerson(string personNumber)
        {
            try
            {
                var response = await FindPersonCall(personNumber);
                return new ResponseResult<CssFindPersonResponseModel>(response);
            }
            catch (Exception ex)
            {
                return new ResponseResult<CssFindPersonResponseModel>(null, $"{StringResources.InternalErrorOccured}: {ex.Message}", true);
            }

        }
        public async Task<ResponseResult> CssAuthorize()
        {
            try
            {
                var response = await AuthorizeCall();
                return new ResponseResult<string>(response);
            }
            catch (Exception ex)
            {
                return new ResponseResult($"{StringResources.InternalErrorOccured}: {ex.Message}", true);
            }
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
            {
                throw new Exception("Issue finding person");
            }
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
            {
                throw new Exception("Issue in getting token");
            }
            var authResponse = JsonConvert.DeserializeObject<CssAuthResponseModel>(await response.Content.ReadAsStringAsync());
            return authResponse.AccessToken;
        }
    }
}
