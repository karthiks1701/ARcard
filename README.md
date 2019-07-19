# ARcard
## Objective:
   It is a app or a unity application which can show all the products of the company on any image target which is created in the runtime. The advantage is  that the display objects/images can be changed after the app is build unless the asset bundle is not of the same unity version. All it requires is only one license key in vuforia and no need of datasets also!!!.
   
## file link:
   The main file link is in this google Drive link https://drive.google.com/drive/folders/1UdSJPg5XoA8YsOoLaE18tjPaMKtaDj2E?usp=sharing

# Steps To start the scene in Unity:
   1. Copy the folders in the google drive link.
   2. The main file is the vid.cs which is already attached to a empty gameobject in the sample scenes of the unity folder which is under    the user defined Targets.(\AR_app\7\Aseets\sampleresources\scenes\userdefinedtargets)
   3. Create a Xampp server(tested on local host and other neworks) or any other server: Create a table (img) under a database upload and the columns accordingly as shown in the picture()
   4. Under the htdocs folder of the Xampp server store the unity folder.
   5. Check if the ar_portal.json file in the unity folder has the same address in the vid.cs script attached to the empty game object under the user-defined targets scene in the point number two.
   6. In the unity folder there is a php file which takes the upload data and stores it into the server and creates a json file which the unity interprets.
# Steps to create a asset bundle
   1. For a 3-d object to be augmented, it is good to create a bundle in the same version of the unity.
   2. To create a asset bundle (of .fbx only) open the asset-creator folder and keep the objects in the asset folder rename the asset bundle to the same name of the (.fbx) file without changing anything.
   3. After that press the build asset bundle in the assets in the menu of the unity file. Upload the folder into the server.
   
 # Photos:
 ## The app
 1. After you make the build the app shud look like this :
    (+) - zooming 3-d objects
    (-) - zommingout the objects
    (>) - moving right of the list of objects
    (<) - moving left og the objects
 2. If the top title bar is yellow or green the objects will be shown on the augmeneted objects on pressing the camera option in the app.
![app](https://user-images.githubusercontent.com/47322496/61517482-f9eb4200-aa24-11e9-9c44-22e4b7a11d8c.jpeg)
## The website:
![website_arapp](https://user-images.githubusercontent.com/47322496/61517524-10919900-aa25-11e9-9a5f-73820729a5f7.PNG)
## Sample JSON-file:
![json file](https://user-images.githubusercontent.com/47322496/61517566-2b640d80-aa25-11e9-963c-b00db58cf12a.PNG)
