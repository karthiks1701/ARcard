
<html>
    <head>
        <title>
            prazen website
        </title>
    </head>
    <body>
        <div class="container">
            <div class="head">
                <img id="imgid" src="pz.jpg" width="100px" height="100px">
                <h1 id="h1id" style="padding-left: 120px" >
                    PRAZEN<br>WORLD
                </h1>
            </div>
            <div class="container">
                <form action="upload.php" method="post" enctype="multipart/form-data">
                <label for="file">choose a file</label>
                <input type="file" name="img"/>
                <input type="submit" value="upload"/>
                </form> 

        </div>
    </body>
</html>