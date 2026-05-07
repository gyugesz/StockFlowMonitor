namespace StockFlowMonitor

module StockLogic =

    let calculateCurrentStock productId movements =
        movements
        |> List.filter (fun movement -> movement.ProductId = productId)
        |> List.sumBy (fun movement ->
            match movement.MovementType with
            | Incoming -> movement.Quantity
            | Outgoing -> -movement.Quantity)

    let isLowStock product currentStock =
        currentStock < product.MinimumStock