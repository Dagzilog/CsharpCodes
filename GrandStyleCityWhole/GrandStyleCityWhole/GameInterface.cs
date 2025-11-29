using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandStyleCityWhole
{
    public interface GameInterface
    {
        void MainMenu();
        void NewGame();
        void LoadGame();
        void CampaignMode();
        void Credits();
        void ExitGame();
    }
}
