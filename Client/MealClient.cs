using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KursachBot.Model;
using KursachBot.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Kursach.Client
{


    public class MealClient
    {
        private HttpClient _client;
        public static string _address;
        public static string _apiKey;
        public MealClient()
        {
            _address = Constants.address;
            _apiKey = Constants.apiKey;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }

        public async Task<MealGraphic> GenerateMealGraphic(string diet, string exclude, string calories)
        {
            var response = await _client.GetAsync($"/GetWeekMealGraphic?diet={diet}&exclude={exclude}&calories={calories}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<MealGraphic>(content);
            return result;
        }

        public async Task<Model> GetFindMealAsync(string id)
        {
            var response = await _client.GetAsync($"/GetMealInfbyID?id={id}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Model>(content);
            return result;
        }



        public async Task<Model[]> GetAllMeals()
        {
            var response = await _client.GetAsync($"/api/MealDB/Meal");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Model[]>(content);
            return result;
        }

        public async Task<Model> GetMealDetail(int id)
        {
            var response = await _client.GetAsync($"/api/MealDB/{id}/Meal");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Model>(content);
            return result;
        }

        public async Task PostMeal(Model model)
        {
            var stringPayload = JsonConvert.SerializeObject(model);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/MealDB/Meal", httpContent);
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Model[]>(content);
        }

        public async Task PutMeal(int id, Model model2)
        {
            var stringPayload = JsonConvert.SerializeObject(model2);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/MealDB/{id}/Meal", httpContent);
        }

        public async Task DeleteMeal(int id)
        {
            var response = await _client.DeleteAsync($"/api/MealDB/{id}/Meal");
        }

        public async Task PostNumber(Phone phone)
        {
            var stringPayload = JsonConvert.SerializeObject(phone);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/PhoneDB/Phone", httpContent);
            var content = response.Content.ReadAsStringAsync().Result;

        }
    }
}
