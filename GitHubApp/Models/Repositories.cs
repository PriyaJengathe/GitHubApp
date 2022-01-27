using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubApp.Models
{
    public class User
    {
        public string LogIn { get; set; }
        public string Location { get; set; }
        public string Avatar_url { get; set; }
    }
    public class Repositories
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stargazers_count { get; set; }
        public string Html_url { get; set; }
    }

    public class RepCollections
    {
        private List<Repositories> repositories;

        public List<Repositories> Repositories { get => this.repositories; set => this.repositories = value; }
    }

    public class UserViewModel
    {
        public User UserDetails { get; set; }  
        public RepCollections UserRepCollections { get; set; }
    }
}