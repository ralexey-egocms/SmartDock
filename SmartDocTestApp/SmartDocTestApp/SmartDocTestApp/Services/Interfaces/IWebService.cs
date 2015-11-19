using System;
using System.Threading.Tasks;

namespace SmartDocTestApp.Core
{
    public interface IWebService
    {
        Task<LoginObject> LogIn(string username, string password);

        Task<MenuData> GetMenuData(LoginObject currentUser);
    }
}