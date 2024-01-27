using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int speed = 5;
    [SerializeField] private int damage = 5;
    [SerializeField] private string myTag = string.Empty;

    private readonly float timeBeforeDestroy = 2f;

    private void Update() => transform.Translate(speed * Time.deltaTime * Vector2.down);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ship ship = collision.gameObject.GetComponent<Ship>();
        if (ship != null && !collision.gameObject.CompareTag(myTag))
        {
            ship.TakeDamage(damage);
            gameObject.SetActive(false);           
        }
        else
        {
            StartCoroutine(DelayBeforeDestroy());
        }
    }
    
    private IEnumerator DelayBeforeDestroy()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        gameObject.SetActive(false);
    }
}
