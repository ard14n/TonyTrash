using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable", fileName = "Generic Consumable")]
public class Consumable : Item {

    [Header("Consumable Properties")]
    public Types ItemType;
    public int amount;

	public enum Types
    {
        HealthPU, 
        MagnetPU, 
        JumpPU,
        BombPU
    }
}
