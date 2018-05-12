using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private Slot northSlot;
    private Slot southSlot;
	// Use this for initialization
	void Start () {
		
	}

    public void SetupNeighborSlots(Slot northSlot, Slot southSlot)
    {
        northSlot = northSlot;
        southSlot = southSlot;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
