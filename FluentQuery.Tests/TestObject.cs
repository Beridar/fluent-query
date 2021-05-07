using System.Diagnostics.CodeAnalysis;

namespace FluentQuery.Tests
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestObject
    {
        public string PublicStringWithGetAndSet { get; set; }

        public string PublicReadonlyString { get; private set; }

        public string PublicWriteonlyString { private get; set; }

        public void Set_PublicReadonlyString(string value)
        {
            PublicReadonlyString = value;
        }

        public string Get_PublicWriteonlyString()
        {
            return PublicWriteonlyString;
        }

        public int PublicIntWithGetAndSet { get; set; }

        public object PublicObjectWithGetAndSet { get; set; }

        public string PublicStringField;

        private string PrivateStringField = string.Empty;

        private string PrivateStringProperty { get; set; }
    }
}
