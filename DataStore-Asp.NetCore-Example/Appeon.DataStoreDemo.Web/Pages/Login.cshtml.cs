using Appeon.MvcModelMapperDemo.Models;
using Appeon.DataStoreDemo.Service.Models;
using Appeon.DataStoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Appeon.MvcModelMapperDemo.Pages
{
    public class LoginModel : BasePageModel
    {
        private readonly ILoginService loginService;

        public LoginModel(ILoginService _loginService)
        {
            this.loginService = _loginService;
        }

        [BindProperty]
        public Login Login { get; set; }

        public void OnGet()
        {
            Login = new Login();
            Login.Password = "K7dMpTY=";
            Login.Firstname = "Michael.Raheem";
        }

        public IActionResult OnPost()
        {
            try
            {
                bool isExist = loginService.UserIsExist(Login.Firstname);

                if (isExist)
                {
                    bool isLogin = loginService.Login(Login.Firstname, Login.Password);

                    if (!isLogin)
                    {
                        return GenJsonResult(-1, "Login fail,The user name or password is not valid.", 0);
                    }
                    else
                    {
                        //save session
                        byte[] b_login = System.Text.Encoding.Default.GetBytes(Login.Firstname);

                        HttpContext.Session.Set("loginName", b_login);
                    }
                }
                else
                {
                    return GenJsonResult(-1, "Login fail,The user is not exist.", 0);
                }
            }
            catch (Exception e)
            {
                return GenJsonResult(-1, e.Message, 0);
            }

            return GenJsonResult(1, "", 0);
        }
    }
}