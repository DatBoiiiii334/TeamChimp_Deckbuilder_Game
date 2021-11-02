using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    protected Dictionary<int, State> m_states;
    protected State m_currentState;

    public FSM(){

    }

    public void Add(int key, State state){
        m_states.Add(key, state);
    }

    public State GetState(int key){
        return m_states[key];
    }

    public void SetCurrentState(State state){
        if(m_currentState != null){
            m_currentState.Exit();
        }

        m_currentState = state;

        if(m_currentState != null){
            m_currentState.Enter();
        }
    }

    public void Update(){
        if(m_currentState != null){
            m_currentState.Update();
        }
    }

    public void FixedUpdate(){
        if(m_currentState != null){
            m_currentState.FixedUpdate();
        }
    }

    
}
