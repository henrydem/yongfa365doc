DECLARE @tableName nvarchar(100)
SET @tableName ='articles'
SELECT 
(CASE WHEN a.colorder=1 THEN d.name ELSE '' END)表名,
a.colorder 字段序号, a.name 字段名,
(CASE WHEN COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 THEN '√' ELSE '' END) 标识,
(CASE WHEN ( SELECT COUNT(*) FROM sysobjects WHERE (name IN (SELECT name FROM sysindexes WHERE (id = a.id) AND (indid IN (SELECT indid FROM sysindexkeys WHERE (id = a.id) AND (colid IN (SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name))))))) AND (xtype = 'PK'))>0 THEN '√' ELSE '' END) 主键,
b.name 类型,
a.length 占用字节数,
COLUMNPROPERTY(a.id,a.name,'PRECISION') AS 长度,
ISNULL(COLUMNPROPERTY(a.id,a.name,'Scale'),0) AS 小数位数,
(CASE WHEN a.isnullable=1 THEN '√' ELSE '' END) 允许空,
ISNULL(e.text,'') 默认值, g.[value] AS 字段说明
FROM syscolumns a
LEFT JOIN systypes b ON a.xtype=b.xusertype
INNER JOIN sysobjects d ON a.id=d.id AND d.xtype='U' AND d.name <>'dtproperties'
LEFT JOIN syscomments e ON a.cdefault=e.id
LEFT JOIN sys.extended_properties g ON a.id=g.major_id AND a.colid = g.minor_id
WHERE d.name=@tableName
ORDER BY a.id,a.colorder 