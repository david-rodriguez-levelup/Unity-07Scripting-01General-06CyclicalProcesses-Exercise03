using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLifeController : MonoBehaviour
{

    #region Fields/Properties

    [SerializeField]
    [Tooltip("Player's LifeBehaviour component.")]
    private LifeBehaviour _playerLifeBehaviour;

    private Text _label;

    private Text _value;

    #endregion

    #region Lifecycle

    private void Awake()
    {
        _label = transform.Find("Label").GetComponent<Text>();
        _label.color = Color.black;

        _value = transform.Find("Value").GetComponent<Text>();
        _value.color = Color.black;
    }

    private void OnEnable()
    {
        _playerLifeBehaviour.OnLifeChangedActions += Refresh;
    }

    private void OnDisable()
    {
        _playerLifeBehaviour.OnLifeChangedActions -= Refresh;
    }

    #endregion

    #region Methods

    private void Refresh(int currentLife)
    {
        if (currentLife <= 0)
        {
            _label.color = Color.red;
            _value.color = Color.red;
        }
        _value.text = Convert.ToString(currentLife);
    }

    #endregion

}
