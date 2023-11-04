// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

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