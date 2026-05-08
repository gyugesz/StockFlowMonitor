namespace StockFlowMonitor

module HtmlTemplates =

    let css =
        """
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            background-color: #f4f6f8;
            color: #222;
        }

        nav {
            background-color: #1f2937;
            padding: 18px 40px;
            margin-bottom: 35px;
        }

        nav a {
            margin-right: 24px;
            text-decoration: none;
            color: white;
            font-weight: bold;
        }

        h1 {
            margin-left: 40px;
            font-size: 32px;
        }

        h2 {
            margin-left: 40px;
            margin-top: 28px;
        }

        .cards {
            display: flex;
            gap: 20px;
            margin: 20px 40px 30px 40px;
        }

        .card, form {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            border: 1px solid #e5e7eb;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
        }

        .card {
            width: 220px;
        }

        form {
            margin: 10px 40px 25px 40px;
            width: fit-content;
        }

        input, select {
            padding: 8px;
            margin-right: 12px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        button {
            padding: 8px 14px;
            border: none;
            border-radius: 6px;
            background-color: #2563eb;
            color: white;
            font-weight: bold;
            cursor: pointer;
        }

        table {
            border-collapse: collapse;
            width: calc(100% - 80px);
            margin: 25px 40px;
            background-color: white;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
        }

        th, td {
            border-bottom: 1px solid #e5e7eb;
            padding: 14px 18px;
            text-align: left;
        }

        th {
            background-color: #f9fafb;
            color: #374151;
        }
        .alert-box {
            background-color: white;
            color: #991b1b;
            margin: 20px 40px 30px 40px;
            padding: 20px;
            border-left: 6px solid #dc2626;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            max-width: 520px;
        }

        .alert-box h2 {
            margin: 0 0 12px 0;
            font-size: 22px;
        }

        .alert-box ul {
            margin: 0;
            padding-left: 22px;
        }

        .alert-box li {
            margin-bottom: 6px;
        }

        .success-box {
            background-color: white;
            color: #166534;
            margin: 20px 40px 30px 40px;
            padding: 20px;
            border-left: 6px solid #16a34a;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            max-width: 520px;
        }
        """

    let layout title body =
        $"""
        <html>
        <head>
            <title>{title}</title>
            <style>
                {css}
            </style>
        </head>

        <body>
            <nav>
                <a href="/stock">Dashboard</a>
                <a href="/movements">Movements</a>
                <a href="/products">Products</a>
            </nav>

            {body}
        </body>
        </html>
        """