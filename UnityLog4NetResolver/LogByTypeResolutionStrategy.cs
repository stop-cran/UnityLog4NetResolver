using log4net;
using Unity.Builder;
using Unity.Builder.Strategy;

namespace UnityLog4NetResolver
{
    internal sealed class LogByTypeResolutionStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            if (!context.BuildComplete && context.ParentContext != null && context.OriginalBuildKey.Type == typeof(ILog))
            {
                context.Existing = LogManager.GetLogger(context.ParentContext.BuildKey.Type);
                context.BuildComplete = true;
            }

            base.PreBuildUp(context);
        }
    }
}
