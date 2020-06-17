// Copyright (C) 2020 Yotam Cohen
//
// This file is part of DoubleClickFix.
//
// DoubleClickFix is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DoubleClickFix is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DoubleClickFix.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace DoubleClickFix.Configuration
{

    public static class WriteableJsonConfigurationExtensions
    {
        public static IConfigurationBuilder AddWriteableJsonFile(this IConfigurationBuilder builder, string path, IFileProvider provider = null, bool optional = false, bool reloadOnChange = false, bool createIfMissing = false)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (createIfMissing && !File.Exists(path))
                File.WriteAllText(path, "{}");

            return builder.AddWriteableJsonFile(s =>
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        public static IConfigurationBuilder AddWriteableJsonFile(this IConfigurationBuilder builder, Action<WritableJsonConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
