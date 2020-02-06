
for(var i = 0; i < document.getElementsByClassName("butterfly").length; i++)
{
	document.getElementsByClassName("toright")[i].addEventListener("click", function(){Move(this.parentNode.parentNode, true, false);}, false); 
	document.getElementsByClassName("toleft")[i].addEventListener("click", function(){Move(this.parentNode.parentNode, false, false);}, false);
	document.getElementsByClassName("torightall")[i].addEventListener("click", function(){Move(this.parentNode.parentNode, true, true);}, false);
	document.getElementsByClassName("toleftall")[i].addEventListener("click", function(){Move(this.parentNode.parentNode, false, true);}, false);
}

function Move(classitem, toRight, allItems)
{
	var toSelect = (toRight? classitem.children[2]: classitem.children[0]);
	var fromSelect = (toRight? classitem.children[0]: classitem.children[2]);
	
	if(allItems)
	{
		while (fromSelect.children.length > 0) 
		{
			toSelect.appendChild(fromSelect.children[0]);
		}
	}
	else
	{
		toSelect.appendChild(fromSelect.children[fromSelect.selectedIndex]);
		toSelect.selectedIndex = fromSelect.selectedIndex = -1;
	}
}