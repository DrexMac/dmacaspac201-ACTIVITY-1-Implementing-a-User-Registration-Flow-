using AutoMapper;
using dmacaspac201.Contracts;
using dmacaspac201.Contracts.LoginInfo;
using dmacaspac201.Contracts.Security;
using dmacaspac201.Contracts.Users;
using dmacaspac201.Data.Models;
using dmacaspac201.EntityFramework;
using dmacaspac201.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;

namespace dmacaspac201.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly DefaultDbContext _context;
        private readonly IMapper _mapper;
        private readonly HashHelper _hashHelper;
        private readonly IRepository<User> _userRepository;

        public UserService(IConfiguration configuration, ILogger<BaseService> logger, IMapper mapper,
            IRepository<User> userRepository, DefaultDbContext context)
            : base(configuration, logger, mapper)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public List<UserDto>? GetUsers()
        {
            var query = _userRepository.All();
            return Mapper.Map<List<UserDto>>(query);
        }

        public UserDto? GetUserByEmail(string? emailAddress = null)
        {
            if (emailAddress == null)
            {
                return null;
            }

            var query = _userRepository.All().FirstOrDefault(a => a.EmailAddress != null && a.EmailAddress.ToLower() == emailAddress!.ToLower());
            return Mapper.Map<UserDto?>(query);
        }

        public UserDto? GetUserById(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var query = _userRepository.All().FirstOrDefault(a => a.Id != null && a.Id == id);
            return Mapper.Map<UserDto?>(query);
        }

        public UserDto? UpdateUserProfile(UserDto? userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            if (userDto.Id == null || string.IsNullOrEmpty(userDto.FirstName) || string.IsNullOrEmpty(userDto.LastName))
            {
                return null;
            }

            var user = _userRepository.All().FirstOrDefault(a => a.Id != null && a.Id == userDto.Id);

            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;

                _userRepository.Update(user);

                return Mapper.Map<UserDto?>(user);
            }

            return null;
        }

        public Task<Paged<UserDto>> Search(bool? isActive = true, int? pageIndex = 1, int? pageSize = 10, string? keyword = "")
        {
            var query = _userRepository.All().AsQueryable();

            // Filter by IsActive if provided
            if (isActive.HasValue)
            {
                query = query.Where(u => u.IsActive == isActive.Value);
            }

            // Filter by keyword in FirstName, LastName, or EmailAddress
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(u => u.FirstName.ToLower().Contains(keyword) ||
                                          u.LastName.ToLower().Contains(keyword) ||
                                          u.EmailAddress.ToLower().Contains(keyword));
            }

            // Calculate total number of users that match the filters
            var totalItems = query.Count();

            // Apply pagination
            var pagedUsers = query
                .Skip((pageIndex.Value - 1) * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            // Map the results to UserDto
            var userDtos = Mapper.Map<List<UserDto>>(pagedUsers);

            // Create a Paged result to return with pagination details
            var pagedResult = new Paged<UserDto>
            {
                Items = userDtos,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalCount = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize.Value)
            };

            // Return the result wrapped in a Task
            return Task.FromResult(pagedResult);
        }

        public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = new User
            {
                EmailAddress = registerUserDto.EmailAddress,
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Role = registerUserDto.Role,
                IsActive = true,
                LoginInfos = new List<LoginInfo>
                {
                    new LoginInfo
                    {
                        Key = "password",
                        Value = _hashHelper.HashPassword(registerUserDto.Password),
                        UpdatedAt = DateTime.UtcNow
                    }
                }
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
