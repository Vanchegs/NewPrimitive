using YG;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.Adv
{
    public sealed class ADVService : IADVService
    {
        public void ShowFullScreenADV()
        {
            if (IsSDKNotInit())
                return;

            YandexGame.FullscreenShow();
        }

        private static bool IsSDKNotInit() =>
            !YandexGame.SDKEnabled;
    }
}