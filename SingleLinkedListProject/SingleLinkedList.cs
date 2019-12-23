using System;

namespace SingleLinkedListProject
{
    public class SingleLinkedList
    {
        private Node _start;

        public SingleLinkedList()
        {
            _start = null;
        }

        public void DisplayList()
        {
            if (_start == null)
            {
                Console.WriteLine("List is null");
                return;
            }

            Console.Write("List is : ");
            var p = _start;
            while (p != null)
            {
                Console.Write(p.Info + " ");
                p = p.Link;
            }

            Console.WriteLine();
        }

        public void CountNodes()
        {
            var n = 0;
            var p = _start;
            while (p != null)
            {
                n++;
                p = p.Link;
            }

            Console.WriteLine("Number of nodes in the list = " + n);
        }

        public bool Search(int x)
        {
            var position = 1;
            var p = _start;
            while (p != null)
            {
                if (p.Info == x)
                    break;

                position++;
                p = p.Link;
            }

            if (p == null)
            {
                Console.WriteLine(x + " not found in list");
                return false;
            }

            Console.WriteLine(x + " is at position " + position);
            return true;
        }

        public void CreateList()
        {
            int i;
            Console.Write("Enter the number of nodes : ");
            var n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;

            for (i = 1; i <= n; i++)
            {
                Console.Write("Enter the element to be inserted : ");
                var data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }

        public void InsertInBeginning(int data)
        {
            var temp = new Node(data)
            {
                Link = _start
            };

            _start = temp;
        }

        public void InsertAtEnd(int data)
        {
            var temp = new Node(data);
            if (_start == null)
            {
                _start = temp;
                return;
            }

            var p = _start;

            while (p.Link != null)
                p = p.Link;

            p.Link = temp;
        }

        public void InsertAfter(int data, int x)
        {
            // If list is empty
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            // Find reference to successor of node containing x
            var p = _start;
            while (p != null)
            {
                if (p.Info == x)
                    break;

                p = p.Link;
            }

            // Check p khong ton tai
            if (p == null)
                Console.WriteLine($"{x} not present in the list");

            else
            {
                var temp = new Node(data)
                {
                    Link = p.Link
                };

                p.Link = temp;
            }
        }

        public void InsertBefore(int data, int x)
        {
            Node temp;
            // If list is empty
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            // x is in first node, new node is inserted before first node
            if (x == _start.Info)
            {
                temp = new Node(data) {Link = _start};
                _start = temp;
                return;
            }

            // Find reference to predecessor of node containing x
            var p = _start;
            while (p.Link != null)
            {
                if (p.Link.Info == x)
                    break;

                p = p.Link;
            }

            if (p.Link == null)
                Console.WriteLine($"{x} not present in the list");

            else
            {
                temp = new Node(data)
                {
                    Link = p.Link
                };

                p.Link = temp;
            }
        }

        public void InsertAtPosition(int data, int k)
        {
            Node temp;
            int i;

            if (k == 1)
            {
                temp = new Node(data)
                {
                    Link = _start
                };

                _start = temp;
            }

            var p = _start;
            for (i = 1; i < k - 1 && p != null; i++) // find a refence to k-1 node
            {
                p = p.Link;
            }

            if (p == null)
                Console.WriteLine($"You can insert only upto {i} th position");

            else
            {
                temp = new Node(data)
                {
                    Link = p.Link
                };

                p.Link = temp;
            }
        }

        public void DeleteFirstNode()
        {
            if (_start == null)
                return;

            _start = _start.Link;
        }

        public void DeleteLastNode()
        {
            if (_start == null)
                return;

            if (_start.Link == null)
            {
                _start = null;
                return;
            }

            var p = _start;
            while (p.Link.Link != null)
                p = p.Link;
            p.Link = null;
        }

        public void DeleteNode(int x)
        {
            if (_start == null)
            {
                Console.WriteLine("List is empty\n");
                return;
            }

            // Deletion of first node
            if (_start.Info == x)
            {
                _start = _start.Link;
                return;
            }

            // Deletion in between or at the end
            var p = _start;

            while (p.Link != null)
            {
                if (p.Link.Info == x)
                    break;
                p = p.Link;
            }

            if (p.Link == null)
            {
                Console.WriteLine($"Element {x} not in the list");
                return;
            }

            p.Link = p.Link.Link;
        }

        public void ReverseList()
        {
            Node prev = null;
            var p = _start;
            while (p != null)
            {
                var next = p.Link;
                p.Link = prev;
                prev = p;
                p = next;
            }

            _start = prev;
        }

        public void BubbleSortExData()
        {
            Node end, p;
            for (end = null; end != _start.Link; end = p)
            {
                for (p = _start; p.Link != end; p = p.Link)
                {
                    var q = p.Link;
                    if (p.Info <= q.Info) continue;
                    var temp = p.Info;
                    p.Info = q.Info;
                    q.Info = temp;
                }
            }
        }

        public void BubbleSortExLinks()
        {
            Node end;
            Node p;
            for (end = null; end != _start.Link; end = p)
            {
                Node r;
                for (r = p = _start; p.Link != end; r = p, p = p.Link)
                {
                    var q = p.Link;
                    if (p.Info <= q.Info) continue;
                    p.Link = q.Link;
                    q.Link = p;
                    if (p != _start)
                    {
                        r.Link = q;
                    }
                    else
                    {
                        _start = q;
                    }

                    // var temp = p;
                    p = q;
                    // q = temp;
                }
            }
        }

        public SingleLinkedList Merge2(SingleLinkedList list)
        {
            var mergeList = new SingleLinkedList {_start = Merge2(_start, list._start)};
            return mergeList;
        }

        private static Node Merge2(Node p1, Node p2)
        {
            Node startM;
            if (p1.Info <= p2.Info)
            {
                startM = p1;
                p1 = p1.Link;
            }
            else
            {
                startM = p2;
                p2 = p2.Link;
            }

            var pM = startM;
            while (p1 != null && p2 != null)
            {
                if (p1.Info <= p2.Info)
                {
                    pM.Link = p1;
                    pM = p1;
                    p1 = p1.Link;
                }
                else
                {
                    pM.Link = p2;
                    pM = p2;
                    p2 = p2.Link;
                }
            }

            pM.Link = p1 ?? p2;

            return startM;
        }

        public void MergeSort()
        {
            _start = MergeSortRec(_start);
        }

        private static Node MergeSortRec(Node listStart)
        {
            if (listStart?.Link == null) //if list empty or has one element
                return listStart;

            //if more than one element
            var start1 = listStart;
            var start2 = DivideList(listStart);
            start1 = MergeSortRec(start1);
            start2 = MergeSortRec(start2);
            var startM = Merge2(start1, start2);
            return startM;
        }

        private static Node DivideList(Node p)
        {
            var q = p.Link.Link;
            while (q?.Link != null)
            {
                p = p.Link;
                q = q.Link.Link;
            }

            var start2 = p.Link;
            p.Link = null;
            return start2;
        }

        public void InsertCycle(int x)
        {
            if (_start == null)
            {
                return;
            }

            Node p = _start, px = null, prev = null;
            while (p != null)
            {
                if (p.Info == x)
                {
                    px = p;
                }

                prev = p;
                p = p.Link;
            }

            if (px != null)
            {
                prev.Link = px;
            }
            else
            {
                Console.WriteLine(x + " not present in list");
            }
        }

        public bool HasCycle()
        {
            return FindCycle() != null;
        }

        private Node FindCycle()
        {
            if (_start?.Link == null)
            {
                return null;
            }

            Node slowR = _start, fastR = _start;
            while (fastR?.Link != null)
            {
                slowR = slowR.Link;
                fastR = fastR.Link.Link;
                if (slowR == fastR)
                {
                    return slowR;
                }
            }

            return null;
        }

        public void RemoveCycle()
        {
            var c = FindCycle();
            if (c == null)
            {
                return;
            }

            Console.WriteLine("Node at which the cycle was detected is " + c.Info);

            Node p = c, q = c;
            var lenCycle = 0;
            do
            {
                lenCycle++;
                q = q.Link;
            } while (p != q);

            Console.WriteLine("Length of cycle is : " + lenCycle);

            var lenRemList = 0;
            p = _start;
            while (p != q)
            {
                lenRemList++;
                p = p.Link;
                q = q.Link;
            }

            Console.WriteLine("Number of nodes not included in the cycle are: " + lenRemList);

            var lengthList = lenCycle + lenRemList;
            Console.WriteLine("Length of the list is : " + lengthList);

            p = _start;
            for (var i = 0; i < lengthList - 1; i++)
            {
                p = p.Link;
            }

            p.Link = null;
        }
    }
}