using log4net;
using Unity.Builder;
using Unity.Builder.Strategy;

namespace UnityLog4NetResolver
{
    internal sealed class LogByTypeResolutionStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            if (context.OriginalBuildKey.Type == typeof(ILog) && context.ParentContext != null)
                context.Existing = LogManager.GetLogger(context.ParentContext.BuildKey.Type);

            base.PreBuildUp(context);
        }
    }
}
