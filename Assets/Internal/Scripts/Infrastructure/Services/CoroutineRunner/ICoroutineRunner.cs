using System.Collections;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);

        public void StopAllCoroutines();

        public void StopCoroutine(Coroutine coroutine);
    }
}