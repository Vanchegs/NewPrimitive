// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
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