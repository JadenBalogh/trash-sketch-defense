using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorText : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float deathTime = 1.5f;

    private void Start()
    {
        StartCoroutine(DestroySelf());
    }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
