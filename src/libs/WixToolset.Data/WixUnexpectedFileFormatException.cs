﻿//-------------------------------------------------------------------------------------------------
// <copyright file="WixUnexpectedFileFormatException.cs" company="Outercurve Foundation">
//   Copyright (c) 2004, Outercurve Foundation.
//   This software is released under Microsoft Reciprocal License (MS-RL).
//   The license and further copyright text can be found in the file
//   LICENSE.TXT at the root directory of the distribution.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace WixToolset.Data
{
    using System;

    /// <summary>
    /// Exception when file does not match the expected format.
    /// </summary>
    public class WixUnexpectedFileFormatException : WixException
    {
        public WixUnexpectedFileFormatException(string path, FileFormat expectedFormat, FileFormat format, Exception innerException = null)
            : base(WixDataErrors.UnexpectedFileFormat(path, expectedFormat.ToString().ToLowerInvariant(), format.ToString().ToLowerInvariant()), innerException)
        {
            this.Path = path;
            this.ExpectedFileFormat = expectedFormat;
            this.FileFormat = format;
        }

        /// <summary>
        /// Gets the expected file format.
        /// </summary>
        public FileFormat ExpectedFileFormat { get; private set; }

        /// <summary>
        /// Gets the actual file format found in the file.
        /// </summary>
        public FileFormat FileFormat { get; private set; }

        /// <summary>
        /// Gets the path to the file with unexpected format.
        /// </summary>
        public string Path { get; set; }
    }
}
