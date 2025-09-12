using System.Collections.Generic;
using static BinaryHeap.Tests.TestUtils;

namespace BinaryHeap.Tests
{
    public static class TestUtils
    {
        public static string ListToCommaSeparatedString<T>(IEnumerable<T?> values)
        {
            return '[' + string.Join(",", values) + ']';
        }

        public class Mnemonic : IComparable<Mnemonic?> //a reference type to use as a test subject
        {
            public int Value { get; set; }
            public int Order { get; set; }

            public int CompareTo(Mnemonic? other)
            {
                if (other is null) { return -1; } //assume this mnemonic precedes a null mnemonic
                return Value.CompareTo(other.Value);
            }
        }

        public static Comparison<int> IntOrder = (a, b) => (a.CompareTo(b));
        public static Comparison<Mnemonic?> MnemonicOrder = (a, b) => (a?.CompareTo(b)) ?? 1; //assume null mnemonics follow all others
    }

    public class BinaryHeapTests
    {

        [Theory]
        [InlineData((int[])[1, 33, 9, 7, 3, 11, 77], (int[])[1, 3, 9, 33, 7, 11, 77])]
        public void Insertion_Structures_Elements_Properly(int[] values, int[] expectedResult)
        {
            BinaryHeap<int> heap = new(IntOrder);
            foreach (int val in values) { heap.Insert(val); }

            Assert.True(expectedResult.SequenceEqual(heap.Values),
                $"Sequences {ListToCommaSeparatedString(expectedResult)} and " +
                $"{ListToCommaSeparatedString(heap.Values)} are not equal");
        }


        [Theory]
        [InlineData((int[])[1,3,7,34,4,6,7,32,6,7,5,9,7,86,3,7,1000000])]
        [InlineData((int[])[1, 33, 9, 7, 3, 11, 77])]
        public void Popping_Sorts_Inserted_Elements(int[] values)
        { 
            List<int> sortedInputs = [.. values];
            sortedInputs.Sort(IntOrder);
            BinaryHeap<int> heap = new(IntOrder);
            foreach (int val in values) { heap.Insert(val); }

            List<int> heapSortedValues = new();
            while (heap.Values.Count > 0)
            {
                heapSortedValues.Add(heap.Pop());
            }

            Assert.True(sortedInputs.SequenceEqual(heapSortedValues), 
                $"Sequences {ListToCommaSeparatedString(sortedInputs)} and " +
                $"{ListToCommaSeparatedString(heapSortedValues)} are not equal");
        }
    }
}