using UnityEngine;
using System.Collections.Generic;

namespace SPACE.Observer
{
    public class Observer : MonoBehaviour
    {
        #region Private Fields

        private List<BaseObserver> _observers = new();

        #endregion

        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Observer Design Pattern example started.");

            AddObserver(new Foo());
            AddObserver(new Bar());

            Debug.Log("Press 'N' for notify all observers.");
        }

        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                Notify();
        }

        /// <summary>
        /// Helps for add observer.
        /// </summary>
        /// <param name="baseObserver"></param>
        public void AddObserver(BaseObserver baseObserver)
        {
            _observers.Add(baseObserver);
        }

        /// <summary>
        /// Helps for remove observer.
        /// </summary>
        /// <param name="baseObserver"></param>
        public void RemoveObserver(BaseObserver baseObserver)
        {
            _observers.Remove(baseObserver);
        }

        /// <summary>
        /// Helps for notify all observers.
        /// </summary>
        public void Notify()
        {
            _observers.ForEach(baseObserver =>
            {
                baseObserver.Execute();
            });
        }
    }
    
    /// <summary>
    /// Base Observer.
    /// </summary>
    public abstract class BaseObserver
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public abstract void Execute();
    }
    
    /// <summary>
    /// Sample Observer.
    /// </summary>
    public class Foo : BaseObserver
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public override void Execute()
        {
            Debug.Log("It's foo!");
        }
    }
    
    /// <summary>
    /// Sample Observer.
    /// </summary>
    public class Bar : BaseObserver
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public override void Execute()
        {
            Debug.Log("It's bar!");
        }
    }
}