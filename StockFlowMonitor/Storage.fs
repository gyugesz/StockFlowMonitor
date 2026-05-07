namespace StockFlowMonitor

open System

module Storage =

    let products =
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

    let movements =
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