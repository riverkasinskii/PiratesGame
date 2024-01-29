using UnityEngine;

public class TestSubscriber2 : MonoBehaviour
{
    [SerializeField] Person person;

    private void Start()
    {
        print("Старт подписчика 2");
        person.OnDied += OnDied;
        person.OnDiedEvent += OnDied;
    }

    private void OnDied(string name, int age)
    {
        print($"Его звали {name}...");
    }
}
