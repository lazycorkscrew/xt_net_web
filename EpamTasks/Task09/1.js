document.getElementById("btnRemove").addEventListener("click", clearTextareaDoubeLetters, false);

function clearTextareaDoubeLetters() {	
	document.getElementById("outputtext").innerHTML = clearDoubleLetters(document.getElementById("inputtext").value);
}

function clearDoubleLetters(inputtext) {
	var separators="?!:;,. 	";
	var currentword="";
	var doublechars="";
	for (var i = 0; i < inputtext.length; i++) {
		if (!separators.includes(inputtext.charAt(i))) { //Если проверяемый символ - не разделитель
			if (currentword.includes(inputtext.charAt(i))){ //Если в текущем слове уже есть следующая буква
				if(!doublechars.includes(inputtext.charAt(i))) { //Если текущая буква не находится в списке повторяющихся
					doublechars+=inputtext.charAt(i);
				}
			}
			else {
				currentword+=inputtext.charAt(i); //Добавляем
			}
		}
		else {
			currentword="";
		}
	}
	
	for (var i = 0; i < doublechars.length; i++) {
		inputtext=inputtext.split(doublechars.charAt(i)).join("");
	}
	
	return inputtext;			
}