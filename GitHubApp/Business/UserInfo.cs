using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GitHubApp.Interface;
using GitHubApp.Models;
using Newtonsoft.Json;

namespace GitHubApp.Business
{
    public class UserInfo : IGitHub
    {
        private HttpClient _client;
       
        public UserInfo()
        {
            _client = getClient();

        }
        private HttpClient getClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubApp", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public async Task<User> GetUserDetails(string userName)
        {
            try
            {
                var response = await _client.GetAsync($"/users/{userName}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(stringResult);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Repositories>> GetUserRepos(string userName)
        {
            try
            {
                var response = await _client.GetAsync($"/users/{userName}/repos");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Repositories>>(stringResult);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}