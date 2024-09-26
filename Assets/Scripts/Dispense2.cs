using UnityEngine;
using UnityEngine.Events;

public class Dispense2 : MonoBehaviour 
{
    
}



public class UnityActionExample : MonoBehaviour
{
    private UnityAction action;

    void Start()
    {
        action = MethodToCall;
        action.Invoke();
    }

    void MethodToCall()
    {
        Debug.Log("UnityAction Invoke!");
    }
}


public class UnityEventExample : MonoBehaviour
{
    public UnityEvent customEvent;

    void Start()
    {
        if (customEvent != null)
        {
            customEvent.Invoke();
        }
    }
}