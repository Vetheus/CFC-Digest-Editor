﻿//Copyright (C) 2014+ Marco (Phoenix) Calautti.

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 2.0.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License 2.0 for more details.

//A copy of the GPL 2.0 should have been included with the program.
//If not, see http://www.gnu.org/licenses/

//Official repository and contact information can be found at
//http://github.com/marco-calautti/Rainbow

using System;

using Rainbow.ImgLib.Encoding.Implementation;
using Rainbow.ImgLib.Common;
using Rainbow.ImgLib.Filters;
using CFC_Digest_Editor.Classes;

namespace Rainbow.ImgLib.Encoding
{
    public abstract class IndexCodec
    {

        public abstract int GetPixelIndex(byte[] pixelData, int width, int height, int x, int y);
        public abstract byte[] PackIndexes(int[] indexes, int start, int length);
        public byte[] PackIndexes(int[] indexes)
        {
            return PackIndexes(indexes, 0, indexes.Length);
        }

        public abstract int BitDepth { get; }

        public static IndexCodec FromBitPerPixel(int bpp, Endianess order = Endianess.LittleEndian)
        {
            return FromNumberOfColors(1 << bpp, order);
        }

        public static IndexCodec FromNumberOfColors(int colors, Endianess order = Endianess.LittleEndian)
        {
            if (colors <= 16)
            {
                return new IndexCodec4Bpp(order);
            }
            else if (colors <= 256)
            {
                return new IndexCodec8Bpp();
            }
            else
            {
                throw new ArgumentException("Unsupported number of colors");
            }
        }

        public virtual int GetBytesNeededForEncode(int width, int height, ImageFilter referenceFilter = null)
        {
            int encWidth = width, encHeight = height;

            if(referenceFilter != null)
            {
                encWidth = referenceFilter.GetWidthForEncoding(width);
                encHeight = referenceFilter.GetHeightForEncoding(height);
            }

            int totalPixel = encWidth * encHeight;
            int bytes = totalPixel * BitDepth / 8;
            int remainder = (totalPixel * BitDepth) % 8;
            return remainder == 0 ? bytes : bytes + 1;
        }
    }
}
