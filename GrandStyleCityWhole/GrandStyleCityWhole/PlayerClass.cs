using System.Collections.Generic;

namespace GrandStyleCityWhole
{
    public struct PlayerStruct
    {
        public string PlayerName;
        public string SaveDate;

        // For single-selection options (Gender, Hair, FaceShape, etc.)
        public Dictionary<string, int?> SingleOptions;

        // For multiple-selection options (Earrings, Rings, Bracelets, etc.)
        public List<(string usage, int optionId)> MultipleOptions;

        public void InitializeLists()
        {
            SingleOptions = new Dictionary<string, int?>();
            MultipleOptions = new List<(string, int)>();
        }
    }
}
