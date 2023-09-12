using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using lizg1.BlogBackEndL.Services.Context;

namespace lizg1.BlogBackEndL.Services
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
            _context.Add(newBlogItem);

            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return ;
        }

        public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        {
            return ;
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return ;
        }

        public List<BlogItemModel> GetItemsByTag(string tag)
        {
            return ;
        }

        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
            return ;
        }

        public bool DeleteBlogItem(BlogItemModel blogDelete)
        {
            return ;
        }
    }
}