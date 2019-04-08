using YgoProFrPatcher.Core.Model;

namespace YgoProFrPatcher.Core.Service
{
    public interface IConfigService
    {
        ConfigModel GetConfig();
        void SetConfig(ConfigModel configModel);
    }
}