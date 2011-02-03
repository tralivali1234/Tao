﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tao.Model
{
    /// <summary>
    /// Represents a module definition.
    /// </summary>
    public class ModuleDef
    {
        /// <summary>
        /// Gets a value indicating the Name of the current type.
        /// </summary>
        /// <value>The Name of the current type.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets a value indicating the Mvid of the current type.
        /// </summary>
        /// <value>The module Mvid value.</value>
        public Guid Mvid { get; set; }  
    }
}