﻿//-------------------------------------------------------------------------------------------------
// <copyright file="PackageItemTargetsFile.cs" company="Outercurve Foundation">
//   Copyright (c) 2004, Outercurve Foundation.
//   This software is released under Microsoft Reciprocal License (MS-RL).
//   The license and further copyright text can be found in the file
//   LICENSE.TXT at the root directory of the distribution.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace WixToolset.Simplified.Lexicon
{
    using System.ComponentModel;
    using WixToolset.Simplified.CompilerFrontend;

    /// <summary>
    /// Base class for all package items that target files.
    /// </summary>
    public abstract class PackageItemTargetsFile : PackageItem, ITargetFile
    {
        /// <summary>
        /// Gets or sets the file that is the target of the package item.
        /// </summary>
        [TypeConverter(typeof(IdTypeConverter))]
        public File File { get; set; }

        /// <summary>
        /// Gets the file targeted by this item.
        /// </summary>
        /// <returns>The File property.</returns>
        public File GetTargetedFile()
        {
            return this.File;
        }

        protected override void OnResolveEnd(FrontendCompiler context)
        {
            base.OnResolveEnd(context);

            // If the File wasn't explicitly set, default it to the parent if the parent is a file.
            if (this.File == null)
            {
                this.File = this.Parent as File;
            }
            else if (this.Parent is File)
            {
                // TODO: display a warning that we overrode the implicit (via parent) file with an explicit file reference.
            }
        }
    }
}
