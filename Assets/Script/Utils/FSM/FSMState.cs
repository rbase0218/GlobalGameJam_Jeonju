using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[AttributeUsage(AttributeTargets.Class)]
public class SetStateAttribute : Attribute
{
    public readonly int key;

    public SetStateAttribute(int key) => this.key = key;
}

public class FSMState<T> : IFSMOwner
{
    protected readonly T ownerEntity;

    public FSMState(IFSMOwner owner) => ownerEntity = (T)owner;

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Begin()
    {
    }

    public virtual void Exit()
    {
    }
}
