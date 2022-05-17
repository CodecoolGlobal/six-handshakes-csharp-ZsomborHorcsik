using System;
using Codecool.SixHandshakes.Model;
using System.Collections.Generic;

namespace Codecool.SixHandshakes.Finders
{
    public static class FriendsOfFriendsFinder
    {
        public static List<UserNode> GetFriendsOfFriends(UserNode user, int dist)
        {
            int distance = 1;
            List<UserNode> currentDist = new();
            List<UserNode> visited = new() { user };
            foreach (UserNode node in user.Friends)
            {
                currentDist.Add(node);
            }

            
            while (distance != dist)
            {
                List<UserNode> nextDist = new();
                foreach (UserNode node in currentDist)
                {
                    visited.Add(node);
                    foreach (UserNode adjNode in node.Friends)
                    {
                        if (!visited.Contains(adjNode) && !currentDist.Contains(adjNode) && !nextDist.Contains(adjNode))
                        {
                            nextDist.Add(adjNode);
                        }
                    }
                }
                distance++;
                currentDist = nextDist;
            }
            return currentDist;
        }

        public static void TestOfFriendsOfFriends(UserNode user, int dist)
        {
            List<UserNode> friends = GetFriendsOfFriends(user, dist);
            foreach (UserNode friend in friends)
            {
                Console.WriteLine(friend.FirstName);
            }

        }
    }
}
