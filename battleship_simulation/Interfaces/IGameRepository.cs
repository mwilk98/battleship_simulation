﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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