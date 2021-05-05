using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot //beware its a PRIVATE class
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public int maxAmount;

        void Update()
        {
            if (ammoAmount < 0)
                ammoAmount = 0;
            if (ammoAmount > maxAmount)
                ammoAmount = maxAmount;
        }
    }



    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType, int reduceAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount -= reduceAmount;
    }

    public void IncraseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    public void ReloadCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = 10;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }//if no return
        return null;
    }
}
