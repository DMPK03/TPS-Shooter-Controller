 
namespace Dmpk_TPS
{
    public class CustomCinemachineInputProvider : Cinemachine.CinemachineInputProvider
    {
        private void OnEnable() {
            InputManager.Esc += e => inputEnabled = !e;
        }

        protected override void OnDisable() {
            InputManager.Esc -= e => inputEnabled = !e;
        }
        
        private bool inputEnabled = true;

        public override float GetAxisValue(int axis)
        {
            if(!inputEnabled)
                return 0;
            return base.GetAxisValue(axis);  
        }
    }
}