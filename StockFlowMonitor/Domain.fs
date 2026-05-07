namespace StockFlowMonitor

open System

type Product =
    {
        Id: int
        Name: string
        MinimumStock: decimal
    }

type StockMovementType =
    | Incoming
    | Outgoing

type StockMovement =
    {
        Id: int
        ProductId: int
        Quantity: decimal
        MovementType: StockMovementType
        Date: DateTime
    }