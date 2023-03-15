using UnityEngine;

namespace SPACE.Factory
{
    public class Factory : MonoBehaviour
    {
        #region Private Fields

        private CarCreator _carCreator;
        private HelicopterCreator _helicopterCreator;

        #endregion
        
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Factory Design Pattern example started.");

            _carCreator = new CarCreator();
            _helicopterCreator = new HelicopterCreator();

            Debug.Log("Press 'D' for create car.");
            Debug.Log("Press 'F' for create helicopter.");
        }

        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
                _carCreator.CreateVehicle();
            
            if (Input.GetKeyDown(KeyCode.F))
                _helicopterCreator.CreateVehicle();
        }
    }
    
    /// <summary>
    /// Base Creator.
    /// </summary>
    public abstract class Creator
    {
        /// <summary>
        /// Helps for create vehicle.
        /// </summary>
        /// <returns></returns>
        public abstract IVehicle CreateVehicle();
    }

    /// <summary>
    /// Car Creator.
    /// </summary>
    public class CarCreator : Creator
    {
        /// <summary>
        /// Helps for create vehicle.
        /// </summary>
        /// <returns></returns>
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }
    
    /// <summary>
    /// Helicopter creator.
    /// </summary>
    public class HelicopterCreator : Creator
    {
        /// <summary>
        /// Helps for create vehicle.
        /// </summary>
        /// <returns></returns>
        public override IVehicle CreateVehicle()
        {
            return new Helicopter();
        }
    }

    /// <summary>
    /// Vehicle Interface.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute();
    }

    /// <summary>
    /// Car Class.
    /// </summary>
    public class Car : IVehicle
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Car()
        {
            Debug.Log("Car created.");
            Execute();
        }

        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            Debug.Log("Hey it's a car!");
        }
    }

    /// <summary>
    /// Helicopter Class.
    /// </summary>
    public class Helicopter : IVehicle
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Helicopter()
        {
            Debug.Log("Helicopter created.");
            Execute();
        }

        /// <summary>
        /// Helps for execute.
        /// </summary>
        public void Execute()
        {
            Debug.Log("Hey it's a helicopter!");
        }
    }
}