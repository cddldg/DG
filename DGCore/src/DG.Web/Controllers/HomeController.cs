using ACC.Safety;
using DG.Application.Member;
using DG.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DG.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMemberService _memberService;
        public HomeController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            
            //string encryptedOldPassword = PasswordHelper.Encrypt(oldPassword, userLogOn.UserSecretkey);
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
