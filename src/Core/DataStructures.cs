using System.Runtime.InteropServices;

namespace CaitSith
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct CamData
    {
		// EYE
		public ushort eye_x;
		public ushort eye_y;
		public ushort eye_z;
		// TARGET
		public ushort target_x;
		public ushort target_y;
		public ushort target_z;
		// UP
		public ushort up_x;
		public ushort up_y;
		public ushort up_z;
		// FILLER?
		public ushort padding;
		// POSITION
		public uint pos_x;
		public uint pos_y;
		public uint pos_z;
		// PAN
		public ushort pan_x;
		public ushort pan_y;
		// ZOOM
		public ushort zoom;
		// FILLER?
		public ushort padding2;
	}
}
