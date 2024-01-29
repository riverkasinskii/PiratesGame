using UnityEngine;

public class TestSubscriber1 : MonoBehaviour
{
    [SerializeField] Person person;    

    private void Start()
    {
        print("Старт подписчика 1");
        person.OnDied += OnDied;
        person.OnDiedEvent += OnDied;       
    }

    private void OnDied(string name, int age)
    {
        print($"Он умер в возрасте {age} лет");
    }

    private void TestMethodSubscriber1(string message)
    {
        print($"Сообщение {message}");
    }
}
