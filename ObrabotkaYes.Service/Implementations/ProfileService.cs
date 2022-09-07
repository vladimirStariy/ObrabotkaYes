using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ObrabotkaYes.DataAcessLayer.Interfaces;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Enum;
using ObrabotkaYes.Domain.Response;
using ObrabotkaYes.Domain.ViewModels;
using ObrabotkaYes.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IBaseRepository<Profile> _profileRepository;

        public ProfileService(ILogger<ProfileService> logger, IBaseRepository<Profile> profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        public async Task<BaseResponse<ProfileViewModel>> GetProfile(string Login)
        {
            try
            {
                var profile = await _profileRepository.GetAll()
                    .Select(x => new ProfileViewModel()
                    {
                        Profile_ID = x.Profile_ID,
                        Login = x.User.Login
                    })
                    .FirstOrDefaultAsync(x => x.Login == Login);
                return new BaseResponse<ProfileViewModel>()
                {
                    Result = profile,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ProfileService.GetProfile] error: {ex.Message}");
                return new BaseResponse<ProfileViewModel>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<Profile>> UpdateProfile(ProfileViewModel model)
        {
            try
            {
                var profile = await _profileRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Profile_ID == model.Profile_ID);

                profile.Login = model.Login;

                await _profileRepository.Update(profile);

                return new BaseResponse<Profile>()
                {
                    Result = profile,
                    Description = "Данные обновлены",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ProfileService.UpdateProfile] error: {ex.Message}");
                return new BaseResponse<Profile>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
