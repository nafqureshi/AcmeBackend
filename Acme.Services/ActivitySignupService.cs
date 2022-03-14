using Acme.Data.DBRepository.Concrete;
using Acme.Data.DBRepository.Entity;
using Acme.Services.Repository.Abstract.ServiceAbstract;
using Acme.Services.Repository.Entity;
using Acme.Shared.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Services
{
    public class ActivitySignupService : IActivitySignupService
    {
        private readonly DbContext context;

        private User userData;

        private UserActivity userActivityData;

        public ActivitySignupService (DbContext context)
        {
            this.context = context;
        }

        public bool Signup(ActivitySignup request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return false; 

            userData = new User()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            userActivityData = new UserActivity()
            {
                Email = request.Email,
                Activity = request.Activity,
                YearsOfExperience = request.YearsOfExperience,
                StartDate = request.StartDate,
                Comments = request.Comments
            };

            var user = context.Set<User>().Local.FirstOrDefault(x => x.Email == request.Email);
            //same user filling out for presumably a new activity or updating his/her details
            if (user != null)
            {
                context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                var userActivity = context.Set<UserActivity>().Local.FirstOrDefault(x => x.Email == request.Email && x.Activity == request.Activity);
                if (userActivity != null)
                    context.Entry(userActivity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                context.UpdateUserActivity(userData, userActivityData, userActivity == null);
            }
            else
            {
                //new user activity signup
                context.InsertUserActivity(userData, userActivityData);
            }

            return true;
        }

        public List<ActivitySignup> GetAllUserActivity()
        {
            return context.User.Join(context.UserActivity, user => user.Email, userActivity => userActivity.Email,
                (user, userActivity) => new ActivitySignup
                {
                    Email = user.Email,
                    Activity = userActivity.Activity,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    YearsOfExperience = userActivity.YearsOfExperience,
                    StartDate = userActivity.StartDate,
                    Comments = userActivity.Comments
                }).OrderBy(x => x.Email).ThenBy(x => x.Activity).ToList();
        }

        public List<ActivitySignup> GetUsersActivityWise(ActivityEnum activity)
        {
            return GetAllUserActivity().Where(x => x.Activity == activity).ToList();
        }
    }
}
