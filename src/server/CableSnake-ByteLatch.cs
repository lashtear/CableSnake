using LogicAPI.Server.Components;

namespace CableSnake
{
    public class ByteLatch : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            if (this.Inputs[0].On) {
                for (int c=0; c<8; ++c) {
                    this.Outputs[c].On = this.Inputs[c+1].On;
                }
            }
        }
    }
}