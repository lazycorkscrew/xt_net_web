using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.Entities
{
    public class Users
    {
        Dictionary<int, UserInfo> _users;
        int _nextId = 0;

        public User this[int Key]
        {
            get
            {
                return new User { Id =Key, Name = _users[Key].Name, DateOfBirth = _users[Key].DateOfBirth, Age = _users[Key].Age };
            }
        }

        public Users()
        {
            _users = new Dictionary<int, UserInfo>();
        }

        public void Add(string name, DateTime birthDay)
        {
            _users.Add(_nextId++ , new UserInfo(name, birthDay));
        }

        public bool RemoveAt(int id)
        {
            return _users.Remove(id);
        }

        public User[] ToArray()
        {
            User[] users = new User[_users.Count];
            int i = 0;

            foreach( KeyValuePair<int, UserInfo> user in _users)
            {
                users[i++] = new User { Id = user.Key, Name = user.Value.Name, DateOfBirth = user.Value.DateOfBirth, Age = user.Value.Age };
            }

            return users;
        }
    }
}
