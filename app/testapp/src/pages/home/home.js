document.getElementById("iBtn").addEventListener("click", ClickEvent);
function ClickEvent()
{
	window.alert(document.getElementById("iTextinput").value + document.getElementById("iTextarea").value);
}