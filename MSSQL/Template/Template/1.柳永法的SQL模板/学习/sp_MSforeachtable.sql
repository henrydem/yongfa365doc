1)˵��
ϵͳ�洢����sp_MSforeachtable��sp_MSforeachdb,��΢���ṩ�������������Ĵ洢����,��ms sql 6.5��ʼ��
�����SQL Server��MASTER���ݿ��С�

2)����˵��:
@command1 nvarchar(2000),          --��һ�����е�SQLָ��
@replacechar nchar(1) = N'?',      --ָ����ռλ����
@command2 nvarchar(2000)= null,    --�ڶ������е�SQLָ��
@command3 nvarchar(2000)= null,    --���������е�SQLָ��
@whereand nvarchar(2000)= null,    --��ѡ������ѡ���
@precommand nvarchar(2000)= null,  --ִ��ָ��ǰ�Ĳ���(���ƿؼ��Ĵ���ǰ�Ĳ���)
@postcommand nvarchar(2000)= null  --ִ��ָ���Ĳ���(���ƿؼ��Ĵ�����Ĳ���)

3)����
--ͳ�����ݿ���ÿ�������ϸ���
exec sp_MSforeachtable @command1="sp_spaceused '?'"
--���ÿ����ļ�¼��������:
EXEC sp_MSforeachtable @command1="print '?'",
@command2="sp_spaceused '?'",
@command3= "SELECT count(*) FROM ? "
--������е����ݿ�Ĵ洢�ռ�:
EXEC sp_MSforeachdb   @command1="print '?'",
@command2="sp_spaceused "
--������е����ݿ�
EXEC sp_MSforeachdb   @command1="print '?'",
@command2="DBCC CHECKDB (?) "
--����PUBS���ݿ�����t��ͷ�����б��ͳ��:
EXEC sp_MSforeachtable @whereand="and name like 't%'",
@replacechar='*',
@precommand="print 'Updating Statistics.....' print ''",
@command1="print '*' update statistics * ",
@postcommand= "print''print 'Complete Update Statistics!'"
--ɾ����ǰ���ݿ����б��е�����
sp_MSforeachtable @command1='Delete from ?'
sp_MSforeachtable @command1 = "TRUNCATE TABLE ?"

4)����@whereand���÷�
@whereand�����ڴ洢��������ָ���������Ƶ�����,�����д������:
@whereend,������ôд @whereand=' AND o.name in (''Table1'',''Table2'',.......)'
����:�������Table1/Table2/Table3��NOTE��ΪNULL��ֵ
sp_MSforeachtable @command1='Update ? Set NOTE='''' Where NOTE is NULL',@whereand=' AND o.name in (''Table1'',''Table2'',''Table3'')'

5)"?"�ڴ洢���̵������÷�,���������������ǿ��Ĵ洢����
����"?"������,�൱��DOS�����С��Լ�������WINDOWS�������ļ�ʱ��ͨ��������á�