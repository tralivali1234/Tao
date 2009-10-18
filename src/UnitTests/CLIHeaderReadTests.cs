﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tao.Core;
using BinaryReader = Tao.Core.BinaryReader;

namespace Tao.UnitTests
{
    [TestFixture]
    public class CLIHeaderReadTests : BaseHeaderReadTest
    {
        [Test]
        public void ShouldReadHeaderSize()
        {
            AssertEquals<uint?>(0x48, h => h.SizeOfHeader);
        }

        [Test]
        public void ShouldReadMajorRuntimeVersion()
        {
            AssertEquals<ushort?>(0x02, h => h.MajorRuntimeVersion);
        }

        [Test]
        public void ShouldReadMinorRuntimeVersion()
        {
            AssertEquals<ushort?>(0x05, h => h.MinorRuntimeVersion);
        }

        [Test]
        public void ShouldReadMetadataRVA()
        {
            AssertEquals<uint?>(0x2060, h => h.MetadataRva);
        }

        [Test]
        public void ShouldReadSizeOfMetadata()
        {
            AssertEquals<uint?>(0x11c, h => h.SizeOfMetadata);
        }

        [Test]
        public void ShouldReadRuntimeFlags()
        {
            AssertEquals(RuntimeFlags.ILOnly, h => h.RuntimeFlags);
        }

        [Test]
        public void ShouldReadEntryPointToken()
        {
            AssertEquals<uint?>(0x06000001, h => h.EntryPointToken);
        }

        [Test]
        public void ShouldReadResources()
        {
            AssertEquals<ulong?>(0, h => h.Resources);
        }

        [Test]
        public void ShouldReadStrongNameSignature()
        {
            AssertEquals<ulong?>(0, h => h.StrongNameSignature);
        }

        [Test]
        public void ShouldReadCodeManagerTable()
        {
            AssertEquals<ulong?>(0, h => h.CodeManagerTable);
        }

        [Test]
        public void ShouldReadVTableFixups()
        {
            AssertEquals<ulong?>(0, h => h.VTableFixups);
        }

        [Test]
        public void ShouldReadExportAddressTableJumps()
        {
            AssertEquals<ulong?>(0, h => h.ExportAddressTableJumps);
        }

        [Test]
        public void ShouldReadManagedNativeHeader()
        {
            AssertEquals<ulong?>(0, h => h.ManagedNativeHeader);
        }

        private void AssertEquals<TValue>(TValue expected, Func<CLIHeader, TValue> getActualValue)
        {
            Test(header => Assert.AreEqual(expected, getActualValue(header)));
        }

        private void Test(Action<CLIHeader> doTest)
        {
            var header = GetHeader();
            doTest(header);
        }

        private CLIHeader GetHeader()
        {
            var stream = OpenSampleAssembly();
            stream.Seek(0x208, SeekOrigin.Begin);

            var reader = new BinaryReader(stream);

            var header = new CLIHeader();
            header.ReadFrom(reader);

            return header;
        }
    }
}