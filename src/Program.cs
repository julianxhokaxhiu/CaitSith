/***************************************************************************
*    Copyright (C) 2024 Julian Xhokaxhiu                                   *
*                                                                          *
*    This file is part of CaitSith                                         *
*                                                                          *
*    CaitSith is free software: you can redistribute it and/or modify      *
*    it under the terms of the GNU General Public License as published by  *
*    the Free Software Foundation, either version 3 of the License         *
*                                                                          *
*    CaitSith is distributed in the hope that it will be useful,           *
*    but WITHOUT ANY WARRANTY; without even the implied warranty of        *
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
*    GNU General Public License for more details.                          *
***************************************************************************/

using System;
using System.Windows.Forms;

namespace CaitSith
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Entry());
        }
    }
}
