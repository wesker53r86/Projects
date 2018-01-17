function LoadImages(obj)
{ 
	$.ajax(
	{
		url:"PHPfiles/ImageGather.php",
		//contentType: 'application/json; charset=utf-8',
		type:"GET",
		dataType:"json",
		success:function(data)
		{
			console.log(data);
			IfSucc(data);
		},
		error:function(data)
		{
			alert(data);
			console.log(data);
		}
	}

	);

	function IfSucc(data)
	{
		var zz = JSON.stringify(data);
		var zx = JSON.parse(zz);
		console.log(zx);
		//document.getElementById("inputspot").innerHTML = zx[0];
		var bods = document.getElementById("Content");
		var i;
		for(i=0;i<zx.length;i++)
		{
			var imgVar = document.createElement("img");
			imgVar.setAttribute("src",zx[i]);
			imgVar.setAttribute("class","gallery");
			imgVar.setAttribute("id","galleryImg"+i);
			imgVar.innerHTML = "Img";
			//imgSRC.value = zx[i];
			//imgVar.setAttributeNode(imgSRC);
			//document.body.appendChild(imgVar);
			bods.appendChild(imgVar);
		}
	}
}