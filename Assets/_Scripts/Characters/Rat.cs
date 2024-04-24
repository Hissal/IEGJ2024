using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour
{
    [SerializeField] Transform childTransform;
    [SerializeField] float speed;
    public bool active { get; private set; }

    private void FixedUpdate()
    {
        if (!active) return;

        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void OnCollisionStay(Collision collision)
    {
        print("Collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Eat
            print("eat child");
        }
        else
        {
            print("Collided with not player");
            collision.gameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        active = true;
    }
}
