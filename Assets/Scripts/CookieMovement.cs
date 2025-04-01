using UnityEngine;

public class CookieMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public AudioSource EndSoundSource;

    public void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
