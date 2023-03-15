using UnityEngine;

namespace SPACE.Facade
{
    public class Facade : MonoBehaviour
    {
        #region Private Fields

        private GameManager _gameManager;

        #endregion
        
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Facade Design Pattern example started.");

            _gameManager = new GameManager();
            
            Debug.Log("Press 'A' to increase score.");
            Debug.Log("Press 'S' to decrease score.");
            Debug.Log("Press 'D' to play sound.");
        }
                
        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _gameManager.IncreaseScore();
            
            if (Input.GetKeyDown(KeyCode.S))
                _gameManager.DecreaseScore();
            
            if (Input.GetKeyDown(KeyCode.D))
                _gameManager.PlaySound();
        }
    }

    /// <summary>
    /// Game Manager.
    /// </summary>
    public class GameManager
    {
        #region Private Fields

        private ScoreManager _scoreManager;
        private SoundManager _soundManager;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameManager()
        {
            _scoreManager = new ScoreManager();
            _soundManager = new SoundManager();
        }

        /// <summary>
        /// Helps for increase score.
        /// </summary>
        public void IncreaseScore()
        {
            _scoreManager.IncraseScore();
        }

        /// <summary>
        /// Helps for decrease score.
        /// </summary>
        public void DecreaseScore()
        {
            _scoreManager.DecreaseScore();
        }

        /// <summary>
        /// Helps for play sound.
        /// </summary>
        public void PlaySound()
        {
            _soundManager.PlaySound();
        }
    }

    /// <summary>
    /// Score Manager.
    /// </summary>
    public class ScoreManager
    {
        /// <summary>
        /// Helps for increase score.
        /// </summary>
        public void IncraseScore()
        {
            Debug.Log("Score increased.");
        }
        
        /// <summary>
        /// Helps for decrease score.
        /// </summary>
        public void DecreaseScore()
        {
            Debug.Log("Score decreased.");
        }
    }

    /// <summary>
    /// Sound Manager.
    /// </summary>
    public class SoundManager
    {
        /// <summary>
        /// Helps for play sound.
        /// </summary>
        public void PlaySound()
        {
            Debug.Log("Sound played.");
        }
    }
}