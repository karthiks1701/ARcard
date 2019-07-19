<?php


$con=mysqli_connect("localhost","root","","upload");
if(isset($_FILES['img']))
{   
    
  
    $path = 'C:/xampp/htdocs/unity/img/'; 
    $path1= 'http://192.168.43.141/unity/img/';
    $location = $path . $_FILES['img']['name'];
    $location1=$path1 . $_FILES['img']['name'];
    $namess=$_FILES['img']['name'];
    move_uploaded_file(($_FILES['img']['tmp_name']),$location);
    //copy($_FILES['img']['tmp_name'], $path);
    $query=mysqli_query($con,"SELECT count(*) FROM img");
    $result=mysqli_fetch_array($query);
    $r=$result['count(*)'];
    $sql="INSERT INTO img(id,url,names) VALUES(($r+1),'$location1','$namess')";
    mysqli_query($con,$sql);
    increment();
  
}

function increment(){
    $con=mysqli_connect("localhost","root","","upload");
    $file = './ar_portal.json';
    $contents = file_get_contents($file,true);
    $obj = json_decode($contents);
    $data =array();
    $bigdata=array();
    $query=mysqli_query($con,"SELECT count(*) FROM img");
    $result=mysqli_fetch_array($query);
    $r=$result['count(*)'];
    
    $result = mysqli_query($con,"SELECT * FROM img");
    
  
    
     while($row = mysqli_fetch_array($result)){
       
             array_push($data, array('total'=>$r,'id' => $row['id'],'names'=>$row['names'],'url'=>$row['url']));
             $row++;
             
             
         }
     $json = str_replace('\/','/',json_encode($data));//only allow forward slach
     echo $json;
     file_put_contents($file, $json);
    

    }
?>
