CREATE TABLE [Articles] (  
  [Id] integer Primary key not null,  
  [txtTitle] text null,--����  
  [txtContent] text null,--����  
  [Adder]  text null,--�����  
  [AddTime]  text DEFAULT (datetime('now','localtime')) not null,--�ύʱ��  
  [ModiTime]  text DEFAULT (datetime('now','localtime')) not null,--�޸�ʱ��  
  [Hits] integer Default (0)  not null,--�����  
  [Flags] integer Default (0)  not null ,--��ʶ  
  [SortID] integer Default (0)  not null--�����  
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
