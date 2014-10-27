using System;
using DataAccess.Entity;
using DataAccess.Repository;

namespace DataAccess.Service
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository usersRepository = RepositoryFactory.GetUsersRepository();
            AuthenticationService.LoggedUser = usersRepository.GetByUsernameAndPassword(username, password);
        }
    }
}
