namespace StockFlowMonitor

#nowarn "20"
open System.Globalization
open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0

    let products =
        Storage.products

    let layout title bodyContent =
        $"""
        <html>
        <head>
            <title>{title}</title>
            <style>
                body {{
                    font-family: Arial;
                    margin: 40px;
                }}

                nav {{
                    margin-bottom: 30px;
                }}

                nav a {{
                    margin-right: 20px;
                    text-decoration: none;
                    color: #0066cc;
                    font-weight: bold;
                }}

                .cards {{
                    display: flex;
                    gap: 20px;
                    margin-bottom: 24px;
                }}

                .card {{
                    padding: 20px;
                    width: 200px;
                    border: 1px solid #dcdcdc;
                    box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                }}

                .card h3 {{
                    margin: 0 0 10px 0;
                    font-size: 16px;
                }}

                .card p {{
                    margin: 0;
                    font-size: 28px;
                    font-weight: bold;
                }}

                table {{
                    border-collapse: collapse;
                    width: 900px;
                    box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                }}

                th, td {{
                    border: 1px solid #dcdcdc;
                    padding: 14px;
                    text-align: left;
                }}

                th {{
                    background-color: #f5f5f5;
                }}

                tr:nth-child(even) {{
                    background-color: #fafafa;
                }}

                tr:hover {{
                    background-color: #f0f7ff;
                }}
            </style>
        </head>

        <body>
            <nav>
                <a href="/stock">Dashboard</a>
                <a href="/movements">Movements</a>
            </nav>

            {bodyContent}
        </body>
        </html>
        """

    [<EntryPoint>]
    let main args =
        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllersWithViews() |> ignore
        builder.Services.AddRazorPages() |> ignore

        let app = builder.Build()

        if not (builder.Environment.IsDevelopment()) then
            app.UseExceptionHandler("/Home/Error") |> ignore
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore
        app.UseRouting() |> ignore
        app.UseAuthorization() |> ignore

        app.MapGet("/stock", Func<HttpContext, Task>(fun context ->

            let rows =
                products
                |> List.map (fun product ->
                    let currentStock =
                        StockLogic.calculateCurrentStock product.Id Storage.movements

                    let status =
                        if StockLogic.isLowStock product currentStock then
                            "<span style='color:red;font-weight:bold;'>LOW STOCK</span>"
                        else
                            "<span style='color:green;font-weight:bold;'>OK</span>"

                    $"""
                    <tr>
                        <td>{product.Name}</td>
                        <td>{currentStock}</td>
                        <td>{product.MinimumStock}</td>
                        <td>{status}</td>
                    </tr>
                    """
                )
                |> String.concat ""

            let totalProducts =
                products.Length

            let lowStockCount =
                products
                |> List.filter (fun product ->
                    let currentStock =
                        StockLogic.calculateCurrentStock product.Id Storage.movements

                    StockLogic.isLowStock product currentStock
                )
                |> List.length

            let body =
                $"""
                <h1>StockFlow Monitor</h1>

                <div class="cards">
                    <div class="card">
                        <h3>Total Products</h3>
                        <p>{totalProducts}</p>
                    </div>

                    <div class="card">
                        <h3>Low Stock Items</h3>
                        <p>{lowStockCount}</p>
                    </div>
                </div>

                <table>
                    <tr>
                        <th>Product</th>
                        <th>Current Stock</th>
                        <th>Minimum Stock</th>
                        <th>Status</th>
                    </tr>

                    {rows}
                </table>
                """

            let html =
                HtmlTemplates.layout "StockFlow Monitor" body

            context.Response.ContentType <- "text/html"
            context.Response.WriteAsync(html)
        )) |> ignore

        app.MapGet("/movements", Func<HttpContext, Task>(fun context ->
            
            let productOptions =
                products
                |> List.map (fun product ->
                    $"<option value='{product.Id}'>{product.Name}</option>"
                )
                |> String.concat ""
            let rows =
                Storage.movements
                |> List.map (fun movement ->
                    let movementType =
                        match movement.MovementType with
                        | Incoming ->
                          "<span style='color:green;font-weight:bold;'>Incoming</span>"

                        | Outgoing ->
                         "<span style='color:red;font-weight:bold;'>Outgoing</span>"

                    $"""
                    <tr>
                        <td>{movement.Id}</td>
                        <td>
                            {
                                products
                                |> List.find (fun p -> p.Id = movement.ProductId)
                                |> fun p -> p.Name
                            }
                        </td>
                        <td>{movement.Quantity}</td>
                        <td>{movementType}</td>
                        <td>{movement.Date}</td>
                    </tr>
                    """
                )
                |> String.concat ""

            let body =
                $"""
                <h1>Stock Movements</h1>
                 <h2>Receive Stock</h2>

            <form method="post" action="/receive-stock" style="margin-bottom: 30px;">

                <label>Product:</label>

                <select name="productId">
                    {productOptions}
                </select>

                <label style="margin-left:20px;">Quantity:</label>

                <input
                    type="number"
                    name="quantity"
                    step="0.01"
                    min="0.01"
                    required />

                <button type="submit">
                    Receive
                </button>

            </form>
             <h2>Issue Stock</h2>
                <form method="post" action="/issue-stock" style="margin-bottom: 30px;">

                    <label>Product:</label>

                    <select name="productId">
                        {productOptions}
                    </select>

                    <label style="margin-left:20px;">Quantity:</label>

                    <input
                        type="number"
                        name="quantity"
                        step="0.01"
                        min="0.01"
                        required />

                    <button type="submit">
                        Issue
                    </button>

                </form>
                <table>
                    <tr>
                        <th>Id</th>
                        <th>Product Id</th>
                        <th>Quantity</th>
                        <th>Movement Type</th>
                        <th>Date</th>
                    </tr>

                    {rows}
                </table>
                """

            let html =
                HtmlTemplates.layout "Stock Movements" body

            context.Response.ContentType <- "text/html"
            context.Response.WriteAsync(html)
        )) |> ignore

        app.MapPost("/issue-stock", Func<HttpContext, Task>(fun context ->

            task {
                let! form =
                    context.Request.ReadFormAsync()

                let productId =
                    form["productId"].ToString()
                    |> int

                let quantity =
                    form["quantity"].ToString().Replace(",", ".")
                    |> fun value ->
                        Decimal.Parse(value, CultureInfo.InvariantCulture)

                Storage.addMovement productId quantity Outgoing

                context.Response.Redirect("/movements")
            }

        )) |> ignore
        app.MapPost("/receive-stock", Func<HttpContext, Task>(fun context ->

            task {
                let! form =
                    context.Request.ReadFormAsync()

                let productId =
                    form["productId"].ToString()
                    |> int

                let quantity =
                    form["quantity"].ToString().Replace(",", ".")
                    |> fun value ->
                        Decimal.Parse(value, CultureInfo.InvariantCulture)

                Storage.addMovement productId quantity Incoming

                context.Response.Redirect("/movements")
            }

        )) |> ignore
        app.MapGet("/", Func<HttpContext, Task>(fun context ->
            context.Response.Redirect("/stock")
            Task.CompletedTask
        )) |> ignore
        app.MapRazorPages() |> ignore

        app.Run()

        exitCode