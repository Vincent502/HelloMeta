using UnityEngine;
using UnityEngine.Events;

namespace Vincent
{
    public class PrimitiveToString : MonoBehaviour
    {
        [SerializeField] public UnityEvent<string> m_onRelay;
        [SerializeField] string m_format = "{0}";

        public void Relay(string relay)
        {
            m_onRelay.Invoke(relay);
        }
        public void Relay(float toRelay)
        {
            m_onRelay.Invoke(string.Format(m_format, toRelay));
        }
        //ajouter les autres primitives
    }

}
//press "ctrl + k + F = restruc code"