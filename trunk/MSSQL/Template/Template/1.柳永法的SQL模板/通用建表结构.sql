--通用建表结构
Create Table [dbo].[test] (
  [Id] int primary key identity(1,1),--ID，主键，自动号
  [txtTitle] nvarchar(255),--标题
  [txtContent] nvarchar(MAX),--内容
  [Adder] nvarchar(20),--添加人
  [AddTime] datetime Default (getdate()),--提交时间
  [ModiTime] datetime Default (getdate()),--修改时间
  [Hits] int Default (0),--点击数
  [Flags] int Default (0) ,--标识
  [SortID] int Default (0)--排序号
 )
--添加人 Adder
--报告人 reporter
--修改人 updater
--测试人 tester
--审核人 auditor

create table 计算列测试表(
生日 datetime,
生日日期 as convert(varchar,生日,23)
)