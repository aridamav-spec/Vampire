using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NewPlayerBehaviour2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float speed = 10f;

        Move(x, y, speed);
    }
    private void Move(float x, float y, float speed)
    {
        Vector2 moveVelocity = new Vector2(x * speed, y * speed);
    }
}
