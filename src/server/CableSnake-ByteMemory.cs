using LogicAPI.Server.Components;

namespace CableSnake
{
    public class ByteMemory : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            if (this.Inputs[8].On) {
                for (int c=0; c<8; ++c) {
                    this.Outputs[c].On = this.Inputs[c].On;
                }
            }
        }
    }
}