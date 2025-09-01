using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Business.Constants
{
    public static class ResultMessages
    {
        public static string SuccessCategoryCreated = "Category was added successfully";
        public static string SuccessCategoryUpdated = "Category was updated successfully";
        public static string SuccessCategoryDeleted = "Category was deleted successfully";
        public static string SuccessCategoryListed = "Category was listed successfully";
        public static string SuccessCategoryGetById = "Category was retrieved successfully";
        public static string ErrorCategoryCreated = "Category creation failed";
        public static string ErrorCategoryUpdated = "Category update failed";
        public static string ErrorCategoryDeleted = "Category deletion failed";
        public static string ErrorCategoryListed = "Category listing failed";
        public static string ErrorCategoryGetById = "Failed to retrieve the selected category";

        public static string SuccessMovieCreated = "Movie was added successfully";
        public static string SuccessMovieUpdated = "Movie was updated successfully";
        public static string SuccessMovieDeleted = "Movie was deleted successfully";
        public static string SuccessMovieListed = "Movie was listed successfully";
        public static string SuccessMovieGetById = "Movie was retrieved successfully";
        public static string ErrorMovieCreated = "Movie creation failed";
        public static string ErrorMovieUpdated = "Movie update failed";
        public static string ErrorMovieDeleted = "Movie deletion failed";
        public static string ErrorMovieListed = "Movie listing failed";
        public static string ErrorMovieGetById = "Failed to retrieve the selected movie";

        public static string SuccessCreated = "Creation completed successfully.";
        public static string SuccessUpdated = "Update completed successfully.";
        public static string SuccessDeleted = "Deletion completed successfully.";
        public static string SuccessListed = "Listing completed successfully.";
        public static string SuccessGetById = "Retrieval completed successfully.";
        public static string ErrorCreated = "Creation failed.";
        public static string ErrorUpdated = "Update failed.";
        public static string ErrorDeleted = "Deletion failed.";
        public static string ErrorListed = "Listing failed.";
        public static string ErrorGetById = "Retrieval failed.";

        public static string SuccessUserRegister = "User was created successfully.";
        public static string ErrorPassword = "Incorrect password.";

        public static string SuccessLogin = "Login successful.";

        public static string UserExits = "This email address is already registered.";
    }
}
