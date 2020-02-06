if(location.hash==="#close"){
	window.open("Task8/task9.html", '_self').close();
}

document.getElementById("btnStart").addEventListener("click", startPreview);

function startPreview() {
	window.open("Task8/task1.html", '_blank');
}