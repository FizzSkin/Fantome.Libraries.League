﻿using System.IO;

namespace Fantome.Libraries.League.Helpers.Structures
{
    /// <summary>
    /// Represents an Axis-Aligned Bounding Box
    /// </summary>
    public class R3DBox
    {
        /// <summary>
        /// The Min component
        /// </summary>
        public Vector3 Min { get; private set; }
        /// <summary>
        /// The Max component
        /// </summary>
        public Vector3 Max { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="R3DBox"/>
        /// </summary>
        /// <param name="min">The Min component</param>
        /// <param name="max">The Max component</param>
        public R3DBox(Vector3 min, Vector3 max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Initializes a new <see cref="R3DBox"/> from a <see cref="BinaryReader"/>
        /// </summary>
        /// <param name="br">The <see cref="BinaryReader"/> to read from</param>
        public R3DBox(BinaryReader br)
        {
            this.Min = new Vector3(br);
            this.Max = new Vector3(br);
        }

        /// <summary>
        /// Writes this <see cref="R3DBox"/> into a <see cref="BinaryWriter"/>
        /// </summary>
        /// <param name="bw"></param>
        public void Write(BinaryWriter bw)
        {
            this.Min.Write(bw);
            this.Max.Write(bw);
        }

        /// <summary>
        /// Calculates the proportions of this <see cref="R3DBox"/>
        /// </summary>
        public Vector3 GetProportions()
        {
            return this.Max - this.Min;
        }

        /// <summary>
        /// Determines whether this <see cref="R3DBox"/> contains <paramref name="point"/>
        /// </summary>
        /// <param name="point">The containing point</param>
        public bool ContainsPoint(Vector3 point)
        {
            return ((point.X >= this.Min.X) && (point.X <= this.Max.X) && (point.Y >= this.Min.Y) && (point.Y <= this.Max.Y) && (point.Z >= this.Min.Z) && (point.Z <= this.Max.Z));
        }
    }
}