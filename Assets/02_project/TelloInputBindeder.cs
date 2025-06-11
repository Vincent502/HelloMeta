using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TelloJoystickRelayMono))]
public class TelloInputBinder : MonoBehaviour
{
    private DroneControls controls;
    private TelloJoystickRelayMono relay;

    private void Awake()
    {
        controls = new DroneControls();
        relay = GetComponent<TelloJoystickRelayMono>();

        controls.Drone.LeftStick.performed += ctx => HandleLeftStick(ctx.ReadValue<Vector2>());
        controls.Drone.LeftStick.canceled += ctx => HandleLeftStick(Vector2.zero);

        controls.Drone.RightStick.performed += ctx => HandleRightStick(ctx.ReadValue<Vector2>());
        controls.Drone.RightStick.canceled += ctx => HandleRightStick(Vector2.zero);
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void HandleLeftStick(Vector2 value)
    {
        relay.SetVerticalMove(value.y);       // Haut/Bas
        relay.SetLeftRightRotate(value.x);    // Rotation gauche/droite
    }

    private void HandleRightStick(Vector2 value)
    {
        relay.SetFrontalMove(value.y);        // Avant/Arrière
        relay.SetHorizontalMove(value.x);     // Déplacement latéral
    }
}
