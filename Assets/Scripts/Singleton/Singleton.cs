using UnityEngine;

namespace SPACE.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Public Fields
        
        public static T Instance
        {
            get
            {
                if (instace == null)
                {
                    instace = FindObjectOfType<T>();
    
                    if (instace == null)
                    {
                        GameObject createdGameObject = new GameObject();
    
                        createdGameObject.name = typeof(T).Name;
                        instace = createdGameObject.AddComponent<T>();
                    }
                }
                
                return instace;
            }
        }
        
        #endregion
        #region Private Fields
    
        private static T instace;
    
        #endregion
        #region Serializable Fields

        [Header("General")]
        [Tooltip("Set true if you want don't destroy on load to the object.")]
        [SerializeField] private bool _dontDestroyOnLoad;

        #endregion

        /// <summary>
        /// Helps for initialization.
        /// </summary>
        protected virtual void Awake()
        {
            if (instace == null)
            {
                instace = this as T;
                
                if(_dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}