using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonElement : MonoBehaviour
{

    [SerializeField] private Image _star1;
    [SerializeField] private Image _star2;
    [SerializeField] private Image _star3;
    [SerializeField] private Text _text;
    [SerializeField] private Image _closeImage;

    [SerializeField] private Color _compliteColor;
    [SerializeField] private Color _closeColor;

    [SerializeField] private bool _isOpen;
    [SerializeField] private int _complitedLevel = 0;

    private void Start()
    {
        IsOpen = _isOpen;
        ComplitedLevel = _complitedLevel;

        //transform.GetChild(0).GetChild(2).GetComponent<LevelButtonElement>().ComplitedLevel = 3;
    }

    public bool IsOpen
    {
        get { return _isOpen; }
        set
        {
            _isOpen = value;
            if (_isOpen)
            {
                _closeImage.gameObject.SetActive(false);
            }
            else
            {
                _closeImage.gameObject.SetActive(true);
            }
        }
    }

    public int ComplitedLevel
    {
        get { return _complitedLevel; }
        set
        {
            _complitedLevel = value;
            OpenStars(value);
        }
    }

    public void OpenStars(int value)
    {
        switch (value)
        {
            case 1:
                _star1.color = _compliteColor;
                _star2.color = _closeColor;
                _star3.color = _closeColor;
                break;

            case 2:
                _star1.color = _compliteColor;
                _star2.color = _compliteColor;
                _star3.color = _closeColor;
                break;

            case 3:
                _star1.color = _compliteColor;
                _star2.color = _compliteColor;
                _star3.color = _compliteColor;
                break;

            default:
                _star1.color = _closeColor;
                _star2.color = _closeColor;
                _star3.color = _closeColor;
                break;
        }

}public void   onLevel1Click()
    {
        SceneManager.LoadScene("L1");
    }

      }

