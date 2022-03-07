using Codecool.SixHandshakes.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.SixHandshakes
{
    public static class RandomDataGenerator
    {
        private const int CONNECTIVITY_STEP_THRESHOLD = 30;
        private const int MAX_NUMBER_OF_FRIENDS_AT_START = 3;
        private const int MAX_DISTANCE_FROM_FIRST = 4;

        private static readonly Random Random = new Random(1234);

        private static readonly string[] firstNames = {
            "Inez", "Emery", "Virginia", "Charissa", "Tyrone", "Ayanna", "Jena", "Ora",
            "Cooper", "Gareth", "Karleigh", "Aladdin", "Arden", "Pearl", "Mariko", "Hadley",
            "Tanya", "Madeline", "Naomi", "Maggie", "Kerry", "Elmo", "Wylie", "Alec",
            "Axel", "Belle", "Cally", "Theodore", "Emmanuel", "Christopher", "Olympia"
        };

        private static readonly string[] lastNames = {
            "Winifred", "Tanner", "Rajah", "Cedric", "Tyler", "Nicholas", "Abra", "Aurora",
            "Bryar", "Kibo", "Myles", "Hillary", "Lydia", "Dolan", "Lucian", "Prescott",
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson"
        };

        public static IEnumerable<UserNode> Generate()
        {
            var users = new List<UserNode>();
            var firstUser = CreateNewUser();
            users.Add(firstUser);

            GenerateTree(firstUser, users, MAX_DISTANCE_FROM_FIRST);

            MakeFriendShips(users);

            CreateDiamondRoute(users);

            return users;
        }

        private static void CreateDiamondRoute(List<UserNode> users)
        {
            var anotherUser = CreateNewUser();
            users.Add(anotherUser);
            anotherUser.AddFriend(users.ElementAt(0));
            anotherUser.AddFriend(users.ElementAt(108));
        }

        private static void MakeFriendShips(List<UserNode> users)
        {
            for (var i = 0; i < users.Count - CONNECTIVITY_STEP_THRESHOLD; i++)
            {
                if (ShouldConnect(i))
                {
                    users.ElementAt(i).AddFriend(users.ElementAt(i + CONNECTIVITY_STEP_THRESHOLD));
                }
            }
        }

        private static bool ShouldConnect(int indexOfUser)
        {
            return indexOfUser % 4 == 0;
        }

        private static void GenerateTree(UserNode user, List<UserNode> allUsers, int depth)
        {
            if (depth == 0)
                return;

            for (int i = 0; i < MAX_NUMBER_OF_FRIENDS_AT_START; i++)
            {
                var newUser = CreateNewUser();
                user.AddFriend(newUser);
                allUsers.Add(newUser);
                GenerateTree(newUser, allUsers, depth - 1);
            }
        }

        private static UserNode CreateNewUser()
        {
            return new UserNode(GetRandomElement(firstNames), GetRandomElement(lastNames));
        }

        private static string GetRandomElement(IEnumerable<string> enumerable)
        {
            var array = enumerable as string[] ?? enumerable.ToArray();
            return array[Random.Next(array.Length)];
        }
    }
}
