/*
在一条 INSERT、SELECT INTO 或大容量复制语句完成后，@@IDENTITY 中包含此语句产生的最后的标识值。
若此语句没有影响任何有标识列的表，则 @@IDENTITY 返回 NULL。
若插入了多个行，则会产生多个标识值，@@IDENTITY 返回最后产生的标识值。
如果此语句激发一个或多个执行产生标识值的插入操作的触发器，则语句执行后立即调用 @@IDENTITY 将返回由触发器产生的最后的标识值。
若 INSERT 或 SELECT INTO 语句失败或大容量复制失败，或事务被回滚，则 @@IDENTITY 值不会还原为以前的设置。
在返回插入到表的 @@IDENTITY 列的最后一个值方面，@@IDENTITY、SCOPE_IDENTITY 和 IDENT_CURRENT 函数类似。
@@IDENTITY 和 SCOPE_IDENTITY 将返回在当前会话的所有表中生成的最后一个标识值。
但是，SCOPE_IDENTITY 只在当前作用域内返回值，而 @@IDENTITY 不限于特定的作用域。
IDENT_CURRENT 不受作用域和会话的限制，而受限于指定的表。IDENT_CURRENT 返回任何会话和任何作用域中为特定表生成的标识值。


*/


Create Table [dbo].[test] (  
  [Id] int primary key identity(1,1),
  [txtTitle] nvarchar(255),
  [txtContent] nvarchar(4000) 
 ) 
 SELECT * INTO test2 FROM dbo.test 
INSERT INTO dbo.test (txtTitle,txtContent)
      SELECT '11','111'
UNION SELECT  '11','111'
UNION SELECT  '11','111'


CREATE TRIGGER update2 ON test
AFTER INSERT
AS 
BEGIN
INSERT INTO dbo.test2 (txtTitle,txtContent)
SELECT txtTitle,txtContent FROM inserted
END

	INSERT INTO dbo.test (txtTitle,txtContent)
	VALUES  (NULL, -- txtTitle - nvarchar(255)
	         NULL  -- txtContent - nvarchar(4000)
	         )
SELECT IDENT_CURRENT('test')     
SELECT IDENT_CURRENT('test2')     
SELECT @@IDENTITY
SELECT SCOPE_IDENTITY()