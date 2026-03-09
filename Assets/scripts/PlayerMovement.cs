using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5.0f;

    void Update()
    {
         
        Vector2 input = GetInput();
         
        if (input != Vector2.zero)
        {
            Move(input);
        }
    }

    // Helper method to gather input (New Input System)
    private Vector2 GetInput()
    {
        if (Keyboard.current == null) return Vector2.zero;

        float x = 0;
        float z = 0;

        if (Keyboard.current.dKey.isPressed) x = 1;
        if (Keyboard.current.aKey.isPressed) x = -1;
        if (Keyboard.current.wKey.isPressed) z = 1;
        if (Keyboard.current.sKey.isPressed) z = -1;

        return new Vector2(x, z);
    }

    // Public Method: Can be called by this script, AI, or other controllers
    public void Move(Vector2 direction)
    {
        
        direction.Normalize();

        // Calculate world direction relative to the object's facing
        Vector3 worldDirection = transform.right * direction.x + transform.forward * direction.y;

        // Apply movement
        transform.position += worldDirection * moveSpeed * Time.deltaTime;
    }
}