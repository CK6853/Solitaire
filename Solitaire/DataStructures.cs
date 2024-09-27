using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    /// <summary>
    /// Generic LinkedList - mostly to refresh my memory of these data structures
    /// </summary>
    /// <typeparam name="T">Generic Type of the LinkedList</typeparam>
    public class LinkedList<T>
    {

        /// <summary>
        /// Implements a single node of a LinkedList
        /// Contains a value, and a pointer to the next Node in the list
        /// </summary>
        /// <typeparam name="K">The type of the Node (should be the same as the LinkedList)</typeparam>
        private class Node<K>
            // Intellisense was complaining when I used "T" for both the LinkedList and Node... even though I want them to be identical
        {
            public K value;
            public Node<K> next; 

            public Node(K value, Node<K> next)
            {
                this.value = value;
                this.next = next;
            }

            /// <summary>
            /// Transforms this Node into a String in the following format: 
            /// [(value of this node)-> value of next node]
            /// If there is no next node, value of next node will show null
            /// </summary>
            /// <returns>The Node as a string</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("[(");
                sb.Append(value);
                sb.Append(")->");
                sb.Append(next == null ? "null" : next.value.ToString());
                sb.Append("]");

                return sb.ToString();
            }
        }

        private Node<T> Head;
        public int Count { get; private set; }

        /// <summary>
        /// Constructor - creates an empty LinkedList
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Find the last element of the LinkedList
        /// Helper for classes that need to act on the last item
        /// </summary>
        /// <returns>Last Node in the LinkedList</returns>
        private Node<T> GetLastNode()
        {
            //check if empty
            if (Count == 0) return null;
            // List not empty - find current last node
            Node<T> currentNode = Head;
            // Traverse through the list until we find the last node
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }
            return currentNode;
        }

        /// <summary>
        /// Add a new entry to the start of a LinkedList
        /// </summary>
        /// <param name="value">The value of the item to be added</param>
        public void AddFirst(T value)
        {
            // If the list is empty, make this the whole list
            if(Count == 0)
            {
                Head = new Node<T>(value, null);
                Count = 1;
                return;
            }

            // List not empty - create a new node pointing to the (old) list start
            Node<T> newNode = new Node<T>(value, Head);
            // Put this item at the start of the list
            Head = newNode;
            // Update number of items in the list
            Count++;
        }

        /// <summary>
        /// Add a new entry to the end of a LinkedList
        /// </summary>
        /// <param name="value">The value of the item to be added</param>
        public void AddLast(T value)
        {
            // If the list is empty, make this the whole list
            if (Count == 0)
            {
                Head = new Node<T>(value, null);
                Count = 1;
                return;
            }

            // List not empty - find current last node
            Node<T> lastNode = GetLastNode();

            // Create the new node
            Node<T> newNode = new Node<T>(value, null);
            // Put this item at the end of the list
            lastNode.next = newNode;
            // Update number of items in the list
            Count++;
        }

        /// <summary>
        /// Returns the value of the first Node in the LinkedList
        /// Returns default if N/A
        /// </summary>
        /// <returns>Value of the first Node</returns>
        public T GetFirst()
        {
            if (Count == 0) return default;
            return Head.value;
        }

        /// <summary>
        /// Returns the value of the last Node in the LinkedList
        /// Returns default if N/A
        /// </summary>
        /// <returns>Value of the larst Node</returns>
        public T GetLast()
        {
            if (Count == 0) return default;
            return GetLastNode().value;
        }

        /// <summary>
        /// Remove the first Node of the LinkedList
        /// </summary>
        public void RemoveFirst()
        {
            if (Count == 0) return;
            if (Count == 1) Clear(); 
            else
            {
                Head.value = Head.next.value;
                Head.next = Head.next.next;
                Count--;
            }
        }

        /// <summary>
        /// Remove the last Node of the LinkedList
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 0) return;
            if (Count == 1)
            {
                Clear();
                return;
            }
            // Find the second-last Node
            Node<T> currentNode = Head;
            while (currentNode.next.next != null)
            {
                currentNode = currentNode.next;
            }

            // Remove reference to the last Node
            currentNode.next = null;
        }

        /// <summary>
        /// Clear the LinkedList
        /// </summary>
        public void Clear()
        {   
            // Garbage Collector go brrr
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Transforms the whole LinkedList into a String
        /// Combined with per-Node ToString, produces the following format:
        /// {[(node 1 value)]->node 2 value][(node 2 value)->node 3 value]}
        /// </summary>
        /// <returns>The LinkedList as a string</returns>
        public override string ToString()
        {
            // If empty, return early
            if (Count == 0) return "{}";

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            // Keep track of current node for traversal
            Node<T> currentNode = Head;
            // Until we find the last node in the list
            while (currentNode.next != null)
            {
                // Add it to the string
                sb.Append(currentNode.ToString());
                // Go to next node
                currentNode = currentNode.next;
            }
            // Loop will exit upon finding last node in the list
            // Add the last node to the string as well
            sb.Append(currentNode.ToString());
            sb.Append("}");

            return sb.ToString();
        }

        /// <summary>
        /// Transform the whole LinkedList into an Array
        /// </summary>
        /// <returns>The LinkedList as an Array</returns>
        public T[] ToArray()
        {
            if (Count == 0) return new T[0];

            // Create empty array to fill
            T[] returnArray = new T[Count];

            // Iterate through the list, keeping track of how deep we are
            Node<T> currentNode = Head;
            int index = 0;
            while (currentNode.next != null)
            {
                // Store this value in its place in the new array
                returnArray[index] = currentNode.value;
                currentNode = currentNode.next;
                index++;
            }
            // Loop will end when it finds the last item, process it separately
            returnArray[index] = currentNode.value;
            return returnArray;
        }

        /// <summary>
        /// Randomizes the card order for this LinkedList using Fisher-Yates algorithm
        /// </summary>
        public void Randomize()
        {
            // Convert to an array
            T[] shuffleArray = ToArray();

            // Set up number generator
            Random rng = new Random();

            // Fisher-Yates
            int n = shuffleArray.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                // Swap elements
                (shuffleArray[n], shuffleArray[k]) = (shuffleArray[k], shuffleArray[n]);
            }

            // Iterate through the list, keeping track of how deep we are
            Node<T> currentNode = Head;
            int index = 0;
            while (currentNode.next != null)
            {
                // Store the corresponding shuffled array value into the LinkedList
                currentNode.value = shuffleArray[index];
                currentNode = currentNode.next;
                index++;
            }
            // Loop will end when it finds the last item, process it separately
            currentNode.value = shuffleArray[index];

        }
    }
}
