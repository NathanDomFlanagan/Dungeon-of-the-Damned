using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject objectToDisappear;
    public Color triggeredColor; // New variable to hold the color of the button when triggered

    private Renderer buttonRenderer; // Reference to the button object's Renderer component
    private Color originalColor; // Variable to store the original color of the button
    private bool isTriggered; // Variable to track if the button has been triggered

    private void Start()
    {
        // Get the Renderer component from the button object
        buttonRenderer = GetComponent<Renderer>();

        // Store the original color of the button
        originalColor = buttonRenderer.material.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            // Disable the objectToDisappear game object
            objectToDisappear.SetActive(false);

            // Change the color of the button to the triggered color
            buttonRenderer.material.color = triggeredColor;

            // Set the button as triggered
            isTriggered = true;
        }
    }
}
