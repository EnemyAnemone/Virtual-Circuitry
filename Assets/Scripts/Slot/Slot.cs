using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public Slot NorthSlot;
    public Slot SouthSlot;

    void Start()
    {

    }

    public void SetNeighborSlots(Slot newNorthSlot, Slot newSouthSlot)
    {
        NorthSlot = newNorthSlot;
        SouthSlot = newSouthSlot;
    }

    void Update()
    {

    }
}
