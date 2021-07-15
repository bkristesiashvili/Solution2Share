using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Solution2Share.Service;

namespace Solution2Share.Controllers
{
    public class AccountController : Controller
    {
        #region PRIVATE FIELDS

        private readonly IOptions<GraphOption> _options;
        private readonly IUserService _userService;

        #endregion

        #region CTOR

        public AccountController(IOptions<GraphOption> options, 
            IUserService userService)
        {
            _options = options;
            _userService = userService;
            _userService.InitializeGraphClient(options.Value);
        }

        #endregion

        #region ACTIONS

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
