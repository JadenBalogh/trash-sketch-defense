using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int goldAmount = 5;

    private int health = 0;
    private int positionIndex = 1;
    private Transform targetPoint;

    private void Start()
    {
        health = maxHealth;
        targetPoint = GameManager.PathSystem.GetPosition(positionIndex);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            positionIndex++;
            targetPoint = GameManager.PathSystem.GetPosition(positionIndex);
            if (targetPoint == null)
            {
                // we reached the end
                Destroy(gameObject);
                GameManager.ScoreSystem.DecreaseScore();
            }
        }
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.ScoreSystem.Gold += goldAmount;
            GameManager.SpawnSystem.SpawnedObjects.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
