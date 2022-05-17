using System;
using Codecool.SixHandshakes.Model;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.SixHandshakes.Finders
{
    public static class HandshakeCalculator
    {
        public static int? GetMinimumHandshakesBetween(UserNode start, UserNode end)
        {
            bool found = false;
            int distance = 1;
            List<UserNode> watchList= new();
            List<UserNode> visited= new();
            if (start.Equals(end)) return 0;
            visited.Add(start);
            foreach (UserNode node in start.Friends)
            {
                watchList.Add(node);
            }
            do 
            {
                List<UserNode> nextDistanceNodes = new();
                foreach (UserNode node in watchList)
                {
                    if (node.Equals(end))
                    {
                        found = true;
                        return distance; 
                    }
                    visited.Add(node);
                    foreach (UserNode adjNode in node.Friends)
                    {
                        if (!visited.Contains(adjNode)) nextDistanceNodes.Add(adjNode);
                    }
                }
                watchList = nextDistanceNodes;
                distance++;
            } while (found);
            return distance;
        }
    }

}
