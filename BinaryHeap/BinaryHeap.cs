namespace BinaryHeap
{
    public class BinaryHeap<T>
    {
        public List<T?> Values { get; private set; }
        public Comparison<T?> Order { get; private set; }
        public BinaryHeap(Comparison<T?> O)
        { 
            Values = [];
            Order = O;
        }


        private bool HeapifyUp(int idx)
        {
            if (idx == 0) { return false; }
            int i = idx;
            int p = i;
            while (i == p)
            {
                p = GetParentIndex(i);
                if (Order(Values[i], Values[p]) < 0) //min-heap with respect to ordering on T
                {
                    T? temp = Values[i];
                    Values[i] = Values[p];
                    Values[p] = temp;
                    i = p;
                }
            }
            return true;
        }

        private bool HeapifyDown(int idx)
        {
            if (!(idx < Values.Count && idx >= 0)) { return false; }

            int i = idx - 1; //something that's NOT the index we want to start at
            int next = idx;
            int l;
            int r;
            while (i != next)
            {
                i = next;
                l = GetLeftChildIndex(i);
                r = GetRightChildIndex(i);
                bool rightExists = r < Values.Count;

                if (l >= Values.Count) { break; } //no children to swap with

                if ((!rightExists || Order(Values[l], Values[r]) <= 0) && Order(Values[i], Values[l]) > 0)
                {
                    next = l;
                }
                else if (rightExists && Order(Values[i], Values[r]) > 0)
                {
                    next = r;
                }

                T? temp = Values[i];
                Values[i] = Values[next];
                Values[next] = temp;
            }

            return true;
        }

        public int GetParentIndex(int nodeIndex)
        {
            //return (nodeIndex + (nodeIndex & 1) - 1) / 2;
            return (nodeIndex - 1) / 2;
        }

        public int GetLeftChildIndex(int nodeIndex)
        {
            return (2 * nodeIndex) + 1;
        }

        public int GetRightChildIndex(int nodeIndex)
        {
            return (2 * nodeIndex) + 2;
        }

        public void Insert(T? value)
        {
            Values.Add(value);
            HeapifyUp(Values.Count - 1);
        }

        public T? Pop()
        { 
            T? result = Values[0];
            Values[0] = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);
            HeapifyDown(0);
            return result;
        }
    }
}
