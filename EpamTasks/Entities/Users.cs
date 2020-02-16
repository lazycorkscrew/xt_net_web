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
        public Dictionary<int, Award> Awards { get; } 

        public User this[int Key]
        {
            get
            {
                return new User { Id = Key, Name = _users[Key].Name, DateOfBirth = _users[Key].DateOfBirth, Age = _users[Key].Age, Awards = GetUserAwards(Key), ProfileImagePath = _users[Key].ProfileImagePath };
            }
        }

        public Users()
        {
            _users = new Dictionary<int, UserInfo>();
            Awards = new Dictionary<int, Award>();
        }

        public void Add(string name, DateTime birthDay, bool rights, string imagePath)
        {
            _users.Add(_nextUserId++ , new UserInfo(name, birthDay, rights, imagePath));
        }

        public bool AddNewAward(string awardName, string imagePath)
        {

            Award award = new Award {id = _nextAwardId++, Name = awardName, ImagePath = imagePath };
            bool containsValue = (Awards.ContainsValue(award));
            if (!containsValue)
            {
                Awards.Add(_nextAwardId, award);
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

        public bool DepriveAwardFromUser(int userId, int awardId)
        {
            bool allContainsKey = (_users.ContainsKey(userId));
            if (allContainsKey)
            {
                _users[userId].DepriveAward(awardId);
            }

            return allContainsKey;
        }

        public KeyValuePair<Award, int>[] GetUserAwards(int userId)
        {
            UserInfo user = _users[userId];
            int[] keys = user?.Awards?.Keys.ToArray();
            KeyValuePair<Award, int>[] userAwards = new KeyValuePair<Award, int>[keys.Length];
            
            for(int i = 0; i < keys.Length; i++)
            {
                //Award awardName = new Award {Name = (Awards.ContainsKey(keys[i]) ? Awards[keys[i]] : "(Неизвестная награда)"), ImagePath = string.Empty};
                Award awardName;

                try
                {
                    awardName = new Award {id=keys[i], Name = Awards[keys[i]].Name, ImagePath = Awards[keys[i]].ImagePath };
                }
                catch(KeyNotFoundException)
                {
                    awardName = new Award {id=keys[i], Name = $"(Неизвестная награда с ID = {keys[i]})", ImagePath = string.Empty };
                }

                userAwards[i] = new KeyValuePair<Award, int>(awardName, user.Awards[keys[i]]);
            }

            return userAwards;
        }

        public void SetImageName(int id, string fileName)
        {
            _users[id].ProfileImagePath = fileName;
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
