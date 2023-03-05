<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="bcms._404" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
<style>
    @import url('https://fonts.googleapis.com/css?family=Nunito+Sans');

    :root {
        --blue: #0e0620;
        --white: #fff;
        --green: #2ccf6d;
    }

    html,
    body {
        height: 100%;
    }

    body {
        display: flex;
        align-items: center;
        justify-content: center;
        font-family: "Nunito Sans";
        color: var(--blue);
        font-size: 1em;
    }

    button {
        font-family: "Nunito Sans";
    }

    h1 {
        font-size: 7.5em;
        margin: 15px 0px;
        font-weight: bold;
    }

    h2 {
        font-weight: bold;
    }


    @media screen and (max-width:768px) {
        body {
            display: block;
        }

        .container {
            margin-top: 70px;
            margin-bottom: 70px;
        }
    }
</style>


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>404</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <div class="container">
                <div class="row">
                    <div class="col-md-6 align-self-center">
                        <h3>There was a bit of an issue with the server</h3>
                        <h5>The server gave us an error with your request, would you mind going back and trying again?</h5>
                        <div class="dropdown-divider"></div>
                        <p>
                            Internal server issue occurred, click the button below to go back to the dashboard</p>
                        <a href="private/View/dashboard.aspx" class="btn btn-primary green">HOME</a>
                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
