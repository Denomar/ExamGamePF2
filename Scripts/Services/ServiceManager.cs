using UnityEngine;

namespace gameservices
{
    public class ServiceManager : MonoBehaviour
    {

        private static ServiceManager _instance;

        void Awake()
        {
            if (_instance)
            {
                DestroyImmediate(this);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            ActivateServices();

        }

        private void ActivateServices()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            foreach (var service in GetComponentsInChildren<Service>())
            {
                service.Execute();
            }
        }

        public T GetService<T>() where T : Service
        {
            return GetComponentInChildren<T>();
        }

        public static ServiceManager GetInstance()
        {
            return _instance;
        }
    }
}
