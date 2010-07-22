--统计SQL语句执行时间  
DECLARE @dt DATETIME  
SET @dt = GETDATE()  
--要执行的SQL语句  






--测试用，等待多久
--WaitFor Delay '00:00:01'
SELECT  [语句执行花费时间(毫秒)] = DATEDIFF(ms, @dt, GETDATE()) 