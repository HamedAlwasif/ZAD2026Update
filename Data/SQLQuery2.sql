SELECT 
    SUM(Quantity)  AS SumQuantity,
    SUM(QuantityT) AS SumQuantityT,
    SUM(Total)     AS SumTotal,
    SUM(Value)     AS SumValue
FROM dbo.Category;