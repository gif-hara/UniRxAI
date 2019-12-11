using UniRx;
using UnityEngine;

namespace HK.UniRxAI
{
    /// <summary>
    /// AIを切り替えるAI
    /// </summary>
    [CreateAssetMenu(fileName = "ChangeAI", menuName = "Bright2/AI/Elements/ChangeAI")]
    public sealed class ChangeAI : ScriptableAIElement
    {
        [SerializeField]
        private string nextAIName = default;

        public override void Enter<T>(T owner, AIObserver ownerAI)
        {
            base.Enter(owner, ownerAI);
            
            this.GetObserver(owner)
                .SubscribeWithState2(this, owner, (_, _this, _owner) =>
                {
                    ownerAI.ChangeAI(this.nextAIName);
                })
                .AddTo(this.events);
        }
    }
}
