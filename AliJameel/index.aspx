<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap demo</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>      
  </head>
  <body>

    <form id="loginform" method="post">
    <div id="login" class="text-center container">
        <div class="card" style=" width:500px; padding:50px; margin-top:20px; justify-content: center">
            <img src="Content/carebibi-logo-01-1200x1200.jpeg" width="150" height="100" style="padding-bottom: 20px;margin-left:120px;"/>
           
            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                 
                    
                        <h1 class="h3 mb-3 font-weight-normal">Sign In</h1>
                       
                        <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required="" autofocus="">
                        <br />
                        
                        <input type="password" id="inputPassword" class="form-control" placeholder="Password" required="">
                        <br />
                        <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                        <script>    

                            $("loginform").submit(function () {
                                alert('submit');
                            });
                            //var username = document.getElementById('inputEmail');
                            //var password = document.getElementById('password');

                            function login() {
                                alert('test');
                            }

                        </script>
                        <br />
                </div>
            </div>
        </div>
    </div>
    </form>
  </body>
</html>