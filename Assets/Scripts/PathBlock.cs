using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 2023.9.12
/// </summary>

public class PathBlock : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isDarkened = false;

    private void Start()
    {
        // Get the SpriteRenderer component and store the original color
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        // Cast a 2D ray downward to detect enemies in the block
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            // An enemy entered the block, darken the color
            if (!isDarkened)
            {
                spriteRenderer.color = originalColor * 0.5f; // Darken the color
                isDarkened = true;
                Debug.Log("in");
            }
        }
        else
        {
            // No enemy in the block, reset the color
            if (isDarkened)
            {
                spriteRenderer.color = originalColor; // Reset the color
                isDarkened = false;
                Debug.Log("out");
            }
        }
    }
}
