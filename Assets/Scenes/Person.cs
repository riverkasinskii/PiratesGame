using System.Collections;
using UnityEngine;

public class Person : MonoBehaviour
{
    public delegate void Died(string name, int age);
    public Died OnDied;
    public event Died OnDiedEvent;

    private IEnumerator Start()
    {
        int currentAge = 70;
        int yearsUntilAge = Random.Range(2, 7);
        yield return new WaitForSeconds(yearsUntilAge);
        OnDied?.Invoke("Роберт", currentAge + yearsUntilAge);
        OnDiedEvent?.Invoke("Роберт", currentAge + yearsUntilAge);
    }
}
