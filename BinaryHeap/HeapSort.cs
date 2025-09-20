using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    static public class HeapSort
    {
        static public int GetParentIndex(int nodeIndex)
        {
            //return (nodeIndex + (nodeIndex & 1) - 1) / 2;
            return (nodeIndex - 1) / 2;
        }

        static public int GetLeftChildIndex(int nodeIndex)
        {
            return (2 * nodeIndex) + 1;
        }

        static public int GetRightChildIndex(int nodeIndex)
        {
            return (2 * nodeIndex) + 2;
        }
        static public bool HeapifyUp(ref int[] values, int idx)
        {
            if (idx == 0) { return false; }
            int i = idx;
            int p = i;
            while (i == p)
            {
                p = GetParentIndex(i);
                if (values[i] < values[p]) //min-heap with respect to ordering on T
                {
                    int temp = values[i];
                    values[i] = values[p];
                    values[p] = temp;
                    i = p;
                }
            }
            return true;
        }

        static private bool HeapifyDown(ref int[] values, int idx, int upperBound)
        {
            if (!(idx < upperBound && idx >= 0)) { return false; }

            int i = idx - 1; //something that's NOT the index we want to start at
            int next = idx;
            int l;
            int r;
            while (i != next)
            {
                i = next;
                l = GetLeftChildIndex(i);
                r = GetRightChildIndex(i);
                bool rightExists = r < upperBound;

                if (l >= upperBound) { break; } //no children to swap with

                if ((!rightExists || values[l] <= values[r]) && values[i] > values[l])
                {
                    next = l;
                }
                else if (rightExists && values[i] > values[r])
                {
                    next = r;
                }

                int temp = values[i];
                values[i] = values[next];
                values[next] = temp;
            }

            return true;
        }

        static public void InsertAll(ref int[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                HeapifyUp(ref values, i);
            }
        }
        static public void UprootAll(ref int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                int root = values[0];
                values[0] = values[(values.Length - 1) - i];
                values[(values.Length - 1) - i] = root;
                HeapifyDown(ref values, 0, (values.Length - 1) - i);
            }
        }

        static public void ReverseArray(ref int[] values)
        {
            for (int i = 0; i < (values.Length / 2) + (values.Length & 1); i++)
            {
                int temp = values[i];
                values[i] = values[values.Length - (i + 1)];
                values[values.Length - (i + 1)] = temp;
            }
        }

        static public void Sort(int[] elements) //example with integers
        {
            InsertAll(ref elements);
            UprootAll(ref elements);
            ReverseArray(ref elements);
        }
    }
}
