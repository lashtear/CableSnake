using LogicAPI.Server.Components;

namespace CableSnake
{
    public class ThroughInverter : LogicComponent
    {
        protected override void DoLogicUpdate() => this.Outputs[0].On = !this.Inputs[0].On;
    }
}
