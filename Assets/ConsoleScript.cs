using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleScript : MonoBehaviour {

    [SerializeField]
    GameObject consoleMessage;

    private void Start()
    {

        consoleMessage.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            consoleMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            consoleMessage.SetActive(false);
        }

    }

    private void Update()
    {
        if (consoleMessage.activeSelf)
        {
            if (Input.GetButton("Jump"))
            {
                SceneManager.LoadScene("Level 1");
            }
        }
    }

}
