/*
    This file is part of the iText (R) project.
    Copyright (c) 1998-2019 iText Group NV
    Authors: iText Software.

This program is free software; you can redistribute it and/or modify it under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation with the addition of the following permission added to Section 15 as permitted in Section 7(a): FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY iText Group NV, iText Group NV DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License along with this program; if not, see http://www.gnu.org/licenses or write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA, 02110-1301 USA, or download the license from the following URL:

http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions of this program must display Appropriate Legal Notices, as required under Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License, a covered work must retain the producer line in every PDF that is created or manipulated using iText.

You can be released from the requirements of the license by purchasing a commercial license. Buying such a license is mandatory as soon as you develop commercial activities involving the iText software without disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP, serving PDFs on the fly in a web application, shipping iText with a closed source product.

For more information, please contact iText Software Corp. at this address: sales@itextpdf.com */
using System;



namespace Org.BouncyCastle.Bcpg.Sig
{
    /**
    * packet giving signature expiration time.
    */
    public class SignatureExpirationTime
        : SignatureSubpacket
    {
        protected static byte[] TimeToBytes(
            long      t)
        {
            byte[]    data = new byte[4];

            data[0] = (byte)(t >> 24);
            data[1] = (byte)(t >> 16);
            data[2] = (byte)(t >> 8);
            data[3] = (byte)t;

            return data;
        }

        public SignatureExpirationTime(
            bool    critical,
            byte[]     data)
            : base(SignatureSubpacketTag.ExpireTime, critical, data)
    {
        }

        public SignatureExpirationTime(
            bool    critical,
            long       seconds)
            : base(SignatureSubpacketTag.ExpireTime, critical, TimeToBytes(seconds))
        {
        }

        /**
        * return time in seconds before signature expires after creation time.
        */
        public long Time
        {
            get
            {
                long time = ((long)(data[0] & 0xff) << 24) | ((long)(data[1] & 0xff) << 16)
                    | ((long)(data[2] & 0xff) << 8) | ((long)data[3] & 0xff);

                return time;
            }
        }
    }
}
