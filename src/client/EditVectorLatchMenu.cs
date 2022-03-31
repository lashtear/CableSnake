using LogicAPI.Data.BuildingRequests;
using LogicSettings;
using LogicUI.MenuParts;
using LogicWorld.BuildingManagement;
using LogicWorld.UI;
using LogicWorld.UnityBullshit;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CableSnake.Client
{
    public class EditVectorLatchMenu : EditComponentMenu
    {
        [SerializeField]
        private InputSlider InputCountSlider;

        protected override void OnStartEditing() => 
            this.InputCountSlider.SetValueWithoutNotify(
                (float) ((IEnumerable<EditingComponentInfo>) this.ComponentsBeingEdited)
                    .First<EditingComponentInfo>().Component.Data.OutputCount);

        public override void Initialize()
        {
            base.Initialize();
            this.InputCountSlider = new InputSlider();
            this.InputCountSlider.SliderInterval = 1f;
            this.InputCountSlider.Min = 1f;
            this.InputCountSlider.Max = (float) EditVectorLatchMenu.MaxBits;
            this.InputCountSlider.OnValueChangedInt += new Action<int>(this.InputCountSlider_OnValueChangedInt);
        }

        private void InputCountSlider_OnValueChangedInt(int value)
        {
            foreach (EditingComponentInfo editingComponentInfo in (IEnumerable<EditingComponentInfo>) this.ComponentsBeingEdited)
                BuildRequestManager.SendBuildRequest((BuildRequest) new BuildRequest_ChangeDynamicComponentPegCounts(editingComponentInfo.Address, value+1, value));
        }

        protected override IEnumerable<string> GetTextIDsOfComponentTypesThatCanBeEdited()
        {
            yield return "CS.VectorLatch";
        }

        [Setting_SliderInt("CS.Components.VectorLatch.MaxBits")]
        private static int MaxBits { get; set; } = 16;
    }
}
