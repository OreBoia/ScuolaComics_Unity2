using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Create Assets/ScriptableObject")]
public class EsempioScriptableObject : ScriptableObject
{
    public float playerSpeed;
    public float maxPlayerSpeed;
}

[CreateAssetMenu(fileName = "FloatVariableSO", menuName = "Create Assets/ScriptableObject/FloatVariable")]
public class FloatVariableSO : ScriptableObject
{
    public float value;
    public UnityEvent<float> onValueChanged;


    public void SetValue(float newValue)
    {
        value = newValue;
    }

    public void AddListener(UnityAction<float> listener)
    {
        onValueChanged.AddListener(listener);
    }
}