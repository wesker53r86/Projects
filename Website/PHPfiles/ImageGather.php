<?php
//header('Content-Type: application/json');
// This handles getting the directory
$dir = dirname(__FILE__)."/..";
$imagedir = $dir."/Images";
$test = opendir($imagedir);
//echo $imagedir."\n";
$rrs = scandir($imagedir); // This returns the array of files 
$a = array_slice($rrs,2); // cuts out the . and .. from array
//echo "The Directory is:". $a[0]. "\n";
$san = readdir($test);
//echo "Testing: ".$san."\n";
$zai;
//echo $a[0]."\n";
//$zai->vax=$a[0];//$a[0];
 for($i=0;$i < count($a);$i++)
{
	$a[$i]="Images/".$a[$i];
	//$zai[$i]->$vax=$a[$i];
	//$zai[$i]="hello";
} 
$zai->vax=$a;//$a[0];
$pow =  json_encode($a);
echo $pow;
//echo $a;
?>