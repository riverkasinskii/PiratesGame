using UnityEngine;

public class EnemyShip : Ship
{    
    private Transform target;
    [SerializeField] private float distanceToTarget = 5f;

    protected override void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;        
        base.Start();        
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > distanceToTarget)
        {
            Move();
        }
        SetAngle(target.position);
        if (timer <= 0)
        {
            Shoot();
            timer = shipConfig.reloadTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
