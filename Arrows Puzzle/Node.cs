using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Arrows_Puzzle
{
    class Node
    {
        //properties
        private Node next;
        private Node prev;
        private Node head;

        private Vector2Int pos;

        //constructor
        public Node(Vector2Int pos)
        {
            this.pos = pos;
        }

        //getters & setters
        public Vector2Int Pos { get { return pos; } }
        public Node Next { get { return next; } set { next = value; if (value != null) value.prev = this; } }
        public Node Prev { get { return prev; } }

        //override ToString method
        public override string ToString()
        {
            return $"Node Data: {pos}, direction: {GetDirection()}" +
            $"\n Previous Node: {(Prev != null ? $"{Prev.pos}" : "null")}" +
            $"\n Next Node: {(Next != null ? $"{Next.pos}" : "null")}";
        }

        //Direction methods
        public Vector2Int GetDirection()
        {
            if (prev == null) return new Vector2Int(0, 0); // No previous node, no direction
            return new Vector2Int(pos.X - prev.pos.X, pos.Y - prev.pos.Y);
        }

        public Node GetTail()
        {
            Node node = this;

            while (node.Next != null)
                node = node.Next;

            return node;
        }



        public bool IsFree((int x, int y) grid, List<Node> heads)
        {
            var tempPos = GetTail().Pos;
            while (tempPos.X > 0 && tempPos.Y > 0 && tempPos.X < grid.x && tempPos.Y < grid.y)
            {
                tempPos += GetTail().GetDirection();
                foreach (var head in heads)
                {
                    Node node = head;
                    while (node != null)
                    {
                        if (node.Pos == tempPos && node != GetTail()) {return false;}
                        node = node.Next;
                    }
                }

            }
            return true;
        }
        
    }
}
