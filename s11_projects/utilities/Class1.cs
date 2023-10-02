namespace utilities
{
    public static class EnumerableExtensions
    {
        public static string AsString<T>(this IEnumerable<T> items)
        {
            return string.Join(Environment.NewLine,items);
        }
    }
    public class PublicClass
    {
        private InternalClass _internalClass;

        public int SomeMethod()
        {
            var someVariable = new InternalClass();
            return 0;
        }
        protected internal void ProtectedInternal() { }
        private protected void PrivateProtected() { }
    }
    internal class DerivedFromPublicClass : PublicClass
    { 
        void Test()
        {
            PrivateProtected();
        }
    }
    internal class InternalClass
    {
        public static void PublicMethod() 
        {
            new PublicClass().ProtectedInternal();
        }
    }
}