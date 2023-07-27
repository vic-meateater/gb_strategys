using System;
using UnityEngine;

public abstract class ScriptableObjectValueBase<T> : ScriptableObject, IAwaitable<T>
{
    public T CurrentValue { get; private set; }
    public event Action<T> OnNewValue;

    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}