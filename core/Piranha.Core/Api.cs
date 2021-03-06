﻿/*
 * Copyright (c) 2016 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using System;
using System.Threading.Tasks;

namespace Piranha
{
	/// <summary>
	/// The main application api.
	/// </summary>
    public sealed class Api : IApi
    {
		#region Members
		/// <summary>
		/// The current db context.
		/// </summary>
		private readonly Db db;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the archive repository.
		/// </summary>
		public Repositories.IArchiveRepository Archives { get; private set; }

		/// <summary>
		/// Gets the category repository.
		/// </summary>
		public Repositories.ICategoryRepository Categories { get; private set; }

		/// <summary>
		/// Gets the page repository.
		/// </summary>
		public Repositories.IPageRepository Pages { get; private set; }

		/// <summary>
		/// Gets the post repository.
		/// </summary>
		public Repositories.IPostRepository Posts { get; private set; }

		/// <summary>
		/// Gets the site map repository.
		/// </summary>
		public Repositories.ISiteMapRepository SiteMap { get; private set; }
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Api(Db db) {
			this.db = db;

			Archives = new Repositories.ArchiveRepository(db);
			Categories = new Repositories.CategoryRepository(db);
			Pages = new Repositories.PageRepository(db);
			Posts = new Repositories.PostRepository(db);
			SiteMap = new Repositories.SiteMapRepository(db);
		}

		/// <summary>
		/// Saves the changes made to the api.
		/// </summary>
		/// <returns>The number of saved rows.</returns>
		public int SaveChanges() {
			return db.SaveChanges();
		}

		/// <summary>
		/// Saves the changes made to the api.
		/// </summary>
		/// <returns>The number of saved rows.</returns>
		public Task<int> SaveChangesAsync() {
			return db.SaveChangesAsync();
		}

		/// <summary>
		/// Disposes the api.
		/// </summary>
		public void Dispose() {
			db.Dispose();
			GC.SuppressFinalize(this);
		}
    }
}
