<?php



$imgurl = $_POST['mapurl'];



if($imgurl !=""){
//////////////////////////////
// get Unity3d Data
//////////////////////////////

  $byteSize =  (int)$_POST['byteSize'];

//////////////////////////////
//get URL image data
////////////////////////////// 

   function getImageData($imgLink)
   {

    $curl = curl_init(); 
    curl_setopt($curl, CURLOPT_URL, $imgLink);
    curl_setopt($curl, CURLOPT_TIMEOUT,0.8);
	curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
	curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
     curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);
    $data = curl_exec($curl);
    curl_close($curl);
    return $data;    
   }


//////////////////////////////
//Create Image
//////////////////////////////


    $data = getImageData($imgurl);

	if (strlen($data) <$byteSize){
      die;
	}
	else{

    $im = imagecreatefromstring($data);
    imagejpeg($im);
    imagedestroy($im); 
	}

}
	
?>