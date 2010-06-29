DECLARE @tb TABLE(UserName NVARCHAR(20),sex NVARCHAR(5))
INSERT @tb VALUES ('柳永法','男')
INSERT @tb VALUES ('柳永法老婆','女')
INSERT @tb VALUES ('柳永法灵魂','未知')
SELECT UserName,  sex=
CASE  sex
  WHEN '男' THEN '男人'  
  WHEN '女' THEN '女人'  
  ELSE '哈哈'  
END  
 FROM @tb
 
SELECT UserName,  sex=
CASE 
  WHEN sex='男' THEN '男人'  
  WHEN sex='女' THEN '女人'  
  ELSE '哈哈'  
END  
 FROM @tb