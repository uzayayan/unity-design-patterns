using UnityEngine;

namespace SPACE.Decorator
{
    public class Decorator : MonoBehaviour
    {
        /// <summary>
        /// Helps for initialization.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Decorator Design Pattern example started.");

            Debug.Log("Press 'A' to use health potion.");
            Debug.Log("Press 'S' to use speed potion.");
            Debug.Log("Press 'D' to use mixed potion.");
        }
        
        /// <summary>
        /// Called per frame.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                IPotion healthPotion = new HealthPotionDecorator(new BasePotion());
                healthPotion.Use();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                IPotion speedPotion = new SpeedPotionDecorator(new BasePotion());
                speedPotion.Use();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                IPotion mixedPotion = new HealthPotionDecorator(new SpeedPotionDecorator(new BasePotion()));
                mixedPotion.Use();
            }
        }
    }
    
    /// <summary>
    /// Potion Interface.
    /// </summary>
    public interface IPotion
    {
        /// <summary>
        /// Helps for use.
        /// </summary>
        void Use();
    }
    
    /// <summary>
    /// Base Potion.
    /// </summary>
    public class BasePotion : IPotion
    {
        /// <summary>
        /// Helps for use.
        /// </summary>
        public void Use() {}
    }

    /// <summary>
    /// Potion Decorator.
    /// </summary>
    public abstract class PotionDecorator : IPotion
    {
        private IPotion _potion;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="potion"></param>
        protected PotionDecorator(IPotion potion)
        {
            _potion = potion;
        }

        /// <summary>
        /// Helps for use.
        /// </summary>
        public virtual void Use()
        {
            _potion.Use();
        }
    }

    /// <summary>
    /// Speed Potion Decorator.
    /// </summary>
    public class SpeedPotionDecorator : PotionDecorator
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="potion"></param>
        public SpeedPotionDecorator(IPotion potion) : base(potion) {}

        /// <summary>
        /// Helps for use.
        /// </summary>
        public override void Use()
        {
            Debug.Log("Speed Potion used.");
            base.Use();
        }
    }
    
    /// <summary>
    /// Health Potion Decorator.
    /// </summary>
    public class HealthPotionDecorator : PotionDecorator
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="potion"></param>
        public HealthPotionDecorator(IPotion potion) : base(potion) {}

        /// <summary>
        /// Helps for use.
        /// </summary>
        public override void Use()
        {
            Debug.Log("Health Potion used.");
            base.Use();
        }
    }
}