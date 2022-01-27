using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GitHubApp.Business;
using GitHubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GitHubApp.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public  ActionResult SearchUser()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserDetails = new User();
            userViewModel.UserRepCollections = new RepCollections();
            return View("SearchUser", userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> SearchUser(UserViewModel user)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                UserRepCollections = new RepCollections()
            };
        
            UserInfo userInfo = new UserInfo();
            string userName = user.UserDetails.LogIn;
        
            userViewModel.UserDetails = await userInfo.GetUserDetails(userName);

            //repositories
            userViewModel.UserRepCollections.Repositories = await userInfo.GetUserRepos(userName);
            return View("SearchUser", userViewModel);
     
        }
       
    }
}