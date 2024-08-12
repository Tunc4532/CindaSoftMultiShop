using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents 
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {

        private readonly ICategoryService _categoryService;
        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Manuel token
            //string token = "";
            //using (var httpClient = new HttpClient())
            //{
            //    var request = new HttpRequestMessage
            //    {
            //        RequestUri = new Uri("http://localhost:5001/connect/token"),
            //        Method = HttpMethod.Post,
            //        Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //        {
            //            { "client_id", "MultiShopVisitorId" },
            //            { "client_secret", "multishopscret" },
            //            { "grant_type", "client_credentials" }
            //        })
            //    };

            //    using (var response = await httpClient.SendAsync(request))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var contend = await response.Content.ReadAsStringAsync();
            //            var tokenResponse = JsonObject.Parse(contend);
            //            token = tokenResponse["access_token"].ToString();
            //        }
            //    }

            //}

            //var client = _httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
