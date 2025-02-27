using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStatsManager PlayerStatsManager;
    
    private float lastAttackTime = 0f;

    
    
    
    
    private void Start() => PlayerStatsManager = FindFirstObjectByType<PlayerStatsManager>().GetComponent<PlayerStatsManager>();

    
    
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + 0.5f)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }


    
    
    
    private void Attack()
    {
        PlayerStats playerStats = PlayerStatsManager.PlayerStats;
        int critrate = Random.Range(0, 101) <= playerStats.CritRate ? 1 : 0;
        int dmg = Mathf.RoundToInt(playerStats.ATK * (1 + critrate * (playerStats.CritDMG / 100f)));
        Transform target = GetEnemy();
        if (target != null)
        {
            Debug.Log($"{target.name} has taken {dmg} DMG");
        }
    }

    private Transform GetEnemy()
    {
        Transform playerCamera = transform.Find("Camera");
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return hit.collider.transform;
            }
        }
        return null;
    }
}