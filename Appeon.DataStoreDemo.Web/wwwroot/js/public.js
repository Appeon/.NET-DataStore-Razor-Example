$(function(){
	var $tr = $("#browse table tbody tr")
	$tr.click(function(){
		$(this).parent().find('tr').removeClass("select");
		$(this).addClass("select");
	});
});