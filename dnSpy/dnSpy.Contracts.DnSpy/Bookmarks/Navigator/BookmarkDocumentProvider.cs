﻿/*
    Copyright (C) 2014-2018 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.ComponentModel.Composition;

namespace dnSpy.Contracts.Bookmarks.Navigator {
	/// <summary>
	/// Creates <see cref="BookmarkDocument"/>s. Use <see cref="ExportBookmarkDocumentProviderAttribute"/>
	/// to export an instance.
	/// </summary>
	public abstract class BookmarkDocumentProvider {
		/// <summary>
		/// Gets the document or null if it's unknown. This method is called on the UI thread.
		/// </summary>
		/// <param name="bookmark">Bookmark</param>
		/// <returns></returns>
		public abstract BookmarkDocument GetDocument(Bookmark bookmark);
	}

	/// <summary>Metadata</summary>
	public interface IBookmarkDocumentProviderMetadata {
		/// <summary>See <see cref="ExportBookmarkDocumentProviderAttribute.Order"/></summary>
		double Order { get; }
	}

	/// <summary>
	/// Exports a <see cref="BookmarkDocumentProvider"/> instance
	/// </summary>
	[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ExportBookmarkDocumentProviderAttribute : ExportAttribute, IBookmarkDocumentProviderMetadata {
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="order">Order</param>
		public ExportBookmarkDocumentProviderAttribute(double order = double.MaxValue)
			: base(typeof(BookmarkDocumentProvider)) => Order = order;

		/// <summary>
		/// Order
		/// </summary>
		public double Order { get; }
	}
}
