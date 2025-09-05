namespace BinaryHeap.Tests
{
    public static class TestUtils
    {
        public static string ListToCommaSeparatedString<T>(IEnumerable<T?> values)
        {
            return string.Join(",", values);
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
        [Fact]
        public void Test1()
        {

        }
    }
}