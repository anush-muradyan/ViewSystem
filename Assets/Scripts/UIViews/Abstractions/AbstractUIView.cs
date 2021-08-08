using System;
using UnityEngine;

namespace UIViews.Abstractions
{
    public abstract class AbstractUIView : MonoBehaviour
    {
        protected virtual void Start()
        {
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnDestroy()
        {
        }
    }

    public abstract class AbstractUIView<TData> : AbstractUIView
    {
        public TData ViewData { get; private set; }

        public virtual void SetData(TData data)
        {
            ViewData = data;
        }
    }
}