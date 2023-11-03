using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        //Create a variable to hold our data
        private readonly BlogItemService _data;

        //Create a constructor
        public BlogController(BlogItemService dataFromService){
            _data = dataFromService;
        }

        //create the endpoints:
        //AddBlogItems
        [HttpPost("AddBlogItems")]
        public bool AddBlogItem(BlogItemModel newBlogItem){
            return _data.AddBlogItem(newBlogItem);
        }

        //GetAllBlogItems
        [HttpGet("GetBlogItem")]

        public IEnumerable<BlogItemModel>GetAllBlogItems(){
            return _data.GetAllBlogItems();
        }

        //GetBlogItemsByCategory
        [HttpGet("GetItemsByCategory/{Category}")]

        public IEnumerable<BlogItemModel>GetItemsByCategory(string Category){
            return _data.GetItemsByCategory(Category);
        }

        //GetAllBlogItemsByTags
        [HttpGet("GetItemsByTag/{Tag}")]

        public List<BlogItemModel>GetItemsByTag(string Tag){
            return _data.GetItemsByTag(Tag);
        }

        //GetBlogItemsByDate
        [HttpGet("GetItemsByDate/{Date}")]

        public IEnumerable<BlogItemModel>GetItemsByDate(string Date){
            return _data.GetItemsByDate(Date);
        }

        [HttpGet("GetItemsByUserId/{UserId}")]

        public IEnumerable<BlogItemModel>GetItemsByUserId(int UserId){
            return _data.GetItemsByUserId(UserId);
        }

        //UpdateBlogItems
        [HttpPost("UpdateBlogItems")]

        public bool UpdateBlogItems(BlogItemModel BlogUpdate){
            return _data.UpdateBlogItems(BlogUpdate);
        }

        //DeleteBlogItems
        [HttpPost("DeleteBlogItem/{BlogItemToDelete}")]

        public bool DeleteBlogItem(BlogItemModel BlogDelete){
            return _data.DeleteBlogItem(BlogDelete);
        }

        //GetPublishedBlogItems
        [HttpGet("GetPublishedItems")]

        public IEnumerable<BlogItemModel>GetPublishedItems(){
            return _data.GetPublishedItems();
        }
    }
}