using UnityEngine;

    [RequireComponent(typeof(TMPro.TextMeshPro))]
public class GetText : MonoBehaviour
{
    
    private TMPro.TextMeshPro m_TextMeshPro;
    private void Awake()
    {
        m_TextMeshPro = GetComponent<TMPro.TextMeshPro>();
    }
    public string text;
    public void DisplayText(string text)
    {
        m_TextMeshPro.text = text;
        
    }
}
