using System.Collections.Generic;
using VideoBrek.Core.Domain.Category;
using VideoBrekWeb.Models;

namespace VideoBrekWeb.Services.Category
{
    public partial interface ICategoryServices
    {
        /// <summary>
        /// Insert a Category
        /// </summary>
        /// <param name="Category">Category</param>
        void InsertCategory(MediaCategory category);

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="Category">Category</param>
        void UpdateCategory(MediaCategory category);
        // Delete category
        void DeleteCategory(MediaCategory category);


        /// <summary>
        /// Gets a Category
        /// </summary>
        /// <param name="CategoryId">Category identifier</param>
        /// <returns>A Category</returns>
        MediaCategory GetCategoryById(int CategoryId);

        /// <summary>
        /// Gets all Category
        /// </summary>

        /// <returns>A Category</returns>
        IList<MediaCategory> GetAllCategory();
    }
}
