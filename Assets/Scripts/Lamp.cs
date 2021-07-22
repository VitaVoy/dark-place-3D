using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private GameObject _lamp;
    private bool _lampwork;

    private void Start()
    {
        _lamp.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _lampwork == false)
        {
            _lamp.SetActive(true);
            _lampwork = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && _lampwork == true)
        {
            _lamp.SetActive(false);
            _lampwork = false;
        }
    }
}
