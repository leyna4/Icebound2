using UnityEngine;
using TMPro;

public class PlayerFish : MonoBehaviour
{
    public int fishCount = 0;

    public TextMeshProUGUI fishText;
    public PlayerHealth playerHealth;
    public int healAmount = 1;

    FishingSpot currentSpot;

    void Start()
    {
        UpdateFishUI();
    }

    void Update()
    {
        // Balýk alma
        if (Input.GetKeyDown(KeyCode.E) && currentSpot != null)
        {
            if (currentSpot.HasFish())
            {
                fishCount++;
                currentSpot.TakeFish();
                UpdateFishUI();
            }
        }

        // Balýk yeme
        if (Input.GetKeyDown(KeyCode.F) && fishCount > 0)
        {
            fishCount--;
            playerHealth.Heal(healAmount);
            UpdateFishUI();
        }
    }

    void UpdateFishUI()
    {
        fishText.text = "Fish: " + fishCount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FishingSpot"))
        {
            currentSpot = other.GetComponent<FishingSpot>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FishingSpot"))
        {
            currentSpot = null;
        }
    }
}
