using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.Entities
{
    public class Users
    {
        public Dictionary<int, UserInfo> _users { get; }
        public int _nextUserId = 0;
        public int _nextAwardId = 0;
        public Dictionary<int, string> Awards { get; } 

        public User this[int Key]
        {
            get
            {
                return new User { Id = Key, Name = _users[Key].Name, DateOfBirth = _users[Key].DateOfBirth, Age = _users[Key].Age, Awards = GetUserAwards(Key) };
            }
        }

        public Users()
        {
            _users = new Dictionary<int, UserInfo>();
            Awards = new Dictionary<int, string>();
        }

        public void Add(string name, DateTime birthDay)
        {
            _users.Add(_nextUserId++ , new UserInfo(name, birthDay));
        }

        public bool AddNewAward(string awardName)
        {
            bool containsValue = (Awards.ContainsValue(awardName));
            if (!containsValue)
            {
                Awards.Add(_nextAwardId++, awardName);
            }

            return !containsValue;
        }

        public bool RemoveAward(int awardId)
        {
            return Awards.Remove(awardId);
        }

        public bool GiveAwardToUser(int userId, int awardId)
        {
            bool allContainsKey = (Awards.ContainsKey(awardId) && _users.ContainsKey(userId));
            if(allContainsKey)
            {
                _users[userId].GiveAward(awardId);
            }

            return allContainsKey;
        }



        public KeyValuePair<string, int>[] GetUserAwards(int userId)
        {
            UserInfo user = _users[userId];
            int[] keys = user?.Awards?.Keys.ToArray();
            KeyValuePair<string, int>[] userAwards = new KeyValuePair<string, int>[keys.Length];
            
            for(int i = 0; i < keys.Length; i++)
            {
                string awardName = (Awards.ContainsKey(keys[i]) ? Awards[keys[i]] : "(Неизвестная награда)");
                userAwards[i] = new KeyValuePair<string, int>(awardName, user.Awards[keys[i]]);
            }

            return userAwards;
        }

        public bool RemoveUserAt(int id)
        {
            return _users.Remove(id);
        }

        public User[] ToArray()
        {
            User[] users = new User[_users.Count];
            int i = 0;

            foreach( KeyValuePair<int, UserInfo> user in _users)
            {
                users[i++] = new User { Id = user.Key, Name = user.Value.Name, DateOfBirth = user.Value.DateOfBirth, Age = user.Value.Age, Awards = GetUserAwards(user.Key) };
            }

            return users;
        }
    }
}
