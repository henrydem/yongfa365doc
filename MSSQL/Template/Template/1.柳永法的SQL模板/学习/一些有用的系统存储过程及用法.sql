--һЩ���õ�ϵͳ�洢���̼��÷�
  ---------------------------
--  �õ�SQL   SERVER   �ķ�������
select convert(sysname, serverproperty(N'servername'))

--  ��ȡ��ֵ
EXEC xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\Setup',
    N'SQLPath'

--  �õ�SQL   SERVER   ƽ̨��Ϣ
EXEC xp_msver
    N'ProductVersion',
    N'Language',
    N'Platform',
    N'WindowsVersion',
    N'ProcessorCount',
    N'PhysicalMemory'

--  �õ�SQL   SERVERʵ���ĵ�½ģʽ
--LoginMode=2��Ϊ�����֤ =1ȱʡnt��֤ =0sa��֤
EXEC  xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    'LoginMode'

-- �޸�SQL   SERVERʵ���ĵ�½ģʽ
EXEC xp_instance_regwrite
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    N'LoginMode',
    N'REG_DWORD',
    1
--1Windows��֤ģʽ
--2SQL��Windows��֤ģʽ

--  �õ�sql   server   �����������������б�
EXEC  xp_ntsec_enumdomain

exec   sp_grantdbaccess   N'zhang',   N'zhang'
exec   sp_droplogin   N'zhang'
exec   sp_revokedbaccess   N'zhang'
exec   sp_dbcmptlevel   N'dbname'

exec  sp_stored_procedures
--  �õ��洢�����б�

exec  xp_availablemedia   2
--  �õ�Ӳ�̷�����Ϣ

EXECUTE   master.dbo.xp_dirtree   N'E:\',   1,   1
--  �õ�E:\�µ��ļ��б�

EXECUTE   master.dbo.xp_fileexist   N'c:\Program Files\Microsoft SQL Server\MSSQL\BACKUP\fdsa.dat'
--  �ļ��Ƿ����

backup   log   database_name   with   NO_LOG|TRUNCATE_ONLY
--  �ض�������־

DBCC   SHRINKDATABASE   database_name
--  �������ݿ�

exec   sp_addumpdevice   N'disk',   N'bakdevice',   N'D:\BACKUP\bakdevice'
--  ��ӱ����豸
exec   sp_dropdevice   N'bakdevice'
--  ɾ�������豸

EXEC xp_instance_regread
    N'HKEY_CURRENT_USER',
    N'Software\Microsoft\MSSQLServer',
    N'LastBackupFileDir'
--  �ϴα��ݵ�·��

exec xp_instance_regwrite
    N'HKEY_CURRENT_USER',
    N'Software\Microsoft\MSSQLServer',
    N'LastBackupFileDir',
    REG_SZ,
    N'D:\Program Files\Microsoft SQL Server\MSSQL$FANHUI\BACKUP\'
--  ��д����·��

exec  sp_rename 'tablename.id1','id'
--  �����ֶ���

--master����
  USE   master
  SELECT   filename   AS   mdf�ļ�����·��
                            FROM   sysdatabases
                            WHERE   (name   =   '���ݿ�����')