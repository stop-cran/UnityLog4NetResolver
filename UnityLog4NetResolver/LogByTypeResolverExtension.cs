using Unity.Builder;
using Unity.Extension;

namespace UnityLog4NetResolver
{
    public class LogByTypeResolverExtension : UnityContainerExtension
    {
        protected override void Initialize() =>
            Context.Strategies.Add(new LogByTypeResolutionStrategy(), UnityBuildStage.PreCreation);
    }
}
