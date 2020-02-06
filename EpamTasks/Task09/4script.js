var count=5;
var pages;
var intervalID;
var paused;
var counterSpan;

var topDiv= document.createElement("div");
topDiv.innerHTML="<div id='preview'><img src=\"../logo.bmp\"/>Следующая страница через  <span id='counter'>"+count+"</span><button id='btnPause'>Пауза</button><button id='btnPrevious'>Предыдущая страница</button>";
document.body.appendChild(topDiv);

var linkCSS= document.createElement("link");
linkCSS.rel="stylesheet";
linkCSS.type="text/css";
linkCSS.href="../4.css";
document.head.appendChild(linkCSS);


document.addEventListener("DOMContentLoaded", startTimer);

function startTimer() {
	pages=["task1","task2","task3","task4","task5","task6","task7","task8","task9"];
	paused=false;
	document.getElementById("btnPause").addEventListener("click", pauseTimer);
	document.getElementById("btnPrevious").addEventListener("click", goPrevious);
	counterSpan=document.getElementById("counter");
	intervalID= setInterval(countDown,1000);
}

function countDown(){
	count--;
	if(count>0){
		counterSpan.innerHTML=count;
	}
	else{
		clearInterval(intervalID);
		var pageId=identifyPage();
		if(pageId<(pages.length-1)){
			location=pages[pageId+1]+".html";
		}
		else{
			confirmRepeat();
		}		
	}
}

function identifyPage(){
	var pageId=pages.length;
	var regexp=/\/(\w+)\.html/;
	var page=regexp.exec(location.href)[1];
	for (var i = 0; i < pages.length; i++) {
		if(pages[i]===page){
			return i;
		}
	}
	return pageId;
}

function confirmRepeat(){
	result = confirm("Запустить с начала?");
	if(result){
		location=pages[0]+".html";
	}
	else{
		location="../4.html#close";
	}

}
function pauseTimer() {
	var btn =document.getElementById("btnPause");
	if(paused){
		intervalID= setInterval(countDown,1000);
		btn.innerHTML="Пауза";
	}
	else{
		clearInterval(intervalID);
		btn.innerHTML="Продолжить";
	}
	paused=!paused;
}

function goPrevious(){
	var pageId=identifyPage();
	if(pageId>0){
		location=pages[pageId-1]+".html";
	}
	else{
		location=pages[pages.length-1]+".html";
	}	
}