using UnityEngine;

public class FishingSpot : MonoBehaviour
{
    public float fishTime = 5f;

    bool hasFish = false;

    void Start()
    {
        InvokeRepeating(nameof(CatchFish), fishTime, fishTime);
    }

    void CatchFish()
    {
        hasFish = true;
    }

    public bool HasFish()
    {
        return hasFish;
    }

    public void TakeFish()
    {
        hasFish = false;
    }
}
