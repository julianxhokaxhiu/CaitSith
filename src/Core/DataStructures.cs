/***************************************************************************
*    Copyright (C) 2021 Julian Xhokaxhiu                                   *
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

using System.Runtime.InteropServices;

namespace CaitSith.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct CamData
    {
		// EYE
		public short eye_x;
		public short eye_y;
		public short eye_z;
		// TARGET
		public short target_x;
		public short target_y;
		public short target_z;
		// UP
		public short up_x;
		public short up_y;
		public short up_z;
		// FILLER?
		public short padding;
		// POSITION
		public int pos_x;
		public int pos_y;
		public int pos_z;
		// PAN
		public short pan_x;
		public short pan_y;
		// ZOOM
		public short zoom;
		// FILLER?
		public short padding2;
	}
}
