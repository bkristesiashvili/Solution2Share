﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Web;

using Solution2Share.Models;
using Solution2Share.Service;
using Solution2Share.Service.Extensions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Solution2Share.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly GraphServiceClient _client;

        public HomeController(ILogger<HomeController> logger,
            IUserService userService,
            GraphServiceClient client)
        {
            _logger = logger;
            _userService = userService;
            _client = client;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [AuthorizeForScopes(Scopes = new[] {"User.Read.All"})]
        public async Task<IActionResult> Complete()
        {
            var me = await _client
                .Me
                .Request()
                .GetAsync();

            await _userService
                .CompleteRegistration(me.CompanyName, me.Department, string.Empty);

            return Redirect(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
