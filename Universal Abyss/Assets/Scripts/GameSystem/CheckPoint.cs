using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private float _x, _y;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        _x = _playerPosition.position.x;
        _y = _playerPosition.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Save X Pos", _x);
        PlayerPrefs.SetFloat("Save Y Pos", _y);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save X Pos"))
        {
            _x = PlayerPrefs.GetFloat("Save X Pos");
        }

        if (PlayerPrefs.HasKey("Save Y Pos"))
        {
            _y = PlayerPrefs.GetFloat("Save Y Pos");
        }

        _playerPosition.transform.position = new Vector3(_x, _y);
    }
}
