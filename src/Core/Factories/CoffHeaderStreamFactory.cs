﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tao.Interfaces;

namespace Tao.Core.Factories
{
    /// <summary>
    /// Represents a factory class that extracts the Coff header stream from an existing portable executable image.
    /// </summary>
    public class CoffHeaderStreamFactory : IConversion<Stream, Stream>
    {
        private readonly ISubStreamReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoffHeaderStreamFactory"/> class.
        /// </summary>
        /// <param name="reader">The substream reader.</param>
        public CoffHeaderStreamFactory(ISubStreamReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Creates a coff header substream from the given <paramref name="input"/> stream.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <returns>A stream containing the Coff header data.</returns>
        public Stream Convert(Stream input)
        {
            input.Seek(0x98, SeekOrigin.Begin);

            const int size = 0x5c;
            return _reader.Read(size, input);
        }
    }
}
