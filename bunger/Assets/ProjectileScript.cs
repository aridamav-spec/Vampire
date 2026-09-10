using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ProjectileScript : PlayerBehaviour
{
    void Start()
    {
        
        
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
