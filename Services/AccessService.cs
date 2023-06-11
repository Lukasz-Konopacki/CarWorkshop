using System.Collections.Generic;
using CarWorkshop.Model;

namespace CarWorkshop.Services
{
    public interface IAccessServie
    {
        public bool IsLogged();
        public bool LogIn(string username, string password);
        public bool LogOut();
        public bool Register();
        public bool CheckPermission(UserPermission permissionToCheck);
    }

    public class AccessServie : IAccessServie
    {
        private bool _isLogged;
        private List<UserPermission> _permissions;
        private User _user;

        public AccessServie()
        {
            _isLogged = false;
            _permissions = new List<UserPermission>();
        }


        public bool LogIn(string username, string password)
        {
            _isLogged = true;
            return true;
        }

        public bool LogOut()
        {
            _isLogged = false;
            return true;
        }

        public bool Register()
        {
            return true;
        }

        public bool IsLogged()
        {
            return _isLogged;
        }

        public bool CheckPermission(UserPermission permissionToCheck)
        {
            return true;
        }
    }
}
