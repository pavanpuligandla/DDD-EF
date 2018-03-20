

BEGIN
INSERT INTO [dbo].[ProjectType]
           ([ProjectTypeName]
           ,[ProjectTypeDescription]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[CreatedBy]
           ,[ModifiedBy])
     VALUES
           ('TestProjectType'
           ,'Test project type description'
           ,GETDATE()
           ,GETUTCDATE()
           ,1
           ,1)
END
GO