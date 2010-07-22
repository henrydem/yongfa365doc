--一个字段的例子
DECLARE cur CURSOR FOR SELECT name FROM TableName
DECLARE @tb VARCHAR(50)
  
OPEN cur   
FETCH NEXT FROM cur INTO @tb   
WHILE @@fetch_status = 0 
    BEGIN   
 --要用到名字的SQL语句
        PRINT @tb
 
 
 
 
        FETCH NEXT FROM cur INTO @tb   
    END   
CLOSE cur   
DEALLOCATE cur




--多个字段的例子
DECLARE cur CURSOR FOR SELECT Usr,Pwd FROM TableName
DECLARE @tb VARCHAR(50)
DECLARE @tb2 VARCHAR(50)
  
OPEN cur
FETCH NEXT FROM cur INTO @tb,@tb2   
WHILE @@fetch_status = 0 
    BEGIN   
 --要用到名字的SQL语句
        PRINT @tb+@tb2
 
 
 
 
        FETCH NEXT FROM cur INTO @tb,@tb2 
    END   
CLOSE cur   
DEALLOCATE cur