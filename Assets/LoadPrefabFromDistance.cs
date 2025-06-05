using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class RangeToCreatePrefab
{
    public float m_minRange;
    public float m_maxRange;
    public GameObject m_prefab;
}
public class LoadPrefabFromDistance : MonoBehaviour
{
    [SerializeField] private float m_distance;
    public List<RangeToCreatePrefab> m_listOfPrefab;
    public UnityEvent<GameObject> m_onPrefabRangeFound;
    public GameObject m_lastPush;
    public void SetDistance(float distance)
    {
        m_distance = distance;
    }

    [ContextMenu("TryToCreate")]
    public void TryToCreateInRange()
    {
        foreach (var item in m_listOfPrefab)
        {
            if(item == null) continue;
            if (m_distance < item.m_minRange ) continue;
            if (m_distance > item.m_maxRange ) continue;
            m_onPrefabRangeFound.Invoke(item.m_prefab);
            m_lastPush = item.m_prefab;
        }
    }
}
