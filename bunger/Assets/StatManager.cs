using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;

    void Awake()
    {
        instance = this;
    }
}
