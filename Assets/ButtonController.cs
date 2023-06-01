using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject objectToDisappear;
    public Color triggeredColor; // New variable to hold the color of the button when triggered

    private SpriteRenderer buttonRenderer; // Reference to the button object's SpriteRenderer component
    private Color originalColor; // Variable to store the original color of the button
    private bool isTriggered; // Variable to track if the button has been triggered

    private void Start()
    {
        // Get the SpriteRenderer component from the button object
        buttonRenderer = GetComponent<SpriteRenderer>();

        // Store the original color of the button
        originalColor = buttonRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            // Disable the objectToDisappear game object
            objectToDisappear.SetActive(false);

            // Change the color of the button to the triggered color
            buttonRenderer.color = triggeredColor;

            // Set the button as triggered
            isTriggered = true;
        }
    }
}

