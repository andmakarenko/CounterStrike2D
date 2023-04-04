using System;
using System.Collections.Generic;

class ShortestPathFinder
{
    private char[,] map;
    private int rows, cols;
    private int[] dr = { -1, 0, 1, 0 }; // offsets for up, right, down, left
    private int[] dc = { 0, 1, 0, -1 };

    public ShortestPathFinder(char[,] map)
    {
        this.map = map;
        this.rows = map.GetLength(0);
        this.cols = map.GetLength(1);
    }

    public List<Tuple<int, int>> FindShortestPath(Tuple<int,int> startChar, Tuple<int, int> endChar)
    {
        var startCoords = startChar;
        var endCoords = endChar;

        var queue = new Queue<Tuple<int, int>>();
        var visited = new bool[rows, cols];
        var prev = new Tuple<int, int>[rows, cols];

        queue.Enqueue(startCoords);
        visited[startCoords.Item1, startCoords.Item2] = true;

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();

            if (curr.Equals(endCoords))
            {
                break;
            }

            for (int i = 0; i < 4; i++)
            {
                int rr = curr.Item1 + dr[i];
                int cc = curr.Item2 + dc[i];

                if (rr < 0 || rr >= rows || cc < 0 || cc >= cols)
                {
                    continue; // out of bounds
                }

                if (visited[rr, cc] || map[rr, cc] == '#')
                {
                    continue; // already visited or obstacle
                }

                queue.Enqueue(new Tuple<int, int>(rr, cc));
                visited[rr, cc] = true;
                prev[rr, cc] = curr;
            }
        }

        if (prev[endCoords.Item1, endCoords.Item2] == null)
        {
            return null; // no path found
        }

        var path = new List<Tuple<int, int>>();
        var curr2 = endCoords;

        while (!curr2.Equals(startCoords))
        {
            path.Insert(0, curr2);
            curr2 = prev[curr2.Item1, curr2.Item2];
        }

        path.Insert(0, startCoords);
        return path;
    }

    private Tuple<int, int> FindCharCoords(char c)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (map[i, j] == c)
                {
                    return new Tuple<int, int>(i, j);
                }
            }
        }

        return null; // character not found
    }
}