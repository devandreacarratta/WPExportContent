namespace WPExportContent.Core.DataAccess.Queries
{
    public class ContentQuery
    {

        public const string INSERT_CATEGORIES = @"DELETE FROM   Categories  WHERE  RowID  = @RowID;
                INSERT INTO   Categories ( RowID , RowCreationDateUTC , ID , Name , Slug )
                     VALUES(@RowID,@RowCreationDateUTC,@ID,@Name,@Slug)";

        public const string INSERT_CONTENT_CATEGORIES = @"DELETE FROM   ContentCategories  WHERE  RowID  = @RowID;
                INSERT INTO   ContentCategories 
           ( RowID 
           , RowCreationDateUTC 
           , IDContent 
           , IDCategory )
     VALUES
           ( @RowID, 
           @RowCreationDateUTC, 
           @IDContent,
           @IDCategory)";


        public const string INSERT_CONTENT_TAGS = @"DELETE FROM   ContentTags  WHERE  RowID  = @RowID;
                  INSERT INTO  ContentTags 
        ( RowID 
                  , RowCreationDateUTC 
                  , IDContent 
                  , IDTag )
            VALUES
                  (@RowID
                  , @RowCreationDateUTC
                  , @IDContent
                  , @IDTag)";


        public const string INSERT_TAGS = @"DELETE FROM   Tags  WHERE  RowID  = @RowID;
                  INSERT INTO   Tags 
           ( RowID 
           , RowCreationDateUTC 
           , ID 
           , Name 
           , Slug )
     VALUES
           (@RowID
           ,@RowCreationDateUTC
           ,@ID
           ,@Name
           ,@Slug)";


        public const string INSERT_USERS = @"DELETE FROM   Users  WHERE  RowID  = @RowID;
                 INSERT INTO   Users 
           ( RowID 
           , RowCreationDateUTC 
           , ID 
           , UserName 
           , UserPassword 
           , UserNicename 
           , UserEmail 
           , UserUrl 
           , UserRegistered 
           , UserActivationKey 
           , UserStatus 
           , DisplayName )
     VALUES
           (@RowID,
           @RowCreationDateUTC, 
           @ID, 
           @UserName, 
           @UserPassword, 
           @UserNicename, 
           @UserEmail, 
           @UserUrl, 
           @UserRegistered, 
           @UserActivationKey, 
           @UserStatus, 
           @DisplayName )";


        public const string INSERT_PRODUCTS = @"DELETE FROM   Products  WHERE  RowID  = @RowID;                  
INSERT INTO   Products 
           ( RowID 
           , RowCreationDateUTC 
           , ID 
           , PostAuthor 
           , PostDate 
           , PostDateGTM 
           , PostContent 
           , PostTitle 
           , PostExcerpt 
           , PostStatus 
           , CommentStatus 
           , PingStatus 
           , PostPassword 
           , PostName 
           , ToPing 
           , Pinged 
           , PostModified 
           , PostModifiedGTM 
           , PostContentFiltered 
           , PostParent 
           , guid 
           , MenuOrder 
           , PostType 
           , PostMimeType 
           , CommentCount )
     VALUES
           (@RowID, 
           @RowCreationDateUTC, 
           @ID, 
           @PostAuthor, 
           @PostDate, 
           @PostDateGTM, 
           @PostContent, 
           @PostTitle, 
           @PostExcerpt, 
           @PostStatus, 
           @CommentStatus, 
           @PingStatus, 
           @PostPassword, 
           @PostName, 
           @ToPing, 
           @Pinged, 
           @PostModified, 
           @PostModifiedGTM, 
           @PostContentFiltered, 
           @PostParent, 
           @guid, 
           @MenuOrder,
           @PostType, 
           @PostMimeType, 
           @CommentCount)";


        public const string INSERT_POSTS = @"DELETE FROM   Posts  WHERE  RowID  = @RowID;
INSERT INTO   Posts 
           ( RowID 
           , RowCreationDateUTC 
           , ID 
           , PostAuthor 
           , PostDate 
           , PostDateGTM 
           , PostContent 
           , PostTitle 
           , PostExcerpt 
           , PostStatus 
           , CommentStatus 
           , PingStatus 
           , PostPassword 
           , PostName 
           , ToPing 
           , Pinged 
           , PostModified 
           , PostModifiedGTM 
           , PostContentFiltered 
           , PostParent 
           , guid 
           , MenuOrder 
           , PostType 
           , PostMimeType 
           , CommentCount )
     VALUES
                    (@RowID, 
           @RowCreationDateUTC, 
           @ID,
           @PostAuthor,
           @PostDate, 
           @PostDateGTM, 
           @PostContent,
           @PostTitle,
           @PostExcerpt,
           @PostStatus,
           @CommentStatus,
           @PingStatus,
           @PostPassword,
           @PostName,
           @ToPing,
           @Pinged,
           @PostModified, 
           @PostModifiedGTM, 
           @PostContentFiltered,
           @PostParent,
           @guid,
           @MenuOrder,
           @PostType,
           @PostMimeType,
           @CommentCount)";

        public const string INSERT_SEOMETA = @"INSERT INTO   SeoMeta 
                   ( RowID 
                   , RowCreationDateUTC 
                   , PostID 
                   , FocusKW 
                   , MetaDescription )
             VALUES
                   (@RowID
                   ,@RowCreationDateUTC
                   ,@PostID 
                   ,@FocusKW 
                   ,@MetaDescription)";

    }

}