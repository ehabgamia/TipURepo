using System;
using System.Collections.Generic;
using System.Linq;
using VideoBrek.Core.Domain.Category;
using VideoBrek.Data.Interfaces;
using VideoBrekWeb.Models;

namespace VideoBrekWeb.Services.Category
{
    public partial class CategoryServices : ICategoryServices
    {
        #region  Fields

        private readonly IRepository<MediaCategory> _mediaCategoryModelRepository;
        #endregion

        #region  CTOR
        public CategoryServices(IRepository<MediaCategory> MediaCategoryModelRepository)
        {
            this._mediaCategoryModelRepository = MediaCategoryModelRepository;
        }

        #endregion


        /// <summary>
        /// Insert a Category
        /// </summary>
        /// <param name="Category">Category</param>
        public void InsertCategory(MediaCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _mediaCategoryModelRepository.Insert(category);
        }

        /// <summary>
        /// Updates the Category
        /// </summary>
        /// <param name="Category">Category</param>
        public void UpdateCategory(MediaCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _mediaCategoryModelRepository.Update(category);
        }


        /// <summary>
        /// Gets a Nurse
        /// </summary>
        /// <param name="CategoryId">Nurse identifier</param>
        /// <returns>A Nurse</returns>
        public MediaCategory GetCategoryById(int CategoryId)
        {
            var query = from h in _mediaCategoryModelRepository.Table
                        where h.Id == CategoryId
                        select h;
            return query.FirstOrDefault();
        }
        //Delete nurse
     
       public void DeleteCategory(MediaCategory category)
     {
        //    if (category == null)
        //    throw new ArgumentNullException(nameof(category));

        // category.Deleted = true;
        UpdateCategory(category);
    }

    /// <summary>
    /// Gets all Nurse
    /// </summary>

    /// <returns>A Nurse</returns>
    public IList<MediaCategory> GetAllCategory()
        {
            var query = from h in _mediaCategoryModelRepository.Table
                        select h;
            return query.ToList();
        }

    }
}
