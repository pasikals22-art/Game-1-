using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 6f;
    public float attackCooldown = 1.5f;

    private float cooldownTimer;

    private ShootTwoDirection shooter;

    void Start()
    {
        shooter = GetComponent<ShootTwoDirection>();
    }

    void Update()
    {
        if (player == null || shooter == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // countdown timer
        cooldownTimer -= Time.deltaTime;

        if (distance <= detectionRange)
        {
            if (cooldownTimer <= 0f && !shooter.attacking)
            {
                StartCoroutine(shooter.ExecuteAttack(0.3f));
                cooldownTimer = attackCooldown;
            }
        }
    }
}