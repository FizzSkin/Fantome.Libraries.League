﻿using System;
using System.IO;
using System.Globalization;

namespace Fantome.League.Helpers.Structures
{
    public struct Vector2
    {
        public float X;
        public float Y;
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vector2(BinaryReader br)
        {
            this.X = br.ReadSingle();
            this.Y = br.ReadSingle();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.X);
            bw.Write(this.Y);
        }
        public static bool operator <(Vector2 x, Vector2 y)
        {
            return x.X < y.X && x.Y < y.Y;
        }
        public static bool operator >(Vector2 x, Vector2 y)
        {
            return x.X > y.X && x.Y > y.Y;
        }
    }
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;
        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Vector3(BinaryReader br)
        {
            this.X = br.ReadSingle();
            this.Y = br.ReadSingle();
            this.Z = br.ReadSingle();
        }
        public Vector3(StreamReader sr)
        {
            string[] input = sr.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            this.X = float.Parse(input[0], CultureInfo.InvariantCulture.NumberFormat);
            this.Y = float.Parse(input[1], CultureInfo.InvariantCulture.NumberFormat);
            this.Z = float.Parse(input[2], CultureInfo.InvariantCulture.NumberFormat);
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.X);
            bw.Write(this.Y);
            bw.Write(this.Z);
        }
        public void Write(StreamWriter sw)
        {
            sw.WriteLine(string.Format("{0} {1} {2}", this.X, this.Y, this.Z));
        }
        public static Vector3 Cross(Vector3 x, Vector3 y)
        {
            return new Vector3(
                (x.Y * y.Z) - (x.Z * y.Y),
                (x.Z * y.X) - (x.X * y.Z),
                (x.X * y.Y) - (x.Y * y.X));
        }
        public static Vector3 operator +(Vector3 x, Vector3 y)
        {
            return new Vector3(x.X + y.X, x.Y + y.Y, x.Z + y.Z);
        }
        public static Vector3 operator -(Vector3 x, Vector3 y)
        {
            return new Vector3(x.X - y.X, x.Y - y.Y, x.Z - y.Z);
        }
    }
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Vector4(float X, float Y, float Z, float W)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.W = W;
        }
        public Vector4(BinaryReader br)
        {
            this.X = br.ReadSingle();
            this.Y = br.ReadSingle();
            this.Z = br.ReadSingle();
            this.W = br.ReadSingle();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.X);
            bw.Write(this.Y);
            bw.Write(this.Z);
            bw.Write(this.W);
        }
    }
    public struct Vector3Byte
    {
        public byte X;
        public byte Y;
        public byte Z;
        public Vector3Byte(byte X, byte Y, byte Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Vector3Byte(BinaryReader br)
        {
            this.X = br.ReadByte();
            this.Y = br.ReadByte();
            this.Z = br.ReadByte();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.X);
            bw.Write(this.Y);
            bw.Write(this.Z);
        }
    }
    public struct Vector4Byte
    {
        public byte X;
        public byte Y;
        public byte Z;
        public byte W;
        public Vector4Byte(byte X, byte Y, byte Z, byte W)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.W = W;
        }
        public Vector4Byte(BinaryReader br)
        {
            this.X = br.ReadByte();
            this.Y = br.ReadByte();
            this.Z = br.ReadByte();
            this.W = br.ReadByte();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.X);
            bw.Write(this.Y);
            bw.Write(this.Z);
            bw.Write(this.W);
        }
    }
    public struct ColorVector4
    {
        public float R;
        public float G;
        public float B;
        public float A;
        public ColorVector4(float R, float G, float B, float A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }
        public ColorVector4(BinaryReader br)
        {
            this.R = br.ReadSingle();
            this.G = br.ReadSingle();
            this.B = br.ReadSingle();
            this.A = br.ReadSingle();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.R);
            bw.Write(this.G);
            bw.Write(this.B);
            bw.Write(this.A);
        }
        public static ColorVector4Byte Denormalize(ColorVector4Byte Color)
        {
            return new ColorVector4Byte((byte)(Color.R * 255), (byte)(Color.G * 255), (byte)(Color.B * 255), (byte)(Color.A * 255));
        }
    }
    public struct ColorVector4Byte
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;
        public ColorVector4Byte(byte R, byte G, byte B, byte A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }
        public ColorVector4Byte(BinaryReader br)
        {
            this.R = br.ReadByte();
            this.G = br.ReadByte();
            this.B = br.ReadByte();
            this.A = br.ReadByte();
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(this.R);
            bw.Write(this.G);
            bw.Write(this.B);
            bw.Write(this.A);
        }
        public static ColorVector4 Normalize(ColorVector4Byte Color)
        {
            return new ColorVector4(Color.R / 255, Color.G / 255, Color.B / 255, Color.A / 255);
        }
    }
    public struct R3DBoundingBox
    {
        public Vector3 Org;
        public Vector3 Size;
        public R3DBoundingBox(Vector3 Org, Vector3 Size)
        {
            this.Org = Org;
            this.Size = Size;
        }
        public R3DBoundingBox(BinaryReader br)
        {
            this.Org = new Vector3(br);
            this.Size = new Vector3(br);
        }
        public void Write(BinaryWriter bw)
        {
            this.Org.Write(bw);
            this.Size.Write(bw);
        }
    }
    public struct R3DBox
    {
        public Vector3 Min { get; private set; }
        public Vector3 Max { get; private set; }

        public R3DBox(BinaryReader br)
        {
            this.Min = new Vector3(br);
            this.Max = new Vector3(br);
        }

        public R3DBox(Vector3 min, Vector3 max)
        {
            this.Min = min;
            this.Max = max;
        }

        public void Write(BinaryWriter bw)
        {
            this.Min.Write(bw);
            this.Max.Write(bw);
        }
    }
    public struct R3DSphere
    {
        public Vector3 Position;
        public float Radius;
        public R3DSphere(Vector3 Position, float Radius)
        {
            this.Position = Position;
            this.Radius = Radius;
        }
        public R3DSphere(BinaryReader br)
        {
            this.Position = new Vector3(br);
            this.Radius = br.ReadSingle();
        }
        public void Write(BinaryWriter bw)
        {
            Position.Write(bw);
            bw.Write(Radius);
        }
    }
}