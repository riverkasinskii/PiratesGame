using UnityEngine;

public class PlayerShip : Ship
{
    protected override void Move()
    {        
        transform.Translate(Input.GetAxis("Vertical") * 
            shipConfig.movementSpeed * 
            Time.deltaTime * 
            Vector2.down);
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (timer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                timer = shipConfig.reloadTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
