using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public void Print()
        {
            Node node = head;
            while (node != null)
            {
                Console.Write(node.value + "\t");
                node = node.next;
            }
        }
        public int count = 0;
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }
        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
            count++;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (count == 0)
                return false;
            Node node, temp;
            node = Find(_value);

            if (node == head)
            {
                if (count > 1)
                {
                    temp = node.next;
                    node = null;
                    head = temp;
                    head.prev = null;
                    count--;
                    return true;
                }
                else
                {
                    head = null;
                    tail = null;
                    count--;
                    return true;
                }
              
            }
            else
               if (node == tail)
            {
                temp = node.prev;
                temp.next = null;
                tail = temp;
                count--;
                return true;
                
            }
            else
            {
                if (node != null)
                {
                    node = node.prev;
                    temp = node.next.next;
                    node.next = temp;
                    temp.prev = node;
                    count--;
                    return true;
                }
                else
                    return false;
            }
        }

        public void RemoveAll(int _value)
        {
            if (count == 0)
                return;
            Node node = head;
            int cnt = 0;
            while (node != null)
            {
                if (node.value == _value)
                    cnt++;
                node = node.next;
            }
            for (int i = 0; i < cnt; i++)
                Remove(_value);
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Count()
        {
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null || _nodeAfter == tail)
            {
                AddInTail(_nodeToInsert);
                return;
            }
            if (_nodeAfter == head)
            {
                Node lol = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.next = lol;
                lol.prev = _nodeToInsert;
                _nodeToInsert.prev = _nodeAfter;
                return;
            }

            Node node, newnode, temp;
            node = _nodeAfter;
            temp = node.next;
            newnode = _nodeToInsert;
            node.next = newnode;
            newnode.next = temp;
            temp.prev = newnode;
            newnode.prev = node;
            count++;
        }

    }
}
