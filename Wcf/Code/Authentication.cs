using System;
using System.Collections.Generic;
using System.Linq;

namespace Wcf.Code
{
    public sealed class Authentication
    {
        private static readonly List<User> Users = new List<User>
        {
            new User("u1", "p1"),
            new User("u2", "p2"),
            new User("u3", "p3")
        };


        public Guid Login(string userName, string password)
        {
            lock (Users)
            {
                var user = Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower() && u.Password == password);
                if (user == null)
                {
                    throw new InvalidOperationException();
                }
                var sessionId = Guid.NewGuid();
                user.SessionId = sessionId;
                return sessionId;
            }
        }

        public void CheckSession(Guid sessionId)
        {
            lock (Users)
            {
                var user = Users.FirstOrDefault(u => u.SessionId != null && u.SessionId.Value == sessionId);
                if (user == null)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Logout(Guid sessionId)
        {
            lock (Users)
            {
                var user = Users.FirstOrDefault(u => u.SessionId != null && u.SessionId.Value == sessionId);
                if (user != null)
                {
                    user.SessionId = null;
                }
            }
        }

        private class User
        {
            public User(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }

            public string UserName { get; }

            public string Password { get; }

            public Guid? SessionId { get; set; }
        }

    }
}