namespace InconsistentWarningsOnStaticFieldsAndProperties
{
    // ======== Base case ========
    // warning CS8618: Non-nullable property 'TestProperty' is uninitialized.
    // warning CS8618: Non-nullable field 'testField' is uninitialized.
    // (No warnings for TestStaticProperty or testStaticField)
    public class TestClass
    {
        public string TestProperty { get; }
        public string testField;

        public static string TestStaticProperty { get; }
        public static string testStaticField;
    }

    // ======== With initializers ========
    // (No warnings for TestStaticProperty or testStaticField)
    public class TestClassWithInitializers
    {
        public static string TestStaticProperty { get; } = null;
        public static string testStaticField = null;
    }

    // ======== With constructor ========
    // (No warnings for TestStaticProperty or testStaticField)
    public class TestClassWithConstructor
    {
        public static string TestStaticProperty { get; }
        public static string testStaticField;

        static TestClassWithConstructor() { }
    }

    // ======== With initializers and constructor ========
    // CS8625 Warnings on the initializers, see below.
    public class TestClassWithInitializersAndConstructor
    {
        public static string TestStaticProperty { get; } = null; //  warning CS8625: Cannot convert null literal to non-nullable reference or unconstrained type parameter.
        public static string testStaticField = null; // warning CS8625: Cannot convert null literal to non-nullable reference or unconstrained type parameter.

        static TestClassWithInitializersAndConstructor() { }
    }
}
