using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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

            List<Node> heads = new List<Node> { node1, node4 };

            Form form = new Form();

            form.Text = "Arrows Puzzle";
            form.Width = 620;
            form.Height = 640;

            form.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;

                int cellSize = 60;

                // Grid
                for (int i = 0; i <= 10; i++)
                {
                    g.DrawLine(
                        Pens.Black,
                        i * cellSize,
                        0,
                        i * cellSize,
                        600
                    );

                    g.DrawLine(
                        Pens.Black,
                        0,
                        i * cellSize,
                        600,
                        i * cellSize
                    );
                }

                // Nodes
                foreach (var node in heads)
                {
                    Node pos = node;

                    while (pos != null)
                    {
                        DrawNode(
                            g,
                            pos.Pos.X,
                            pos.Pos.Y,
                            cellSize
                        );

                        pos = pos.Next;
                    }
                }
            };

            Timer timer = new Timer();
            timer.Interval = 500;

            timer.Tick += (sender, e) =>
            {
                node1 = node1.MoveNodes();

                heads[0] = node1;

                form.Invalidate();
            };

            timer.Start();

            Application.Run(form);
        }

        static void DrawNode(Graphics g, int x, int y, int cellSize)
        {
            y = 9 - y;

            g.FillRectangle(
                Brushes.Blue,
                x * cellSize + 2,
                y * cellSize + 2,
                cellSize - 4,
                cellSize - 4
            );
        }
    }
}