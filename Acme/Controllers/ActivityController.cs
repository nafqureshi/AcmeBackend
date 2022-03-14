using Acme.Services.Repository.Abstract.ControllerAbstract;
using Acme.Services.Repository.Abstract.ServiceAbstract;
using Acme.Services.Repository.Entity;
using Acme.Shared.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acme.Controllers
{
    [ApiController]
    [Route("activity")]
    public class ActivityController : ControllerBase, IActivitySignupController
    {
        public IActivitySignupService ActivitySignupService { get; set; }

        [HttpPost]
        [Route("signup")]
        public bool Signup(ActivitySignup request)
        {
            return ActivitySignupService.Signup(request);
        }

        [HttpGet]
        [Route("get")]
        public List<ActivitySignup> GetAllUserActivity()
        {
            return ActivitySignupService.GetAllUserActivity();
        }

        [HttpGet]
        [Route("get/activity/{activity}")]
        public List<ActivitySignup> GetUsersActivityWise(ActivityEnum activity)
        {
            return ActivitySignupService.GetUsersActivityWise(activity);
        }
    }
}
