<?php
$con=mysqli_connect("localhost","root","","upload");
echo $con;
// $total_val_temp = $obj->total;
if(isset($_FILES['img']))
{
    
    $destination='img/'.$_FILES['img']['name'];
    $namess=$_FILES['img']['name'];
    move_uploaded_file($_FILES['img']['tmp_name'],$destination);
    $sql="INSERT INTO img(url,names) VALUES('$destination',$namess)";

    mysqli_query($con,$sql);
    //if((count($_FILES['img']['name'])==1)
    //{
    increment();
    //}
}

function increment(){
    $file = './ar_portal.json';
    $contents = file_get_contents($file,true);
    $obj = json_decode($contents);
    $data =array();
    $bigdata=array();
   // $obj->total = $obj->total + 1 ;
//$obj->id= $obj->id+1;
//$obj->name=$_FILES['img']['name'];
//$obj->url="$destination" ;

    //Encode the array back into a JSON string)
  //  for($v=0;$v<$obj->total;$v++)
    //{
    //$json = json_encode($obj);
    //echo $json;
    //Save the file.
    //file_put_contents($file, $json);
    //}
//     array_push($data,($obj->total));
//      $json1 = json_encode($obj);
//     echo $json1;
//    file_put_contents($file,$json1);
    $con=mysqli_connect("localhost","root","","upload");
    $result = mysqli_query($con,"SELECT * FROM img");
  
    
     while($row = mysqli_fetch_array($result)){
            // $u= str_replace('\/','/',$row['url']);
             array_push($data, array('id' => $row['id'],'names'=>$row['names'],'url'=>$row['url']));
             $row++;
             $t=$row['id'];
         }
         array_push($bigdata,array('total'=>$t));
         array_push($bigdata,$data);
     $json = str_replace('\/','/',json_encode($bigdata));//only allow forward slach
     echo $json;
     file_put_contents($file, $json);
    

    }
?>
