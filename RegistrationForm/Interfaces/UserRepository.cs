using Microsoft.EntityFrameworkCore;
using RegistrationForm.Contexts;
using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.Interfaces
{
    public class UserRepository : IUser
    {
        private readonly RegistrationDbContext _registrationDbContext;

        public UserRepository(RegistrationDbContext registrationDbContext)
        {
            _registrationDbContext = registrationDbContext;
        }

        public Registration AddUser(Registration registration)
        {
            _registrationDbContext.Add(registration);
            _registrationDbContext.SaveChanges();
            return (registration);
        }

        public void DeleteUser(Registration registration)
        {
            _registrationDbContext.registration.Remove(registration);
            _registrationDbContext.SaveChanges();
        }

        public async Task<Registration> GetUserById(int id)
        {
            Registration reg = new Registration();
            try
            {
                reg = await _registrationDbContext.registration.FirstOrDefaultAsync(registration => registration.UserId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reg;
        }

        public List<Registration> GetUsers()
        {
            var users = _registrationDbContext.registration.ToList();
            return users;
        }

        public async Task UpdateUserAsync(int id, Registration registration)
        {
            var user = await _registrationDbContext.registration.FindAsync(id);
            if(user != null)
            {
                user.FirstName = registration.FirstName;
                user.LastName = registration.LastName;
                user.MobileNumber = registration.MobileNumber;
                user.EmailId = registration.EmailId;
                user.Gender = registration.Gender;
                user.Country = registration.Country;

                await _registrationDbContext.SaveChangesAsync();
            }
        }
    }
}
