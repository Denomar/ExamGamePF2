using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CHangeWeaponUI : MonoBehaviour
{

    [SerializeField] private Image _autogun;
    [SerializeField] private Image _pistol;
    [SerializeField] private characterController _controller;
    private Image _current;
    private WeaponType _currentType;

    private void Awake()
    {
        _currentType = WeaponType.Autogun;
        SetWeaponImage(_autogun);
        _controller.ChangeWeapon(WeaponType.Autogun);
    }

    private void SetWeaponImage(Image image)
    {
        if (_current)
        {
            _current.gameObject.SetActive(false);
        }
        _current = image;
        _current.gameObject.SetActive(true);
    }

    public void ChangeWeapon()
    {
        if (_currentType == WeaponType.Autogun)
        {
            _currentType = WeaponType.Pistol;
            SetWeaponImage(_pistol);
            _controller.ChangeWeapon(WeaponType.Pistol);
        }
        else
        {
            _currentType = WeaponType.Autogun;
            SetWeaponImage(_autogun);
            _controller.ChangeWeapon(WeaponType.Autogun);
        }
    }
}
