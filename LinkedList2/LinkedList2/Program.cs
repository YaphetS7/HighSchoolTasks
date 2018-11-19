using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
   
        public class Node
        {
            public int value;
            public Node next;
            public Node(int _value) { value = _value; }
        }

        public class LinkedList
        {
            public Node head;
            public Node tail;
            public int count;

            public LinkedList()
            {
                head = null;
                tail = null;
            }

            public void AddInTail(Node _item)
            {
                if (head == null)
                    head = _item;
                else
                    tail.next = _item;
                tail = _item;
                count++;
            }

            public Node Find(int _value)
            {
                Node node = head;
                while (node != null)
                {
                    if (node.value == _value) return node;
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
                Node node = head, temp = null;
                bool check = false;
                if (node.value == _value)
                {
                    check = true;
                    head = node.next;
                }
                else
                {
                    while (!check && node != null)
                    {
                        if (node.next != null && (node.next.value == _value))
                        {
                           
                            temp = node;
                            check = true;
                            break;
                        }
                        node = node.next;
                    }
                    if (check)
                    {
                        if (temp.next == tail)
                        {
                            tail = temp;
                            tail.next = null;
                        }
                        else
                        {
                            temp.next = node.next.next;
                            if (temp.next == tail)
                                tail = temp.next;
                        }
                    }


                }
                if (check)
                    count--;
                return check; 
            }

            public void RemoveAll(int _value)
            {
                Node node = head;
                int k = 0;
                while (node != null)
                {
                    if (node.value == _value)
                        k++;
                    node = node.next;
                }
                for (int i = 0; i < k; i++)
                    Remove(_value);
                count -= k;
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

            public bool InsertAfter(Node _nodeAfter, Node _nodeToInsert)
            {
                Node node = head;
                bool check = false;
                if (node == _nodeAfter && count == 1)
                {
                    check = true;
                    node.next = _nodeToInsert;
                    tail = _nodeToInsert;
                }
                if (node == _nodeAfter && count != 1)
                {
                    check = true;
                    if (count == 2)
                    {
                        node.next = _nodeToInsert;
                        _nodeToInsert.next = tail;
                    }
                    else
                    {
                        check = true;
                        _nodeToInsert.next = _nodeAfter.next;
                        _nodeAfter.next = _nodeToInsert;
                    }
                }
                if (!check)
                {
                    while (node.next != null && node.next != _nodeAfter)
                    {
                        
                        node = node.next;
                    }
                    if (node.next == tail && _nodeAfter == node.next)
                    {
                        tail.next = _nodeToInsert;
                        tail = _nodeToInsert;
                        check = true;
                    }
                    else
                    {
                        if (node.next == _nodeAfter)
                        {
                            _nodeToInsert.next = _nodeAfter.next;
                            _nodeAfter.next = _nodeToInsert;
                            check = true;
                        }
                    }
                }

                if (check)
                    count++;
                return check;
            }
            public void PrintList()
            {
                Node node = head;
                while (node != tail)
                {
                    Console.Write(node.value + "\t");
                    node = node.next;
                }
                Console.Write(tail.value + "\t");
            }
        }
        
    
}
