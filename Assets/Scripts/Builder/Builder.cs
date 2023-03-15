using UnityEngine;

namespace SPACE.Builder
{
    public class Builder : MonoBehaviour
    {
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Builder Design Pattern example started.");
            Debug.Log("Press 'A' to generate level.");
        }

        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LevelBuilder createdLevel = new LevelBuilder()
                    .SetName("Sample Level")
                    .SetBonusCurrency(5)
                    .SetPlayerCapacity(10)
                    .SetPlayersCanJump(true);
                
                createdLevel.PrintDetails();
            }
        }
    }

    public class LevelBuilder
    {
        #region Private Fields

        private string _name;
        private int _bonusCurrency;
        private int _playerCapacity;
        private bool _playersCanJump;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public LevelBuilder() {}

        /// <summary>
        /// Helps for set name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LevelBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Helps for set bonus currency.
        /// </summary>
        /// <param name="bonusCurrency"></param>
        /// <returns></returns>
        public LevelBuilder SetBonusCurrency(int bonusCurrency)
        {
            _bonusCurrency = bonusCurrency;
            return this;
        }
        
        /// <summary>
        /// Helps for set player capacity.
        /// </summary>
        /// <param name="playerCapacity"></param>
        /// <returns></returns>
        public LevelBuilder SetPlayerCapacity(int playerCapacity)
        {
            _playerCapacity = playerCapacity;
            return this;
        }

        /// <summary>
        /// Helps for set player can jump.
        /// </summary>
        /// <param name="playersCanJump"></param>
        /// <returns></returns>
        public LevelBuilder SetPlayersCanJump(bool playersCanJump)
        {
            _playersCanJump = playersCanJump;
            return this;
        }

        /// <summary>
        /// Helps for print details.
        /// </summary>
        public void PrintDetails()
        {
            Debug.Log("Level Created.");
            Debug.Log($"Name : {_name}");
            Debug.Log($"Bonus Currency : {_bonusCurrency}");
            Debug.Log($"Player Capacity : {_playerCapacity}");
            Debug.Log($"Players Can Jump : {_playersCanJump}");
        }
    }
}