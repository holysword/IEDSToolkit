﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IEDSToolkit
{
    class CommonUtility
    {
        public static String FormatedString(Object Value)
        {
            if (Value == null)
                return "";

            if (Value.GetType().Name == "Double")
            {                
                return Convert.ToDouble(Value).ToString("0.##");
            }
            else
            {
                return Value.ToString();
            }
        }

        public static int ByteToInt(byte Value)
        {
            int IntValue = Value;
            if (Value < 0)
                IntValue = Value & 0xFF;

            return IntValue;
        }
        
        public static short ByteToShort(byte Value)
        {

            short ShortValue = Value;
            if (Value < 0)
                ShortValue = (short)(Value & 0xFF);

            return ShortValue;
        }

        public static float Byte2Float(byte[] b, int index)
        {
            int l;
            l = b[index + 0];
            l &= 0xff;
            l |= ((int)b[index + 1] << 8);
            l &= 0xffff;
            l |= ((int)b[index + 2] << 16);
            l &= 0xffffff;
            l |= ((int)b[index + 3] << 24);

            byte[] buf = BitConverter.GetBytes(l);
            return BitConverter.ToSingle(buf, 0);
        }

        public static byte[] float2byte(float f)
        {
            // 把float转换为byte[]
            byte[] b = BitConverter.GetBytes(f);

            // 翻转数组
            int len = b.Length;
            // 建立一个与源数组元素类型相同的数组
            byte[] dest = new byte[len];
            // 为了防止修改源数组，将源数组拷贝一份副本
            System.Array.Copy(b, 0, dest, 0, len);
            byte temp;
            // 将顺位第i个与倒数第i个交换
            for (int i = 0; i < len / 2; ++i)
            {
                temp = dest[i];
                dest[i] = dest[len - i - 1];
                dest[len - i - 1] = temp;
            }

            return dest;
        }

        public static String Bcd2Str(byte[] bytes)
        {
            StringBuilder temp = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
            {
                temp.Append((byte)((bytes[i] & 0xf0) >> 4));
                temp.Append((byte)(bytes[i] & 0x0f));
            }
            return temp.ToString();
        }

        public static byte[] str2Bcd(String asc)
        {
            int len = asc.Length;
            int mod = len % 2;

            if (mod != 0)
            {
                asc = "0" + asc;
                len = asc.Length;
            }

            byte[] abt = new byte[len];
            if (len >= 2)
            {
                len = len / 2;
            }

            byte[] bbt = new byte[len];
            abt = System.Text.Encoding.Default.GetBytes(asc);
            int j, k;

            for (int p = 0; p < asc.Length / 2; p++)
            {
                if ((abt[2 * p] >= '0') && (abt[2 * p] <= '9'))
                {
                    j = abt[2 * p] - '0';
                }
                else if ((abt[2 * p] >= 'a') && (abt[2 * p] <= 'z'))
                {
                    j = abt[2 * p] - 'a' + 0x0a;
                }
                else
                {
                    j = abt[2 * p] - 'A' + 0x0a;
                }

                if ((abt[2 * p + 1] >= '0') && (abt[2 * p + 1] <= '9'))
                {
                    k = abt[2 * p + 1] - '0';
                }
                else if ((abt[2 * p + 1] >= 'a') && (abt[2 * p + 1] <= 'z'))
                {
                    k = abt[2 * p + 1] - 'a' + 0x0a;
                }
                else
                {
                    k = abt[2 * p + 1] - 'A' + 0x0a;
                }

                int a = (j << 4) + k;
                byte b = (byte)a;
                bbt[p] = b;
            }
            return bbt;
        }

        public static String FaultNames = @"<Root><T Index=""0"" Value=""无""/>
			<T Index = ""256"" Value=""报警_热过载保护""/>
			<T Index = ""257"" Value=""报警_阻塞保护""/>
			<T Index = ""258"" Value=""报警_TE时间保护""/>
			<T Index = ""259"" Value=""报警_起动超时保护""/>
			<T Index = ""260"" Value=""报警_单相接地保护""/>
			<T Index = ""261"" Value=""报警_漏电保护""/>
			<T Index = ""262"" Value=""报警_电流断相保护""/>
			<T Index = ""263"" Value=""报警_电流不平衡保护""/>
			<T Index = ""264"" Value=""报警_电流反相序保护""/>
			<T Index = ""265"" Value=""报警_欠载保护""/>
			<T Index = ""266"" Value=""报警_欠电压保护""/>
			<T Index = ""267"" Value=""报警_过电压保护""/>
			<T Index = ""268"" Value=""报警_电压不平衡保护""/>
			<T Index = ""269"" Value=""报警_电压反相序保护""/>
			<T Index = ""270"" Value=""报警_外部故障保护""/>
			<T Index = ""271"" Value=""报警_PT断线保护""/>
			<T Index = ""274"" Value=""报警_温度1保护""/>
			<T Index = ""275"" Value=""报警_堵转保护""/>
			<T Index = ""276"" Value=""报警_电流速断保护""/>
			<T Index = ""277"" Value=""报警_负序电流保护""/>
			<T Index = ""512"" Value=""跳接触器_热过载保护""/>
			<T Index = ""513"" Value=""跳接触器_阻塞保护""/>
			<T Index = ""514"" Value=""跳接触器_TE时间保护""/>
			<T Index = ""515"" Value=""跳接触器_起动超时保护""/>
			<T Index = ""516"" Value=""跳接触器_单相接地保护""/>
			<T Index = ""517"" Value=""跳接触器_漏电保护""/>
			<T Index = ""518"" Value=""跳接触器_电流断相保护""/>
			<T Index = ""519"" Value=""跳接触器_电流不平衡保护""/>
			<T Index = ""520"" Value=""跳接触器_电流反相序保护""/>
			<T Index = ""521"" Value=""跳接触器_欠载保护""/>
			<T Index = ""522"" Value=""跳接触器_欠电压保护""/>
			<T Index = ""523"" Value=""跳接触器_过电压保护""/>
			<T Index = ""524"" Value=""跳接触器_电压不平衡保护""/>
			<T Index = ""525"" Value=""跳接触器_电压反相序保护""/>
			<T Index = ""526"" Value=""跳接触器_外部故障保护""/>
			<T Index = ""530"" Value=""跳接触器_温度1保护""/>
			<T Index = ""531"" Value=""跳接触器_堵转保护""/>
			<T Index = ""532"" Value=""报警_电流速断保护""/>
			<T Index = ""533"" Value=""报警_负序电流保护""/>
			<T Index = ""768"" Value=""跳断路器_单相接地保护""/>
			<T Index = ""769"" Value=""跳断路器_漏电保护""/>
			<T Index = ""770"" Value=""跳断路器_接触器故障保护""/>
			<T Index = ""771"" Value=""跳断路器_电流速断保护""/>
			<T Index = ""1024"" Value=""跳断路器(接触器分断电流大于分断能力)_热过载保护""/>
			<T Index = ""1025"" Value=""跳断路器(接触器分断电流大于分断能力)_阻塞保护""/>
			<T Index = ""1026"" Value=""跳断路器(接触器分断电流大于分断能力)_TE时间保护""/>
			<T Index = ""1027"" Value=""跳断路器(接触器分断电流大于分断能力)_起动超时保护""/>
			<T Index = ""1028"" Value=""跳断路器(接触器分断电流大于分断能力)_单相接地保护""/>
			<T Index = ""1029"" Value=""跳断路器(接触器分断电流大于分断能力)_漏电保护""/>
			<T Index = ""1030"" Value=""跳断路器(接触器分断电流大于分断能力)_电流断相保护""/>
			<T Index = ""1031"" Value=""跳断路器(接触器分断电流大于分断能力)_电流不平衡保护""/>
			<T Index = ""1032"" Value=""跳断路器(接触器分断电流大于分断能力)_电流反相序保护""/>
			<T Index = ""1033"" Value=""跳断路器(接触器分断电流大于分断能力)_欠载保护""/>
			<T Index = ""1034"" Value=""跳断路器(接触器分断电流大于分断能力)_欠电压保护""/>
			<T Index = ""1035"" Value=""跳断路器(接触器分断电流大于分断能力)_过电压保护""/>
			<T Index = ""1036"" Value=""跳断路器(接触器分断电流大于分断能力)_电压不平衡保护""/>
			<T Index = ""1037"" Value=""跳断路器(接触器分断电流大于分断能力)_电压反相序保护""/>
			<T Index = ""1038"" Value=""跳断路器(接触器分断电流大于分断能力)_外部故障保护""/>
			<T Index = ""1042"" Value=""跳断路器(接触器分断电流大于分断能力)_温度1保护""/>
			<T Index = ""1043"" Value=""跳断路器(接触器分断电流大于分断能力)_堵转保护""/>
			<T Index = ""1044"" Value=""跳断路器(接触器分断电流大于分断能力)_电流速断保护""/>
			<T Index = ""1045"" Value=""跳断路器(接触器分断电流大于分断能力)_负序电流保护""/></Root>";
        public static String GetFaultName(int FaultType)
        {
            String FaultName = "未知_未知";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(FaultNames);
            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                if (Convert.ToInt32(node.Attributes["Index"].Value) == FaultType)
                {
                    FaultName = node.Attributes["Value"].Value;
                    break;
                }
            }
            return FaultName;
        }
    }
}
