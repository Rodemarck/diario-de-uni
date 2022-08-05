using UnityEngine;

public abstract class Translatable : MonoBehaviour{
    abstract public void Translate();
    protected void Start()
    {
        Translate();
    }
}
