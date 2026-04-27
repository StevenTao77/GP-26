using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float originalSpeed;
    private Coroutine activeSpeedBoost;
     
    private Transform cameraTransform;
    public event System.Action<float> OnSpeedChanged;

    private void Start()
    {
        originalSpeed = moveSpeed;
         
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Main Camera not found! Please ensure your camera has the 'MainCamera' tag.");
        }

        Invoke(nameof(IntializeUI), 0.1f);
    }

    private void Update()
    {
        Vector2 input = GetInput();

        if (input != Vector2.zero)
        {
            Move(input);
        }
    }

    private void IntializeUI()
    {
        if (OnSpeedChanged != null)
        {
            OnSpeedChanged.Invoke(moveSpeed);
        }
    }

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

    public void Move(Vector2 direction)
    {
        direction.Normalize();

        if (cameraTransform == null) return;
         
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
         
        camForward.y = 0;
        camRight.y = 0;
         
        camForward.Normalize();
        camRight.Normalize();
         
        Vector3 worldDirection = camForward * direction.y + camRight * direction.x;
         
        transform.position += worldDirection * moveSpeed * Time.deltaTime;
         
        if (worldDirection != Vector3.zero)
        { 
            Quaternion targetRotation = Quaternion.LookRotation(worldDirection, Vector3.up);
             
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }
    }

    public void ApplySpeedBoost(float multiplier, float duration)
    {
        if (activeSpeedBoost != null)
        {
            StopCoroutine(activeSpeedBoost);
        }
        activeSpeedBoost = StartCoroutine(SpeedBoostCoroutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier, float duration)
    {
        moveSpeed = originalSpeed * multiplier;
        OnSpeedChanged?.Invoke(moveSpeed);
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
        OnSpeedChanged?.Invoke(moveSpeed);
        activeSpeedBoost = null;
    }
}