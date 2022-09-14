using Microsoft.EntityFrameworkCore;
using netflix.Core.Dtos;
using netflix.Core.Enums;
using netflix.Core.Models;
using netflix.Core.Results;
using netflix.Repository.Abstract;
using netflix.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly IUserInterestRepository _userInterestRepository;
        private readonly IProgramRepository _programRepository;
        private readonly IProgramInterestRepository _programInterestRepository;

        public UserService(IUserRepository userRepository, IInterestRepository interestRepository, IUserInterestRepository userInterestRepository, IProgramRepository programRepository, IProgramInterestRepository programInterestRepository)
            {
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _userInterestRepository = userInterestRepository;
            _programRepository = programRepository;
            _programInterestRepository = programInterestRepository;
        }

        public async Task<DataResult<User>> Login(UserLoginDto loginUser)
        {
            try
            {
                var user = await _userRepository.GetAsync(x => x.Email == loginUser.Email);
                
                if(user.Password == loginUser.Password)
                {
                    return new DataResult<User>(user);
                }

                return new DataResult<User>(false, null, "Login işleminde hata","");

            }
            catch (Exception e)
            {
                return new DataResult<User>(false, null, "Login işleminde hata", e.Message);
            }
        }

        public async Task<DataResult<User>> Register(UserRegisterDto createUser)
        {
            try
            {
                createUser.Password = createUser.Password;
                //var asd = await _userRepository.AnyAsync(u => u.Email == createUser.Email);

                var user = new User()
                {
                    UserName = createUser.UserName,
                    Email = createUser.Email,
                    Password = createUser.Password,
                    Birthday = DateTime.Parse(createUser.Birthday),
                    CreatedDate = DateTime.Now,
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChanges();

                return new DataResult<User>(user);

            }
            catch (Exception e)
            {
                return new DataResult<User>(false, null, "Register işleminde hata", e.Message);
            }
        }

        public async Task<DataResult<User>> Interest(UserInterestDto userInterestDtoList)
        {
            //throw new NotImplementedException();
            try
            {
                var userModel = await _userRepository.GetAsync(x => x.Id == userInterestDtoList.userId);

                //var userInterestList = new List<UserInterest>();
                foreach (var userInterestId in userInterestDtoList.InterestId)
                {
                    var interestModel = await _interestRepository.GetAsync(x => x.Id == userInterestId);
                    var userInterest = new UserInterest()
                    {
                        User = userModel,
                        Interest = interestModel,
                        //Name = (InterestEnum)userInterestId,
                    };

                    //userInterestList.Add(userInterest);
                    await _userInterestRepository.AddAsync(userInterest);
                }


                //userModel.Interests = interestList;

                await _userInterestRepository.SaveChanges();

                return new DataResult<User>(userModel);

            }
            catch (Exception e)
            {
                return new DataResult<User>(false, null, "Register işleminde hata", e.Message);
            }
        }

        public async Task<DataResult<IList<ProgramResponseDto>>> Program()
        {
            try
            {
                var programs = await _programRepository.GetAllAsync();

                var programResponseList = new List<ProgramResponseDto>(); // json body

                foreach (var program in programs)
                {
                    var programResponse = new ProgramResponseDto(); // json body each item

                    programResponse.Name = program.Name;
                    programResponse.EpisodeCount = program.EpisodeCount;
                    programResponse.Duration = program.Duration;
                    programResponse.Type = program.Type;

                    // json body for interest array
                    var programInterests = await _programInterestRepository.GetAllWithThenInclude().Where(x => x.Program.Id == program.Id)
                        .Include(x => x.Interest)
                        .Include(x => x.Program)
                        .ToListAsync();
                    var interestStringList = new List<string>();
                    foreach (var programInterest in programInterests)
                    {
                        interestStringList.Add(programInterest.Interest.Name);

                    }
                    // json body build
                    programResponse.Interests = interestStringList;
                    programResponseList.Add(programResponse);
                }

                return new DataResult<IList<ProgramResponseDto>>(programResponseList);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<ProgramResponseDto>>(false, null, "Register işleminde hata", ex.Message);
            }
        }
    }
}
