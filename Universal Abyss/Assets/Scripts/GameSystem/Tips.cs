using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _tableForText;


    private void Start()
    {
        if (_text != null)
        {
            _text.enabled = false;
        }
        if (_tableForText != null)
        {
            _tableForText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            _text.enabled = true;
            _tableForText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            _text.enabled = false;
            _tableForText.SetActive(false);
        }
    }
}
