using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJC_GraphSearching
{
    class Graph
    {
        //FIELDS
        private int[,] adjMatrix ;
        private Dictionary<String, Vertex> vertByName = new Dictionary<string, Vertex>();
        private List<Vertex> verts = new List<Vertex>();

        //CONSTRUCTORS
        public Graph(int maxVertices)
        {
            adjMatrix = new int[maxVertices, maxVertices];
        }

        //METHODS
        public Vertex GetVertex(string name)
        {
            if(vertByName.ContainsKey(name) == true)
            {
                return vertByName[name];
            }
            else
            {
                Vertex newRoom = new Vertex(name);
                vertByName.Add(name, newRoom);
                verts.Add(newRoom);
                return newRoom;
            }
        }

        public void AddConnection(string roomA, string roomB)
        {
            Vertex vertA = GetVertex(roomA);
            Vertex vertB = GetVertex(roomB);
            int indexA = verts.IndexOf(vertA);
            int indexB = verts.IndexOf(vertB);
            adjMatrix[indexA, indexB] = 1;
            adjMatrix[indexB, indexA] = 1;
        }

        public void Reset()
        {
            foreach(Vertex v in verts)
            {
                v.Visited = false;
            }
        }

        public Vertex GetUnvisitedNeighbor(Vertex current)
        {
            int currentIndex = verts.IndexOf(current);
            for(int i = 0; i < verts.Count; i++)
            {
                
                if(adjMatrix[currentIndex,i] == 1 && verts[i].Visited == false)
                {
                    return verts[i];
                }
            }
            return null;
        }

        public void DepthFirst(String name)
        {
            Console.WriteLine("-----");
            if(vertByName.ContainsKey(name) == false)
            {
                Console.WriteLine("Vertex does not exist.");
                Console.WriteLine("-----");
                return;
            }

            Reset();

            Stack<Vertex> vertStack = new Stack<Vertex>();
            Vertex currentVert = vertByName[name];
            Console.WriteLine($"Starting at vertex {name}");
            vertStack.Push(currentVert);
            currentVert.Visited = true;

            while(vertStack.Count != 0)
            {
                Vertex adjacentUnvisitedVertex = GetUnvisitedNeighbor(vertStack.Peek());
                if (adjacentUnvisitedVertex == null)
                {
                    vertStack.Pop();
                }
                else
                {
                    Console.WriteLine($"Working on vertex {adjacentUnvisitedVertex.Name}");
                    vertStack.Push(adjacentUnvisitedVertex);
                    adjacentUnvisitedVertex.Visited = true;
                }
            }
            Console.WriteLine("-----");
            Console.WriteLine("");
        }
    }
}
