using Sdl.LanguagePlatform.TranslationMemoryApi.AICompanion;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
    [AICompanionFactory(Id = "AICompanionFactory")]
    internal class AICompanionFactory : IAICompanionFactory
    {
        public IAICompanion GetAICompanion()
        {
            return new AICompanion();
        }
    }
}
