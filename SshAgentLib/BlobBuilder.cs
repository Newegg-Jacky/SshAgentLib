//
// BlobBuilder.cs
//
// Author(s): David Lechner <david@lechnology.com>
//            Max Laverse
//
// Copyright (c) 2012-2013 David Lechner
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Math;

namespace dlech.SshAgentLib
{
  /// <summary>
  /// used to build blobs that are used for storing and sending keys
  /// in open-ssh/PuTTY format
  /// </summary>
  public class BlobBuilder
  {

    private List<byte> byteList;

    /// <summary>
    /// Gets current length of blob
    /// </summary>
    public int Length
    {
      get
      {
        return byteList.Count();
      }
    }

    /// <summary>
    /// Creates new instance of BlobBuilder
    /// </summary>
    public BlobBuilder()
    {
      byteList = new List<byte>();
    }


    ~BlobBuilder()
    {
      Clear();
    }

    /// <summary>
    /// Adds byte to the blob
    /// </summary>
    public void AddByte(byte aByte)
    {
      byteList.Add(aByte);
    }

    /// <summary>
    /// Adds byte[] to the blob
    /// </summary>
    /// <param name="aBytes"></param>
    public void AddBytes(byte[] aBytes)
    {
      byteList.AddRange(aBytes);
    }

    public void AddInt(int aInt)
    {
      AddInt((UInt32)aInt);
    }

    public void AddInt(UInt32 aInt)
    {
      byteList.AddRange(aInt.ToBytes());
    }

    /// <summary>
    /// Adds a string to the blob
    /// </summary>
    /// <param name="aString">the string to add</param>
    public void AddStringBlob(string aString)
    {
      AddBlob(Encoding.UTF8.GetBytes(aString));
    }

    /// <summary>
    /// Adds BigInteger to builder prefixed with size
    /// </summary>
    /// <param name="bigInt"></param>
    public void AddBigIntBlob(BigInteger aBigInt)
    {
      byte[] bytes = aBigInt.ToByteArray();
      AddBlob(bytes);
    }

    /// <summary>
    /// Adds byte[] to builder as Ssh1 sub-blob
    /// </summary>
    /// <param name="blob"></param>
    public void AddSsh1BigIntBlob(BigInteger aBigInt)
    {
        ushort size = (ushort)(aBigInt.BitLength);
        AddByte((byte)((size >> 8) & 0xFF));
        AddByte((byte)(size & 0xFF));
        byte[] bytes = aBigInt.ToByteArrayUnsigned();
        byteList.AddRange(bytes);
    }

    /// <summary>
    /// Adds byte[] to builder as sub-blob
    /// </summary>
    /// <param name="blob"></param>
    public void AddBlob(byte[] blob)
    {
      byteList.AddRange(blob.Length.ToBytes());
      byteList.AddRange(blob);
    }
    
    /// <summary>
    /// Prepends header 
    /// </summary>
    /// <param name="aMessage">message number to include in header</param>
    /// <param name="aHeaderData">data to include in header</param>
    public void InsertHeader(Agent.Message aMessage, int aHeaderData)
    {
      byteList.InsertRange(0, aHeaderData.ToBytes());
      InsertHeader(aMessage);
    }

    /// <summary>
    /// Prepends header 
    /// </summary>
    /// <param name="aMessage">message number to include in header</param>
    public void InsertHeader(Agent.Message aMessage)
    {
      byteList.Insert(0, (byte)aMessage);
      byte[] blobLength = byteList.Count.ToBytes();
      byteList.InsertRange(0, blobLength);
    }

    /// <summary>
    /// Gets the resulting blob from the blob builder.
    /// </summary>
    /// <returns>byte[] containing the blob</returns>
    public byte[] GetBlob()
    {
      return byteList.ToArray();
    }

    public PinnedArray<byte> GetBlobAsPinnedByteArray()
    {
      return new PinnedArray<byte>(GetBlob());      
    }

    /// <summary>
    /// Writes 0 to all values, then clears list
    /// </summary>
    public void Clear()
    {
      Util.ClearByteList(byteList);
    }
  }
}
