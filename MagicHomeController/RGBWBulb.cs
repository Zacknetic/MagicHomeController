﻿using System;
using System.Threading;

namespace MagicHomeConsoleApp
{
    class RGBWBulb : Bulb
    {
        public RGBWBulb(string ipAddress, string macAddress, string bulbID) : base(ipAddress, macAddress, bulbID)
        {

        }
        public override void CreateColorMessage(byte mask)
        {
            byte[] sendMessageByte;

            // 7 byte message for RGBW bulbs
            sendMessageByte = new byte[]
            {
                0x31,
                Color.Red, // Red byte
                Color.Green, //3 Green byte
                Color.Blue, //4 Blue byte
                Color.WarmWhite, //5 WarmWhite byte
                mask, //6 Mask
                0x0F  //7 terminator (I'll be back)
            };

            CreateBasicMessage(sendMessageByte);
        }
        public override void SetColorLevel(byte r, byte g, byte b)
        {
            Color.Red = r;
            Color.Green = g;
            Color.Blue = b;
            UpdateStateColor();
        }
        public override void SetWarmWhiteLevel(byte w)
        {
            Color.WarmWhite = w;
            UpdateStateWhite();
        }
        public override void SetColdWhiteLevel(byte c)
        {
            Color.ColdWhite = c;
            Color.WarmWhite = c;
            UpdateStateWhite();
        }
        public override void SetBothWhiteLevel(byte w, byte c)
        {
            int intWarmWhiteValue = (int)(w + c) / 2;
            byte byteWarmWhiteValue = (byte)intWarmWhiteValue;
            Color.WarmWhite = byteWarmWhiteValue;
            Color.ColdWhite = c;
            UpdateStateWhite();
        }
        public override void SetColorAndWhiteLevel(byte r, byte g, byte b, byte w, byte c)
        {
            Color.Red = r;
            Color.Green = g;
            Color.Blue = b;
            Color.WarmWhite = w;
            Color.ColdWhite = c;
            UpdateStateColor();
        }
    }
}
