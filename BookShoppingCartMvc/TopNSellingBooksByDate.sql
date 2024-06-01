--create  procedure [dbo].[Usp_GetTopNSellingBooksByDate]
--@startDate datetime,@endDate datetime
--as
--begin

--SET NOCOUNT ON;

--with UnitSold as
--(
--select od.BookId, SUM(od.Quantity) as TotalUnitSold from [order] o 
--join OrderDetail od on o.Id = od.OrderId
--where o.IsPaid=1 and o.IsDeleted=0 and o.CreateDate between @startDate and @endDate
--group by od.BookId
--)

--select top 5 b.BookName,b.AuthorName,b.[Image],us.TotalUnitSold 
--from  UnitSold us
--join [Book] b
--on us.BookId = b.Id
--order by us.TotalUnitSold desc
--end

use [aspnet-BookShoppingCartMvc]
update [order] set IsPaid=1