using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.Interfaces
{
    public interface IUser
    {
        List<Registration> GetUsers();
        Task<Registration> GetUserById(int id);
        Registration AddUser(Registration registration);
        void DeleteUser(Registration registration);
        Task UpdateUserAsync(int id, Registration registration);
    }
}
