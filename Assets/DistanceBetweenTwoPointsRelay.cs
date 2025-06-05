using UnityEngine;
using UnityEngine.Events;

namespace Vincent
{
    public class DistanceBetweenTwoPointsRelay : MonoBehaviour
    {

        [SerializeField] Transform m_leftHand;
        [SerializeField] Transform m_rightHand;
        [SerializeField] float m_distanceBetween;
        [SerializeField] UnityEvent<float> m_onDistanceChanged;
        private void OnValidate()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {

            var distance = Vector3.Distance(m_leftHand.position, m_rightHand.position);
            if (distance != m_distanceBetween)
            {
                m_distanceBetween = distance;
                m_onDistanceChanged.Invoke(distance);
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdatePosition();
        }
    }

}
