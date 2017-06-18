using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Texture2D veryHealthyPicture;
    public Texture2D healthyPicture;
    public Texture2D notHealthyPicture;
    public Texture2D dyingPicture;
    private Renderer pictureRenderer;
    private void Awake()
    {
        pictureRenderer = GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
        if (playerHealth.currentHealth > 90)
        {
            pictureRenderer.material.mainTexture = veryHealthyPicture;
        }
        else if (playerHealth.currentHealth > 50)
        {
            pictureRenderer.material.mainTexture = healthyPicture;
        }
        else if (playerHealth.currentHealth > 25)
        {
            pictureRenderer.material.mainTexture = notHealthyPicture;
        }
        else if (playerHealth.currentHealth > 1)
        {
            pictureRenderer.material.mainTexture = dyingPicture;
        }
        else
        {
            gameObject.SetActive(false);
        }

        transform.up = Camera.main.transform.position - transform.position;
        transform.forward = -Camera.main.transform.up;
    }
}
