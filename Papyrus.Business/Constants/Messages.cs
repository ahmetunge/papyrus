using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Constants
{
    public static class Messages
    {
        public static string SuccessAddedBook = "Book added successfully";

        public static string UserNotFound = "User not found";
        public static string SuccessLogin = "Login successfully";

        public static string CategoryRequired = "Category is required";

        public static string MemberRequired = "Member is required";

        public static string TitleRequired = "Title is required";

        public static string UserAlreadyExist = "User already exist";

        public static string EmailRequired = "Email is required";

        public static string UserRegistered = "User registered successfully";

        public static string UserAddedSuccessfully = "User added successfully";

        public static string InvalidMail = "Invalid mail adress";

        public static string BookNotFound = "Book not found";

        public static string BookEditSuccessfully = "Book edit successfully";

        public static string BookRequired = "Book is required";

        public static string PasswordRequired = "Password is required";
        public static string AuthorizationDenied = "Authorization denied";

        public static string GenreNotFound = "Genre not found";

        public static string CategoryNotFound = "Category not found";

        public static string AdRequired = "Ad is required";

        public static string AdCreated = "Ad is created";

        public static string PropertiesNotFound = "Properties not found";

        public static string InternalServerError = "Internal server error";

        public static string AdNotFound = "Ad not found";
    }
}