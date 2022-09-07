using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Interfaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string Login);
        Task<BaseResponse<Profile>> UpdateProfile(ProfileViewModel model);
    }
}
