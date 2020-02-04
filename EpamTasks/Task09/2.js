document.getElementById("btn_calc").addEventListener("click", CalcStringExpr, false);

function CalcStringExpr() {	
	document.getElementById("output_text").innerHTML=calcString(document.getElementById("input_text").value);
}

function calcString(input_text) {
	var parts;
	var result = 0;

	input_text = input_text.split(" ").join("");
	
	if(input_text != input_text.match(/[-]?\d+(?:\.\d+)?(?:[\+\-\*\/]\d+(?:\.\d+)?)+=/g)[0]) {
		return "Invalid expression";
	}
	
	/*if(input_text.charAt(0) != "-") {
		input_text = "+" + input_text;
	}*/
	
	input_text = (input_text.charAt(0) != "-")? "+" + input_text : input_text;
	
	parts = input_text.match(/(?:[\+\-\*\/]|\d+(?:\.\d+)?)/g);
	for (var i = 0; i < parts.length; i += 2) {	
		switch(parts[i]) {
			case '+': result = +parts[i+1] + result; break;
			case '-': result -= parts[i+1]; break;
			case '/': result /= parts[i+1]; break;
			case '*': result *= parts[i+1]; break;
			default: result = NaN; break;
		}
		
		if(result === NaN) {
			return "Invalid expression";
		}
	}
	
	return result.toFixed(2);			
}