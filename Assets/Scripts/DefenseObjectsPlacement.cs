using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.9.11
/// </summary>

public class DefenseObjectsPlacement : MonoBehaviour
{
    public GameObject towerPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Ground"))
            {
                if (!IsTowerAtLocation(hit.transform.position))
                {
                    Instantiate(towerPrefab, hit.transform.position, Quaternion.identity);
                    Debug.Log("touched");
                }
            }
        }
    }
    bool IsTowerAtLocation(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f); // Adjust the radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Tower"))
            {
                return true;
            }
        }

        return false;
    }
}
