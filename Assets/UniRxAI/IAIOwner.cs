using System;
using UniRx;

namespace HK.UniRxAI
{
    /// <summary>
    /// AIの親となるインターフェイス
    /// </summary>
    public interface IAIOwner
    {
        IObservable<Unit> UpdateAsObservable();

        AIObserver GetAIController();
    }
}
