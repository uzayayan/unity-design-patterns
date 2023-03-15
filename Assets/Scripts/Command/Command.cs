using UnityEngine;
using System.Collections.Generic;

namespace SPACE.Command
{
    public class Command : MonoBehaviour
    {
        #region Private Fields

        private Block _block;
        private Stack<ICommand> _commands = new();

        #endregion

        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Command Design Pattern example started.");

            _block = new Block();
            
            Debug.Log("Press 'A' to move left.");
            Debug.Log("Press 'D' to move right.");
            Debug.Log("Press 'U' to undo last move.");
        }
        
        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                AddCommand(new MoveLeftCommand(_block));
            
            if (Input.GetKeyDown(KeyCode.D))
                AddCommand(new MoveRightCommand(_block));
            
            if (Input.GetKeyDown(KeyCode.U))
                UndoCommand();
        }

        /// <summary>
        /// Helps for add command.
        /// </summary>
        private void AddCommand(ICommand command)
        {
            _commands.Push(command);
            command.Execute();
        }

        /// <summary>
        /// Helps for undo last command.
        /// </summary>
        private void UndoCommand()
        {
            _commands.TryPop(out ICommand command);
            command?.Undo();
        }
    }

    public class Block
    {
        #region Private Fields

        private Vector2 _coordinate = Vector2.zero;

        #endregion

        /// <summary>
        /// Helps for move.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector2 direction)
        {
            _coordinate += direction;
            
            Debug.Log($"Current Coordinate : {_coordinate}");
        }
    }

    /// <summary>
    /// Command Interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute();
        
        /// <summary>
        /// Helps for undo.
        /// </summary>
        public void Undo();
    }

    /// <summary>
    /// Move Left Command.
    /// </summary>
    public class MoveLeftCommand : ICommand
    {
        #region Private Fields

        private Block _block;

        #endregion
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="block"></param>
        public MoveLeftCommand(Block block)
        {
            _block = block;
        }
        
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            _block.Move(Vector2.left);
        }

        /// <summary>
        /// Helps for undo.
        /// </summary>
        public void Undo()
        {
            _block.Move(Vector2.right);
        }
    }
    
    /// <summary>
    /// Move Right Command.
    /// </summary>
    public class MoveRightCommand : ICommand
    {
        #region Private Fields

        private Block _block;

        #endregion
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="block"></param>
        public MoveRightCommand(Block block)
        {
            _block = block;
        }
        
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            _block.Move(Vector2.right);
        }

        /// <summary>
        /// Helps for undo.
        /// </summary>
        public void Undo()
        {
            _block.Move(Vector2.left);
        }
    }
}   