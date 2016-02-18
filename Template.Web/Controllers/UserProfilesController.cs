using Demo.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models.Domain.UserModels;
using Demo.ServicesPortable.UserProfileService;
using Demo.Validation;

namespace Demo.Web.Controllers
{
    public class UserProfilesController : Controller
    {
        private UserProfileService userProfileService;

        public UserProfilesController(UserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        // GET: UserProfiles
        public ActionResult Index()
        {
            var models = userProfileService.GetProfiles().ToList();

            return View(models);
        }

        public ActionResult Create()
        {
            var model = new UserProfile();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserProfile model)
        {

            var validator = new UserProfileValidator();

            var result = validator.Validate(model);

            if (result.IsValid)
            {               

                userProfileService.SaveProfile(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Update(int id)
        {
            var model = userProfileService.GetProfiles(x => x.Id == id).FirstOrDefault();

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                userProfileService.SaveProfile(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}