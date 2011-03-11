﻿using System.IO;
using Tao.Interfaces;
using Tao.Model;

namespace Tao.Signatures
{
    /// <summary>
    /// Represents a type that can read a MethodRef signature from a given blob.
    /// </summary>
    public class MethodRefSignatureStreamReader : IMethodSignatureStreamReader<IMethodRefSignature>
    {
        private readonly IFunction<ITuple<Stream, IMethodSignature>> _readMethodSignatureFromBlob;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodRefSignatureStreamReader"/> class.
        /// </summary>
        public MethodRefSignatureStreamReader(IFunction<ITuple<Stream, IMethodSignature>> readMethodDefSignatureFromBlob)
        {
            _readMethodSignatureFromBlob = readMethodDefSignatureFromBlob;
        }

        /// <summary>
        /// Reads an <see cref="IMethodSignature"/> instance from the given <paramref name="blobStream"/>.
        /// </summary>
        /// <param name="blobStream">The blob stream that contains the method signature.</param>
        /// <returns>A method signature object.</returns>
        public IMethodRefSignature ReadSignature(Stream blobStream)
        {
            var methodDefSig = new MethodRefSig();
            _readMethodSignatureFromBlob.Execute(blobStream, methodDefSig);

            return methodDefSig;
        }
    }
}
