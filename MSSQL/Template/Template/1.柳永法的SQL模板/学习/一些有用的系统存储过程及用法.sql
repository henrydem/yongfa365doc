--一些有用的系统存储过程及用法
  ---------------------------
--  得到SQL   SERVER   的服务器名
select convert(sysname, serverproperty(N'servername'))

--  读取键值
EXEC xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\Setup',
    N'SQLPath'

--  得到SQL   SERVER   平台信息
EXEC xp_msver
    N'ProductVersion',
    N'Language',
    N'Platform',
    N'WindowsVersion',
    N'ProcessorCount',
    N'PhysicalMemory'

--  得到SQL   SERVER实例的登陆模式
--LoginMode=2则为混合认证 =1缺省nt认证 =0sa认证
EXEC  xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    'LoginMode'

-- 修改SQL   SERVER实例的登陆模式
EXEC xp_instance_regwrite
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    N'LoginMode',
    N'REG_DWORD',
    1
--1Windows认证模式
--2SQL和Windows认证模式

--  得到sql   server   服务器名，和域名列表
EXEC  xp_ntsec_enumdomain

exec   sp_grantdbaccess   N'zhang',   N'zhang'
exec   sp_droplogin   N'zhang'
exec   sp_revokedbaccess   N'zhang'
exec   sp_dbcmptlevel   N'dbname'

exec  sp_stored_procedures
--  得到存储过程列表

exec  xp_availablemedia   2
--  得到硬盘分区信息

EXECUTE   master.dbo.xp_dirtree   N'E:\',   1,   1
--  得到E:\下的文件列表

EXECUTE   master.dbo.xp_fileexist   N'c:\Program Files\Microsoft SQL Server\MSSQL\BACKUP\fdsa.dat'
--  文件是否存在

backup   log   database_name   with   NO_LOG|TRUNCATE_ONLY
--  截断事务日志

DBCC   SHRINKDATABASE   database_name
--  收缩数据库

exec   sp_addumpdevice   N'disk',   N'bakdevice',   N'D:\BACKUP\bakdevice'
--  添加备份设备
exec   sp_dropdevice   N'bakdevice'
--  删除备份设备

EXEC xp_instance_regread
    N'HKEY_CURRENT_USER',
    N'Software\Microsoft\MSSQLServer',
    N'LastBackupFileDir'
--  上次备份的路径

exec xp_instance_regwrite
    N'HKEY_CURRENT_USER',
    N'Software\Microsoft\MSSQLServer',
    N'LastBackupFileDir',
    REG_SZ,
    N'D:\Program Files\Microsoft SQL Server\MSSQL$FANHUI\BACKUP\'
--  改写备份路径

exec  sp_rename 'tablename.id1','id'
--  更改字段名

--master库中
  USE   master
  SELECT   filename   AS   mdf文件名和路径
                            FROM   sysdatabases
                            WHERE   (name   =   '数据库名称')