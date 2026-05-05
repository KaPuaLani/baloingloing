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
    public float minSprintSpeed = 3f;
    public float minJumpHeight = 1f;

    [Header("References")]
    public FirstPersonController playerController;

    private float baseSpeed;
    private float baseSprintSpeed;
    private float baseJumpHeight;

    void Start()
    {
        if (playerController == null)
        {
            playerController = GetComponent<FirstPersonController>();
        }

        baseSpeed = playerController.MoveSpeed;
        baseSprintSpeed = playerController.SprintSpeed;
        baseJumpHeight = playerController.JumpHeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Food"))
        {
            AddFood();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Apple"))
        {
            ResetGreed();
            Destroy(other.gameObject);
        }
    }

    public void AddCoin(int amount = 1)
    {
        coinsCollected += amount;
        ApplyPenalty();
    }

    public void AddFood(int amount = 1)
    {
        foodCollected += amount;
        ApplyPenalty();
    }

    void ApplyPenalty()
    {
        int totalItems = coinsCollected + foodCollected;

        float newSpeed = baseSpeed - (totalItems * speedPenaltyPerItem);
        float newSprint = baseSprintSpeed - (totalItems * speedPenaltyPerItem);
        float newJump = baseJumpHeight - (totalItems * jumpPenaltyPerItem);

        playerController.MoveSpeed = Mathf.Max(minSpeed, newSpeed);
        playerController.SprintSpeed = Mathf.Max(minSprintSpeed, newSprint);
        playerController.JumpHeight = Mathf.Max(minJumpHeight, newJump);
    }

    void ResetGreed()
    {
        coinsCollected = 0;
        foodCollected = 0;

        playerController.MoveSpeed = baseSpeed;
        playerController.SprintSpeed = baseSprintSpeed;
        playerController.JumpHeight = baseJumpHeight;
    }
}