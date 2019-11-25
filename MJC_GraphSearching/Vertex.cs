using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJC_GraphSearching
{
    class Vertex
    {
        //FIELDS
        private string name;
        private bool visited;

        //PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        //CONSTRUCTORS
        public Vertex(string name)
        {
            this.name = name;
            visited = false;
        }
    }
}
