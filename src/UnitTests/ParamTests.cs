﻿using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Tao.Containers;
using Tao.Interfaces;
using Tao.Model;

namespace Tao.UnitTests
{
    [TestFixture]
    public class ParamTests : BaseStreamTests
    {
        [Test]
        public void ShouldBeAbleToReadByRefSimpleParam()
        {
            var typeBytes = new[] { Convert.ToByte(ElementType.ByRef), Convert.ToByte(ElementType.Boolean) };
            var stream = new MemoryStream(typeBytes);
            var reader = container.GetInstance<IFunction<Stream, MethodSignatureElement>>("ParamSignatureReader");
            Assert.IsNotNull(reader);

            var param = (TypedMethodSignatureElement)reader.Execute(stream);
            Assert.AreEqual(0, param.CustomMods.Count);
            Assert.IsTrue(param.IsByRef);
            Assert.IsNotNull(param.Type);

            TypeSignature typeSignature = param.Type;
            Assert.AreEqual(ElementType.Boolean, typeSignature.ElementType);
        }

        [Test]
        public void ShouldBeAbleToReadSimpleParam()
        {
            var typeBytes = new[] { Convert.ToByte(ElementType.Boolean) };
            var stream = new MemoryStream(typeBytes);
            var reader = container.GetInstance<IFunction<Stream, MethodSignatureElement>>("ParamSignatureReader");
            Assert.IsNotNull(reader);

            var param = (TypedMethodSignatureElement)reader.Execute(stream);
            Assert.AreEqual(0, param.CustomMods.Count);
            Assert.IsFalse(param.IsByRef);
            Assert.IsNotNull(param.Type);

            TypeSignature typeSignature = param.Type;
            Assert.AreEqual(ElementType.Boolean, typeSignature.ElementType);
        }

        [Test]
        public void ShouldBeAbleToReadSimpleParamWithCustomMods()
        {
            var firstModBytes = GetCustomModBytes(ElementType.CMOD_REQD, 0x49);
            var secondModBytes = GetCustomModBytes(ElementType.CMOD_OPT, 0x49);

            var bytes = new List<byte>();
            bytes.AddRange(firstModBytes);
            bytes.AddRange(secondModBytes);
            bytes.Add(Convert.ToByte(ElementType.Boolean));

            var typeBytes = bytes.ToArray();
            var stream = new MemoryStream(typeBytes);
            var reader = container.GetInstance<IFunction<Stream, MethodSignatureElement>>("ParamSignatureReader");
            Assert.IsNotNull(reader);

            var param = (TypedMethodSignatureElement)reader.Execute(stream);           
            Assert.IsFalse(param.IsByRef);
            Assert.IsNotNull(param.Type);

            TypeSignature typeSignature = param.Type;
            Assert.AreEqual(ElementType.Boolean, typeSignature.ElementType);

            var customMods = param.CustomMods;
            Assert.AreEqual(2, customMods.Count);
            var firstMod = customMods[0];

            Assert.AreEqual(firstMod.ElementType, ElementType.CMOD_REQD);
            Assert.AreEqual(firstMod.TableId, TableId.TypeRef);
            Assert.AreEqual(firstMod.RowIndex, 0x12);

            var secondMod = customMods[1];
            Assert.AreEqual(secondMod.ElementType, ElementType.CMOD_OPT);
            Assert.AreEqual(secondMod.TableId, TableId.TypeRef);
            Assert.AreEqual(secondMod.RowIndex, 0x12);
        }

        [Test]
        public void ShouldBeAbleToReadTypedByRef()
        {
            var typeBytes = new[] { Convert.ToByte(ElementType.TypedByRef) };
            var stream = new MemoryStream(typeBytes);
            var reader = container.GetInstance<IFunction<Stream, MethodSignatureElement>>("ParamSignatureReader");
            Assert.IsNotNull(reader);

            var param = reader.Execute(stream);
            Assert.IsNotNull(param);
            Assert.IsInstanceOfType(typeof(TypedByRefMethodSignatureElement), param);
            Assert.AreEqual(0, param.CustomMods.Count);
            Assert.IsFalse(param.IsByRef);
        }

        private byte[] GetCustomModBytes(ElementType elementType, byte codedToken)
        {
            return new[] { Convert.ToByte(elementType), Convert.ToByte(codedToken) };
        }
    }
}
