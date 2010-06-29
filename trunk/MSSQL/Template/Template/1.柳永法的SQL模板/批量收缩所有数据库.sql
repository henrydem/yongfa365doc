--批量收缩所有数据库  
DECLARE cur CURSOR FOR SELECT name FROM Master..SysDatabases WHERE name NOT IN ('master','model','msdb','Northwind','pubs')  
DECLARE @tb SYSNAME   
  
OPEN cur   
FETCH NEXT FROM cur INTO @tb   
WHILE @@fetch_status = 0 
    BEGIN   
        DUMP TRANSACTION  @tb  WITH NO_LOG  
        BACKUP LOG  @tb WITH NO_LOG  
        DBCC shrinkdatabase(@tb)  
        FETCH NEXT FROM cur INTO @tb   
    END   
CLOSE cur   
DEALLOCATE cur 