using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedCap = 10f;
    [SerializeField] private bool invincible = false;
    //private float gravity = 4.81f; 

    public int lives = 3;
    public float invincibleTime = 1.5f;
    public float blinkInterval = 0.1f;

    private SpriteRenderer spriteRenderer;
    private UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, /*gravity * Time.deltaTime*/ 0, 0));
        if (gameObject.transform.rotation.z != Quaternion.identity.z)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
        
        if (gameObject.transform.position.y > 15 || gameObject.transform.position.y < 0)
        {
            PlayerDeath();
        }

        if (speed < speedCap) speed += 0.01f;
    }

    public void TakeDamage()
    {
        if (invincible) return;

        lives--;

        if (uiManager != null)
        {
            uiManager.UpdateHearts(lives);
        }

        if (lives <= 0)
        {
            PlayerDeath();
        }
        else
        {
            StartCoroutine(DamageFlicker()); 
        }
    }
    private IEnumerator DamageFlicker()
    {
        invincible = true; 
        float elapsedTime = 0f;

        while (elapsedTime < invincibleTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        spriteRenderer.enabled = true;
        invincible = false;
    }

    public void PlayerDeath()
    {
        if (invincible && lives > 0) return; 

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }
}
