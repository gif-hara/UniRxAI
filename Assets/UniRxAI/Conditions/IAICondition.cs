using System;
using UniRx;

namespace HK.UniRxAI
{
    /// <summary>
    /// AIを実行する条件を持つインターフェイス
    /// </summary>
    public interface IAICondition
    {
        /// <summary>
        /// 条件を満たした場合に発行される<see cref="IObservable{Unit}"/>を返す
        /// </summary>
        IObservable<Unit> Satisfy<T>(T owner) where T : IAIOwner;
    }
}
