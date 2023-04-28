using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // 最大HP
    public float currentHealth; // 現在のHP

    void Start()
    {
        currentHealth = maxHealth; // 最初は最大HPに設定する
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ダメージを受ける
        if (currentHealth <= 0)
        {
            Die(); // HPが0以下になったら死亡処理を実行する
        }
    }

    void Die()
    {
    SceneManager.LoadScene("GameOverScene");
    }
}







