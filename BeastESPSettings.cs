using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace BeastESP
{
    public class BeastESPSettings : ISettings
    {
        public BeastESPSettings()
        {
            Enable = new ToggleNode(true);
        }
        public ToggleNode Enable { get; set; }
    }
}
