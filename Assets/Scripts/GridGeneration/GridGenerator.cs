using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public GameObject SlotPrefab;


	// Set the top ones to private if you want
	public int horizontalSlotCount = 0;
    public int HorizontalSlotCount {
		get { return this.horizontalSlotCount; }
		set { 
			this.horizontalSlotCount = value; 
		}
	}

	public int verticalSlotCount = 0;
	public int VerticalSlotCount {
		get { return this.verticalSlotCount; }
		set {
			this.verticalSlotCount = value;
		}
	}

	public float slotSize = 0;
	public float SlotSize {
		get { return this.slotSize; }
		set {
			this.slotSize = value;
		}
	}

	public float slotSpacing = 0;
	public float SlotSpacing {
		get { return this.slotSpacing; }
		set {
			this.slotSpacing = value;
		}
	}

	public float slotHorizontalOffset = 0;
	public float SlotHorizontalOffset {
		get { return this.slotHorizontalOffset; }
		set {
			this.slotHorizontalOffset = value;
		}
	}

	public float slotVerticalOffset = 0;
	public float SlotVerticalOffset {
		get { return this.slotVerticalOffset; }
		set {
			this.slotVerticalOffset = value;
		}
	}

	private List<List<Slot>> slots;

	void Start () {
		if (SlotPrefab == null)
        {
            SlotPrefab = Resources.Load<GameObject>("Prefabs/Slot");

            if (SlotPrefab.GetComponent<Slot>() == null)
            {
                Debug.Log("Slot prefab does not have a slot script");
                return;
            }
        }

        InitializeSlotVariables();
        InitializeSlotAttributes();

        GenerateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitializeSlotVariables()
    {
        if (HorizontalSlotCount <= 0)
        {
            HorizontalSlotCount = 5;
        }
        if (VerticalSlotCount <= 0)
        {
            VerticalSlotCount = 5;
        }

    }

    private void InitializeSlotAttributes()
    {
        if (SlotSize == 0)
        {
            SlotSize = .025f;
        }
        if (SlotSpacing == 0)
        {
            SlotSpacing = .05f;
        }
    }

    private List<List<Slot>> GenerateGrid()
    {
        slots = new List<List<Slot>>();

        SlotHorizontalOffset = (HorizontalSlotCount * SlotSize + (HorizontalSlotCount - 1) * SlotSpacing) / 2;
        SlotVerticalOffset = (VerticalSlotCount * SlotSize + (VerticalSlotCount - 1) * SlotSpacing) / 2;

        for (int i = 0; i < HorizontalSlotCount; i++)
        {
            slots.Add(new List<Slot>());

            for (int j = 0; j < VerticalSlotCount; j++)
            {
                Slot slot;
                if (j > 0)
                {
                    slot = CreateSlot(i, j, slots[i][j - 1]);
                }
                else
                    slot = CreateSlot(i, j);
                slots[i].Add(slot);
            }
        }

        return slots;
    }

    private Slot CreateSlot(int horizontalPosition, int verticalPosition)
    {
        float horizontalCenter = horizontalPosition * (SlotSpacing + SlotSize) + (SlotSize / 2) - SlotHorizontalOffset;
        float verticalCenter = verticalPosition * (SlotSpacing + SlotSize) + (SlotSize / 2) - SlotVerticalOffset;

        Vector3 positionalVector = new Vector3(horizontalCenter, 0, verticalCenter);
        Vector3 scaleVector = new Vector3(SlotSize, .1f, SlotSize);

        GameObject slot = Instantiate<GameObject>(SlotPrefab, positionalVector, Quaternion.identity, this.gameObject.transform);
        slot.transform.localScale = scaleVector;
        Slot slotScript = slot.GetComponent<Slot>();
        return slotScript;
    }

    private Slot CreateSlot(int horizontalPosition, int verticalPosition, Slot previousSlot)
    {
        Slot slot = CreateSlot(horizontalPosition, verticalPosition);
        if (previousSlot != null)
        {
            slot.SouthSlot = previousSlot;
            previousSlot.NorthSlot = slot;
        }
        return slot;
    }

    private GameObject CreateWires()
    {
        return null;
    }
}
