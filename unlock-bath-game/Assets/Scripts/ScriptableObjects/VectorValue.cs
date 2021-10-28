using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    public Vector2 initalValue;

    private void OnEnable()
    {
        initalValue = new Vector2(4, -4);
    }
}
