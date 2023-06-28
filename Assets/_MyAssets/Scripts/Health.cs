using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int currentHealth = 3;
    [SerializeField]
    private int maxHealth = 3;
    private bool canBeDamaged = true;
    private float damageImmunityTime = 0.15f;

    public UnityEvent<int> OnHealthChange;

    public static event Action OnPlayerDeath;

    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            OnHealthChange?.Invoke(CurrentHealth);
        }
    }

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public void GetHit()
    {
        if (!canBeDamaged)
            return;

        StartCoroutine(DamageImmunity());
        CurrentHealth--;
        if (CurrentHealth <= 0)
        {
            transform.parent.position = new Vector2(-2.4f, 0);
            OnPlayerDeath?.Invoke();
        }
    }

    IEnumerator DamageImmunity()
    {
        canBeDamaged = false;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageImmunityTime);
        canBeDamaged = true;
        spriteRenderer.color = Color.white;
    }
}
