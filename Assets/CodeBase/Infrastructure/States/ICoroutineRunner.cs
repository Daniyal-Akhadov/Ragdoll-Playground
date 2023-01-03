using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}