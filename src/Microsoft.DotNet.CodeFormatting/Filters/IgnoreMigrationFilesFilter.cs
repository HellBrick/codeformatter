using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Microsoft.DotNet.CodeFormatting.Filters
{
	[Export( typeof( IFormattingFilter ) )]
	internal sealed class IgnoreMigrationFilesFilter : IFormattingFilter
	{
		private readonly Options _options;

		[ImportingConstructor]
		public IgnoreMigrationFilesFilter( Options options )
		{
			_options = options;
		}

		public bool ShouldBeProcessed( Document document )
		{
			string parentFolderName = Path.GetFileName( Path.GetDirectoryName( document.FilePath ) );
			return parentFolderName != "Migrations";
		}
	}
}
