using UnityEngine;

[CreateAssetMenu(fileName = "LifeData", menuName = "Data/LifeData")]
public class LifeData : ScriptableObject
{

    #region Fields/Properties

    /// <summary>
    /// Max value allowed for <see cref="CurrentLife"/>.
    /// </summary>
    public int MaxLife
    {
        get { return _maxLife; }
    }

    /// <summary>
    /// Current life changed at runtime.
    /// </summary>
    public int CurrentLife
    {
        get { return _currentLife; }
    }

    [SerializeField]
    private int _maxLife = 100;

    [SerializeField]
    private int _currentLife = 100;

    #endregion

    #region

    /// <summary>
    /// Sets <see cref="CurrentLife"/> to <see cref="MaxLife"/>.
    /// </summary>
    public void Reset()
    {
        _currentLife = _maxLife;
    }

    /// <summary>
    /// Changes the <see cref="CurrentLife"/> by delta.
    /// Values out of 0 to <see cref="MaxLife"/> range are clamped.
    /// </summary>
    public bool TryChangeCurrentLife(int delta)
    {
        int _previousLife = _currentLife;
        _currentLife = Mathf.Clamp(_currentLife + delta, 0, _maxLife);
        return _currentLife != _previousLife;
    }

    #endregion

}