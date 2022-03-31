using LogicAPI.Client;
using LogicWorld.UI;
using CableSnake.Client;

public class CableSnakeClientMod : ClientMod {

//    public EditVectorLatchMenu m = new CableSnake.Client.EditVectorLatchMenu ();

    protected override void Initialize() {
        Logger.Info("CableSnake loading client mod");
        //ComponentMenusManager.Add((IEditComponentMenu) m);
        //m.Initialize();
    }
}