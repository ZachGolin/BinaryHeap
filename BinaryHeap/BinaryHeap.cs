namespace BinaryHeap
{
    public class BinaryHeap<T>
    {
        public List<T?> Values { get; private set; }
        public Comparer<T?> Order { get; private set; }
        public BinaryHeap(Comparer<T?> O)
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
                if (Order.Compare(Values[i], Values[p]) < 0) //min-heap with respect to ordering on T
                {
                    T? temp = Values[i];
                    Values[i] = Values[p];
                    Values[p] = temp;
                    i = p;
                }
            }
            return true;
        }

        private bool HeapifyDown(int idx) //TODO: keep working on this
        {
            int i = idx;
            int L = GetLeftChildIndex(i);
            int R = GetRightChildIndex(i);
            bool rightExists = R < Values.Count - 1;
            bool leftExists = rightExists || L < Values.Count - 1;
            bool leftBeforeRight = Order.Compare(Values[L], Values[R]) < 0;

            if (leftBeforeRight && Order.Compare(Values[i], Values[L]) < 0)
            {
                T? temp = Values[i];
                Values[i] = Values[L];
                Values[L] = temp;
            }
            else if (!leftBeforeRight && Order.Compare(Values[i], Values[R]) > 0)
            {
                T? temp = Values[i];
                Values[i] = Values[L];
                Values[L] = temp;
            }
        }

        public int GetParentIndex(int nodeIndex)
        {
            return (nodeIndex + (nodeIndex & 1) - 1) / 2;
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
            HeapifyUp();
        }
    }
}
