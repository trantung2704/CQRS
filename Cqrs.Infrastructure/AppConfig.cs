using Cqrs.Core;

namespace Cqrs.Infrastructure
{
    public class AppConfig : IAppConfig
    {
        public int LocationMinLength
        {
            get { return 3; }
        }
    }
}