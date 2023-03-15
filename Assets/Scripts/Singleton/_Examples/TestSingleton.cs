using UnityEngine;

namespace SPACE.Singleton
{
    public class TestSingleton : MonoBehaviour
    {
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Start()
        {
            Debug.Log("Singleton Design Pattern example started.");
            Debug.Log("Press 'E' to execute Game Manager.");
        }

        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                GameManager.Instance.Execute();
        }
    }
}
