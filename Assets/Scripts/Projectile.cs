using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string myTag = string.Empty;
    [SerializeField] private float timeBeforeDestroy = 3f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

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
