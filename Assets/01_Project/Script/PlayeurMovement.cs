using UnityEngine;
using UnityEngine.InputSystem;

public class PlayeurMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 60f;
    public float turretRotationSpeed = 80f;

    public InputActionProperty moveInput;   // Stick gauche (Vector2)
    public InputActionProperty turretInput; // Stick droit  (Vector2)

    public Transform turretTransform; // Assigne ici ton canon (TankTurret)

    void OnEnable()
    {
        moveInput.action.Enable();
        turretInput.action.Enable();
    }

    void OnDisable()
    {
        moveInput.action.Disable();
        turretInput.action.Disable();
    }

    void Update()
    {
        // Mouvement du tank
        Vector2 move = moveInput.action.ReadValue<Vector2>();

        // Avancer / Reculer
        Vector3 forward = transform.forward * move.y * moveSpeed * Time.deltaTime;
        transform.position += forward;

        // Tourner le tank (gauche/droite avec X)
        float rotationAmount = move.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);

        // Rotation du canon
        Vector2 turret = turretInput.action.ReadValue<Vector2>();

        float turretRotation = turret.x * turretRotationSpeed * Time.deltaTime;
        turretTransform.Rotate(0, turretRotation, 0); // uniquement sur Y
    }
}
