using UnityEngine;

public class TestSubscriber2 : MonoBehaviour
{
    [SerializeField] Person person;

    private void Start()
    {
        print("����� ���������� 2");
        person.OnDied += OnDied;
        person.OnDiedEvent += OnDied;
    }

    private void OnDied(string name, int age)
    {
        print($"��� ����� {name}...");
    }
}
