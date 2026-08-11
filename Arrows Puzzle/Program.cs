using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrows_Puzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(new Vector2Int(3, 1));
            Node node2 = new Node(new Vector2Int(4, 1));
            Node node3 = new Node(new Vector2Int(4, 2));

            Node node4 = new Node(new Vector2Int(5, 4));

            node1.Next = node2;
            node2.Next = node3;


            List<Node> heads = new List<Node> { node1, node4};
            Console.WriteLine(node1.GetTail());
            Console.WriteLine(node1.IsFree((10, 10), heads));
        }
    }
}
