using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public Texture2D picture = new Texture2D(10,10);
    public GameObject pic;
    private CanvasGroup _fadeGroup;
    private float _loadTime;
    private float _minimumLogoTime = 3.0f;


    // Use this for initialization
    void Start()
    {

        _fadeGroup = FindObjectOfType<CanvasGroup>();
        _fadeGroup.alpha = 1;


        if (Time.time < _minimumLogoTime)

            _loadTime = _minimumLogoTime;
        else

            _loadTime = Time.time;

}
        // Update is called once per frame
     private   void Update()
        {
            if (Time.time < _minimumLogoTime)
            {
                _fadeGroup.alpha = 1 - Time.time;
            }

            if (Time.time > _minimumLogoTime && _loadTime != 0)
            {

                _fadeGroup.alpha = Time.time - _minimumLogoTime;
                if (_fadeGroup.alpha >= 1)
                {
                    Debug.Log("Change Scene");
                }
              //  GUITexture.texture = picture;
               // pic.SetActive(true);
 SceneManager.LoadScene("MenuScene");
            }


        }


}