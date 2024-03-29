﻿using System;

namespace SingleLinkedListProject
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            // if (args == null) throw new ArgumentNullException(nameof(args));

            /*
            var list1 = new SingleLinkedList();
            var list2 = new SingleLinkedList();

            list1.CreateList();
            list2.CreateList();

            list1.BubbleSortExLinks();
            list2.BubbleSortExLinks();

            Console.Write("First list - ");
            list1.DisplayList();
            Console.Write("Second list - ");
            list2.DisplayList();

            var list3 = list1.Merge2(list2);
            Console.Write("Merge list - ");
            list3.DisplayList();
            Console.Write("First list - ");
            list1.DisplayList();
            Console.Write("Second list - ");
            list2.DisplayList();
            */


            var list = new SingleLinkedList();
            list.CreateList();
            while (true)
            {
                Console.WriteLine("1. Display list");
                Console.WriteLine("2. Count the number of nodes");
                Console.WriteLine("3. Search for an element");
                Console.WriteLine("4. Insert in empty list/Insert in beginning of the list");
                Console.WriteLine("5. Insert a node at the end of the list");
                Console.WriteLine("6. Insert a node before a specified node");
                Console.WriteLine("7. Insert a node after a specified node");
                Console.WriteLine("8. Insert a node at a given position");
                Console.WriteLine("9. Delete first node");
                Console.WriteLine("10. Delete last node");
                Console.WriteLine("11. Delete any node");
                Console.WriteLine("12. Reserve the list");
                Console.WriteLine("13. Bubble sort by exchanging data");
                Console.WriteLine("14. Bubble sort by exchanging links");
                Console.WriteLine("15. Merge sort");
                Console.WriteLine("16. Insert cycle");
                Console.WriteLine("17. Detect cycle");
                Console.WriteLine("18. Remove cycle");
                Console.WriteLine("19. Quit");

                Console.Write("Enter your choice: ");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 19)
                {
                    break;
                }

                int data;
                int x;
                switch (choice)
                {
                    case 1:
                        list.DisplayList();
                        break;
                    case 2:
                        list.CountNodes();
                        break;
                    case 3:
                        Console.Write("Enter the element to be searched : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.Search(data);
                        break;
                    case 4:
                        Console.Write("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertInBeginning(data);
                        break;
                    case 5:
                        Console.Write("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtEnd(data);
                        break;
                    case 6:
                        Console.Write("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the element after which to insert : ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.InsertAfter(data, x);
                        break;
                    case 7:
                        Console.Write("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the element before which to insert : ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.InsertBefore(data, x);
                        break;
                    case 8:
                        Console.Write("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the position at which to insert : ");
                        var k = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtPosition(data, k);
                        break;
                    case 9:
                        list.DeleteFirstNode();
                        break;
                    case 10:
                        list.DeleteLastNode();
                        break;
                    case 11:
                        Console.Write("Enter the element to be deleted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.DeleteNode(data);
                        break;
                    case 12:
                        list.ReverseList();
                        break;
                    case 13:
                        list.BubbleSortExData();
                        break;
                    case 14:
                        list.BubbleSortExLinks();
                        break;
                    case 15:
                        list.MergeSort();
                        break;
                    case 16:
                        Console.Write("Enter the element at which the cycle has to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertCycle(data);
                        break;
                    case 17:
                        Console.Write(list.HasCycle() ? "List has a cycle" : "List does not have a cycle");
                        break;
                    case 18:
                        list.RemoveCycle();
                        break;
                    default:
                        Console.Write("Wrong choice");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Exiting");
            Console.ReadKey();
        }
    }
}