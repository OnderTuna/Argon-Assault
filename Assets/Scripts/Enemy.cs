using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject expEffect;
    [SerializeField] private GameObject hitEffect;
    private Scoreboard scoreScript;
    private float point = 5f;
    [SerializeField] float enemyHealth = 10f;
    private float takenDamage = 1f;

    void Awake()
    {
        scoreScript = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        EnemyHealthProcess();
        HitTheEnemy();
        ScoreUpdate();
        if (enemyHealth < 1)
        {
            KillEnemy();
        }
    }

    private void HitTheEnemy()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
    }

    private void KillEnemy()
    {
        Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void ScoreUpdate()
    {
        scoreScript.ScoreCalculator(point);
    }

    private void EnemyHealthProcess()
    {
        enemyHealth -= takenDamage;
    }
}
