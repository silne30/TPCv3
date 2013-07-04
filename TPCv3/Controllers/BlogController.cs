﻿using System;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TPCv3.Domain.Abstract;
using TPCv3.Domain.Entities;
<<<<<<< HEAD
using TPCv3.Helpers;
=======
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
using TPCv3.Models;

namespace TPCv3.Controllers{
    public class BlogController : Controller{
        #region Constants and Fields

        private const int itemsPerPage = 2;
        private readonly IBlogRepository _blogRepository;

        #endregion

        #region Constructors and Destructors

        //Constructor injecting the blog repository
        public BlogController(IBlogRepository blogRepository){
            _blogRepository = blogRepository;
        }

        #endregion

        #region Public Methods and Operators

        //Get Blog/Category Action
        public virtual ViewResult Category(string selectedCategory, int categoryPage = 1){
            var viewModel = new ListPostViewModel(_blogRepository, selectedCategory, "Category", categoryPage);
<<<<<<< HEAD
            if (viewModel.Category == null){
                throw new HttpException(404, "Category not found.");
            }
            ViewBag.Title = "The Power Coder | Category: " + selectedCategory;
            ViewBag.Caption = String.Format(@"Articles about " + "{0}", viewModel.Category.Name);
=======
            if (viewModel.Category == null)
            {
                throw new HttpException(404, "Category not found.");
            }
            ViewBag.Title = String.Format(@"Latest posts on category ""{0}""", viewModel.Category.Name);
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
            viewModel.Posts = viewModel.Posts.Take(itemsPerPage);
            return View("List", viewModel);
        }

        //Get Blog/List Action
<<<<<<< HEAD
        public virtual ActionResult List(int blogPage = 1){
            var viewModel = new ListPostViewModel(_blogRepository, blogPage);

            ViewBag.Title = "The Power Blog | Home";
=======
        public virtual ActionResult List(int page = 1){
            var viewModel = new ListPostViewModel(_blogRepository, page);

            ViewBag.Title = "Latest Posts";
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
            viewModel.Posts = viewModel.Posts.Take(itemsPerPage);
            return View("List", viewModel);
        }

        //Get Blog/Tag Action
        public virtual ViewResult Tag(string tag, int tagPage = 1){
            var viewModel = new ListPostViewModel(_blogRepository, tag, "Tag", tagPage);
<<<<<<< HEAD
            if (viewModel.Tag == null){
                throw new HttpException(404, "Tag not found.");
            }
            ViewBag.Title = "The Power Coder | Tag: " + tag;
            ViewBag.Caption = String.Format(@"Articles that mention " + "{0}", viewModel.Tag.Name);
=======
            if (viewModel.Tag == null)
            {
                throw new HttpException(404, "Tag not found.");
            }
            ViewBag.Title = String.Format(@"Latest posts tagged on ""{0}""", viewModel.Tag.Name);
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
            viewModel.Posts = viewModel.Posts.Take(itemsPerPage);
            return View("List", viewModel);
        }

        //Get Blog/Search Action
<<<<<<< HEAD
        public virtual ViewResult Search(string txtSearch, int searchPage = 1){
            ViewBag.Title = "The Power Blog - Search: " + txtSearch;
            ViewBag.Caption = String.Format(@"Lists of posts found 
                        containing ""{0}""", txtSearch);

            var viewModel = new ListPostViewModel(_blogRepository, txtSearch, "Search", searchPage);
=======
        public virtual ViewResult Search(string txtSearch, int page = 1){
            ViewBag.Title = String.Format(@"Lists of posts found 
                        for search text ""{0}""", txtSearch);

            var viewModel = new ListPostViewModel(_blogRepository, txtSearch, "Search", page);
>>>>>>> 59de76e6a20a87d878d82b2dd67d0cfdbd639233
            viewModel.Posts = viewModel.Posts.Take(itemsPerPage);
            return View("List", viewModel);
        }

        //Get Blog/Posts Action
        public virtual ViewResult Post(int month, int year, string title){
            Post post = _blogRepository.Post(month, year, title);

            if (post == null)
            {
                throw new HttpException(404, "Post not found.");
            }

            if (post.Published == false && User.Identity.IsAuthenticated == false)
            {
                throw new HttpException(401, "The post is not published");
            }
            return View(post);
        }

        //Get Blog/Feed Action
        public virtual ViewResult Feed(){
            // Create a collection of SyndicationItemobjects from the latest posts
            var posts = _blogRepository.Posts(0, 25).OrderByDescending(p => p.PostedOn);
            Response.ContentType = "text/xml";
            return View(posts);
        }

        //Get PartialViewResult Action Blog/Sidebars
        [ChildActionOnly]
        public PartialViewResult SideBars(){
            var widgetModel = new WidgetViewModel(_blogRepository);
            return PartialView("_Sidebars", widgetModel);
        }

        #endregion
    }
}