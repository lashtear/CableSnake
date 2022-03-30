using LogicAPI.Server.Components;

namespace CableSnake
{
    public class ThroughBlotter : LogicComponent
    {
        protected override void DoLogicUpdate() => this.Outputs[0].On = this.Inputs[0].On;
    }
}
