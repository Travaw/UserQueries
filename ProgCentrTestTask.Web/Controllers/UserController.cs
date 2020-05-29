using AutoMapper;
using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Application.Services;
using ProgCentrTestTask.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProgCentrTestTask.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly IQueryService queryService;

        private readonly IMapper mapper;

        public UserController(IUserService userService, IQueryService queryService, IMapper mapper)
        {
            this.userService = userService;
            this.queryService = queryService;
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            var users = userService.GetAll();
            return View("Index",mapper.Map<ICollection<UserModel>>(users));
        }

        public ActionResult UsersForQuery(int queryId)
        {
            var users = userService.GetAllForQuery(queryId);
            return View("Index", mapper.Map<ICollection<UserModel>>(users));
        }

        [HttpPost]
        public ActionResult Search(UserModel model)
        {
            var users = userService.Search(mapper.Map<UserDTO>(model));
            return PartialView("UserList", mapper.Map<ICollection<UserModel>>(users));
        }
    }
}