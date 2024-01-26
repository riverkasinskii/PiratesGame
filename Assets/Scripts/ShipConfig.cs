using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "CreateShip")]
public class ShipConfig : ScriptableObject
{
    public float movementSpeed;
    public float angleOffset;
    public float rotationSpeed;
    public float reloadTime;    
}
