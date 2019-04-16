using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGraph
{
    class DynGraph
    {
        static void Main(string[] args)
        {
            DynamicGraphWithConnectivity<int> g = new DynamicGraphWithConnectivity<int>();
            Node<int> a = new Node<int>(0);
            Node<int> b = new Node<int>(1);
            Node<int> c = new Node<int>(2);
            Node<int> d = new Node<int>(3);
            g.MakeSet(a);
            g.MakeSet(b);
            g.MakeSet(c);
            g.MakeSet(d);
            g.AddEdge(a, b);
            g.AddEdge(b, c);
            g.AddEdge(a, c);
            g.AddEdge(a, d);
            foreach(Set<int> set in g.list)
            {
                foreach (Edge<int> edge in set.edges)
                    Console.WriteLine(edge.left.value + " " + edge.right.value); // 0 3
            }
        }
    }
    public class Edge<T>
    {
        public Node<T> left;
        public Node<T> right;
        public Edge()
        {

        }
        public Edge(Node<T> left, Node<T> right)
        {
            this.left = left;
            this.right = right;
        }
    }
    /// <summary>
    /// Класс, реализующий граф с помощью adjacency list(список смежных вершин).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public List<Node<T>> childs = new List<Node<T>>();
        public int tin, fup;
        /// <summary>
        /// Ссылка на представителя рёберной двусвязности.
        /// Представитель рёберной двусвязности - любой(в реализации - первый) добавленный узел в компоненту
        /// </summary>
        public Node<T> parent;
        public T value;
        public bool hit = false;
        public Node(T value)
        {
            this.value = value;
            parent = null;
        }
    }
    /// <summary>
    /// Класс, реализующий компоненты связности.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Set<T>
    {

        /// <summary>
        /// Представитель компоненты(любой узел из компоненты).
        /// </summary>
        public Node<T> root;

        /// <summary>
        /// Список мостов(ребер, при удалении которых увеличивается кол-во компонент связности).
        /// </summary>
        public List<Edge<T>> edges = new List<Edge<T>>();

        public List<Node<T>> nodes = new List<Node<T>>();
        public void AddRoot(Node<T> root)
        {
            this.root = root;
            this.root.parent = root;
        }
    }
    /// <summary>
    /// Класс, реализующий динамический граф с поддержкой компонент связности.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicGraphWithConnectivity<T>
    {
        /// <summary>
        /// Список подграфов(компонент связности).
        /// </summary>
        public List<Set<T>> list = new List<Set<T>>();

      

        /// <summary>
        /// Количество текущих подграфов(компонент связности).
        /// </summary>
        public int cntOfSets = 0;

        /// <summary>
        /// Добавление нового подграфа(компоненты связности) в текущую систему.
        /// </summary>
        /// <param name="node"></param>
        public void MakeSet(Node<T> node)
        {
            Set<T> newset = new Set<T>();
            node.parent = node;
            newset.AddRoot(node);
            list.Add(newset);
            cntOfSets++;
        }

        /// <summary>
        /// Ищет представителя компоненты связности.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> Find(Node<T> node)
        {
            while(node.parent != node)
            {
                node = node.parent;
            }
            return node;
        }

        /// <summary>
        /// Добавление ребра между вершинами first и second.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void AddEdge(Node<T> first, Node<T> second)
        {
            if (!first.childs.Contains(second))
            {
                first.childs.Add(second);
                second.childs.Add(first);
                if (first.parent == second.parent)//если добавляется ребро для узлов в одной компоненте связности
                {
                   
                    CheckOnEdges();
                }
                else
                {
                    Unite(first, second);
                }
            }
        }

        /// <summary>
        /// Удаление ребра между first и second, если они находятся в одной компоненте связности.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void DelEdge(Node<T> first, Node<T> second)
        {
            if(first.parent != second.parent)//если вершины находятся в разных компонентах связности
            {
                return;
            }
            first.childs.Remove(second);
            second.childs.Remove(first);
            foreach (Set<T> set in list)
            {
                foreach (Edge<T> edge in set.edges)
                {
                    if ((edge.left == first || edge.right == first) && (edge.left == second || edge.right == second))//если удаляется мост
                    {
                        set.edges.Remove(edge);
                        Split(first, second);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Проверка на принадлежность одной компоненте связности вершин first и second.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool Equivalence(Node<T> first, Node<T> second)
        {
            return (first.parent == second.parent);
        }
        // Разъединяет компоненту связности на две после удаления моста.
        private void Split(Node<T> first, Node<T> second)
        {
            BFS(first);
            BFS(second);
        }
        // Обход в ширину, который выделяет компоненту связности.
        private void BFS(Node<T> start)
        {
            Set<T> newset = new Set<T>();
            Queue<Node<T>> que = new Queue<Node<T>>();
            foreach (Set<T> set in list)
            {
                if (set.root.childs.Contains(start))
                {
                    list.Remove(set);
                    break;
                }
            }
            que.Enqueue(start);
            newset.AddRoot(start);
            start.hit = true;
            while(que.Count > 0)
            {
                que.First().parent = start;
                que.First().hit = true;
                newset.nodes.Add(que.First());
                foreach(Node<T> node in que.First().childs)
                {
                    if (!node.hit)
                        que.Enqueue(node);
                }
                que.Dequeue();
            }
            list.Add(newset);
            HitOff(newset);
        }
        // Убирает с вершин пометки о том, что они были посещены по время обходов.
        private void HitOff(Set<T> set)
        {
            foreach(Node<T> node in set.nodes)
            {
                node.hit = false;
            }
        }
        public int timer = 0;
        private void DFS(Node<T> v, Node<T> parent, Set<T> set)
        {
            v.hit = true;
            v.tin = v.fup = timer++;
            foreach(Node<T> child in v.childs)
            {
                if (child == parent)
                    continue;
                if(child.hit)
                {
                    v.fup = Math.Min(v.fup, child.fup);
                }
                else
                {
                    DFS(child, v, set);
                    v.fup = Math.Min(v.fup, child.fup);
                    if (child.fup > v.tin)
                        set.edges.Add(new Edge<T>(child, v));
                }
            }
            
        }
        // Поиск мостов в подграфах(в компонентах связности)
        private void CheckOnEdges()
        {
            foreach(Set<T> set in list)
            {
                set.edges.Clear();
                foreach (Node<T> node in set.nodes)
                {
                    DFS(node, null, set);
                }
                HitOff(set);
            }
            timer = 0;
        }

        // Объединяет две компоненты связности в одну.
        private void Unite(Node<T> first, Node<T> second)
        {
            Set<T> temp = new Set<T>();
            Node<T> node1 = Find(first);
            Node<T> node2 = Find(second);
            if (node1 == node2)
                return;
            node1.parent = node2;

            // Эвристика сжатия путей(переподвешивание дочерних узлов к родительскому)
            foreach (Node<T> node in node1.childs) 
                node.parent = node2;

            foreach (Node<T> node in node2.childs)
                node.parent = node2;

            temp.edges.Add(new Edge<T>(first, second));
            temp.nodes.AddRange(node1.childs);
            temp.nodes.AddRange(node2.childs);
            temp.nodes.Remove(node1);
            temp.nodes.Remove(node2);
            temp.AddRoot(node2);
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].nodes.Contains(node1))
                {
                    list.Remove(list[i]);
                    i--;
                    continue;
                }
                if(list[i].nodes.Contains(node2))
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
            list.Add(temp);
            cntOfSets--;
        }
    }
}
