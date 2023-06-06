using UnityEngine;
using NUnit.Framework;

public class ButtonControllerTests
{
    [Test]
    public void OnCollisionEnter2D_PlayerCollision_ChangesButtonColor()
    {
        // Arrange
        GameObject buttonObject = new GameObject();
        ButtonController buttonController = buttonObject.AddComponent<ButtonController>();

        Color triggeredColor = Color.red;
        SpriteRenderer buttonRenderer = buttonObject.AddComponent<SpriteRenderer>();
        buttonRenderer.color = Color.white;
        buttonController.triggeredColor = triggeredColor;

        // Act
        buttonController.OnCollisionEnter2D(new Collision2D());

        // Assert
        Assert.AreEqual(triggeredColor, buttonRenderer.color);

        // Clean up
        Object.DestroyImmediate(buttonObject);
    }
}