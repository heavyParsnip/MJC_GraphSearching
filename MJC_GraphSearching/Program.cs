using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJC_GraphSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myGraph = new Graph(6);
            myGraph.AddConnection("Courtyard", "Boiler Room");
            myGraph.AddConnection("Courtyard", "Foyer");
            myGraph.AddConnection("Courtyard","Library");
            myGraph.AddConnection("Foyer","Library");
            myGraph.AddConnection("Library", "Archive");
            myGraph.AddConnection("Library", "Exit");
            myGraph.AddConnection("Archive", "Exit");

            myGraph.DepthFirst("Foyer");
            myGraph.DepthFirst("Boiler Room");
            myGraph.DepthFirst("Exit");
            Console.ReadLine();
        }
    }
}
