using QMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using QMS.Data;

namespace QMS.Services
{
    public class AccountService
    {
        private readonly BookingContext _dbContext;
        private readonly ILogger<AccountService> _logger;

        public AccountService(BookingContext dbContext, ILogger<AccountService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            try
            {
                // ตรวจสอบไม่ให้ PersonalId ซ้ำกัน
                var existingUserById = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.PersonalId == model.PersonalId);

                if (existingUserById != null)
                {
                    throw new InvalidOperationException("รหัสบัตรประชาชนหมายเลขนี้ได้ถูกใช้งานไปแล้ว กรุณาใช้หมายเลขอื่น");
                }

                // ตรวจสอบไม่ให้ Password ซ้ำกัน
                var existingUserByPassword = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Password == model.Password);

                if (existingUserByPassword != null)
                {
                    throw new InvalidOperationException("รหัสผ่านนี้ได้ถูกใช้งานไปแล้ว กรุณาลองใหม่");
                }

                var user = new User
                {
                    PersonalId = model.PersonalId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password // ตรวจสอบให้แน่ใจว่ารหัสผ่านถูกแฮชในแอปพลิเคชันจริง
                };

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration.");
                throw; // อาจต้องการ throw exception ต่อเพื่อให้ component จัดการ
            }
        }

        public async Task<User> LoginAsync(string personalId, string password)
        {
            try
            {
                // ค้นหาผู้ใช้จากฐานข้อมูล
                var user = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.PersonalId == personalId && u.Password == password);
                return user; // คืนค่าผู้ใช้ที่ค้นพบ หรือ null ถ้าไม่พบ
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login.");
                throw; // อาจต้องการ throw exception ต่อเพื่อให้ component จัดการ
            }
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
        }

        public async Task UpdateUserAsync(User updatedUser)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(updatedUser.Id);
                if (user != null)
                {
                    user.FirstName = updatedUser.FirstName;
                    user.LastName = updatedUser.LastName;
                    user.PhoneNumber = updatedUser.PhoneNumber;

                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user.");
                throw;
            }

        }
    }
}
