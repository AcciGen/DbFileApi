using DbFileApi.Domain.Entities.DTOs;
using DbFileApi.Domain.Entities.Models;
using DbFileApi.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DbFileApi.Application.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileService
    {

        private readonly ApplicationDbContext _context;


        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<string> CreateUserProfileAsync(UserProfileDTO userDTO, string picturePath)
        {

            var model = new UserProfile()
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                UserRole = userDTO.UserRole,
                Login = userDTO.Login,
                Password = userDTO.Password,
                PicturePath = picturePath,
            };

            await _context.Users.AddAsync(model);

            await _context.SaveChangesAsync();

            return "Created";
        }

        public async Task<bool> DeleteUserProfileAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.Users.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<UserProfile>> GetAllUserProfileAsync()
        {
            var result = await _context.Users.ToListAsync();

            return result;
        }

        public async Task<UserProfile> GetByIdUserProfileAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                return result!;
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<UserProfile> UpdateUserProfileAsync(int id, UserProfileDTO modelDTO)
        {
            var result = await _context.Users.FirstAsync(x => x.Id == id);

            if (result != null)
            {
                result.FullName = modelDTO.FullName;
                result.Phone = modelDTO.Phone;
                result.UserRole = modelDTO.UserRole;
                result.Login = modelDTO.Login;
                result.Password = modelDTO.Password;

                await _context.SaveChangesAsync();

                return result!;
            }
            return null!;
        }
    }
}
