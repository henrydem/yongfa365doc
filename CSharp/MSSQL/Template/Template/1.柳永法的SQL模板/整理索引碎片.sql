DBCC SHOWCONTIG --查看所有表的索引碎片
EXEC sp_msforeachtable "DBCC DBREINDEX('?')"  --重建所有表的所有索引




---------------------------------------------------------
--不管3721，检查所有，重建所有
--1.必须断开所有用户的连接.
--2.数据库大时,那要花较长的时间


USE MASTER
GO

sp_dboption '你的数据库名', 'single user', 'true'
Go

DBCC CHECKDB('你的数据库名', REPAIR_REBUILD)
Go

USE [你的数据库名]
Go

EXEC sp_msforeachtable 'DBCC CHECKTABLE( ''?'',REPAIR_REBUILD)'
EXEC sp_msforeachtable 'DBCC DBREINDEX( ''?'')'
Go

sp_dboption '你的数据库名', 'single user', 'false'
Go

