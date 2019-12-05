using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HarryPotterApp.Models;
using Newtonsoft.Json;

namespace HarryPotterApp.Services
{
    public class RESTService
    {
        private readonly string BaseURL = "https://harrypotterwebapi.azurewebsites.net/api/";

        public async Task<List<HPCharacter>> GetCharacters()
        {
            var result = await GetAsync<List<HPCharacter>>("HPCharacters");
            return result;
        }

        public async Task<HPCharacter> GetUniqueCharacter(string characterId)
        {
            var result = await GetAsync<HPCharacter>("HPCharacters" + "/" + characterId);
            return result;
        }

        public async Task<HPCharacter> AddCharacter(HPCharacter character)
        {
            var result = await PostAsync("HPCharacters", character);
            return result;
        }

        public async Task<HPCharacter> EditCharacter(HPCharacter character)
        {
            var result = await EditAsync("HPCharacters", character._id, character);
            return result;
        }

        public async Task<bool> DeleteCharacter(string id)
        {
            var result = await DeleteAsync("HPCharacters", id);
            return result;
        }

        private async Task<T> GetAsync<T>(string method)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetStringAsync(BaseURL + method);
            if (String.IsNullOrEmpty(responseMessage))
                return default(T);

            return JsonConvert.DeserializeObject<T>(responseMessage);
        }

        private async Task<T> PostAsync<T>(string method, T content)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync(BaseURL + method, stringContent);
            if (!responseMessage.IsSuccessStatusCode)
                return default(T);

            return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }

        private async Task<T> EditAsync<T>(string method, string id, T content)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PutAsync(BaseURL + method + "/" + id, stringContent);
            if (!responseMessage.IsSuccessStatusCode)
                return default(T);

            return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }

        private async Task<bool> DeleteAsync(string method, string id)
        {
            var httpClient = new HttpClient();

            var responseMessage = await httpClient.DeleteAsync(BaseURL + method + "/" + id);
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
