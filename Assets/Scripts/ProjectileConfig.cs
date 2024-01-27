using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "CreateProjectile")]
public class ProjectileConfig : ScriptableObject
{
    public string shipTag;
    public GameObject prefab;
    public int size;
}
