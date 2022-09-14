using netflix.Core.Dtos;
using netflix.Core.Models;
using netflix.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Service.Abstract
{
    public interface IUserService
    {
        //Task<DataResult<UserResponseDto>> Authenticate(string userName, string password);
        //Task<DataResult<User>> GetUserWithUserName(string userName);
        Task<DataResult<UserResponseDto>> Login(UserLoginDto userLoginDto);
        Task<DataResult<User>> Register(UserRegisterDto userRegisterDto);
        Task<DataResult<UserResponseDto>> Interest(UserInterestDto userInterestDto);

        Task<DataResult<User>> Watch(WatchAddDto watchDto);
        Task<DataResult<IList<ProgramResponseDto>>> Program();
        //Task<DataResult<UserResponseDto>> UpdateUser(UserUpdateDto updateUserDto);
        //int GetUserIdFromToken(string token);
        //string PasswordToHash(string password);
        //DataResult<ActiveUserDto> ActiveUser();
        //Task<DataResult<UserResponseDto>> GetCurrentUser();
        //DataResult<ActiveUserDto> ActiveUserCompanyId();
    }
}
