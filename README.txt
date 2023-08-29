//Goals

//Create backend for a blog site
//Create frontend for the blog site
//Deploy to Azure
//Learn about DevOps and SCRUM

Create an API for blog. This API must handle all CRUD functions:
    Create, Read, Update, Delete

//In this app, the user should be able to login. Create an account
Blog page to view all the published items
Dashboard (The user profile page for them to edit, delete and add blog items)

We will talk about the folder structure:

Controller//Folders
    UserController (This will handle all our user interactions)
    Login//endpoints
    Add a user//endpoints
    Update a user
    Delete a user

BlogController//file
    Add blog items//function C
    GetAllBlogItems//function R
    GetBlogItemsByCategory
    GetAllBlogItemsByTags
    GetBlogItemsByDate
    UpdateBlogItems//function U
    DeleteBlogItems//function D

Model//folder
    UserModel
        int ID
        string Username
        string Salt
        string Hash 256 characters

    BlogItemModel
        int ID
        int UserID
        string PublisherName
        string Title
        string Image
        string Description
        string Date
        string Category
        bool isPublished
        bool isDeleted

-------------- Items that will be saved to our database DB are above ------------------
LoginModel
    string Username
    string password
Create AccountModel
    int ID = 0
    string Username
    string password
passwordModel
    string Salt
    string Hash


Services//folder    
    Context//folder

    UserService//file
        GetUsersByUsername
        Login
        Add User
        Delete User
    BlogItemService//file
     Add blog items//function C
    GetAllBlogItems//function R
    GetBlogItemsByCategory
    GetAllBlogItemsByTags
    GetBlogItemsByDate
    UpdateBlogItems//function U
    DeleteBlogItems//function D
    GetUserByID//functions

PasswordService//file
    Hash Password
    Very Hash Password


    //under appsettings.json:

//"AllowedHosts": "*",
//"_comment" : "Server Admin login: AcademyBlogAdmin  Password: "AcademyBlogPassword!"