using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubApp.Models;

namespace GitHubApp.Interface
{
    public interface IGitHub
    {
        Task<User>  GetUserDetails(string userName);
        Task<List<Repositories>> GetUserRepos(string userName);

    }
}
