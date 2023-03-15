using UnityEngine;

namespace SPACE.State
{
    public class State : MonoBehaviour
    {
        #region Private Fields

        private Character _character;

        #endregion
        
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("State Design Pattern example started.");

            _character = new Character();
            
            Debug.Log("Press 'I' to idle state.");
            Debug.Log("Press 'W' to move forward state.");
            Debug.Log("Press 'S' to move backward state.");
        }

        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                _character.UpdateCharacterState(new IdleState());
            
            if (Input.GetKeyDown(KeyCode.W))
                _character.UpdateCharacterState(new MoveForwardState());
            
            if (Input.GetKeyDown(KeyCode.S))
                _character.UpdateCharacterState(new MoveBackwardState());
            
            _character?.Execute();
        }
    }

    /// <summary>
    /// Character.
    /// </summary>
    public class Character
    {
        #region Private Fields

        private ICharacterState currentCharacterState;

        #endregion

        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            currentCharacterState?.Execute(this);
        }

        /// <summary>
        /// Helps for update character state.
        /// </summary>
        /// <param name="currentCharacterState"></param>
        public void UpdateCharacterState(ICharacterState currentCharacterState)
        {
            this.currentCharacterState?.Exit(this);
            this.currentCharacterState = currentCharacterState;
        }
    }

    /// <summary>
    /// Character State Interface.
    /// </summary>
    public interface ICharacterState
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        /// <param name="character"></param>
        void Execute(Character character);
        
        /// <summary>
        /// Helps for exit.
        /// </summary>
        /// <param name="character"></param>
        void Exit(Character character);
    }
    
    /// <summary>
    /// Idle State Interface.
    /// </summary>
    public class IdleState : ICharacterState
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        /// <param name="character"></param>
        public void Execute(Character character)
        {
            Debug.Log("Idle.");
        }

        /// <summary>
        /// Helps for exit.
        /// </summary>
        /// <param name="character"></param>
        public void Exit(Character character)
        {
            Debug.Log("Exit Idle.");
        }
    }

    /// <summary>
    /// Move Forward State Interface.
    /// </summary>
    public class MoveForwardState : ICharacterState
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        /// <param name="character"></param>
        public void Execute(Character character)
        {
            Debug.Log("Moving forward.");
        }
        
        /// <summary>
        /// Helps for exit.
        /// </summary>
        /// <param name="character"></param>
        public void Exit(Character character)
        {
            Debug.Log("Exit Move Forward.");
        }
    }
    
    /// <summary>
    /// Move Backward State Interface.
    /// </summary>
    public class MoveBackwardState : ICharacterState
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        /// <param name="character"></param>
        public void Execute(Character character)
        {
            Debug.Log("Moving backward.");
        }
        
        /// <summary>
        /// Helps for exit.
        /// </summary>
        /// <param name="character"></param>
        public void Exit(Character character)
        {
            Debug.Log("Exit Backward.");
        }
    }
}
