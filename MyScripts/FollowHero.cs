using UnityEngine;
using System.Collections;
using gameservices;
using UnityEngine.UI;

public class FollowHero : MonoBehaviour
{

    [SerializeField] private GameObject _hero;
    [SerializeField] private Vector2 _distance;

	// Use this for initialization
	void Start ()
	{
	    Text t =  GetComponent<Text>();
	    t.text = ServiceManager.GetInstance().GetService<ConfigurationService>().Username;
	}
	
	// Update is called once per frame
	void Update () {
	    transform.position = new Vector3(_hero.transform.position.x + _distance.x, _hero.transform.position.y + _distance.y);
	}
}
