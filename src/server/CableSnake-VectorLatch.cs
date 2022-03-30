using LogicAPI.Server.Components;

namespace CableSnake {
    public class VectorLatch : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            if (this.Inputs[0].On) {
                if (this.Inputs.Count != this.Outputs.Count + 1) 
                    throw new System.Exception("foo");
                for (int index = 0; index < this.Outputs.Count; ++index) {
                    this.Outputs[index].On = this.Inputs[index+1].On;
                }
            }
        }
    }
}