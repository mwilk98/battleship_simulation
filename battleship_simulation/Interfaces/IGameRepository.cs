using System.Collections.Generic;

namespace battleship_simulation.Interfaces
{
    /* interface describing game repository */
    public interface IGameRepository
    {
        string[][] GetFirst();

        string[][] GetSecond();

        List<string> GetEvents();

        void Add();
    }
}
