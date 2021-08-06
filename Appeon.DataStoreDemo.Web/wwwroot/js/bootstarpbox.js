var jsq = setInterval(startTimeExec, 1000);
function exec() {
	CBox.confirm({ message: "We invite you to a live demo and tech meeting.  We can discuss tech details, demo more in-depth, and provide recommendations tailored to your situation.<br><br>Would you like to schedule a meeting with our tech team?" })
		.on(function (e) {
			//jsq = setInterval(startTimeExec, 1000);
			if (!e) {
				return;
			}
			window.open("https://www.appeon.com/products/request-a-live-demo.html", "_blank");

		});
}


function startTimeExec() {
	var timesRun = parseInt(sessionStorage.getItem("timesRun"));
	if (isNaN(timesRun)) {
		sessionStorage.setItem("flag", 1)//第一次
		timesRun = 0;
	}
	var storeFlag = parseInt(sessionStorage.getItem("flag"));
	if (storeFlag != 1) return;
	
	if (timesRun >= 15) {
		sessionStorage.setItem("flag", 2)//执行一次后改变
		clearInterval(jsq);
		timesRun = 0;
		sessionStorage.setItem("timesRun", timesRun);
		exec();
		return;
	}
	timesRun += 1;
	sessionStorage.setItem("timesRun", timesRun);
}
