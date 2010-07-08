CREATE TABLE [Articles] (  
  [Id] integer Primary key not null,  
  [txtTitle] text null,--标题  
  [txtContent] text null,--内容  
  [Adder]  text null,--添加人  
  [AddTime]  text DEFAULT (datetime('now','localtime')) not null,--提交时间  
  [ModiTime]  text DEFAULT (datetime('now','localtime')) not null,--修改时间  
  [Hits] integer Default (0)  not null,--点击数  
  [Flags] integer Default (0)  not null ,--标识  
  [SortID] integer Default (0)  not null--排序号  
 );

CREATE TABLE "Books" (
   "ID" integer Primary key  not null,
   "BookURL" text null ,
   "BookID" integer  null ,
   "BookName" text null ,
   "BookNO" integer  null 
  );

CREATE TABLE [Pages] (
    [ID] integer Primary key  not null,
   [PageURL] text null ,
   [PageNO] integer null ,
   [BookID] integer null ,
   [PageContent] text null ,
   [PageTitle] text null ,
   [doing] integer null,
   [done] integer null
  );

CREATE INDEX idx_001 on Pages(doing,done);
