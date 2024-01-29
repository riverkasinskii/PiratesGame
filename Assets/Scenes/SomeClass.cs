using UnityEngine;

public class SomeClass : MonoBehaviour
{
    [SerializeField] private Person person;

    private void Start()
    {
        person.OnDied("Вася", 70);        
    }
}
