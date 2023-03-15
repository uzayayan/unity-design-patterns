using UnityEngine;

namespace SPACE.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            Debug.Log("Game Manager executed.");
        }
    }
}