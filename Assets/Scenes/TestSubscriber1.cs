using UnityEngine;

public class TestSubscriber1 : MonoBehaviour
{
    [SerializeField] Person person;    

    private void Start()
    {
        print("����� ���������� 1");
        person.OnDied += OnDied;
        person.OnDiedEvent += OnDied;       
    }

    private void OnDied(string name, int age)
    {
        print($"�� ���� � �������� {age} ���");
    }

    private void TestMethodSubscriber1(string message)
    {
        print($"��������� {message}");
    }
}
