﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tao.Interfaces;

namespace Tao.Core.Seekers
{
    /// <summary>
    /// Represents a <see cref="IStreamSeeker"/> that can find the coff header position.
    /// </summary>
    public class DosHeaderSeeker : IStreamSeeker
    {
        /// <summary>
        /// Seeks the coff header position within a given stream.
        /// </summary>
        /// <param name="stream">The target stream.</param>
        public void Seek(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
