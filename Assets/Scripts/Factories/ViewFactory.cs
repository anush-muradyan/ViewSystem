using UIFactoryConfigs;

namespace Factories
{
    public class ViewFactory : UIFactory<ViewFactoryConfig>
    {
        public ViewFactory(ViewFactoryConfig config) : base(config)
        {
        }
    }
}