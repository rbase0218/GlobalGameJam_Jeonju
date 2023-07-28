using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public abstract class FSMRunner<T> : MonoBehaviour where T : IFSMOwner
{
    private Dictionary<int, FSMState<T>> states;

    private FSMState<T> currentState;
    private FSMState<T> previousState;
    
    #region Process

    protected void SetUp(ValueType firstState)
    {
        states = new Dictionary<int, FSMState<T>>();
        
        var stateTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(FSMState<T>).IsAssignableFrom(t));

        foreach (var stateType in stateTypes)
        {
            var attribute = stateType.GetCustomAttribute<SetStateAttribute>();

            if (attribute is null)
            {
                continue;
            }

            var state = Activator.CreateInstance(stateType, this as IFSMOwner) as FSMState<T>;
            
            if (!states.TryAdd(attribute.key, state))
            {
                Debug.LogError($"{typeof(T)} 의 {attribute.key} 키가 중복되었습니다.");
            }
        }

        ChangeState(firstState);
    }
    
    #endregion

    protected void Update()
    {
        currentState?.Update();
    }

    protected void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public void ChangeState(ValueType enumValue)
    {
        if (!states.TryGetValue((int)enumValue, out var state))
        {
            return;
        }
        
        ChangeState(state);
    }

    private void ChangeState(FSMState<T> state)
    {
        if (state is null)
        {
            return;
        }

        if (currentState is not null)
        {
            previousState = currentState;
            
            currentState?.Exit();
        }
        
        currentState = state;
        currentState?.Begin();
    }

    private void UndoState()
    {
        ChangeState(previousState);
    }
}
