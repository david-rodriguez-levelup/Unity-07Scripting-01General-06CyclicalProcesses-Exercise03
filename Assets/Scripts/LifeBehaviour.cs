using UnityEngine;

public class LifeBehaviour : MonoBehaviour
{

    /// <summary>
    /// Delegate signature "LifeChanged" event.
    /// </summary>
    /// <param name="currentLife">Current life points after life change has been done.</param>
    public delegate void LifeChangedAction(int currentLife);

    #region Fields/Properties

    /// <summary>
    /// Delegates subscribed to "LifeChanged" event.
    /// </summary>
    public event LifeChangedAction OnLifeChangedActions;

    [SerializeField]
    [Tooltip("LifeData for this LifeBehaviour.")]
    private LifeData _lifeData;

    #endregion

    #region Lifecycle

    private void Start()
    {
        _lifeData.Reset();
        OnLifeChanged();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Apply damage to current life.
    /// </summary>
    /// <param name="damage">Points of damage.</param>
    public void ApplyDamage(int damage)
    {
        if (_lifeData.TryChangeCurrentLife(-damage))
        {
            OnLifeChanged();
        }
    }

    /// <summary>
    /// Apply healing to current life.
    /// </summary>
    /// <param name="healing">Points of healing.</param>
    public void ApplyHealing(int healing)
    {
        if (_lifeData.TryChangeCurrentLife(healing))
        {
            OnLifeChanged();
        }
    }

    private void OnLifeChanged()
    {
        OnLifeChangedActions?.Invoke(_lifeData.CurrentLife);
    }

    #endregion

}
