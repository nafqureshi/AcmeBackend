using Acme.Services.Repository.Entity;
using Acme.Shared.Enum;
using System.Collections.Generic;

namespace Acme.Services.Repository.Abstract.ServiceAbstract
{
    public interface IActivitySignupService
    {
        bool Signup(ActivitySignup request);

        List<ActivitySignup> GetAllUserActivity();

        List<ActivitySignup> GetUsersActivityWise(ActivityEnum activity);
    }
}
