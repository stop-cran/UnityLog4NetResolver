using log4net;

namespace UnityLog4NetResolver.Tests
{
    internal class ClassA
    {
        public ClassA(ILog log)
        {
            Log = log;
        }

        public ILog Log { get; }
    }
}
