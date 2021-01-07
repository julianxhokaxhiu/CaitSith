﻿/***************************************************************************
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

using System;
using System.IO;

namespace CaitSith.Core
{
    class DataManipulation
    {
        public static long getNumberOfFrames(FileInfo fileInfo)
        {
            return fileInfo.Length / 40;
        }

        public static bool parse(FileInfo inFile, ref CamData[] camData)
        {
            FileStream file = inFile.OpenRead();

            for (int i = 0; i < camData.Length; ++i)
            {
                // Read Cam Data
                camData[i] = file.ReadStruct<CamData>();
            }

            file.Close();

            return true;
        }

        public static bool dump(string outFile, ref CamData[] camData)
        {
            FileStream file = File.OpenWrite(outFile);

            for (int i = 0; i < camData.Length; ++i)
            {
                // Write Cam Data
                file.WriteStruct<CamData>(camData[i]);
            }

            file.Close();

            return true;
        }

        public static short interpolateValues(short prev, short next)
        {
            if (next > prev)
            {
                return (short)(prev + ((next - prev) / 2));
            }
            else
            {
                return (short)(next + ((prev - next) / 2));
            }
        }

        public static int interpolateValues(int prev, int next)
        {
            if (next > prev)
            {
                return (int)(prev + ((next - prev) / 2));
            }
            else
            {
                return (int)(next + ((prev - next) / 2));
            }
        }

        public static bool interpolate(ref CamData[] inData)
        {
            CamData[] outData = new CamData[inData.Length * 2];

            // Prepare the new array of data
            for (int i = 0; i < inData.Length; i++)
            {                
                outData[i * 2] = inData[i];
            }

            // Interpolate new slots
            for (int i = 1; i < outData.Length; i += 2)
            {
                if (i + 1 >= outData.Length)
                {
                    outData[i] = outData[i - 1];
                }
                else
                {
                    ref CamData prev = ref outData[i - 1],
                                current = ref outData[i],
                                next = ref outData[i + 1];

                    current.eye_x = interpolateValues(prev.eye_x, next.eye_x);
                    current.eye_y = interpolateValues(prev.eye_y, next.eye_y);
                    current.eye_z = interpolateValues(prev.eye_z, next.eye_z);
                    current.target_x = interpolateValues(prev.target_x, next.target_x);
                    current.target_y = interpolateValues(prev.target_y, next.target_y);
                    current.target_z = interpolateValues(prev.target_z, next.target_z);
                    current.up_x = interpolateValues(prev.up_x, next.up_x);
                    current.up_y = interpolateValues(prev.up_y, next.up_y);
                    current.up_z = interpolateValues(prev.up_z, next.up_z);
                    current.pos_x = interpolateValues(prev.pos_x, next.pos_x);
                    current.pos_y = interpolateValues(prev.pos_y, next.pos_y);
                    current.pos_z = interpolateValues(prev.pos_z, next.pos_z);
                    current.pan_x = interpolateValues(prev.pan_x, next.pan_x);
                    current.pan_y = interpolateValues(prev.pan_y, next.pan_y);
                    current.zoom = interpolateValues(prev.zoom, next.zoom);
                }
            }

            // Return the new interpolated data
            inData = outData;

            return true;
        }
    }
}
