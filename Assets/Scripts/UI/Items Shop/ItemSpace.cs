using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpace : MonoBehaviour
{
    [SerializeField]
    private GameObject slot;
    public void DrawSlotItem(List<Items> item)
    {
        int x = -120;
        int y = 60;
        for (int i = 0; i < item.Count; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + x, transform.position.y + y);
            GameObject newSlot = Instantiate(slot, newPos, Quaternion.identity, transform);
            newSlot.GetComponent<SlotItem>().SetItem(item[i]);
            x += 60;
            if (x > 120)
            {
                x = -120;
                y -= 60;
            }
        }
    }
}
