// Based on the AndGate and Displays in the MHG mod, e.g.:
// Decompiled with JetBrains decompiler
// Type: LogicWorld.ClientCode.AndGateVariantInfo
// Assembly: LogicWorld.ClientCode, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2F70835D-46E4-4981-B11A-A99AE3BBAAEE
// Assembly location: D:\SteamLibrary\steamapps\common\Logic World\Logic_World_Data\Managed\LogicWorld.ClientCode.dll
// Mostly

using JimmysUnityUtilities;
using LogicWorld.Interfaces;
using LogicWorld.Rendering.Dynamics;
using LogicWorld.SharedCode.Components;
using System;
using UnityEngine;

namespace CableSnake.Client
{
    public class VectorLatchVariantInfo : PrefabVariantInfo
    {
        private static Color24 blockColor = new Color24(0x443366);

        public override string ComponentTextID => "CS.VectorLatch";

        public override PrefabVariantIdentifier GetDefaultComponentVariant() => new PrefabVariantIdentifier(2, 1);

        public override ComponentVariant GenerateVariant(PrefabVariantIdentifier identifier)
        {
            if (identifier.InputCount < 2)
                throw new Exception("VectorLatches need one input plus one clock/enable.");
            if (identifier.InputCount != identifier.OutputCount + 1)
                throw new Exception("VectorLatches need balanced inputs and outputs (plus clock).");

            ComponentVariant variant = new ComponentVariant() {
                VariantPrefab = new Prefab() {            
                    Blocks = new Block[1] {
                        new Block() { 
                            // Centered but still grid aligned
                            Position = new Vector3((identifier.InputCount & 1) / 2.0f, 0.0f, 0.0f),
                            Scale = new Vector3((float) identifier.OutputCount, 1.0f, 1.0f),
                            RawColor = VectorLatchVariantInfo.blockColor
                        }
                    },
                    Inputs = new ComponentInput[identifier.InputCount],
                    Outputs = new ComponentOutput[identifier.OutputCount]
                },
                VariantPlacingRules = new PlacingRules() {
                    AllowFineRotation = false,
                    GridPlacingDimensions = new Vector2Int(identifier.InputCount, 3)
                }
            };
            Vector3 input1 = new Vector3(identifier.OutputCount / 2.0f - 0.5f, 0.5f, -0.5f);
            variant.VariantPrefab.Inputs[0] = new ComponentInput() {
                Length = 1.2f,
                Position = new Vector3(input1.x + 0.4f, input1.y, 0.0f),
                Rotation = new Vector3(0.0f, 45.0f, -90.0f)
            };
            for (int index=0; index<identifier.OutputCount; ++index) {
                variant.VariantPrefab.Inputs[index+1] = new ComponentInput() {
                    Position = new Vector3(input1.x - ((float) index), input1.y, input1.z),
                    Rotation = new Vector3(-90.0f, 0.0f, 0.0f)
                };
                variant.VariantPrefab.Outputs[index] = new ComponentOutput() {
                    Position = new Vector3(input1.x - ((float) index), input1.y, input1.z + 1.0f),
                    Rotation = new Vector3(90.0f, 0.0f, 0.0f)
                };
            }
            return variant;
        }
    }
}
