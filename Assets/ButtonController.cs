using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject objectToDisappear;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToDisappear.SetActive(false);
        }
    }
}
