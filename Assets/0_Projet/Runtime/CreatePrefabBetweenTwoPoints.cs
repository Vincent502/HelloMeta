using UnityEngine;
using UnityEngine.Events;

public class CreatePrefabBetweenTwoPoints : MonoBehaviour
{
    [SerializeField] Transform m_startPoint;
    [SerializeField] Transform m_endPoint;
    [SerializeField] GameObject m_prefab;
    [SerializeField] UnityEvent<GameObject> m_onInstatiated;


    //On reuni deux methode en une et ouais 2 pour le pris d'1
    public void SetPrefabAndCreated(GameObject prefab)
    {
        SetPrefabToCreate(prefab);
        InstantiatePrefabInInspector();

    }
    public void SetPrefabToCreate(GameObject whatToCreate)
    {
        m_prefab = whatToCreate;
    }
    [ContextMenu("Create Object")]
    public void InstantiatePrefabInInspector()
    {
        if (m_prefab == null) return;
        var created = Instantiate(m_prefab);
        Vector3 midPosition = (m_startPoint.position + m_endPoint.position) / 2;
        created.transform.position = midPosition;

        Vector3 up = Vector3.up;
        Vector3 directionX = m_endPoint.position - m_startPoint.position;
        Vector3 forward = Vector3.Cross(directionX, up);
        
        Quaternion rotation = Quaternion.LookRotation(forward, up);
        created.transform.rotation = rotation;


        m_onInstatiated.Invoke(created);
    }
    public void KillQuickInTenSec(GameObject target) 
    {
        if (Application.isPlaying)
            Destroy(target,10);
        else
        {
            DestroyImmediate(target);
        }
    }
}
