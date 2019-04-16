using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_tree
{
    class EulerTourTree
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// Класс, реализующий какое-либо ребро графа с направлением left-right.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Доступные для ребра вершины left и right.
        /// </summary>
        public Node left, right;

        public bool hit = false;
        public Edge()
        {

        }
        public Edge(Node first, Node second)
        {
            left = first;
            right = second;
        }
    }

    /// <summary>
    /// Класс, реализующий какую-либо вершину графа.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Список ребер, связанных с текущей вершиной Node.
        /// </summary>
        public List<Edge> edges = new List<Edge>();

        public Node parent, left, right;
        public Node()
        {
            parent = null;
            left = null;
            right = null;
        }
    }

    /// <summary>
    /// Класс, содержащий отдельные Эйлеровы графы.
    /// </summary>
    public class Set
    {
        /// <summary>
        /// Инициализирует новый граф с корнем node
        /// </summary>
        /// <param name="node"></param>
        public Set(Node node)
        {
            tree.root = node;
        }

        /// <summary>
        /// Проверка на принадлежность node к данному графу.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Check(Node node)
        {
            return (tree.Find(node));
        }

        /// <summary>
        /// Splay-tree with implicit keys, хранящее в себе Эйлеров обход графа.
        /// </summary>
        public Splay_Tree tree = new Splay_Tree();

        /// <summary>
        /// Изменение текущего корня в эйлеровом графе.
        /// </summary>
        /// <param name="newroot"></param>
        public void NewRoot(Node newroot)
        {
            if (Check(newroot))
                tree.Splay(newroot);
        }

        /// <summary>
        /// Эйлеров обход графа.
        /// </summary>
        /// <returns></returns>
        public List<Node> EulerTour()
        {
            return tree.InOrderSearch(tree.root, new List<Node>());
        }
    }
    /// <summary>
    /// Класс, реализующий дерево Эйлерового обхода.
    /// </summary>
    public class ETT
    {
        /// <summary>
        /// Список эйлеровых графов в текущей системе.
        /// </summary>
        public List<Set> list = new List<Set>();

        /// <summary>
        /// Проверка принадлежности двух вершин одному графу.
        /// </summary>
        /// <returns></returns>
        public bool Equivalence(Node first, Node second)
        {
            if (first == null || second == null)
                return false;
            return (FindParent(first) == FindParent(second));
        }

        /// <summary>
        /// Метод добавления ребра между Эйлеровыми деревьями.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void AddEdge(Node first, Node second)
        {
            if (FindParent(first) != FindParent(second))
            {
                return;
            }
            Edge edge1 = new Edge(first, second);
            Edge edge2 = new Edge(second, first);
            first.edges.Add(edge1);
            first.edges.Add(edge2);
            second.edges.Add(edge1);
            second.edges.Add(edge2);

            Set set1 = FindSet(first);
            Set set2 = FindSet(second);
            set1.tree.Merge(set2.tree);
            list.Remove(set2);
        }
        private Set FindSet(Node node)
        {
            foreach (Set set in list)
            {
                if (set.Check(node))
                    return set;
            }
            return null;
        }
        private Node FindParent(Node node)
        {
            while (node.parent != null)
            {
                node = node.parent;
            }
            return node;
        }
    }
}
