using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
