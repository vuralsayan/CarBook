using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Blogs/GetAllBlogsWithAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorsDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v = "Bloglar";  
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogID = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7073/api/Comments/GetCommentCountByBlogId?id={id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCommentCountDto>(jsonData);
                ViewBag.CommentCount = values?.CommentCount ?? 0;
            }

            return View();
        }

        [HttpGet]
        public PartialViewResult CreateComment(int id)
        {
            ViewBag.blogID = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentdDto createCommentdDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentdDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7073/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail","Blog", new {id = createCommentdDto.BlogID});
            }
            return View();
        }
    }
}
