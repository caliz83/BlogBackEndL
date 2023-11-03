using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Services.Context;

namespace BlogBackEndL.Services
{
    public class BlogItemService
    {

        //variable to hold data _context
        private readonly DataContext _context; //data is on the controller, context goes in the service

        //constructor 
        public BlogItemService(DataContext context){
            _context = context;
        }
        public bool AddBlogItem(BlogItemModel newBlogItem)
        {
            bool result = false;

            _context.Add<BlogItemModel>(newBlogItem);
            
            result = _context.SaveChanges() != 0;

            return result;
        }

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogItemModel> GetItemsByCategory(string Category)
        {
            return _context.BlogInfo.Where(item => item.Category == Category);
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(string Date)
        {
            return _context.BlogInfo.Where(item => item.Date == Date);
        }

        public List<BlogItemModel> GetItemsByTag(string Tag)
        {
            List<BlogItemModel>AllBlogsWithTag = new List<BlogItemModel>(); //"Tag1", "Tag2", "Tag3", "Tag4"...
            var allItems = GetAllBlogItems().ToList(); //{Tag: "Tag1", Tag: "Tag2", Tag: "Tag3", Tag: "Tag4"}
            for(int i = 0; i < allItems.Count; i++){
                BlogItemModel Item = allItems[i];
                var itemArray = Item.Tag.Split(','); //{"Tag1", "Tag2"}
                for(int j = 0; j < itemArray.Length; j++){
                    if(itemArray[j].Contains(Tag)){
                        AllBlogsWithTag.Add(Item);
                    }
                }
            }
            return AllBlogsWithTag;
        }

        public bool UpdateBlogItems(BlogItemModel BlogUpdate)
        {
            _context.Update<BlogItemModel>(BlogUpdate);
            return _context.SaveChanges() != 0; //save changes but needs to be a bool so put != 0 and it makes it one
        }

        public bool DeleteBlogItem(BlogItemModel BlogDelete)
        {
            _context.Update<BlogItemModel>(BlogDelete);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.IsPublished); //returns an array so not a list
        }

        public IEnumerable<BlogItemModel> GetItemsByUserId(int UserId)
        {
            return _context.BlogInfo.Where(item => item.UserId == UserId);
        }
    }
}