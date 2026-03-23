using UnityEngine;
using StarterAssets;

public class GreedFactor : MonoBehaviour
{
    [Header("Tracked Values")]
    public int coinsCollected = 0;
    public int foodCollected = 0;

    [Header("Penalty Settings")]
    public float speedPenaltyPerItem = 0.1f;
    public float jumpPenaltyPerItem = 0.05f;

    [Header("Minimum Limits")]
    public float minSpeed = 2f;
    public float minJumpHeight = 1f;

    [Header("References")]
    public FirstPersonController playerController;

    private float baseSpeed;
    private float baseJumpHeight;

    void Start()
    {
        if (playerController == null)
        {
            playerController = GetComponent<FirstPersonController>();
        }

        // Store original values from Starter Assets controller
        baseSpeed = playerController.MoveSpeed;
        baseJumpHeight = playerController.JumpHeight;
    }

    // Call this when a coin is collected
    public void AddCoin(int amount = 1)
    {
        coinsCollected += amount;
        ApplyPenalty();
    }

    // Call this when food is collected
    public void AddFood(int amount = 1)
    {
        foodCollected += amount;
        ApplyPenalty();
    }

    void ApplyPenalty()
    {
        int totalItems = coinsCollected + foodCollected;

        float newSpeed = baseSpeed - (totalItems * speedPenaltyPerItem);
        float newJump = baseJumpHeight - (totalItems * jumpPenaltyPerItem);

        // Clamp so player still functions
        playerController.MoveSpeed = Mathf.Max(minSpeed, newSpeed);
        playerController.JumpHeight = Mathf.Max(minJumpHeight, newJump);
    }
}