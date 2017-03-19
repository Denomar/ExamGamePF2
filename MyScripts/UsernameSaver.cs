using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using gameservices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsernameSaver  : MonoBehaviour
{

    public const string ErrorMatch = "Only symbols a-z,A-Z,0-9";
    public const string ErrorLenght = "Name must contain more than 2 symbols";

    [SerializeField] private InputField _input;
    [SerializeField] private Text _errorString;
    [SerializeField] private string _regString = "[a-z,A-Z,0-9]";
    [SerializeField] private string _username ;//= _input.text.ToString();
    private Regex _regex;

    private void Awake()
    {
        _regex = new Regex(_regString);
        _input.text = ServiceManager.GetInstance().GetService<ConfigurationService>().Username;
    }

    public void OnOkClick()
    {
        string uname = _input.text;

        if (uname.Length < 2)
        {
            _errorString.text = ErrorLenght;
            return;
        }
        if (!_regex.IsMatch(uname))
        {

            _errorString.text = ErrorMatch;
            return;
        }




        _username = _input.text.ToString();
        ServiceManager.GetInstance().GetService<ConfigurationService>().Username = _username;

        SceneManager.LoadScene("L1");


    }

    }
/*public  class MyGameData
{
    private Dictionary<string, string> _heroName;
    private static MyGameData _gameInstance;

    public MyGameData()
         {
            // Dictionary<string, string>
             _heroName= new Dictionary<string, string>();

         }

    public MyGameData GetInstance()
    {

        if (_gameInstance == null)
        {
            _gameInstance = new MyGameData();


        }
        return _gameInstance;
    }

    public string GetName(string sceneName)
    {
        if (!_heroName.ContainsKey(sceneName))
        {
            _heroName.Add(sceneName, "L1");

        }
        return  _heroName[sceneName];
    }

    public string SetName(string sceneName, string value)
    {
        if(_heroName.ContainsKey(sceneName))

        {
            _heroName[sceneName] = value;
        }
        else

            _heroName.Add(sceneName, value);

        return _heroName[sceneName];
    }
//    MyGameData.GetInstance().SetName("L2",GUIText);


}
//MyGameData.GetInstance().GetName("L2", GUIText);*/
