using UnityEngine;

public class FishingSpot : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip fishCaughtSound;
    private AudioSource audioSource;

    public float fishTime = 5f;

    bool hasFish = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(CatchFish), fishTime, fishTime);
    }

    void CatchFish()
    {
        hasFish = true;
        audioSource.PlayOneShot(fishCaughtSound);
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
