using AutoMapper;
using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Application.Helpers;
using ProgCentrTestTask.Application.QueryConsts;
using ProgCentrTestTask.Application.Services;
using ProgCentrTestTask.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProgCentrTestTask.Web.Controllers
{
    public class QueryController : Controller
    {
        
        private readonly IUserService userService;

        private readonly IQueryService queryService;

        private readonly IMapper mapper;

        public QueryController(IMapper mapper)
        {
            this.userService = new UserService(mapper);
            this.queryService = new QueryService(mapper);
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new CreateQueryModel());
        }

        [HttpPost]
        public ActionResult Add(CreateQueryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            queryService.Add(mapper.Map<QueryCreateDTO>(model));
            ViewBag.Message = "Запрос создан";
            return View(mapper.Map<QueryCreateDTO>(model));
        }

        [HttpGet]
        public ActionResult GetExecuted()
        {
            var dto = queryService.GetAllExecuted();
            var model = mapper.Map<ICollection<DisplayQueryModel>>(dto);
            return PartialView("QueryList", model);
        }

        [HttpGet]
        public ActionResult GetNotExecuted()
        {
            var dto = queryService.GetAllNotExecuted();
            var model = mapper.Map<ICollection<DisplayQueryModel>>(dto);
            return PartialView("QueryList", model);
        }

        [HttpGet]
        public ActionResult GetForUser(int userId)
        {
            var dto = queryService.GetAllForUser(userId);
            var model = mapper.Map<ICollection<DisplayQueryModel>>(dto);
            return PartialView("QueryList", model);
        }

        [HttpPost]
        public async Task<ActionResult> Execute(int queryId)
        {
            var dto = await queryService.Execute(queryId, new WebRequestHelper(ConfigurationManager.ConnectionStrings["Request"].ConnectionString));
            var model = mapper.Map<ICollection<UserModel>>(dto);
            return RedirectToAction("UsersForQuery", "User", new { queryId = queryId });
        }

    }
}