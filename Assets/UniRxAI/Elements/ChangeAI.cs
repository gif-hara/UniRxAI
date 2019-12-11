using UniRx;
using UnityEngine;

namespace HK.UniRxAI
{
    /// <summary>
    /// AIを切り替えるAI
    /// </summary>
    [CreateAssetMenu(menuName = "UniRxAI/Elements/ChangeAI")]
    public sealed class ChangeAI : ScriptableAIElement
    {
        [SerializeField]
        private string nextAIName = default;

        public override void Enter<T>(T owner)
        {
            base.Enter(owner);
            
            this.GetObserver(owner)
                .SubscribeWithState2(this, owner, (_, _this, _owner) =>
                {
                    _owner.GetAIController().ChangeAI(this.nextAIName);
                })
                .AddTo(this.events);
        }
    }
}
