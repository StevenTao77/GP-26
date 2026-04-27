using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public float distance = 5f;  
    public float height = 1.5f;  

    [Header("Mouse Control")]
    public float mouseSensitivity = 0.2f; 
    public float pitchMin = -30f;  
    public float pitchMax = 60f;   

    private float yaw;    
    private float pitch; 

    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (target == null) return;
         
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
             
            yaw += mouseDelta.x * mouseSensitivity;
           
            pitch -= mouseDelta.y * mouseSensitivity;

            
            pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        }

    
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        
        Vector3 targetCenter = target.position + Vector3.up * height;
         
        Vector3 finalPosition = targetCenter - (rotation * Vector3.forward * distance);
         
        transform.position = finalPosition;
        transform.rotation = rotation;
    }
}