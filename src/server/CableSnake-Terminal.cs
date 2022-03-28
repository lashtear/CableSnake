using LogicAPI.Server.Components;

namespace CableSnake
{
    public class Terminal : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            base.Outputs[0].On = base.Inputs[0].On;
        }
    }
}