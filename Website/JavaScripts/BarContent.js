var AbsDefaultColor = "#FFCE28";
function Con1()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar1").style;
	var Sar = document.getElementById("Content1");
	Sar.setAttribute("src","Phase1.html");
	Bar.color=AbsDefaultColor;
}
function Con2()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar2").style;
	Bar.color=AbsDefaultColor;
	var Sar = document.getElementById("Content1");
	Sar.setAttribute("src","Phase2.html");
}
function Con3()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar3").style;
	Bar.color=AbsDefaultColor;
}
function Con4()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar4").style;
	Bar.color=AbsDefaultColor;
}
function Con5()
{
	ResetBars();
	var Bar = document.getElementById("ContentBar5").style;
	Bar.color=AbsDefaultColor;
}
function ResetBars()
{
	var defaultColor = '#e2e1d9';
	console.log(defaultColor);
	var Bar = document.getElementById("ContentBar1").style;
	Bar.color=defaultColor;
	var Bar = document.getElementById("ContentBar2").style;
	Bar.color=defaultColor;
	var Bar = document.getElementById("ContentBar3").style;
	Bar.color=defaultColor;
	var Bar = document.getElementById("ContentBar4").style;
	Bar.color=defaultColor;
	var Bar = document.getElementById("ContentBar5").style;
	Bar.color=defaultColor;
}
function ResizeFrames(obj)
{
	//obj.style.height = "auto";
	window.setInterval(function() {
            obj.style.height = obj.contentWindow.document.body.scrollHeight+ "px";
			//obj.style.width = obj.contentWindow.document.body.scrollWidth+"px";
        }, 30);
	
}