using System;
using System.Collections.Generic;

namespace Codecool.SixHandshakes.Model
{
    public class UserNode
    {
        /// <summary>
        ///     This value is used by the shortest path finder
        /// </summary>
        public int? Depth { get; set; }

        public long ID { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public HashSet<UserNode> Friends { get; }

        private static long _idCounter;

        public UserNode(string firstName, string lastName)
        {
            ID = _idCounter++;
            FirstName = firstName;
            LastName = lastName;

            Friends = new HashSet<UserNode>();
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return $"{FirstName}_{LastName} ({ID})";
        }

        public override bool Equals(object o)
        {
            if (this == o)
                return true;

            if (o is UserNode userNode)
                return ID == userNode.ID && FirstName.Equals(userNode.FirstName) && LastName.Equals(userNode.LastName);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, FirstName, LastName);
        }
    }
}