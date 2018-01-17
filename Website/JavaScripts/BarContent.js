function Con1()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar1").style;
	var Sar = document.getElementById("Content1");
	Sar.setAttribute("src","Phase1.html");
	Bar.color="DodgerBlue";
}
function Con2()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar2").style;
	Bar.color="DodgerBlue";
	var Sar = document.getElementById("Content1");
	Sar.setAttribute("src","Phase2.html");
}
function Con3()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar3").style;
	Bar.color="DodgerBlue";
}
function Con4()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar4").style;
	Bar.color="DodgerBlue";
}
function Con5()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar5").style;
	Bar.color="DodgerBlue";
}
function ResetBars()
{
	var Bar = document.getElementById("ContentBar1").style;
	Bar.color="Tomato";
	var Bar = document.getElementById("ContentBar2").style;
	Bar.color="Tomato";
	var Bar = document.getElementById("ContentBar3").style;
	Bar.color="Tomato";
	var Bar = document.getElementById("ContentBar4").style;
	Bar.color="Tomato";
	var Bar = document.getElementById("ContentBar5").style;
	Bar.color="Tomato";
}
function ResizeFrames(obj)
{
	//obj.style.height = "auto";
	window.setInterval(function() {
            obj.style.height = obj.contentWindow.document.body.scrollHeight+50 + "px";
        }, 30);
	
}