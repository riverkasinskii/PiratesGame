using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : Ship
{
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ui.UpdateHp(currentHealth);
        if (currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected override void Start()
    {
        base.Start();
        ui.UpdateHp(currentHealth);
    }

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
            if (Input.GetKeyDown(KeyCode.Space))
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
