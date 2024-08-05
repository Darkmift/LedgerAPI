using LedgerAPI.DTOs;
using LedgerAPI.Models;

namespace LedgerAPI.Extensions
{
    public static class UserExtensions
    {
        public static User dtoToModel(this AddUserDTO userDTO)
        {

            return new User
            {
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname
            };
        }
    }
}
