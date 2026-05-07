namespace StockFlowMonitor

open System

module Storage =

    let mutable products =
        [
            {
                Id = 1
                Name = "Walnuts"
                MinimumStock = 100m
            }

            {
                Id = 2
                Name = "Almonds"
                MinimumStock = 50m
            }

            {
                Id = 3
                Name = "Pistachios"
                MinimumStock = 30m
            }
        ]

    let mutable movements =
        [
            {
                Id = 1
                ProductId = 1
                Quantity = 200m
                MovementType = Incoming
                Date = DateTime.Now
            }

            {
                Id = 2
                ProductId = 1
                Quantity = 80m
                MovementType = Outgoing
                Date = DateTime.Now
            }

            {
                Id = 3
                ProductId = 2
                Quantity = 40m
                MovementType = Incoming
                Date = DateTime.Now
            }

            {
                Id = 4
                ProductId = 3
                Quantity = 75m
                MovementType = Incoming
                Date = DateTime.Now
            }
        ]

    let addMovement productId quantity movementType =
            let nextId =
                movements
                |> List.map (fun m -> m.Id)
                |> List.max
                |> fun id -> id + 1

            let newMovement : StockMovement   =
                {
                    Id = nextId
                    ProductId = productId
                    Quantity = quantity
                    MovementType = movementType
                    Date = DateTime.Now
                }

            movements <- movements @ [ newMovement ]
    let addProduct name minimumStock =
        let nextId =
            products
            |> List.map (fun p -> p.Id)
            |> List.max
            |> fun id -> id + 1

        let newProduct : Product =
            {
                Id = nextId
                Name = name
                MinimumStock = minimumStock
            }

        products <- products @ [ newProduct ]