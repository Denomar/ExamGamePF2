using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;

namespace gameservices
{
    public class ConfigurationService : Service
    {

        public const int CommandNone = 0;
        public const int CommandOpenMain = 1;
        public const int CommandOpenChoseLevelCtl = 2;
        public const int CommandOpenChoseLevelDuel = 3;
        public const int CommandOpenConfigurations = 4;

        public const string SignCTL = "CTL";
        public const string SignDuel = "DL";
        public const string SignStartStatuses = "<";
        public const string SignEndStatuses = ">";
        public const string SignDivideStatuses = ",";

        public const string SignStartStatusesOld = "{";
        public const string SignEndStatusesOld = "}";

        public const string KeyLevelStatus = "LevelStatusNew";
        public const string KeyLevelStatusOld = "LevelStatus";
        public const string KeyLevelCount = "LevelCount";
        public const string KeySoundVolume = "SoundVolume";
        public const string KeySoundState = "SoundState";
        public const string KeyMusicVolume = "MusicVolume";
        public const string KeyMusicState = "MusicState";
        public const string KeyAutomoveType = "AutomoveType";
        public const string KeyCurrentLevelCTL = "CurrentLevelCTL";
        public const string KeyCurrentLevelDuel = "CurrentLevelDuel";
        public const string KeyUsername = "Username";


        public const char LevelStatusOpened = '1';
        public const char LevelStatusClosed = '2';
        public const char LevelStatusComplited = '3';
        public const char LevelStatusInDeveloping = '4';

        public const string DefaultLevelCTLValue = "1222222222222222222222222222222222222222";
        public const string DefaultLevelDLValue = "12222222224444444444";
        public const string DefaultLevelSchemePattern = "CTL<{0}>,DL<{1}>";
        public const float DefaultSoundsVolume = 0.5f;
        public const float DefaultMusicVolume = 0.5f;
        public const string DefaultSoundsState = "true";
        public const string DefaultMusicState = "true";
        public const int DefaultAutomoveConfig = 0;
        public const int DefaultCurrentLevelCTL = 1;
        public const int DefaultCurrentLevelDuel = 1;
        public const string DefaultUsername = " Player";

        public const byte CTL = 1;
        public const byte Duel = 2;


        private static ConfigurationService _instance;
        [SerializeField] private float _soundsVolume;
        [SerializeField] private float _musicVolume;
        [SerializeField] private bool _soundStatus = true;
        [SerializeField] private bool _musciStatus = true;
        [SerializeField] private bool _neverOffDisplay;
        [SerializeField] private string _username = DefaultUsername;

        [SerializeField] private LevelStatus[] _levelStatusesCTL;
        [SerializeField] private LevelStatus[] _levelStatusesDuel;
        private int _currentLevelCTL = 1;
        private int _currentLevelDuel = 1;

        [SerializeField] private int _menuCommand = CommandNone;

        private List<IOnAudioPreferenceChanged> _audioPreferenceListeners;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                SavePreference();
            }
        }

        public int CurrentLevelCtl
        {
            get { return _currentLevelCTL; }
            set
            {
                _currentLevelCTL = value;
                SavePreference();
            }
        }

        public int CurrentLevelDuel
        {
            get { return _currentLevelDuel; }
            set
            {
                _currentLevelDuel = value;
                SavePreference();
            }
        }

        public LevelStatus[] LevelStatusesCtl
        {
            get { return _levelStatusesCTL; }
            set
            {
                _levelStatusesCTL = value;
                SavePreference();
            }
        }

        public LevelStatus[] LevelStatusesDuel
        {
            get { return _levelStatusesDuel; }
            set
            {
                _levelStatusesDuel = value;
                SavePreference();
            }
        }

        private void Awake()
        {
            _instance = this;
            LoadPreference();
            _audioPreferenceListeners = new List<IOnAudioPreferenceChanged>();

            if (_neverOffDisplay)
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
        }

        public float SoundsVolume
        {
            get { return _soundsVolume; }
            set
            {
                _soundsVolume = value;
                SavePreference();
                foreach (var listener in _audioPreferenceListeners)
                {
                    listener.OnSoundVolumeChanged(value);
                }
            }
        }

        public float MusicVolume
        {
            get { return _musicVolume; }
            set
            {
                _musicVolume = value;
                SavePreference();
                foreach (var listener in _audioPreferenceListeners)
                {
                    listener.OnMusicVolumeChanged(value);
                }
            }
        }

        public bool SoundStatus
        {
            get { return _soundStatus; }
            set
            {
                _soundStatus = value;
                SavePreference();
                foreach (var listener in _audioPreferenceListeners)
                {
                    listener.OnSoundStatusChanged(value);
                }
            }
        }

        public bool MusciStatus
        {
            get { return _musciStatus; }
            set
            {
                _musciStatus = value;
                SavePreference();
                foreach (var listener in _audioPreferenceListeners)
                {
                    listener.OnMusicStatusChanged(value);
                }
            }
        }

        public int MenuCommand
        {
            set { _menuCommand = value; }
            get { return _menuCommand; }
        }

        public void SavePreference()
        {
            PlayerPrefs.SetFloat(KeySoundVolume, _soundsVolume);
            PlayerPrefs.SetFloat(KeyMusicVolume, _musicVolume);
            PlayerPrefs.SetString(KeySoundState, _soundStatus.ToString());
            PlayerPrefs.SetString(KeyMusicState, _musciStatus.ToString());
            PlayerPrefs.SetString(KeyUsername, _username);

        }

        public void LoadPreference()
        {
            _musicVolume = PlayerPrefs.GetFloat(KeyMusicVolume, DefaultMusicVolume);
            _soundsVolume = PlayerPrefs.GetFloat(KeySoundVolume, DefaultSoundsVolume);
            _musciStatus = Convert.ToBoolean(PlayerPrefs.GetString(KeyMusicState, DefaultMusicState));
            _soundStatus = Convert.ToBoolean(PlayerPrefs.GetString(KeySoundState, DefaultSoundsState));
            _username = PlayerPrefs.GetString(KeyUsername, DefaultUsername);

        }

        public string UpdateScheme(string levelScheme)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < DefaultLevelSchemePattern.Length; i++)
            {
                if (levelScheme.Length <= i)
                {
                    builder.Append(DefaultLevelSchemePattern[i]);
                }
                else
                {
                    builder.Append(levelScheme[i]);
                }
            }
            return builder.ToString();
        }

        public static ConfigurationService GetInstance()
        {
            return _instance;
        }



        public void Notify()
        {
            foreach (var listener in _audioPreferenceListeners)
            {
                Notify(listener);
            }
        }

        public void Notify(IOnAudioPreferenceChanged listener)
        {
            listener.OnMusicStatusChanged(_musciStatus);
            listener.OnMusicVolumeChanged(_musicVolume);
            listener.OnSoundStatusChanged(_soundStatus);
            listener.OnSoundVolumeChanged(_soundsVolume);
        }

        public void AddAudioListener(IOnAudioPreferenceChanged listener)
        {
            _audioPreferenceListeners.Add(listener);
            Notify(listener);

        }

        public void RemoveAudioListener(IOnAudioPreferenceChanged listener)
        {
            _audioPreferenceListeners.Remove(listener);
        }

        public string ConvertStatusToString(LevelStatus[] statuses)
        {
            StringBuilder builder = new StringBuilder(statuses.Length);
            foreach (var statuse in statuses)
            {
                switch (statuse)
                {
                    case LevelStatus.Opened:
                        builder.Append(LevelStatusOpened);
                        break;

                    case LevelStatus.Closed:
                        builder.Append(LevelStatusClosed);
                        break;

                    case LevelStatus.Developing:
                        builder.Append(LevelStatusInDeveloping);
                        break;

                    case LevelStatus.Complited:
                        builder.Append(LevelStatusComplited);
                        break;
                }
            }
            return builder.ToString();
        }


        public LevelStatus[] ParseLevelStatus(string lvlStatus, byte type)
        {
            int symbInd;
            switch (type)
            {
                case CTL:
                    symbInd = lvlStatus.IndexOf(SignCTL, StringComparison.Ordinal);
                    break;


                case Duel:
                    symbInd = lvlStatus.IndexOf(SignDuel, StringComparison.Ordinal);
                    break;

                default:
                    return null;
            }

            int startInd = lvlStatus.IndexOf(SignStartStatuses, symbInd, StringComparison.Ordinal);
            int endInd = lvlStatus.IndexOf(SignEndStatuses, startInd, StringComparison.Ordinal);
            string lvlString = lvlStatus.Substring(startInd + 1, endInd - startInd - 1);
            //Debug.Log(lvlString);
            return ParseLevelStateAfterTyping(lvlString);
        }

        public LevelStatus[] ParseLevelStatusOld(string lvlStatus, byte type)
        {
            int symbInd;
            switch (type)
            {
                case CTL:
                    symbInd = lvlStatus.IndexOf(SignCTL, StringComparison.Ordinal);
                    break;


                case Duel:
                    symbInd = lvlStatus.IndexOf(SignDuel, StringComparison.Ordinal);
                    break;

                default:
                    return null;
            }

            int startInd = lvlStatus.IndexOf(SignStartStatusesOld, symbInd, StringComparison.Ordinal);
            int endInd = lvlStatus.IndexOf(SignEndStatusesOld, startInd, StringComparison.Ordinal);
            string lvlString = lvlStatus.Substring(startInd + 1, endInd - startInd - 1);
            //Debug.Log(lvlString);
            return ParseLevelStateAfterTyping(lvlString);
        }



        public LevelStatus[] ParseLevelStateAfterTyping(string lvlStatus)
        {

            LevelStatus[] statuses = new LevelStatus[lvlStatus.Length];
            for (int i = 0; i < lvlStatus.Length; i++)
            {
                switch (lvlStatus[i])
                {
                    case LevelStatusOpened:
                        statuses[i] = LevelStatus.Opened;
                        break;

                    case LevelStatusClosed:
                        statuses[i] = LevelStatus.Closed;
                        break;

                    case LevelStatusInDeveloping:
                        if (i < 20)
                            statuses[i] = LevelStatus.Closed;
                        else
                            statuses[i] = LevelStatus.Developing;
                        break;

                    case LevelStatusComplited:
                        statuses[i] = LevelStatus.Complited;
                        break;
                }
            }
            return statuses;
        }

        public override void Execute()
        {
            //
        }
    }

    public interface IOnAudioPreferenceChanged
    {
        void OnSoundStatusChanged(bool state);

        void OnMusicStatusChanged(bool state);

        void OnSoundVolumeChanged(float value);

        void OnMusicVolumeChanged(float value);
    }


    public enum LevelStatus
    {
        Opened,
        Closed,
        Complited,
        Developing
    }
}

