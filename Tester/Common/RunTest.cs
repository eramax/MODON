namespace Tester.Common
{
    public class RunTest<TestCase> where TestCase : ITest, new()
    {
        private TestCase Test { get; set; } = new TestCase();
        public RunTest(int count)
        {
            for (; count > 0; count--) Test.Run();
        }
    }
}
