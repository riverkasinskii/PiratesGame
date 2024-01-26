using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public ShipConfig shipConfig;

    [SerializeField] private Transform shootPoint;

    protected float timer;        
    private ObjectPooler objectPooler;        

    protected virtual void Start()
    {
        timer = shipConfig.reloadTime;
        objectPooler = ObjectPooler.Instance;
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
        objectPooler.SpawnFromPool(gameObject.tag, shootPoint.position, transform.rotation);
    }
}
