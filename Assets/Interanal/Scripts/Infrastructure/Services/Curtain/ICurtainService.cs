using System;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain
{
    public interface ICurtainService
    {
        public void Init();
        public void ShowCurtain(bool isAnimated = true, Action callback = null);
        public void HideCurtain(bool isAnimated = true, Action callback = null);
        public void HideCurtain(float startDelay, Action callback = null);
    }
}