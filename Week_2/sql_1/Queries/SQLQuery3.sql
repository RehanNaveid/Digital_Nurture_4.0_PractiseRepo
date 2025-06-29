WITH Ranked AS (
    SELECT *,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT * FROM Ranked
WHERE RankNum <= 3 OR DenseRankNum <= 3;
