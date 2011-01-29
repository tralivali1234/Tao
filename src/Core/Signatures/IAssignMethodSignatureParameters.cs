﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tao.Interfaces;
using Tao.Model;

namespace Tao.Signatures
{
    /// <summary>
    /// Represents a class that reads the method parameters for a given method signature from
    /// a blob stream.
    /// </summary>
    public interface IAssignMethodSignatureParameters : IFunction<ITuple<Stream, IMethodSignature>>
    {
    }
}
