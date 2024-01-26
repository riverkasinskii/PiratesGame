using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Pool", menuName = "CreatePool")]
public class Pool : ScriptableObject
{
    public string shipTag;
    public GameObject prefab;
    public int size;
}
