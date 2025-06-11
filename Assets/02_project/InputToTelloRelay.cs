using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TelloJoystickRelayMono))]
public class InputToTelloRelay : MonoBehaviour
{
    public DroneControls input; // G�n�r� automatiquement depuis .inputactions
    private TelloJoystickRelayMono relay;

    private void Awake()
    {
        input = new DroneControls();
        relay = GetComponent<TelloJoystickRelayMono>();

        // Connexion des �v�nements de joystick
        input.Drone.LeftStick.performed += ctx => relay.SetWithDoubleJoysticksLeft(ctx.ReadValue<Vector2>());
        input.Drone.RightStick.performed += ctx => relay.SetWithDoubleJoysticksRight(ctx.ReadValue<Vector2>());

        input.Drone.LeftStick.canceled += ctx => relay.SetWithDoubleJoysticksLeft(Vector2.zero);
        input.Drone.RightStick.canceled += ctx => relay.SetWithDoubleJoysticksRight(Vector2.zero);
    }

    private void OnEnable()
    {
        input.Drone.Enable();
    }

    private void OnDisable()
    {
        input.Drone.Disable();
    }
}
