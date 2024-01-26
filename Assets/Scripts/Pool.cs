using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Pool", menuName = "CreateProjectilePool")]
public class Pool : ScriptableObject
{
    public string shipTag;
    public GameObject prefab;
    public int size;
}
