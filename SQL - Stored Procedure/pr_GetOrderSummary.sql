CREATE PROCEDURE pr_GetOrderSummary
  @StartDate DATE,
  @EndDate DATE,
  @EmployeeID INT = NULL,
  @CustomerID NVARCHAR(5) = NULL
AS
BEGIN
 -- Log the execution of the stored procedure for audit purposes
    INSERT INTO ExecutionLog (ProcedureName, ExecutionTime)
    VALUES ('pr_GetOrderSummary', GETDATE());

  -- Validation: Ensure StartDate is not greater than EndDate
  IF @StartDate > @EndDate
  BEGIN
    THROW 50000, 'Start date must be less than or equal to End date.', 1;
    RETURN;
  END

  -- Validation: Ensure EmployeeID is positive (if provided)
  IF @EmployeeID IS NOT NULL AND @EmployeeID <= 0
  BEGIN
    THROW 50000, 'EmployeeID must be a positive value.', 1;
    RETURN;
  END

  -- Validation: Ensure CustomerID is not an empty string (if provided)
  IF @CustomerID IS NOT NULL AND @CustomerID = ''
  BEGIN
    THROW 50000, 'CustomerID cannot be an empty string.', 1;
    RETURN;
  END

  BEGIN
    -- Main Query
    SELECT
      CONCAT(e.TitleOfCourtesy, ' ', e.FirstName, ' ', e.LastName) AS EmployeeFullName,
      s.CompanyName AS ShipperCompanyName,
      c.CompanyName AS CustomerCompanyName,
      COUNT(o.OrderID) AS NumberOfOrders,
      CONVERT(DATE, o.OrderDate) AS OrderDate,
      SUM(o.Freight) AS TotalFreightCost,
      COUNT(DISTINCT od.ProductID) AS NumberOfDifferentProducts,
      SUM(od.UnitPrice * od.Quantity) AS TotalOrderValue
    FROM Orders o
    INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
    LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
    INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
    LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE
      CONVERT(DATE, o.OrderDate) BETWEEN @StartDate AND @EndDate
      AND (@EmployeeID IS NULL OR o.EmployeeID = @EmployeeID)
      AND (@CustomerID IS NULL OR o.CustomerID = @CustomerID)
	GROUP BY
	  CONVERT(DATE, o.OrderDate),
	  e.EmployeeID, e.TitleOfCourtesy, e.FirstName, e.LastName,
	  s.ShipperID, s.CompanyName,
	  c.CustomerID, c.CompanyName,
	  o.OrderID;
  END
END;
