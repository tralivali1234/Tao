﻿using System;
using System.Collections.Generic;
using System.Text;
using Tao.Interfaces;

namespace Tao.Schemas
{
    /// <summary>
    /// Represents the row schema for the StandAloneSig table.
    /// </summary>
    public class StandAloneSigRowSchema : BaseRowSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandAloneSigRowSchema"/> class.
        /// </summary>
        public StandAloneSigRowSchema()
            : base(0, 0, 0, 0, 1, 0)
        {
        }

        /// <summary>
        /// Gets the value indicating the list of table indexes and the number of indexes that point to each table type.
        /// </summary>
        /// <value>The number of table indexes.</value>
        public override IEnumerable<ITuple<IEnumerable<TableId>, int>> Item7
        {
            get
            {
                yield break;
            }
        }
    }
}