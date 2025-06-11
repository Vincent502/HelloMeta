using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float propulsionForce = 15f;
    public int maxBounces = 2;
    public LayerMask wallLayer;

    private Rigidbody rb;
    private int bounceCount = 0;
    private float fixedY;
    public AudioClip bounceSound;
    private AudioSource audioSource;

    public int damage = 20; // dégâts infligés par le projectile

    // Gestion cooldown pour éviter multiples rebonds rapides
    private float lastBounceTime = 0f;
    public float bounceCooldown = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        fixedY = transform.position.y;

        rb.linearVelocity = transform.forward * propulsionForce;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;

        rb.AddForce(transform.forward * propulsionForce, ForceMode.Force);

        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ignorer si cooldown actif (pour éviter multiples rebonds)
        if (Time.time - lastBounceTime < bounceCooldown)
            return;
        // Check si l'objet touché possède un composant Health
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log($"Collision avec {collision.gameObject.name}, inflige {damage} dégâts");
            health.TakeDamage(damage);
        }

        // Debug pour vérifier les collisions
        Debug.Log($"Collision avec {collision.gameObject.name}, layer {collision.gameObject.layer}");

        int bulletLayer = LayerMask.NameToLayer("Bullet");

        // Si collision entre deux projectiles
        if (collision.gameObject.layer == bulletLayer && gameObject.layer == bulletLayer)
        {
            lastBounceTime = Time.time;
            Debug.Log("Collision entre projectiles, destruction mutuelle");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        

        // Collision avec mur
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            bounceCount +=1;
            lastBounceTime = Time.time;
            if (bounceCount >= maxBounces)
            {
                Destroy(gameObject);
            }
            else
            {
                if (audioSource != null)
                    audioSource.Play();
            }
            Vector3 incomingVelocity = rb.linearVelocity;
            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, normal);

            // Garder vitesse constante
            float speed = incomingVelocity.magnitude;

            // Garder Y constant (pas de changement hauteur)
            reflectedVelocity.y = 0f;

            rb.linearVelocity = reflectedVelocity.normalized * speed;

            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            audioSource.PlayOneShot(bounceSound);


        }
    }
}
