using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_tree
{
    public class Splay_Tree
    {
        public Node root;
        public Splay_Tree()
        {
            root = new Node();
        }

        /// <summary>
        /// InOrderSearch для реализации Эйлерового обхода графа.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Node> InOrderSearch(Node node, List<Node> list)
        {
            if (node == null)
                return list;
            InOrderSearch(node.left, list);
            list.Add(node);
            InOrderSearch(node.right, list);
            return list;
        }

        /// <summary>
        /// Метод, делающий node корнем.
        /// </summary>
        /// <param name="node"></param>
        public void Splay(Node node)
        {

            if (node.parent == null)
            {
                root = node;
                return;
            }
            Node parent = node.parent;
            Node gparent = node.parent.parent;
            if (gparent == null)
            {
                Rotate(parent, node);
                root = node;
                return;
            }
            else
            {
                bool zigzig = (gparent.left == parent) == (parent.left == node);
                if (zigzig)
                {
                    Rotate(gparent, parent);
                    Rotate(parent, node);
                }
                else
                {
                    Rotate(parent, node);
                    Rotate(gparent, node);
                }
            }
            Splay(node);
        }
        private void Rotate(Node parent, Node child)
        {
            Node gparent = parent.parent;
            if (gparent != null)
            {
                if (gparent.left == parent)
                    gparent.left = child;
                else
                    gparent.right = child;
            }

            if (parent.left == child)
            {
                parent.left = child.right;
                child.right = parent;
                parent.parent = child;
                if (parent.left != null)
                    parent.left.parent = parent;
            }
            else
            {
                parent.right = child.left;
                parent.parent = child;
                child.left = parent;
                if (parent.right != null)
                    parent.right.parent = parent;
            }
            child.parent = gparent;
        }

        /// <summary>
        /// DFS для поиска вершины в дереве с implicit keys.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Find(Node node)
        {
            Node current = root;
            Queue<Node> que = new Queue<Node>();
            que.Enqueue(current);
            while (que.Count > 0)
            {
                if (current.left != null)
                    que.Enqueue(current.left);
                if (current.right != null)
                    que.Enqueue(current.right);
                current = que.Dequeue();
                if (current == node)
                    return true;
            }
            return false;
        }
        private Node FindMaxFrom(Node start)
        {
            while (start.right != null)
                start = start.right;
            return start;
        }
        private Node FindMinFrom(Node start)
        {
            while (start.left != null)
                start = start.left;
            return start;
        }
        public void Merge(Splay_Tree tree)
        {
            Node max = FindMaxFrom(root);
            Node min = FindMinFrom(tree.root);
            Splay(max);
            max.right = tree.root;
            tree.root.parent = max;
        }
    }
}
