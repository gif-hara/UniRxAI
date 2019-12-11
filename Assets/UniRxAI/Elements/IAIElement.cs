using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UniRxAI
{
    /// <summary>
    /// 1個単位のAIのインターフェイス
    /// </summary>
    public interface IAIElement
    {
        void Enter<T>(T owner, AIController ownerAI) where T : IAIOwner;

        void Exit();
    }
}
