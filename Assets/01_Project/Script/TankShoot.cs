using UnityEngine;
using UnityEngine.InputSystem;

public class TankShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    [Header("Input Action")]
    public InputActionProperty shootAction; // Bindée dans l’inspecteur à la gâchette droite


    void Update()
    {
        if (shootAction.action.WasPressedThisFrame())
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.rotation = Quaternion.LookRotation(firePoint.forward);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
    }
}
