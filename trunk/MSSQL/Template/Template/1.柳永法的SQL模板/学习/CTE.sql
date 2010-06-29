----------------------------------------------------------------------------------
-- Subject     : CET 通用表表达式 之 精典递归实战
-- Author      : 柳永法(yongfa365) http://www.yongfa365.com/ cto@yongfa365.com
-- CreateDate  : 2010-05-03 11:09:46
-- Environment : Microsoft SQL Server 2005 - 9.00.4035.00 (Intel X86) 
--               Nov 24 2008 13:01:59 
--               Copyright (c) 1988-2005 Microsoft Corporation
--               Enterprise Edition on Windows NT 5.2 (Build 3790: Service Pack 2)
-- Reference   : http://msdn.microsoft.com/zh-cn/magazine/cc163346.aspx#S1
----------------------------------------------------------------------------------


IF OBJECT_ID('Dept') IS NOT NULL 
DROP TABLE Dept 

go

CREATE TABLE Dept (Id INT , ParentId INT , DeptName NVARCHAR(10))

INSERT Dept SELECT 1 ,   0 , N'食品'
  UNION ALL SELECT 2 ,   1 , N'水果'
  UNION ALL SELECT 3 ,   1 , N'蔬菜'
  UNION ALL SELECT 4 ,   2 , N'香蕉'
  UNION ALL SELECT 5 ,   2 , N'苹果'
  UNION ALL SELECT 6 ,   3 , N'青菜'
  
  UNION ALL SELECT 11 ,  0 , N'计算机'
  UNION ALL SELECT 12 , 11 , N'软件'
  UNION ALL SELECT 13 , 11 , N'硬件'
  UNION ALL SELECT 14 , 12 , N'Office'
  UNION ALL SELECT 15 , 12 , N'Emeditor'
  UNION ALL SELECT 16 , 13 , N'内存'


--得到所有水果
;WITH cte AS
(
	SELECT Id,ParentId,DeptName FROM Dept WHERE id=2
	UNION ALL
	SELECT a.Id,a.ParentId,a.DeptName FROM Dept a,cte b WHERE a.ParentId=b.Id
)

SELECT * FROM cte


--得到当前及所有父级
;WITH cte AS
(
	SELECT Id,ParentId,DeptName FROM Dept WHERE id=16
	UNION ALL
	SELECT a.Id,a.ParentId,a.DeptName FROM Dept a,cte b WHERE a.Id=b.ParentId
)

SELECT * FROM cte


--得到所有路径
;WITH cte AS
(
	SELECT Id,ParentId,DeptName,Path=CAST(DeptName AS NVARCHAR(MAX)) FROM Dept WHERE parentid=0
	UNION ALL
	SELECT a.Id,a.ParentId,a.DeptName,CAST(b.Path +'-->'+a.DeptName AS NVARCHAR(MAX)) FROM Dept a,cte b WHERE a.ParentId=b.Id
)

SELECT * FROM cte