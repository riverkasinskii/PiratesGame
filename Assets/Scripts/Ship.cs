using UnityEngine;

public abstract class Ship : MonoBehaviour
{    
    public ShipConfig shipConfig;

    [SerializeField] private Transform shootPoint;    

    protected float timer;
    protected UI ui;    
    protected int currentHealth;

    private ProjectilePooler projectilePooler;

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Stats.Score += shipConfig.pointsForKill;
            ui.UpdateScoreAndLevel();
            Destroy(gameObject);
        }
        print(currentHealth);
    }

    protected virtual void Start()
    {
        ui = FindObjectOfType<UI>();
        currentHealth = shipConfig.maxHealth;
        timer = shipConfig.reloadTime;
        projectilePooler = ProjectilePooler.Instance;
    }

    protected virtual void Move()
    {
        transform.Translate(shipConfig.movementSpeed * Time.deltaTime * Vector2.down);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0, angleZ + shipConfig.angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, 
            Time.deltaTime * shipConfig.rotationSpeed);
    }        

    protected void Shoot()
    {        
        projectilePooler.SpawnFromPool(gameObject.tag, shootPoint.position, transform.rotation);
    }        
}
