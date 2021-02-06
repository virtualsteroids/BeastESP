using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using ExileCore;
using ExileCore.PoEMemory;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Cache;
using ExileCore.Shared.Enums;
using SharpDX;

namespace BeastESP
{

    public class BeastESP : BaseSettingsPlugin<BeastESPSettings>
    {
        public static Camera camera;

        public string[] desiredBeasts =
         {
                "Metadata/Monsters/LeagueBestiary/MonkeyBloodBestiary",
                "Metadata/Monsters/LeagueBestiary/GemFrogBestiary",
                "Metadata/Monsters/LeagueBestiary/VultureBestiary",
                "Metadata/Monsters/LeagueBestiary/LynxBestiary",
                "Metadata/Monsters/LeagueBestiary/WolfBestiary",
                "Metadata/Monsters/LeagueBestiary/TigerBestiary",
                "Metadata/Monsters/LeagueBestiary/Avians/MarakethBirdBestiary",
                "Metadata/Monsters/LeagueBestiary/SpiderPlatedBestiary",
                "Metadata/Monsters/LeagueBestiary/CrabSpiderBestiary",
                "Metadata/Monsters/LeagueBestiary/SpiderPlagueBestiary"
        };

        public override void Render()
        {
            if (!Settings.Enable)
                return;

            var monsterEntities = GameController.EntityListWrapper.ValidEntitiesByType[EntityType.Monster];

            Camera camera = GameController.Game.IngameState.Camera;

            foreach (var monster in monsterEntities)
            {
                if (desiredBeasts.Contains(monster.Metadata))
                {
                    Vector2 screenPos = camera.WorldToScreen(monster.Pos);
                    Graphics.DrawBox(new RectangleF(screenPos.X - 40, screenPos.Y, 80, 20), Color.Black);
                    Graphics.DrawText("KILL", screenPos, Color.Red, 32, FontAlign.Center);
                }
            }
        }

    }
}
