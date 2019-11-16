namespace WPExportContent.Core.DataAccess.Queries
{
    public class SQLServerQuery
    {

        public const string INSERT_CATEGORIES = @"DELETE FROM [dbo].[Categories] WHERE [RowID] = @RowID;
                INSERT INTO [dbo].[Categories]([RowID],[RowCreationDateUTC],[ID],[Name],[Slug])
                     VALUES(@RowID,@RowCreationDateUTC,@ID,@Name,@Slug)";

        public const string INSERT_CONTENT_CATEGORIES = @"DELETE FROM [dbo].[ContentCategories] WHERE [RowID] = @RowID;
                INSERT INTO [dbo].[ContentCategories]
           ([RowID]
           ,[RowCreationDateUTC]
           ,[IDContent]
           ,[IDCategory])
     VALUES
           ( @RowID, 
           @RowCreationDateUTC, 
           @IDContent,
           @IDCategory)";


        public const string INSERT_CONTENT_TAGS = @"DELETE FROM [dbo].[ContentTags] WHERE [RowID] = @RowID;
                  INSERT INTO[dbo].[ContentTags]
        ([RowID]
                  ,[RowCreationDateUTC]
                  ,[IDContent]
                  ,[IDTag])
            VALUES
                  (@RowID
                  , @RowCreationDateUTC
                  , @IDContent
                  , @IDTag)";


public const string INSERT_TAGS    = @"DELETE FROM [dbo].[Tags] WHERE [RowID] = @RowID;
                  INSERT INTO [dbo].[Tags]
           ([RowID]
           ,[RowCreationDateUTC]
           ,[ID]
           ,[Name]
           ,[Slug])
     VALUES
           (@RowID
           ,@RowCreationDateUTC
           ,@ID
           ,@Name
           ,@Slug)";


public const string INSERT_USERS = @"DELETE FROM [dbo].[Users] WHERE [RowID] = @RowID;
                 INSERT INTO [dbo].[Users]
           ([RowID]
           ,[RowCreationDateUTC]
           ,[ID]
           ,[UserName]
           ,[UserPassword]
           ,[UserNicename]
           ,[UserEmail]
           ,[UserUrl]
           ,[UserRegistered]
           ,[UserActivationKey]
           ,[UserStatus]
           ,[DisplayName])
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


public const string INSERT_PRODUCTS = @"DELETE FROM [dbo].[Products] WHERE [RowID] = @RowID;                  
INSERT INTO [dbo].[Products]
           ([RowID]
           ,[RowCreationDateUTC]
           ,[ID]
           ,[PostAuthor]
           ,[PostDate]
           ,[PostDateGTM]
           ,[PostContent]
           ,[PostTitle]
           ,[PostExcerpt]
           ,[PostStatus]
           ,[CommentStatus]
           ,[PingStatus]
           ,[PostPassword]
           ,[PostName]
           ,[ToPing]
           ,[Pinged]
           ,[PostModified]
           ,[PostModifiedGTM]
           ,[PostContentFiltered]
           ,[PostParent]
           ,[guid]
           ,[MenuOrder]
           ,[PostType]
           ,[PostMimeType]
           ,[CommentCount])
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


public const string INSERT_POSTS =  @"DELETE FROM [dbo].[Posts] WHERE [RowID] = @RowID;
INSERT INTO [dbo].[Posts]
           ([RowID]
           ,[RowCreationDateUTC]
           ,[ID]
           ,[PostAuthor]
           ,[PostDate]
           ,[PostDateGTM]
           ,[PostContent]
           ,[PostTitle]
           ,[PostExcerpt]
           ,[PostStatus]
           ,[CommentStatus]
           ,[PingStatus]
           ,[PostPassword]
           ,[PostName]
           ,[ToPing]
           ,[Pinged]
           ,[PostModified]
           ,[PostModifiedGTM]
           ,[PostContentFiltered]
           ,[PostParent]
           ,[guid]
           ,[MenuOrder]
           ,[PostType]
           ,[PostMimeType]
           ,[CommentCount])
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

    }
}
