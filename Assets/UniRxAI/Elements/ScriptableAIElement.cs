﻿using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UniRxAI
{
    /// <summary>
    /// <see cref="ScriptableObject"/>で作成可能な<see cref="IAIElement"/>
    /// </summary>
    public abstract class ScriptableAIElement : ScriptableObject, IAIElement
    {
        [SerializeField]
        private List<ScriptableAICondition> conditions = default;

        protected List<IObservable<Unit>> instanceConditions = null;

        protected readonly CompositeDisposable events = new CompositeDisposable();
        
        public virtual void Enter<T>(T owner, AIObserver ownerAI) where T : IAIOwner
        {
            if(this.instanceConditions == null)
            {
                this.instanceConditions = new List<IObservable<Unit>>(this.conditions.Count);
                foreach (var condition in this.conditions)
                {
                    var instance = UnityEngine.Object.Instantiate(condition);
                    this.instanceConditions.Add(instance.Satisfy(owner));
                }
            }
        }

        public virtual void Exit()
        {
            this.events.Clear();
        }

        /// <summary>
        /// 条件が存在するか返す
        /// </summary>
        protected bool AnyConditions => this.instanceConditions.Count > 0;

        protected IObservable<Unit> GetObserver<T>(T owner) where T : IAIOwner
        {
            if(this.AnyConditions)
            {
                return Observable.Merge(this.instanceConditions);
            }
            else
            {
                return owner.UpdateAsObservable();
            }
        }
    }
}
