namespace StockFlowMonitor

module HtmlTemplates =

    let layout title body =
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
                    font-weight: bold;
                    color: #0066cc;
                }}

                table {{
                    border-collapse: collapse;
                    width: 1000px;
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

            </style>

        </head>

        <body>

            <nav>
                <a href="/stock">Dashboard</a>
                <a href="/movements">Movements</a>
            </nav>

            {body}

        </body>
        </html>
        """