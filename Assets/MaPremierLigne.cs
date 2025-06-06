using UnityEngine;

public class MaPremierLigne : MonoBehaviour
{
    public Vector3 m_direction;
    public Color m_color;
    public float m_duration;
    public Transform m_cannonDirection;
    public Transform m_cannonToMove;
    public float m_leftRightAngle;
    public float m_downToAngle;
    public float m_maxVerticalAngle;


    // Update is called once per frame
    void Update()
    {
        if (m_downToAngle < 0) m_downToAngle = 0;
        if (m_downToAngle > m_maxVerticalAngle) m_downToAngle = m_maxVerticalAngle;
        Vector3 startOfCannon = m_cannonDirection.position;
        Vector3 endOfTheCannon = startOfCannon + m_direction;
        Debug.DrawLine(startOfCannon, endOfTheCannon, m_color, 3);
        Quaternion horizontalRotation = Quaternion.Euler(0f, m_leftRightAngle, 0f);
        Quaternion verticalRotation = Quaternion.Euler(-m_downToAngle, 0f, 0f);
        Quaternion finalRotation = (m_cannonDirection.rotation * horizontalRotation) * verticalRotation;
        m_cannonToMove.rotation = finalRotation;
    }
}
